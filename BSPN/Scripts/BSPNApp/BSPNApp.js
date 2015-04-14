'use strict';

var bspnApp = angular.module('BSPNApp', ['ngRoute', 'ngResource'])
    .config(function ($routeProvider) {
        $routeProvider.when('/ListDrivers',
            {
                templateUrl: '/Templates/Drivers/DriverList.html'
            })
        .when('/EditDriver/:driverId',
            {
                templateUrl: '/Templates/Drivers/EditDriver.html'
            })
        .when('/RacePicks',
            {
                templateUrl: '/Templates/Races/RacePicks.html'
            })
    });
