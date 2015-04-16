'use strict';

bspnApp.controller('RacesController', ['$scope', 'raceData',
    function RacesController($scope, raceData) {
        $scope.raceData = raceData.getRaces();
    }]
);

