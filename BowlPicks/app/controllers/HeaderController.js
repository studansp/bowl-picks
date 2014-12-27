"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.Controllers == "undefined") {
    BowlPicks.Controllers = {};
}

if (typeof BowlPicks.Controllers.HeaderController == "undefined") {
    BowlPicks.Controllers.HeaderController = function ($scope, $rootScope, $location) {
        function initRoute(path) {
            $scope.HomeSelected = path.indexOf('/home') == 0 ? 'selectedHeader' : '';
            $scope.MyPicksSelected = path.indexOf('/mypicks') == 0 ? 'selectedHeader' : '';
            $scope.AllPicksSelected = path.indexOf('/allpicks') == 0 ? 'selectedHeader' : '';
            $scope.LoginSelected = path.indexOf('/login') == 0 ? 'selectedHeader' : '';
        }

        $rootScope.$broadcast(BowlPicks.Global.Events.AuthChange);

        $rootScope.$on(BowlPicks.Global.Events.AuthChange, function() {
            $scope.Token = BowlPicks.Global.Token!=null;
        });

        $rootScope.$on(BowlPicks.Global.Events.PageChange, function () {
            initRoute($location.path());
        });

        $scope.Logout = function () {
            eraseCookie(BowlPicks.Global.Cookies.Token);
            BowlPicks.Global.Token = null;
            $rootScope.$broadcast(BowlPicks.Global.Events.AuthChange);
            $location.path('/');
        }

        initRoute($location.path());

        $scope.Token = BowlPicks.Global.Token != null;
    };
}