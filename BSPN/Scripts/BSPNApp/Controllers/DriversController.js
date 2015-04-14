'use strict';

bspnApp.controller('DriverListController', ['$scope', 'driverData',
    function DriverListController($scope, driverData) {
        $scope.driverList = driverData.getDriverList();
    }]
);

bspnApp.controller('DriverController', ['$scope', '$routeParams', 'driverData',
    function DriverController($scope, $routeParams, driverData) {
        $scope.driver = driverData.getDriver($routeParams.driverId);
    }]
);
