(function () {
    'use strict';

    angular
        .module('invoiceApp')
        .controller('invoiceCtrl', invoiceCtrl);

    invoiceCtrl.$inject = ['$scope'];

    function invoiceCtrl($scope) {
        var vm = this;
        vm.products = [];
        vm.invoiceDate = "";
        vm.SaveProduct = function (type, qty, amount) {
            if (type !== undefined && type !== "" || qty !== undefined && qty !== "" || amount !== undefined && amount !== "") {
                var tempObj = {
                    Type: type,
                    Quantity: qty,
                    Amount: amount
                };
                vm.products.push(tempObj);
               
            } else {
                alert("Select Type and Enter Quantity and Amount");
            }
        }
        vm.partyId = "";
        vm.SaveInvoice = function (partyId, dateOfInvoice) {
          
            if (partyId !== undefined && partyId !== "" || dateOfInvoice !== null && dateOfInvoice !== "") {
                var date = new Date($('#DateOfBill').val());
                if (vm.products.length !== 0) {
                    vm.invoiceDate = date.getFullYear() + "-" + date.getMonth() + "-" + date.getDay();
                    vm.partyId = partyId;
                    postInvoiceData(vm.partyId, vm.invoiceDate, vm.products)
                } else {
                    alert("Add products to Invoice");
                }
            } else {
                alert("Select party and date");
            }
           
        };

        function postInvoiceData(partyId, invoiceDate, products) {
            var invoiceData = {
                PartyId: partyId,
                InvoiceDate: invoiceDate,
                Products: products
            }
            debugger;
            $.ajax({
                type: "POST",
                url: "/Invoice.aspx/SaveInvoiceData",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ 'invoiceData': invoiceData }), // Check this call.
                success: function (data) {
                    debugger;
                }
            });
        }
    }
})();
