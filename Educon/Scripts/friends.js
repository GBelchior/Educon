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

        $('#btnAcceptPlayRequest').on('click', function () {
            hub.server.requestAccepted(ANamUser);
        });

        $('#play-request').find('.close').on('click', function () {
            hub.server.requestDenied(ANamUser);
        })
    }

    hub.client.requestDenied = function () {
        document.querySelector('#wait-for-approval').close();
        document.querySelector('#request-denied').showModal();
    }

    $.connection.hub.start();
});