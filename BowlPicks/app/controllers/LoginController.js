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
        $scope.RememberMe = true;

        $scope.Login = function () {
            ServiceWrapper.Login($scope.Model.Username, $scope.Model.Password).then(function (response) {
                BowlPicks.Global.Token = response.data;
                $rootScope.$broadcast(BowlPicks.Global.Events.AuthChange);

                if ($scope.RememberMe) {
                    createCookie(BowlPicks.Global.Cookies.Token, response.data, 30);
                }

                $location.path('/');
            }, function(response) {
                $scope.ErrorMessage = response.data;
            });
        }
    };
}