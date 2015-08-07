'use strict';

bspnApp.controller('NFLCurrentSeasonController', ['$scope', 'NFLCurrentSeasonService',
    function NFLCurrentSeasonController($scope, NFLCurrentSeasonService) {
        $scope.NFLCurrentSeason = NFLCurrentSeasonService.get();

        $scope.SaveGamePicks = function (NFLCurrentSeason) {

            NFLCurrentSeasonService.save(NFLCurrentSeason);

        };
    }
]);

bspnApp.controller('NFLGamePicksController', ['$scope', 'NFLService',
    function NFLGamePicksController($scope, NFLService) {

        $scope.NFLGamePicks = 
    }
]);