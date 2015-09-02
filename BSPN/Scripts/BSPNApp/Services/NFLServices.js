bspnApp.factory('NFLTeamService', ['$resource', function ($resource) {
        return $resource('/api/NFLTeams');
    }]);

bspnApp.factory('NFLCurrentSeasonService', ['$resource', function($resource) {
    return $resource('/api/NFLCurrentSeason');
}]);

bspnApp.factory('NFLGamePicksService', ['$resource', function ($resource) {
    return $resource('/api/NFLGamePicks');
}]);

bspnApp.factory('NFLGameScoresService', ['$resource', function ($resource) {
    return $resource('/api/NFLScores');
}]);
