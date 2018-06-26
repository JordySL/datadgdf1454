/// <reference path="../../views/modelsview/_edit.cshtml" />
(function (angular) {
    angular.module('ngAppDemo', []).controller('ngAppDemoController', ['$scope', function ($scope, $http) {
        $scope.name = '';
        $scope.apellido = '';
        $scope.edad = '';
        $scope.email = '';
        $scope.birthday = '';
        $scope.users = [{ nombre: 'Jordy', ape: 'Sotomayor', Editar: 'Editar', Borrar: 'Borrar' },
                        { nombre: 'Tiff', ape: 'Martinez', Editar: 'Editar', Borrar: 'Borrar' }];

    }]);
    angular.module('ngAppRepert', []).controller('ngAppReperts', ['$scope', '$http', '$templateCache', function ($scope, $http, $templateCache) {
        $scope.Editar = 'Editar';
        $scope.Borrar = 'Borrar';
        $scope.method = 'Post';
        $scope.url = '/ModelsView/JsonListar';
        $http({
            method: $scope.method,
            url: $scope.url,
        }).then(function successCallback(response) {
            $scope.usuarios = response.data;
            console.log(response);
        }, function errorCallback(response) {
            console.log(response);
        });
    }]);
    angular.module('ngAppModal', []).controller('ngAppModalController', ['$scope','$http','$modal', function ($scope, $http) {
        $scope.showModal =function () {
        $scope.Modal = { };
        var modalInstance = $modal.open({
            templateUrl: '~/Views/ModelsView/_Edit.cshtml'})
}
    }]);
})(window.angular);