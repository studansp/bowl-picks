"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.Services == "undefined") {
    BowlPicks.Services = {};
}

if (typeof BowlPicks.Services.ServiceWrapper == "undefined") {
    BowlPicks.Services.ServiceWrapper = function($http) {
        this.GetUsers = function() {
            return $http.get(BowlPicks.Global.ApiRoot + '/BowlPicks/Users');
        };
        this.GetUserPicks = function (userId) {
            return $http.get(BowlPicks.Global.ApiRoot + '/BowlPicks/UserPicks/' + userId);
        };
        this.GetLeaderboard = function() {
            return $http.get(BowlPicks.Global.ApiRoot + '/BowlPicks/Leaderboard');
        };

        this.Login = function(userName, password) {
            return $http.get(BowlPicks.Global.ApiRoot + '/BowlPicks/Token?userName=' + userName + '&password=' + password);
        }

        this.GetMyPicks = function() {
            return $http.get(BowlPicks.Global.ApiRoot + '/BowlPicks/MyPicks?token=' + BowlPicks.Global.Token);
        }

        this.SetPicks = function (pairs) {
            return $http.put(BowlPicks.Global.ApiRoot + '/BowlPicks/MyPicks', { Token: BowlPicks.Global.Token, Picks: pairs });
        }

        this.CreateAccount = function(model) {
            return $http.post(BowlPicks.Global.ApiRoot + '/BowlPicks/Account', model);
        }
    };
}