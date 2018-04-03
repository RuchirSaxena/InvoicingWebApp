(function () {
    'use strict';

    angular
        .module('invoiceApp')
        .controller('recordCtrl', recordCtrl);

    recordCtrl.$inject = ['$scope'];

    function recordCtrl($scope) {
        var vm = this;
       // vm.recordData = null;
        vm.getRecordsData = function () {
            $('#dvData,#btnExport').show();
            var startDate = $('#startDate').val();
            var endDate = $('#endDate').val();
            if (startDate && endDate) {
                vm.recordData = getMonthlySalesData(startDate, endDate);
            } else {
                alert("Select Start Date and End Date!");
            }
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
