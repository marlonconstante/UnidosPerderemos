var Mandrill = require("mandrill");
Mandrill.initialize("E229wwSK9NY7QbEKTCPObw");

var SendEmail = function(email, name, subject, text) {
	Mandrill.sendEmail({
		message: {
			subject: subject,
			text: text,
			from_email: "parse@cloudcode.com",
			from_name: "Equipe Unidos Perderemos",
			to: [
				{
					email: email,
					name: name
				}
			]
		},
		async: true
	}, {
		success: function(response) {
			console.log("E-mail enviado com sucesso para " + email + "...");
		}
	});
}

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

var QueryDedication = function(user, maxDate, previousDays) {
	var query = new Parse.Query(Parse.Object.extend("UserProgress"));
	query.equalTo("user", user);
	query.equalTo("dateInactivation", null);

	if (maxDate && previousDays) {
		var minDate = new Date();
		minDate.setDate(maxDate.getDate() - previousDays);
		minDate.setHours(0, 0, 0, 0);

		query.greaterThanOrEqualTo("date", minDate);
		query.lessThan("date", maxDate);
	}

	return query;
}

var SumDedication = function(results) {
	var dedication = 0;
	for (var index = 0; index < results.length; index++) {
		dedication += results[index].get("dailyDedication");
	}
	return dedication;
}

Parse.Cloud.beforeSave("UserProgress", function(request, response) {
	request.object.set("user", request.user);
	QueryDedication(request.user, request.object.get("date"), 6).find({
		success: function(results) {
			var weeklyDedication = request.object.get("dailyDedication") + SumDedication(results);
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
	if (!userProgress.get("dateInactivation")) {
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
	}
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

Parse.Cloud.define("LoadUserProfile", function(request, response) {
	var query = new Parse.Query(Parse.Object.extend("UserProfile"));
	query.equalTo("user", request.user);
	query.first({
		success: function(userProfile) {
			if (userProfile) {
				QueryDedication(request.user, request.params.maxDate, 7).find({
					success: function(results) {
						var weeklyDedication = SumDedication(results);
						userProfile.set("weeklyDedication", weeklyDedication);
						userProfile.save();
						response.success(userProfile);
					},
					error: function() {
						response.error("Atualização da dedicação semanal falhou...");
					}
				});
			} else {
				response.success();
			}
		}
	});
});

Parse.Cloud.define("ResetUserProfile", function(request, response) {
	var query = new Parse.Query(Parse.Object.extend("UserProfile"));
	query.equalTo("user", request.user);
	query.first({
		success: function(userProfile) {
			if (userProfile) {
				var inactivationDate = request.params.inactivationDate;
				QueryDedication(request.user).find({
					success: function(results) {
						for (var index = 0; index < results.length; index++) {
							var userProgress = results[index];
							userProgress.set("dateInactivation", inactivationDate);
							userProgress.save();
						}

						userProfile.set("startDate", inactivationDate);
						userProfile.set("dateLastWeekly", inactivationDate);
						userProfile.set("dateLastDaily", null);
						userProfile.set("dateLastPrize", null);
						userProfile.set("weeklyDedication", 0);
						userProfile.save();
						response.success();
					},
					error: function() {
						response.error("Reinicialização do perfil do usuário falhou...");
					}
				});
			} else {
				response.success();
			}
		}
	});
});

Parse.Cloud.afterSave(Parse.User, function(request) {
		var user = request.object;
		var email = user.get("email");
		if (email && !user.get("isRegistrationFinished")) {
			var name = user.get("name") || "usuário";
			SendEmail(email, name, "Bem vindo ao Unidos Perderemos!", "Caro " + name + ", obrigado por utilizar o UP.");
		}
});
