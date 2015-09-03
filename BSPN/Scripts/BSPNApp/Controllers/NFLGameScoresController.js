'use strict';

bspnApp.controller('NFLGameScoresController', ['$scope', 'NFLGameScoresService',
    function NFLGameScoresController($scope, NFLGameScoresService) {
        $scope.NFLWeek = NFLGameScoresService.get();

        $scope.SaveGameScores = function (NFLWeek) {

            NFLGameScoresService.save(NFLWeek,
                function () {
                    $scope.SaveResultMessage = "Game Scores Saved Succesfully.";
                },
                function (error) {
                    $scope.SaveResultMessage = error.data;
                }
            );

        };
    }
]);

