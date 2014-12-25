"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.Controllers == "undefined") {
    BowlPicks.Controllers = {};
}

if (typeof BowlPicks.Controllers.LoginController == "undefined") {
    BowlPicks.Controllers.LoginController = function ($scope, ServiceWrapper, $rootScope, $location) {
        $scope.Model = new BowlPicks.Models.LoginModel();
        $scope.ErrorMessage = null;

        $scope.Login = function () {
            ServiceWrapper.Login($scope.Model.Username, $scope.Model.Password).then(function (response) {
                BowlPicks.Global.Token = response.data;
                $rootScope.$broadcast(BowlPicks.Global.Events.AuthChange);
                $location.path('/');
            }, function(response) {
                $scope.ErrorMessage = response.data;
            });
        }
    };
}