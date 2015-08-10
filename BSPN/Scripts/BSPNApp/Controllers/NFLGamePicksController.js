'use strict';

bspnApp.controller('NFLGamePicksController', ['$scope', 'NFLGamePicksService',
    function NFLGamePicksController($scope, NFLGamePicksService) {
        $scope.NFLGamePicks = NFLGamePicksService.get();

        $scope.SaveGamePicks = function (NFLWeek) {

            NFLGamePicksService.save(NFLWeek,
                function () {
                    $scope.SaveResultMessage = "Game Picks Saved Succesfully.";
                },
                function (error) {
                    $scope.SaveResultMessage = error.data;
                }
            );

        };
    }
]);