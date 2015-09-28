'use strict';

bspnApp.controller('NFLPicksRecordController', ['$scope', 'NFLPicksRecordsService',
    function NFLPicksRecordController($scope, NFLPicksRecordsService) {
        $scope.NFLPicksRecords = NFLPicksRecordsService.get();
    }
]);


