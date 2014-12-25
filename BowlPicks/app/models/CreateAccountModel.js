"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.Models == "undefined") {
    BowlPicks.Models = {};
}

if (typeof BowlPicks.Models.CreateAccountModel == "undefined") {
    BowlPicks.Models.CreateAccountModel = function () {
        this.Username = null;
        this.Password = null;
        this.ConfirmPassword = null;
        this.Email = null;
    };
}