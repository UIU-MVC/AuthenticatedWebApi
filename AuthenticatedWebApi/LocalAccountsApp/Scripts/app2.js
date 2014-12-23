var ViewModel = function () {
    var self = this;
    self.students = ko.observableArray();
    self.courses = ko.observableArray();
    self.error = ko.observable();
    var tokenKey = 'accessToken';
    var token = sessionStorage.getItem(tokenKey);
    var headers = {};
    if (token) {
        headers.Authorization = 'Bearer ' + token;
    }

    var studentsUri = '/api/students/';
    var departmentsUri = '/api/departments/';
    var coursesUri = '/api/courses/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            headers: headers,
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllStudents() {
        ajaxHelper(studentsUri, 'GET').done(function (data) {
            self.students(data);
        });
    }
    function getAllCourses() {
        ajaxHelper(coursesUri, 'GET').done(function (data) {
            self.courses(data);
        });
    }
    self.detail = ko.observable();

    self.getStudentDetail = function (item) {
        ajaxHelper(studentsUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }





    self.departments = ko.observableArray();
    self.newStudent = {
        Name: ko.observable(),
        DepartmentId: ko.observable()
    }

    self.newCourse = {
        Name: ko.observable(),
        Credit: ko.observable()
    }


    function getDepartments() {
        ajaxHelper(departmentsUri, 'GET').done(function (data) {
            self.departments(data);
        });
    }

    self.addStudent = function (formElement) {
        var student = {
            DepartmentId: self.newStudent.Department.Id,
            Name: self.newStudent.Name()
        };
        ajaxHelper(studentsUri, 'POST', student).done(function (item) {
            self.students.push(item);
        });
    }

    self.addCourse = function (formElement) {
        var course = {
            Name: self.newCourse.Name(),
            Credit: self.newCourse.Credit()
        };
        ajaxHelper(coursesUri, 'POST', course).done(function (item) {
            self.courses.push(item);
        });
    }
    getAllStudents();
    getAllCourses();
    getDepartments();
}
ko.applyBindings(new ViewModel());