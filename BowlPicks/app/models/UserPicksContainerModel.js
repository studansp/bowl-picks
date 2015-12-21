"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.Models == "undefined") {
    BowlPicks.Models = {};
}

if (typeof BowlPicks.Models.UserPicksContainerModel == "undefined") {
    BowlPicks.Models.UserPicksContainerModel = function () {
        var self = this;

        this.Picks = new Array();
        this.Name = null;
        this.CorrectPicks = 0;
        this.TotalPicks = 0;
        this.PickPercent = 0.0;
        this.Points = 0;
        this.MaxPoints = 0;
        this.Rank = 0;
        this.IsHeader = false;
        this.UserId = 0;
        this.PicksFinal = true;

        this.Init = function (data) {
            self.Name = data.Name;
            self.CorrectPicks = data.CorrectPicks;
            self.TotalPicks = data.TotalPicks;
            self.PickPercent = data.PickPercent;
            self.Points = data.Points;
            self.MaxPoints = data.MaxPoints;
            self.Rank = data.Rank;
            self.UserId = data.UserId;
            self.PicksFinal = data.PicksFinal;

            while (self.Picks.length > 0) {
                self.Picks.pop();
            }

            for (var i = 0; i < data.Picks.length; i++) {
                var picksModel = new BowlPicks.Models.UserPickModel();
                picksModel.Init(data.Picks[i]);
                self.Picks.push(picksModel);
            }

        };
    };
}