"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.Models == "undefined") {
    BowlPicks.Models = {};
}

if (typeof BowlPicks.Models.LeaderboardModel == "undefined") {
    BowlPicks.Models.LeaderboardModel = function () {
        var self = this;

        this.Name = null;
        this.CorrectPicks = 0;
        this.TotalPicks = 0;
        this.PickPercent = 0.0;
        this.Points = 0;
        this.MaxPoints = 0;
        this.Rank = 0;
        this.IsHeader = false;
        this.UserId = 0;

        this.Init = function(data) {
            self.Name = data.Name;
            self.CorrectPicks = data.CorrectPicks;
            self.TotalPicks = data.TotalPicks;
            self.PickPercent = data.PickPercent;
            self.Points = data.Points;
            self.MaxPoints = data.MaxPoints;
            self.Rank = data.Rank;
            self.UserId = data.UserId;
        };

        this.SetHeaderFields = function() {
            self.Name = "Name";
            self.CorrectPicks = "Correct";
            self.TotalPicks = "Total";
            self.PickPercent = "Percent";
            self.Points = "Points";
            self.MaxPoints = "Max";
            self.Rank = "Rank";
            self.IsHeader = true;
        }
    };
}