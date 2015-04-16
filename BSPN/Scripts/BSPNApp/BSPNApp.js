'use strict';

var bspnApp = angular.module('BSPNApp', ['ngRoute', 'ngResource'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/ListDrivers',
            {
                templateUrl: '/Templates/Drivers/DriverList.html'
            })
        .when('/EditDriver/:driverId',
            {
                templateUrl: '/Templates/Drivers/EditDriver.html'
            })
        .when('/Races',
            {
                templateUrl: '/Templates/Races/Races.html'
            })
    }]);
