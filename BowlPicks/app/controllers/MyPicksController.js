"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.Controllers == "undefined") {
    BowlPicks.Controllers = {};
}

if (typeof BowlPicks.Controllers.MyPicksController == "undefined") {
    BowlPicks.Controllers.MyPicksController = function ($scope, ServiceWrapper, $location) {
        $scope.IsLoading = true;
        $scope.PicksFinal = true;

        $scope.IsTeam1Selected = function($index, team1Selected) {
            $scope.Model.Picks[$index].IsTeam1Selected = team1Selected;
        };

        $scope.Up = function ($index) {
            if ($index > 0) {
                var item = $scope.Model.Picks[$index];
                $scope.Model.Picks[$index] = $scope.Model.Picks[$index - 1];
                $scope.Model.Picks[$index-1] = item;
            }
        }

        $scope.Down = function ($index) {
            if ($index < $scope.Model.Picks.length - 1) {
                var item = $scope.Model.Picks[$index];
                $scope.Model.Picks[$index] = $scope.Model.Picks[$index + 1];
                $scope.Model.Picks[$index+1] = item;
            }
        }

        $scope.SubmitPicks = function() {
            $scope.IsLoading = true;

            var pickPairs = new Array();

            for (var i = 0; i < $scope.Model.Picks.length; i++) {
                var currentPair = new BowlPicks.Models.PickModel();
                currentPair.GameId = $scope.Model.Picks[i].GameId;
                currentPair.IsTeam1Selected = $scope.Model.Picks[i].IsTeam1Selected;

                pickPairs.push(currentPair);
            }

            ServiceWrapper.SetPicks(pickPairs).then(function (response) {
                $scope.Model.Init(response.data);
                $scope.IsLoading = false;
            }, function (response) {
                //TODO Error
            });
        }

        if (!BowlPicks.Global.Token) {
            $location.path('/login');
        } else {
            $scope.Model = new BowlPicks.Models.UserPicksContainerModel();

            ServiceWrapper.GetMyPicks().then(function(response) {
                $scope.Model.Init(response.data);
                $scope.IsLoading = false;
            }, function(response) {
                //TODO Error
            });
        }
    };
}