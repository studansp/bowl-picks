"use strict";

if (typeof BowlPicks == "undefined") {
    window.BowlPicks = {};
}

if (typeof BowlPicks.App == "undefined") {
    BowlPicks.App = angular.module('BowlPicks.App', ['ngRoute', 'dndLists']);

    BowlPicks.App.service('ServiceWrapper', ['$http', BowlPicks.Services.ServiceWrapper]);

    BowlPicks.App.controller('HomeController', ['$scope', 'ServiceWrapper', BowlPicks.Controllers.HomeController]);
    BowlPicks.App.controller('HeaderController', ['$scope', '$rootScope', '$location', BowlPicks.Controllers.HeaderController]);
    BowlPicks.App.controller('AllPicksController', ['$scope', 'ServiceWrapper', BowlPicks.Controllers.AllPicksController]);
    BowlPicks.App.controller('MyPicksController', ['$scope', 'ServiceWrapper', '$location', BowlPicks.Controllers.MyPicksController]);
    BowlPicks.App.controller('LoginController', ['$scope', 'ServiceWrapper', '$rootScope', '$location', BowlPicks.Controllers.LoginController]);
    BowlPicks.App.controller('CreateAccountController', ['$scope', 'ServiceWrapper', '$rootScope', '$location', BowlPicks.Controllers.CreateAccountController]);

    BowlPicks.App.config(function($routeProvider) {
        $routeProvider.
          when('/home', {
              templateUrl: '../views/home.html',
              controller: 'HomeController'
          }).
          when('/mypicks', {
              templateUrl: '../views/mypicks.html',
              controller: 'MyPicksController'
          }).
          when('/allpicks', {
              templateUrl: '../views/allpicks.html',
              controller: 'AllPicksController'
          }).
          when('/login', {
              templateUrl: '../views/login.html',
              controller: 'LoginController'
          }).
          when('/createaccount', {
              templateUrl: '../views/createaccount.html',
              controller: 'CreateAccountController'
          }).
          otherwise({
              redirectTo: '/home'
          });
    });

    BowlPicks.App.run(function ($rootScope) {
        $rootScope.$on('$routeChangeSuccess', function (next, current) {
            $rootScope.$broadcast(BowlPicks.Global.Events.PageChange);
        });

        BowlPicks.Global.Token = readCookie(BowlPicks.Global.Cookies.Token);

        if (BowlPicks.Global.Token) {
            $rootScope.$broadcast(BowlPicks.Global.Events.AuthChange);
        }
    });
}