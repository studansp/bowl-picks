if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {}
}

if (typeof BowlPicks.Global == "undefined") {
    BowlPicks.Global = {};

    BowlPicks.Global.HttpStatus = {
        OK: 200
    }

    BowlPicks.Global.Token = null;

    BowlPicks.Global.Events = {};

    BowlPicks.Global.Events.AuthChange = "AUTHCHANGE";
    BowlPicks.Global.Events.PageChange = "PAGECHANGE";
    BowlPicks.Global.ApiRoot = 'http://75.118.10.202:1182/api';

    BowlPicks.Global.Cookies = {};
    BowlPicks.Global.Cookies.Token = 'token';
}

function createCookie(name, value, days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    createCookie(name, "", -1);
}