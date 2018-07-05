/// <reference path="../../views/modelsview/_edit.cshtml" />
(function (angular) {
    angular.module('ngAppDemo', []).controller('ngAppDemoController', ['$scope', function ($scope, $http) {
        $scope.name = '';
        $scope.apellido = '';
        $scope.edad = '';
        $scope.email = '';
        $scope.birthday = '';
        $scope.master = {};
        $scope.update = function (user) {
            if ($scope.validacion.$valid){
                $scope.master = angular.copy(user);
            }
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