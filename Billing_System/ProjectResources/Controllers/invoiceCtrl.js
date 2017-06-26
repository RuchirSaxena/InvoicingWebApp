(function () {
    'use strict';

    angular
        .module('invoiceApp')
        .controller('invoiceCtrl', invoiceCtrl);

    invoiceCtrl.$inject = ['$scope']; 

    function invoiceCtrl($scope) {
        var vm = this;
        vm.test = "Hello";
    }
})();
