"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.Controllers == "undefined") {
    BowlPicks.Controllers = {};
}

if (typeof BowlPicks.Controllers.HeaderController == "undefined") {
    BowlPicks.Controllers.HeaderController = function ($scope, $rootScope, $location) {
        $rootScope.$broadcast(BowlPicks.Global.Events.AuthChange);

        $rootScope.$on(BowlPicks.Global.Events.AuthChange, function() {
            $scope.Token = BowlPicks.Global.Token!=null;
        });

        $scope.Logout = function() {
            BowlPicks.Global.Token = null;
            $rootScope.$broadcast(BowlPicks.Global.Events.AuthChange);
            $location.path('/');
        }
    };
}