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
    angular.module('ExcelModel', []).controller('ExcelController', ['ExcelFactory', '$timeout', '$scope', function (ExcelFactory, $timeout, $scope) {
        $scope.exportToExcel = function (tableId) { // ex: '#my-table'
            $scope.exportHref = ExcelFactory.tableToExcel(tableId, 'sheet name');
            $timeout(function () { location.href = $scope.exportHref; }, 10); // trigger download
        }
    }])
    .factory('ExcelFactory', function ($window) {
        var uri = 'data:application/vnd.ms-excel;base64,',
			template = 
            '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40">'+
            '<head><!--[if gte mso 9]>'+
            '<xml>'+
            '<x:ExcelWorkbook>' +
            '<x:ExcelWorksheets>'+
            '<x:ExcelWorksheet>'+
            '<x:Name>{worksheet}</x:Name><x:WorksheetOptions>'+
            '<x:DisplayGridlines/>'+
            '</x:WorksheetOptions>'+
            '</x:ExcelWorksheet>'+
            '</x:ExcelWorksheets>'+
            '</x:ExcelWorkbook>'+
            '</xml>'+
            '<![endif]--></head>'+
            '<body>'+
            '<table>{table}</table>' +
            '</body>'+
            '</html>',
			base64 = function (s) { return $window.btoa(unescape(encodeURIComponent(s))); },
			format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) };
        return {
            tableToExcel: function (tableId, worksheetName) {
                var table = $(tableId),
					ctx = { worksheet: worksheetName, table: table.html() },
					href = uri + base64(format(template, ctx));
                return href;
            }
            //tableToExcel: function (tableId, worksheetName) {
            //    var table = $(tableId),
            //        ctx = { worksheet: worksheetName, table: table.innerHTML },
            //        href = uri + base64(format(template, ctx));
            //    return href;
            //}
        };
    });
    angular.module('plunker', []).controller('MainCtrl', function ($scope) {
        $scope.name = 'World';
        $scope.exportAction = function (option) {
            switch (option) {
                case 'pdf': $scope.$broadcast('export-pdf', {});
                    break;
                case 'excel': $scope.$broadcast('export-excel', {});
                    break;
                case 'doc': $scope.$broadcast('export-doc', {});
                    break;
                case 'csv': $scope.$broadcast('export-csv', {});
                    break;
                default: console.log('no event caught');
            }
        }
        $scope.Head = [
            { Name: "Data2", Orden: "2" },
            { Name: "Data1", Orden: "1" },
            { Name: "Data0", Orden: "0" },
            { Name: "Data5", Orden: "5" },
        ];
        $scope.reportData = [
            { EmployeeID: "1234567", LastName: "Lastname", FirstName: "First name", Salary: 1000, PersonaTipo: "Nombre", a: "a", b: "b", c: "c", d: "d" },
       ];
    }).directive('exportTable', function () {
        var link = function ($scope, elm, attr) {
            $scope.$on('export-pdf', function (e, d) {
                elm.tableExport({ type: 'pdf', escape: false });
            });
            $scope.$on('export-excel', function (e, d) {
                elm.tableExport({ type: 'excel', escape: false });
            });
            $scope.$on('export-doc', function (e, d) {
                elm.tableExport({ type: 'doc', escape: false });
            });
            $scope.$on('export-csv', function (e, d) {
                elm.tableExport({ type: 'csv', escape: false });
            });
        }
        return {
            restrict: 'C',
            link: link
        }
    });
    /*The MIT License (MIT)

    Copyright (c) 2014 https://github.com/kayalshri/

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.*/
    $.fn.extend({
        tableExport: function (options) {
            var defaults = {
                separator: ',',
                ignoreColumn: [],
                tableName: 'yourTableName',
                type: 'csv',
                pdfFontSize: 14,
                pdfLeftMargin: 20,
                escape: 'true',
                htmlContent: 'false',
                consoleLog: 'false'
            };

            var options = $.extend(defaults, options);
            var el = this;

            if (defaults.type == 'excel') {
                console.log($(this).html()); //GENERADOR DE EXCEL
                var excel = "<table>";
                // Header
                $(el).find('thead').find('tr').each(function () {
                    excel += "<tr>";
                    $(this).filter(':visible').find('th').each(function (index, data) {
                        if ($(this).css('display') != 'none') {
                            if (defaults.ignoreColumn.indexOf(index) == -1) {
                                excel += "<td>" + parseString($(this)) + "</td>";
                            }
                        }
                    });
                    excel += '</tr>';

                });


                // Row Vs Column
                var rowCount = 1;
                $(el).find('tbody').find('tr').each(function () {
                    excel += "<tr>";
                    var colCount = 0;
                    $(this).filter(':visible').find('td').each(function (index, data) {
                        if ($(this).css('display') != 'none') {
                            if (defaults.ignoreColumn.indexOf(index) == -1) {
                                excel += "<td>" + parseString($(this)) + "</td>";
                            }
                        }
                        colCount++;
                    });
                    rowCount++;
                    excel += '</tr>';
                });
                excel += '</table>'

                if (defaults.consoleLog == 'true') {
                    console.log(excel);
                }

                var excelFile = "<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:x='urn:schemas-microsoft-com:office:" + defaults.type + "' xmlns='http://www.w3.org/TR/REC-html40'>";
                excelFile += "<head>";
                excelFile += "<!--[if gte mso 9]>";
                excelFile += "<xml>";
                excelFile += "<x:ExcelWorkbook>";
                excelFile += "<x:ExcelWorksheets>";
                excelFile += "<x:ExcelWorksheet>";
                excelFile += "<x:Name>";
                excelFile += "{worksheet}";
                excelFile += "</x:Name>";
                excelFile += "<x:WorksheetOptions>";
                excelFile += "<x:DisplayGridlines/>";
                excelFile += "</x:WorksheetOptions>";
                excelFile += "</x:ExcelWorksheet>";
                excelFile += "</x:ExcelWorksheets>";
                excelFile += "</x:ExcelWorkbook>";
                excelFile += "</xml>";
                excelFile += "<![endif]-->";
                excelFile += "</head>";
                excelFile += "<body>";
                excelFile += excel;
                excelFile += "</body>";
                excelFile += "</html>";

                var fileType = '';
                if (defaults.type == 'excel') {
                    fileType = 'xls';
                }
                else if (defaults.type == 'doc') {
                    fileType = 'doc';
                }

                var blob = new Blob([excelFile], { type: 'text/' + fileType });
                if (window.navigator.msSaveBlob) { // // IE hack; see http://msdn.microsoft.com/en-us/library/ie/hh779016.aspx
                    window.navigator.msSaveOrOpenBlob(blob, 'exportData' + new Date().toDateString() + '.' + fileType);
                }
                else {
                    var a = window.document.createElement("a");
                    a.href = window.URL.createObjectURL(blob, { type: "text/plain" });
                    a.download = "exportData" + new Date().toDateString() + "." + fileType;
                    document.body.appendChild(a);
                    a.click();  // IE: "Access is denied"; see: https://connect.microsoft.com/IE/feedback/details/797361/ie-10-treats-blob-url-as-cross-origin-and-denies-access
                    document.body.removeChild(a);
                }

            } else if (defaults.type == 'png') {
                html2canvas($(el), {
                    onrendered: function (canvas) {
                        var img = canvas.toDataURL("image/png");
                        window.open(img);


                    }
                });
            } 

            function parseString(data) {

                if (defaults.htmlContent == 'true') {
                    content_data = data.html().trim();
                } else {
                    content_data = data.text().trim();
                }

                if (defaults.escape == 'true') {
                    content_data = escape(content_data);
                }



                return content_data;
            }

        }
    });
})(window.angular);