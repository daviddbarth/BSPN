'use strict';

bspnApp.controller('RacesController', ['$scope', '$routeParams', 'raceData',
    function RacesController($scope, $routeParams, raceData) {
        $scope.raceData = raceData.getRaces();
        }
]);
