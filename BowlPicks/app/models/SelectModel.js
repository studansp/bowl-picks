"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.Models == "undefined") {
    BowlPicks.Models = {};
}

if (typeof BowlPicks.Models.SelectModel == "undefined") {
    BowlPicks.Models.SelectModel = function () {
        var self = this;

        this.Value = 0;
        this.Text = null;

        this.Init = function (data) {
            self.Value = data.Value;
            self.Text = data.Text;
        };
    };
}