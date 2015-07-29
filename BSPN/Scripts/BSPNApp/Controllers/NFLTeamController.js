'use strict';

bspnApp.controller('NFLTeamListController', ['$scope', 'NFLService',
    function NFLTeamListController($scope, NFLService) {
        $scope.NFLTeamList = NFLService.query();

        $scope.saveNFLTeam = function (NFLTeam) {
            NFLService.save(
                NFLTeam,
                function () { },
                function (error) {
                    $scope.errorMsg = error.data;
                }
            );
        };

        $scope.addNFLTeam = function () {
            $scope.NFLTeamList.push($scope.newNFLTeam);
            $scope.saveNFLTeam($scope.newNFLTeam);
        };
    }
]);

bspnApp.controller('NFLTeamController', ['$scope', '$routeParams', 'NFLService',
    function NFLTeamController($scope, $routeParams, NFLService) {
        $scope.NFLTeam = NFLService.getTeam({ id: 1 });
    }
]);
