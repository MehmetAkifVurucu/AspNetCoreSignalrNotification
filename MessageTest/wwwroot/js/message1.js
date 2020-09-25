var connection = new signalR.HubConnectionBuilder().withUrl("/messageHub").build();
connection.on("ShowMessage", function (message) {
	alertMessage(message);
});

connection.start().then(function () {
	connection.invoke("ListeKisiEkle", $("#h4UserName").text()).catch(function (err) {
		return console.error(err.toString());
	});
}).catch(function (err) {
	return console.error(err.toString());
});