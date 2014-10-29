Parse.Cloud.beforeSave("UserProfile", function(request, response) {
	request.object.set("user", request.user);
	response.success();
});
