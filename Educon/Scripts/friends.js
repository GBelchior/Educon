$(function () {
    var hub = $.connection.friendsHub;

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

        $(buttonSelector).attr('disabled', 'disabled');

        $(buttonSelector + ' div.status-led').removeClass('user-online');
        $(buttonSelector + ' div.status-led').addClass('user-offline');

        $(buttonSelector + ' label.status-text').removeClass('user-online');
        $(buttonSelector + ' label.status-text').addClass('user-offline');
    }

    $.connection.hub.start();
});