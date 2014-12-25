"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.Models == "undefined") {
    BowlPicks.Models = {};
}

if (typeof BowlPicks.Models.GameModel == "undefined") {
    BowlPicks.Models.GameModel = function () {
        var self = this;

        this.GameId = 0;
        this.GameName = null;
        this.Team1 = null;
        this.Team2 = null;
        this.Team1Spread = null;
        this.IsGameOver = false;
        this.DidTeam1Win = false;

        this.Init = function (data) {
            self.GameId = data.GameId;
            self.GameName = data.GameName;
            self.Team1 = data.Team1;
            self.Team2 = data.Team2;
            self.Team1Spread = data.Team1Spread;
            self.IsGameOver = data.IsGameOver;
            self.DidTeam1Win = self.DidTeam1Win;
        };
    };
}