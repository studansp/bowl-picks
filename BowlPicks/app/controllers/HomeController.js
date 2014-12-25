"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.Controllers == "undefined") {
    BowlPicks.Controllers = {};
}

if (typeof BowlPicks.Controllers.HomeController == "undefined") {
    BowlPicks.Controllers.HomeController = function ($scope, ServiceWrapper) {
        $scope.Leaders = new Array();
        $scope.IsLoading = true;

        ServiceWrapper.GetLeaderboard().then(function (result) {
            if (result.status == BowlPicks.Global.HttpStatus.OK) {
                var headerModel = new BowlPicks.Models.LeaderboardModel();
                headerModel.SetHeaderFields();
                $scope.Leaders.push(headerModel);

                for (var i = 0; i < result.data.length; i++) {
                    var model = new BowlPicks.Models.LeaderboardModel();
                    model.Init(result.data[i]);
                    $scope.Leaders.push(model);
                }
            } else {
                alert("An error has occurred");
            }

            $scope.IsLoading = false;
        });

    };
}