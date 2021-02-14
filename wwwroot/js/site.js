// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var healthpokemon1 = document.getElementById("healthPlayer1").textContent;
var healthpokemon2 = document.getElementById("healthPlayer2").textContent;


function showhealth() {
    document.getElementById("healthPlayer1").textContent = healthpokemon1;
    document.getElementById("healthPlayer2").textContent = healthpokemon2;
}

function CalculateDamageStep(moveIndex) {
    var attackplayer1 = document.getElementById(moveIndex).textContent;
    healthpokemon2 -= attackplayer1;
    SelectOpponentMove();
    showhealth();
    HasPlayerWon();

}

function SelectOpponentMove() {
    if (healthpokemon1 > 0) {
        var attackplayer2 = document.getElementById(Math.floor(Math.random() * 4) + 1).textContent;
        healthpokemon1 -= attackplayer2;
    }
    
}

function HasPlayerWon() {
    
    if (healthpokemon2 <= 0) {
        var name = document.getElementById("namePlayer1").textContent;
        alert(name + " has won!");
        ReturnToGameScreen();
    }

    if (healthpokemon1 <= 0) {
        var name = document.getElementById("namePlayer2").textContent;
        alert(name + " has won!");
        ReturnToGameScreen();
    }
}

function ReturnToGameScreen() {
    window.history.back();
}

function bindConnectionMessage(connection) {
    var messageCallback = function (name, message) {
        if (!message) return;
        // deal with the message
        alert("message received:" + message);
    };
    // Create a function that the hub can call to broadcast messages.
    connection.on('broadcastMessage', messageCallback);
    connection.on('echo', messageCallback);
}

var connection = new signalR.HubConnectionBuilder()
    .withUrl('/battle')
    .build();

bindConnectionMessage(connection);
connection.start()
    .then(function () {
        onConnected(connection);
    })
    .catch(function (error) {
        console.error(error.message);
    });


