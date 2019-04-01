(function () {
    'use strict';

    angular
        .module('invoiceApp')
        .controller('recordCtrl', recordCtrl);

    recordCtrl.$inject = ['$scope'];

    function recordCtrl($scope) {
        var vm = this;
        var startDate = undefined;
        var endDate = undefined;
       // vm.recordData = null;
        vm.getRecordsData = function () {
            $('#dvData,#btnExport').show();
             startDate = $('#startDate').val();
             endDate = $('#endDate').val();
            if (startDate && endDate) {
                vm.recordData = getMonthlySalesData(startDate, endDate);
            } else {
                alert("Select Start Date and End Date!");
            }
        }

        $scope.deleteInvoice = function (invoiceNo) {
            var result= confirm("Are you sure you want to delete Invoice :" + invoiceNo);
            if (result) {
                removeInvoice(invoiceNo);
            }


        }

        function removeInvoice(invoiceNo) {
            var postData = {
                InvoiceNo: invoiceNo,
            }
           
            $.ajax({
                type: "POST",
                url: "/Records.aspx/DeleteInvoice",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                data: JSON.stringify(postData), // Check this call.
                success: function (data) {
                   alert("Succesfully deleted Invoice No :" + invoiceNo);
                  vm.getRecordsData();
                }
            });
           

        }


 
        function getMonthlySalesData(startDate, endDate) {
            var postData = {
                StartDate:startDate,
                EndDate:endDate
            }
            var recods = null;
            $.ajax({
                type: "POST",
                url: "/Records.aspx/GetMonthlySalesData",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                data: JSON.stringify(postData), // Check this call.
                success: function (data) {
                    recods = JSON.parse(data.d);
                }
            });
            return recods;
        }
    }
})();
