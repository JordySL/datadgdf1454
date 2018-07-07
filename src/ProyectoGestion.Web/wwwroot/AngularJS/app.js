/// <reference path="../../views/modelsview/_edit.cshtml" />
(function (angular) {
    angular.module('ngAppDemo', []).controller('ngAppDemoController', ['$scope','$http', function ($scope, $http) {
        $scope.name = '';
        $scope.apellido = '';
        $scope.edad = '';
        $scope.email = '';
        $scope.birthday = '';
        $scope.master = [];
        Object.toparams = function ObjecttoParams(obj) {
            var p = [];
            for (var key in obj) {
                p.push(key + '=' + encodeURIComponent(obj[key]));
            }
            return p.join('&');
        };
        $scope.update = function (user) {
            //    if ($scope.validacion.$valid){
            console.log(user.UserNameList);
            var dataList = [];
            for (var i = 0; i < user; i++) {
                console.log(user.UserNameList[i]);
                dataList = new dataList[i];
                dataList = user.UserNameList;
                user[i].UserNameList.push(dataList);
                }

                dataojb = {
                    UserNameList: user.UserNameList = [user.UserNameList[0],user.UserNameList[1],user.UserNameList[2]],
                    Name: user.Name
                }
                var jsondata = JSON.stringify(dataojb.UserNameList[0]);
                $scope.master = angular.copy(JSON.stringify(dataojb.UserNameList));

                console.log(jsondata);
            $http({
                method: 'post',
                url: '/ModelsView/Create',
                datatype: 'json',
                data: jsondata,
                contentType: "application/json",
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function successCallback(data) {
                $scope.usuarios = data.data;
                console.log(data);
            }, function errorCallback(data) {
                console.log(data);
            });
        };
        
        $scope.users = [{ nombre: 'Jordy', ape: 'Sotomayor', Editar: 'Editar', Borrar: 'Borrar' },
                        { nombre: 'Tiff', ape: 'Martinez', Editar: 'Editar', Borrar: 'Borrar' }];

    }]);
    angular.module('ngAppRepert', []).controller('ngAppReperts', ['$scope', '$http', '$templateCache', function ($scope, $http, $templateCache) {
        $scope.Editar = 'Editar';
        $scope.Borrar = 'Borrar';
        $http({ method: "Post", url: "/ModelsView/JsonListar", })
            .then(function successCallback(response) {
                $scope.usuarios = response.data;
                console.log(response);
        },function errorCallback(response) {
                console.log(response);
        });
    }]);

    angular.module('Example', []).controller('ExampleController', ['$scope', function ($scope) {
        $scope.NuevoItem = {};
        $scope.usuario = [];
        $scope.agregarNuevoItem = function () {
            $scope.usuario.push($scope.NuevoItem);
            $scope.NuevoItem = {};
        }
}]);
})(window.angular);