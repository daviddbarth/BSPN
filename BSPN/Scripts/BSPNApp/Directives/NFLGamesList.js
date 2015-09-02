'use strict';

bspnApp.directive('nflGamelist', function () {

    return {
        restrict: 'E',
        scope: {
            NFLWeek: '=nflweek',
            ShowPicks: '@showpicks'
        },
        templateUrl: '/Templates/NFL/NFLGameList.html'
    };
});