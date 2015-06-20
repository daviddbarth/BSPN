bspnApp.factory('NFLService', ['$resource', function ($resource) {
        return $resource('/api/NFLTeams');
    }]);
