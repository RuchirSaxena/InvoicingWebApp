/// <reference path="F:\RKAY_Project\InvoicingApp-master\Billing_System\Scripts/angular.js" />
(function () {
    'use strict';

    angular
        .module('invoiceApp')
        .factory('partyFactory', partyFactory);

    partyFactory.$inject = ['$http'];

    function partyFactory($http) {
        var service = {
            getData: getData,
            saveData: saveData
        };

        return service;

        function getData() { }

        function saveData(partyDetails) {
            //$http.post('Invoice.aspx/SavePartyDetails', partyDetails )
            //        .success(function (data, status, headers, config) {

            //        });
            //$http({
            //    method: 'Get',
            //    url: 'Invoice.aspx/SavePartyDetails'
            //   // data: partyDetails 
            //}).then(function (response) {
            //    return response.data;
            //});

            $http({
                url: "Invoice.aspx/SavePartyDetails",
                dataType: 'json',
                method: 'POST',
                data: partyDetails,
                headers: {
                    "Content-Type": "application/json"
                }
            }).success(function (response) {
                $scope.value = response;
            })
          .error(function (error) {
              alert(error);
          });
        }
    }
})();