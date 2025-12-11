
var app = angular.module("dmsApp", ["smart-table", "ui.bootstrap", "ngAnimate", "ngTouch", "ui.select2"]);

app.directive("akFileModel", ["$parse",
    function ($parse) {
        return {
            restrict: "A",
            link: function (scope, element, attrs) {
                var model = $parse(attrs.akFileModel);
                var modelSetter = model.assign;
                element.bind("change", function () {
                    scope.$apply(function () {
                        modelSetter(scope, element[0].files[0]);
                    });
                });
            }
        };
    }]);