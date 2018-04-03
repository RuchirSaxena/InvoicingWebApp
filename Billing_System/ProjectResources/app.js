/// <reference path="F:\RKAY_Project\InvoicingApp-master\Billing_System\Scripts/angular.js" />
(function () {

  var invoiceApp=  angular
        .module("invoiceApp", []);

  invoiceApp.directive('jqdatepicker', function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attrs, ngModelCtrl) {
                element.datepicker({
                    dateFormat: 'DD, d  MM, yy',
                    onSelect: function (date) {
                        scope.date = date;
                        scope.$apply();
                    }
                });
            }
        };
    });

}());
