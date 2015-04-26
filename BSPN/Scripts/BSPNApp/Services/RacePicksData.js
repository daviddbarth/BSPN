bspnApp.factory('racePicksData', ['$resource', function ($resource) {
    return $resource('/api/RacePicks/:id');
}]);


