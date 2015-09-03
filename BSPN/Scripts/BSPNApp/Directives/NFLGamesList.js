'use strict';

bspnApp.directive('nflGamelist', function () {

    return {
        restrict: 'E',
        scope: {
            NFLWeek: '=nflweek',
            ShowPicks: '@showpicks',
            ShowScores: '@showscores'
        },
        templateUrl: '/Templates/NFL/NFLGameList.html'
    };
});