bspnApp.factory('NFLTeamService', ['$resource', function ($resource) {
        return $resource('/api/NFLTeams');
    }]);

bspnApp.factory('NFLCurrentSeasonService', ['$resource', function($resource) {
    return $resource('/api/NFLCurrentSeason');
}]);