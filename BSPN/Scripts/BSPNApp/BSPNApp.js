'use strict';

var bspnApp = angular.module('BSPNApp', ['ngRoute', 'ngResource'])
    .config(function ($routeProvider) {
        $routeProvider.when('/ListDrivers',
            {
                templateUrl: '/Templates/Drivers/DriverList.html'
            })
    });
