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

            //$http({
            //    url: "Invoice.aspx/SavePartyDetails",
            //    dataType: 'json',
            //   // contentType: 'application/json; charset=utf-8',
            //    method: 'POST',
            //  //  JSON.stringify({ haha: $(this).val(),tuan: "hahaha" }),
            //    data: {Party:partyDetails},
            //    headers: {
            //        'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
            //    }
            //}).then(function(data){
            //    alert("done");
            //})
            //$http.post("Invoice.aspx", { Party: partyDetails }, {
            //    transformRequest: angular.identity,
            //    headers: { 'Content-Type': undefined }
            //}).then(function (data) {
            //    //success
            //}, function (error) {
            //    //error
            //});

            //Final Method
            $.ajax({
                type: "POST",
                url: "/Invoice.aspx/SavePartyDetails",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ 'party': partyDetails }), 
                success: function (data) {
                    if (data.d === "1") {
                        alert("Party Details inserted sucessfully");
                        location.reload();  
                    } else {
                        alert("Error Occured");
                    }
                }
            });
         
        }
    }
})();