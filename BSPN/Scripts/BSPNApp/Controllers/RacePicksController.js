'use strict';

bspnApp.controller('RacePicksController', ['$scope', '$routeParams', 'racePicksData',
    function ($scope, $routeParams, racePicksData) {
        $scope.racePicks = racePicksData.get({ id: $routeParams.raceId },
            function (data) { },
            function (error) {
                $scope.errorMsg = error.data;
            });

        $scope.saveRacePicks = function (racePicks) {
            racePicksData.save(racePicks, function() { }, function(error) {
                $scope.errorMsg = error.data;
            });
        }
    }
]);
