var Mandrill = require('mandrill');
Mandrill.initialize('qzZLs8eZROdYBLd9IqnREQ');


var LoadProfilePhoto = function(userProfile) {
	userProfile.get("user").fetch({
		success: function(user) {
			if (Parse.FacebookUtils.isLinked(user)) {
				var accessToken = user.get("authData").facebook.access_token;
				Parse.Cloud.httpRequest({
					url: "https://graph.facebook.com/me/picture?redirect=false&type=square&width=400&height=400&access_token=" + accessToken,
					success: function(response) {
						SaveProfilePhoto(response.data.data.url, userProfile);
					}
				});
			}
		}
	});
}

var SaveProfilePhoto = function(imageUrl, userProfile) {
	Parse.Cloud.httpRequest({
		url: imageUrl,
		success: function(response) {
			var parseFile = new Parse.File("photo.jpeg", { base64: response.buffer.toString("base64") });
			userProfile.set("photo", parseFile);
			userProfile.save();
		}
	});
}

var QueryWeeklyDedication = function(userProgress) {
	var maxDate = userProgress.get("date");
	var minDate = new Date();
	minDate.setDate(maxDate.getDate() - 6);
	minDate.setHours(0, 0, 0, 0);

	var query = new Parse.Query(Parse.Object.extend("UserProgress"));
	query.equalTo("user", userProgress.get("user"));
	query.greaterThanOrEqualTo("date", minDate);
	query.lessThan("date", maxDate);

	return query;
}

Parse.Cloud.beforeSave("UserProgress", function(request, response) {
	request.object.set("user", request.user);
	QueryWeeklyDedication(request.object).find({
		success: function(results) {
			var weeklyDedication = request.object.get("dailyDedication");
			for (var index = 0; index < results.length; index++) {
				weeklyDedication += results[index].get("dailyDedication");
			}
			request.object.set("weeklyDedication", weeklyDedication);
			response.success();
		},
		error: function() {
			response.error("Atualização da dedicação semanal falhou...");
		}
	});
});

Parse.Cloud.afterSave("UserProgress", function(request) {
	var userProgress = request.object;
	var query = new Parse.Query(Parse.Object.extend("UserProfile"));
	query.equalTo("user", userProgress.get("user"));
	query.first({
		success: function(userProfile) {
			userProfile.set("dateLastDaily", userProgress.get("date"));
			if (userProgress.get("type") == "Weekly") {
				userProfile.set("dateLastWeekly", userProgress.get("date"));
			}
			userProfile.set("weeklyDedication", userProgress.get("weeklyDedication"));
			userProfile.set("weight", userProgress.get("weight"));
			userProfile.save();
		}
	});
});

Parse.Cloud.beforeSave("UserProfile", function(request, response) {
	request.object.set("user", request.user);
	response.success();
});

Parse.Cloud.afterSave("UserProfile", function(request) {
	var userProfile = request.object;
	if (!userProfile.get("photo")) {
		LoadProfilePhoto(userProfile);
	}
});

Parse.Cloud.beforeSave(Parse.User, function(request, response) {
		var user = request.object;
		response.success();

		if (user.get("email")) {
			var emailText = "Caro " + user.get("name") + ", Obrigado por utilizar o UP.";

			Mandrill.sendEmail({
				message: {
					text: emailText,
					subject: "Bem vindo ao Unidos Perderemos!",
					from_email: "parse@cloudcode.com",
					from_name: "Equipe Unidos Perderemos",
					to: [
						{
							email: user.get("email"),
							name: user.get("name")
						}
					]
				},
				async: true
			},{
				success: function(httpResponse) {
					console.log(httpResponse);
					response.success("Email sent!");
				},
				error: function(httpResponse) {
					console.error(httpResponse);
					response.error("Uh oh, something went wrong");
				}
			});
		}
});
