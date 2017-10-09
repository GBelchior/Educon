var hub = $.connection.friendsHub;

function playRequest(ANamUser, ANamPerson) {
    var waitForApprovalDialog = document.querySelector('#wait-for-approval');

    $('#wait-for-approval').find('.friend-name').text(ANamPerson);

    hub.server.playRequest(ANamUser);

    waitForApprovalDialog.showModal();
}

$(function () {
    hub.client.userOnline = function (ANamUser) {
        var buttonSelector = '#btnFriend' + ANamUser;
        if ($(buttonSelector).length == 0) return;

        $(buttonSelector).removeAttr('disabled');

        $(buttonSelector + ' div.status-led').removeClass('user-offline');
        $(buttonSelector + ' div.status-led').addClass('user-online');

        $(buttonSelector + ' label.status-text').removeClass('user-offline');
        $(buttonSelector + ' label.status-text').addClass('user-online');
    }

    hub.client.userOffline = function (ANamUser) {
        var buttonSelector = '#btnFriend' + ANamUser;
        if ($(buttonSelector).length == 0) return;

        $('#divPlay' + ANamUser).removeClass('in');
        $('#divPlay' + ANamUser).addClass('collapse');

        $(buttonSelector).attr('disabled', 'disabled');

        $(buttonSelector + ' div.status-led').removeClass('user-online');
        $(buttonSelector + ' div.status-led').addClass('user-offline');

        $(buttonSelector + ' label.status-text').removeClass('user-online');
        $(buttonSelector + ' label.status-text').addClass('user-offline');
    }

    hub.client.receivePlayRequest = function (ANamUser) {
        var playRequestDialog = document.querySelector('#play-request');

        $('#request-user-name').text(ANamUser);
        playRequestDialog.showModal();

        function acceptRequest() {
            hub.server.requestAccepted(ANamUser);
        }

        function denyRequest() {
            hub.server.requestDenied(ANamUser);
        }

        $('#btnAcceptPlayRequest').off('click', acceptRequest);
        $('#play-request').find('.close').off('click', denyRequest);

        $('#btnAcceptPlayRequest').on('click', acceptRequest);
        $('#play-request').find('.close').on('click', denyRequest);
    }

    hub.client.requestDenied = function () {
        document.querySelector('#wait-for-approval').close();
        document.querySelector('#request-denied').showModal();
    }

    hub.client.startGameBetween = function (ANamUser1, ANamUser2) {
        localStorage.NamUser1 = ANamUser1;
        localStorage.NamUser2 = ANamUser2;

        window.location = '/Portal/StartGameBetween?ANamUser1=' + ANamUser1 + '&ANamUser2=' + ANamUser2;
    }

    $.connection.hub.start();
});