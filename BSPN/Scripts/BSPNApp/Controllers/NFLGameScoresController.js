'use strict';

bspnApp.controller('NFLGameScoresController', ['$scope', 'NFLGameScoresService',
    function NFLGameScoresController($scope, NFLGameScoresService) {
        $scope.NFLWeek = NFLGameScoresService.get();

    }
]);

