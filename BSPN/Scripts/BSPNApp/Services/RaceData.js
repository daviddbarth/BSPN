/// <reference path="RaceData.js" />
bspnApp.factory('raceData', ['$resource', function ($resource) {
    return {
        getRaces: function () {
            return $resource('/api/Races').query()
        }
    };
}]);

