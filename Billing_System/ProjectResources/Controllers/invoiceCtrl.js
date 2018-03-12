(function () {
    'use strict';

    angular
        .module('invoiceApp')
        .controller('invoiceCtrl', invoiceCtrl);

    invoiceCtrl.$inject = ['$scope'];

    

    function invoiceCtrl($scope) {
        var vm = this;
        vm.partyData = getPartyData();
        vm.products = [];

        vm.invoiceDate = "";
        vm.SaveProduct = function (type, qty, amount, billType) {
            if (type !== undefined && type !== "" || qty !== undefined && qty !== "" || amount !== undefined && amount !== "") {
                var tempObj = {
                    Type: type,
                    Quantity: qty,
                    Amount: amount,
                    BillType: billType
                };
                vm.products.push(tempObj);
               
            } else {
                alert("Select Type and Enter Quantity and Amount");
            }
        }
        vm.partyId = "";
        vm.SaveInvoice = function (partyId) {
          
            if (partyId !== undefined && partyId !== "" ) {
                
                if (vm.products.length !== 0) {
                    vm.invoiceDate = $('#DateOfBill').val();
                    if (vm.invoiceDate === "") {
                        alert("Select date");
                        return;
                    }
                    vm.partyId = partyId;
                    postInvoiceData(vm.partyId, vm.invoiceDate, vm.products)
                } else {
                    alert("Add products to Invoice");
                }
            } else {
                alert("Select party");
            }
           
        };

        function postInvoiceData(partyId, invoiceDate, products) {
            var invoiceData = {
                PartyId: partyId.PartyId,
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
                    if (data.d === "1") {
                        alert("Invoice Created Sucessfully!");
                        window.location.href = "GenerateInvoice.aspx";
                    }
                }
            });
        }

        function getPartyData() {
            var partyDetails = "";
            $.ajax({
                type: "POST",
                url: "/Invoice.aspx/GetPartyDetail",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                data: {}, // Check this call.
                success: function (data) {
                    partyDetails = JSON.parse(data.d);
                }
            });
            return partyDetails;
        }
    }
})();
