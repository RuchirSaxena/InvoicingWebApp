(function () {
    'use strict';

    angular
        .module('invoiceApp')
        .controller('partyCtrl', partyCtrl);

    partyCtrl.$inject = ['$scope', 'partyFactory'];

    function partyCtrl($scope, partyFactory) {
        var vm = this;
        vm.partyDetails = {};
        vm.partyFactory = partyFactory;
        vm.savePartyDetails = savePartyDetails;
        //saving party details using factory
        function savePartyDetails(partyDetails) {
            debugger;
            vm.partyFactory.saveData(partyDetails);
        }
    }
})();
