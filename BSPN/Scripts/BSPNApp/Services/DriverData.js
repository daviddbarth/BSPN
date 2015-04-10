bspnApp.factory('driverData', function ($resource) {
    return {
        getDriverList: function () {
            return $resource('/api/Drivers').query()
        }
    };
});



//studentTrackApp.factory('teacherData', function ($resource) {
//    return {
//        getTeacherList: function () {
//            return $resource('/api/Teachers').query()
//        },

//        getTeacher: function (teacherId) {
//            var Teacher = $resource('/api/Teachers/:id', { id: '@id' });
//            return Teacher.get({ id: teacherId })
//        },

//        saveTeacher: function (teacher) {
//            var TeacherService = $resource('/api/Teachers/:Teacher');
//            return TeacherService.save(teacher)
//        }
//    };
//});

