// ReSharper disable All
'use strict';

bspnApp.controller('NFLCurrentSeasonController', ['$scope', 'NFLCurrentSeasonService',
    function NFLCurrentSeasonController($scope, NFLCurrentSeasonService) {
        $scope.NFLCurrentSeason = NFLCurrentSeasonService.get();
    }
]);

