$(function () {
    // Reference the auto-generated proxy for the hub.
    var chat = $.connection.chatHub;
    // Create a function that the hub can call back to display messages.
    chat.client.addCustomLineToAPage = function (IdOfContainer, line) {
        $('#' + IdOfContainer).append(line);
    };

    chat.client.showInfo = function (i) {

        if (i == 1) {
            var a = '<li>' + INFO + '</br>Admin commands</br>' + INFOadmin + '</li>';
        }
        else {            
            var a = '<li>' + INFO + '</li>';
        }
        $('#discussion').append(a);
    };

    chat.client.addNewMessageToPage = function (name, message, id) {
        // Add the message to the page.
        let time = new Date();
        let a = '<li id="' + id + '"><button class="del" name="' + id + '" >X</button><strong>' + htmlEncode(name) + '</strong>'
            + ' at <i>' + time.getUTCHours().toString() + ':' + time.getUTCMinutes().toString() + ':' + time.getUTCSeconds().toString()
            + ' </i>' + 'said: ' + '<strong>' + htmlEncode(message) + '</strong>' + '</li>';
        $('#discussion').append(a);
    };

    chat.client.addWhisper = function (message) {
        // Add the Whisper to the page.
        let time = new Date();
        let a ='<li><i>' + time.getUTCHours().toString() + ':' + time.getUTCMinutes().toString() + ':' + time.getUTCSeconds().toString() + ' </i>' +message+ '</li>';
        $('#discussion').append(a);
    };
    {
    //chat.client.addWhisperForCaller = function (taker, message) {
    //    // Add the message to the page.
    //    let time = new Date();
    //    let a = '<li>You whispered to <strong>' + htmlEncode(taker) + '</strong>'
    //        + ' at <i>' + time.getUTCHours().toString() + ':' + time.getUTCMinutes().toString() + ':' + time.getUTCSeconds().toString()
    //        + ' </i>' + ' that: ' + '<strong>' + htmlEncode(message) + '</strong>' + '</li>';
    //    $('#discussion').append(a);
    //};
    } //part of code, where whispers generated on client side
    chat.client.addStatsOfAToPage = function (n, w, s) {
        // Add the stats to the page.
            $('#Stats').append('<li> Name: <strong>' + n + '</strong> | Words: <strong>' + w + '</strong> | Symbols: <strong>' + s + '</strong></li>');
    };

    chat.client.addLoggedMessageToPage = function (message) {
        // Add the logged to the page.
        $('#discussion').append(message);
    };
       
    chat.client.reload = function () {
        window.location = "/Home";
        Location.Reload(true);
    };
    chat.client.deleteMessageS = function (id) {
        let a = '#' + id;
        $(a).remove();
    }
    $(document).on('click', '.del', function () {
        chat.server.deleteMessage(this.name, $('#displayname').val(), $('#pass').val());
    });


    // Get the user name and store it to prepend to messages.
    $('#displayname').val(prompt('Login: ', ''));
    $('#pass').val(prompt('Password: ', ''));
    $('#ChatId').val(prompt('Reenter chat id you want to connect. To confirm connection: ', ''));



    // Set initial focus to message input box.
    $('#message').focus();
    // Start the connection.
    $.connection.hub.start().done(function () {
        chat.server.login($('#displayname').val(), $('#pass').val());
        chat.server.accessChat($('#ChatId').val(), $('#displayname').val(), $('#pass').val());
        chat.server.loadChat($('#ChatId').val());
        chat.server.loadStats($('#ChatId').val(), $('#displayname').val());

        $('#sendmessage').click(function () {
            // Call the Send method on the hub.
            let text = strip($('#message').val());
            chat.server.send($('#displayname').val(), text, $('#ChatId').val(), $('#pass').val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();            
        });
    });
});
// This optional function html-encodes messages for display in the page.
var INFO = '<strong>/w *name*</strong> <i>(example "/w admin Hello!")</i> -  sends whispers to user by name (you can be in diffrent rooms). '
    + "Other users don`t see your whispers. This type of messages don`t saved on site.";
var INFOadmin = '<strong>/global</strong> - sends message to all users, and saves this massages in all chats. Only admins can delete this message. Deleting will delete it from all chats.';
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}
function strip(html) {
    var tmp = document.createElement("DIV");
    tmp.innerHTML = html;
    return tmp.textContent || tmp.innerText || "";
}

