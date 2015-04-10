'use strict';

bspnApp.controller('DriverListController', ['$scope', 'driverData',
    function DriverListController($scope, driverData) {
        $scope.driverList = driverData.getDriverList();
    }]
);


//studentTrackApp.controller('TeacherListController', ['$scope', 'teacherData',
//    function TeacherListController($scope, teacherData) {

//        $scope.teacherList = teacherData.getTeacherList();
//    }]
//);

//studentTrackApp.controller('TeacherController', ['$scope', '$routeParams', 'teacherData',
//    function TeacherController($scope, $routeParams, teacherData) {

//        $scope.teacher = teacherData.getTeacher($routeParams.teacherId);
//        $scope.saveTeacher = function (teacher) {
//            teacherData.saveTeacher(teacher);
//        }
//    }]
//);



