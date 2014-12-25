"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.Controllers == "undefined") {
    BowlPicks.Controllers = {};
}

if (typeof BowlPicks.Controllers.AllPicksController == "undefined") {
    BowlPicks.Controllers.AllPicksController = function ($scope, ServiceWrapper) {
        $scope.IsLoading = true;
        $scope.SelectedPicks = new BowlPicks.Models.UserPicksContainerModel();

        $scope.Users = new Array();
        $scope.EmptyUser = new BowlPicks.Models.SelectModel();
        $scope.EmptyUser.Text = '- Select A User -';
        $scope.EmptyUser.Value = -1;
        $scope.Users.push($scope.EmptyUser);

        $scope.SelectedUser = $scope.EmptyUser;

        ServiceWrapper.GetUsers().then(function(response) {
            if (response.status == BowlPicks.Global.HttpStatus.OK) {
                for (var i = 0; i < response.data.length; i++) {
                    var model = new BowlPicks.Models.SelectModel();
                    model.Init(response.data[i]);
                    $scope.Users.push(model);
                }
            } else {
                alert("Error");
            }
            $scope.IsLoading = false;
        });

        $scope.UserChanged = function () {
            while ($scope.SelectedPicks.length > 0) {
                $scope.SelectedPicks.pop();
            }

            if ($scope.SelectedUser != $scope.EmptyUser) {
                $scope.IsLoading = true;

                ServiceWrapper.GetUserPicks($scope.SelectedUser.Value).then(function(response) {
                    if (response.status == BowlPicks.Global.HttpStatus.OK) {
                        $scope.SelectedPicks.Init(response.data);
                    } else {
                        alert("Error");
                    }
                    $scope.IsLoading = false;
                });
            }
        }
    };
}