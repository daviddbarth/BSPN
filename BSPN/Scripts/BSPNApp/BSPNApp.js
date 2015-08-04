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
        .when('/RacePicks/:raceId',
            {
                templateUrl: '/Templates/Races/RacePicks.html'
            })
        .when('/NFL/Teams',
            {
                templateUrl: '/Templates/NFL/NFLTeam.html'
            })
        .when('/NFL/NFLSeasonPicks',
            {
                templateUrl: '/Templates/NFL/NFLSeasonPicks.html'
            })
    }]);
