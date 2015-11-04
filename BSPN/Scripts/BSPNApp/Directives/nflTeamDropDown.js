'use strict';

bspnApp.directive('nflTeamdrop', function () {

    return {
        restrict: 'E',
        controller: 'NFLTeamListController',
        templateUrl: '/Templates/NFL/Directives/NFLTeamDropDown.html'
    };
});