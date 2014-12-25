"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.Models == "undefined") {
    BowlPicks.Models = {};
}

if (typeof BowlPicks.Models.LoginModel == "undefined") {
    BowlPicks.Models.LoginModel = function () {
        var self = this;

        this.Username = null;
        this.Password = null;
    };
}