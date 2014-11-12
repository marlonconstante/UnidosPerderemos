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

Parse.Cloud.beforeSave("UserProgress", function(request, response) {
	request.object.set("user", request.user);
	response.success();
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
