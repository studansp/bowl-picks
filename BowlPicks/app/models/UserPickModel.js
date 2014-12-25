"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.Models == "undefined") {
    BowlPicks.Models = {};
}

if (typeof BowlPicks.Models.UserPickModel == "undefined") {
    BowlPicks.Models.UserPickModel = function () {
        var self = this;

        this.GameName = null;
        this.GameId = null;
        this.IsTeam1Selected = false;
        this.Confidence = 0;
        this.PointsEarned = 0;
        this.Team1 = null;
        this.Team2 = null;
        this.Team1Spread = 0;

        this.Init = function (data) {
            self.GameName = data.GameName;
            self.GameId = data.GameId;
            self.IsTeam1Selected = data.IsTeam1Selected;
            self.Confidence = data.Confidence;
            self.PointsEarned = data.PointsEarned;
            self.Team1 = data.Team1;
            self.Team2 = data.Team2;
            self.Team1Spread = data.Team1Spread;
        };
    };
}