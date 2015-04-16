'use strict';

bspnApp.controller('DriverListController', ['$scope', 'driverData',
    function ($scope, driverData) {
        $scope.driverList = driverData.getDriverList();
    }]
);

//bspnApp.controller('DriverController', ['$scope', '$routeParams', 'driverData',
//    function ($scope, $routeParams, driverData) {
//        $scope.driver = driverData.getDriver($routeParams.driverId);
//    }]
//);
