bspnApp.factory('driverData', ['$resource', function ($resource) {
    return {
        getDriverList: function () {
            return $resource('/api/Drivers').query()
        },

        getDriver: function (driverId) {
            return $resource('/api/Drivers/:id', { id: '@id' }).get({ id: driverId })
        }
    };
}]);



