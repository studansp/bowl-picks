"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.Models == "undefined") {
    BowlPicks.Models = {};
}

if (typeof BowlPicks.Models.PickModel == "undefined") {
    BowlPicks.Models.PickModel = function () {
        this.GameId = 0;
        this.IsTeam1Selected = false;
    };
}