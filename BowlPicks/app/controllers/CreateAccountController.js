"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.Controllers == "undefined") {
    BowlPicks.Controllers = {};
}

if (typeof BowlPicks.Controllers.CreateAccountController == "undefined") {
    BowlPicks.Controllers.CreateAccountController = function($scope, ServiceWrapper, $rootScope, $location) {
        $scope.Model = new BowlPicks.Models.CreateAccountModel();
        $scope.ErrorMessage = null;

        $scope.CreateAccount = function () {
            if ($scope.Model.Password != $scope.Model.ConfirmPassword) {
                $scope.Model.ErrorMessage = 'Passwords must match';
            } else if ($scope.Model.Password.length < 6) {
                $scope.ErrorMessage = 'Passwords must be at least 6 characters';
            } else {
                ServiceWrapper.CreateAccount($scope.Model).then(function (response) {
                    BowlPicks.Global.Token = response.data;
                    $rootScope.$broadcast(BowlPicks.Global.Events.AuthChange);
                    $location.path('/');
                }, function(response) {
                    $scope.ErrorMessage = response.data;
            });
            }
        };
    };
}