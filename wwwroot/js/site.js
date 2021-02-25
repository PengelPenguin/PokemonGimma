// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/GameScreen").build();
//===============================================================================================
connection.on("ReceiveMove", function (message,connectionId) {
    var a = document.createElement('a');
    var linkText = document.createTextNode(message);
    a.appendChild(linkText);
    a.title = message + connectionId;
    a.href = window.location.href + "/" + connectionId;
   
    var div = document.createElement("div");
    div.innerHTML = a + "<hr/>";

    document.getElementById("messages").appendChild(a);
    //document.body.appendChild(a);
});

connection.on("ReceiveMessage", function (message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var div = document.createElement("div");
    div.innerHTML = msg + "<hr/>";
    document.getElementById("messages").appendChild(div);
});


connection.on("UserConnected", function(connectionId) {
    var groupElement = document.getElementById("group");
    var option = document.createElement("option");
    option.text = connectionId;
    option.value = connectionId;
    groupElement.add(option);
});

connection.on("UserDisconnected", function(connectionId) {
    var groupElement = document.getElementById("group");
    for(var i = 0; i < groupElement.length; i++) {
        if (groupElement.options[i].value == connectionId) {
            groupElement.remove(i);
        }
    }
});

connection.start().catch(function(err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function(event) {
    var message = document.getElementById("message").value;
    var groupElement = document.getElementById("group");
    var groupValue = groupElement.options[groupElement.selectedIndex].value;
    
    if (groupValue === "All" || groupValue === "Myself") {
        var method = groupValue === "All" ? "SendMessageToAll" : "SendMessageToCaller";
        connection.invoke(method, message).catch(function (err) {
            return console.error(err.toString());
        });
    } else if (groupValue === "PrivateGroup") {
        connection.invoke("SendMessageToGroup", "PrivateGroup", message).catch(function (err) {
            return console.error(err.toString());
        });
    } else {
        connection.invoke("SendMessageToUser", groupValue, message).catch(function (err) {
            return console.error(err.toString());
        });
    }
    
    event.preventDefault();
});

document.getElementById("joinGroup").addEventListener("click", function(event) {
    connection.invoke("JoinGroup", "PrivateGroup").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("createGroup").addEventListener("click", function (event) {
    var name = document.getElementById("roomName").value;
    connection.invoke("SendMove",name,name).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

//===============================================================================================
