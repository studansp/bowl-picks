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

    BowlPicks.Global.ApiRoot = 'http://localhost:1182/api';
}