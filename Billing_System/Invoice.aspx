<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="Billing_System.Invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/main.css" rel="stylesheet" />
</head>
<body ng-app="invoiceApp">

    <!--NavBars-->
    <nav class="navbar navbar-inverse">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">R.KAY.STEELS</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="/Invoice.aspx">Generate Invoice</a></li>
                    <li><a href="/Records.aspx">Report</a></li>

                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>
    <!--Page-Heading-->
    <div class="well well-lg text-center">
        <div class="container">
            <h3>Welcome To,</h3>
            <p class="btn btn-primary">
                <strong>R.KAY STEELS</strong>
            </p>
        </div>
    </div>
    <!--Form Inline (Horizontal)-->
    <div class="container" ng-controller="invoiceCtrl as invoice">
        <form class="form-horizontal">
            <fieldset>

                <!-- Form Name -->
                <legend>Invoice Details</legend>

                <!-- Select Party -->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="Party">Select Party</label>
                    <div class="col-md-4">
                        <!--   <select ng-model="d" ng-change="getEmployees(d)"
                         ng-options="dept.DepartmentId as dept.DepartmentName for dept in deptData"></select><br />-->
                        <select id="Party" name="Party" ng-model="PartyId" class="form-control"
                            ng-options="party.PartyName for party in invoice.partyData track by party.PartyId">
                        </select>
                    </div>
                    {{PartyId.PartyNickName}}
                </div>
                <div class="form-group">
                    <div>
                        <label class="col-md-4 control-label" for="Party">Select Bill Type</label>
                        <div class="col-md-4">
                            <select class="form-control" ng-model="BillType">
                                <option value="0">S.S.Utensils(12% | 7323)</option>
                                <option value="1">S.S.Scrap(18% | 7204)</option>
                                <option value="2">S.S.Sheet/Patti/Circles(18% | 7219)</option>
                            </select>
                        </div>
                    </div>
                </div>

                <!-- ADD PARTY Button -->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="singlebutton">Add Party</label>
                    <div class="col-md-4">
                        <a id="AddParty" name="AddParty" class="btn btn-warning">Add Party</a>
                    </div>
                </div>

                <!-- DELETE PARTY Button -->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="singlebutton">Delete Party</label>
                    <div class="col-md-4">
                        <a id="deleteParty" name="deleteParty" class="btn btn-warning">Delete Party</a>
                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="textinput">Date</label>
                    <div class="col-md-4">
                        <input id="DateOfBill" name="DateOfBill" autocomplete="off" type="text" ng-model="DateOfInvoice" class="form-control input-md" />

                    </div>
                </div>
                <legend>Add Products</legend>
                <!-- Multiple Radios -->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="radios">Product Type</label>
                    <div class="col-md-4">
                        <div class="radio">
                            <label for="radios-0">
                                <input type="radio" name="type" ng-model="ProductType" id="radios-0" value="Weight" ng-checked="true" />
                                Weight
                            </label>
                        </div>
                        <div class="radio">
                            <label for="radios-1">
                                <input type="radio" name="type" ng-model="ProductType" id="radios-1" value="Pieces" />
                                Pieces
                            </label>
                        </div>
                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="textinput">Weight/Pieces</label>
                    <div class="col-md-4">
                        <input id="Weight" name="textinput" autocomplete="off" type="text" onkeypress="return isNumberKey(event)" ng-model="Qty" placeholder="Enter Weight/Pieces" class="form-control input-md" />

                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="Amount">Amount</label>
                    <div class="col-md-4">
                        <input id="Amount" name="Amount" type="text" onkeypress="return isNumberKey(event)" ng-model="Amount" placeholder="Enter Amount" class="form-control input-md" />

                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-4 control-label" for="singlebutton">Add Product</label>
                    <div class="col-md-4">
                        <button id="AddProduct" name="singlebutton" ng-click="invoice.SaveProduct(ProductType,Qty,Amount,BillType)" class="btn btn-warning">Add Product</button>
                    </div>
                </div>
                <div>
                    <button class="btn btn-success pull-right" ng-click="invoice.SaveInvoice(PartyId,DateOfInvoice)">Generate Invoice</button>
                </div>
            </fieldset>
        </form>
        <table class="table table-striped table-bordered table-hover table-condensed">
            <tr>
                <td>Type</td>
                <td>Quantity</td>
                <td>Amount</td>
            </tr>

            <tr class="info" ng-repeat="product in invoice.products">
                <td>{{product.Type}}</td>
                <td>{{product.Quantity}}</td>
                <td>{{product.Amount}}</td>
            </tr>

        </table>


        <div class="well well-sm">
            <footer>@Copywrite R.kay Steels</footer>
        </div>
    </div>
    <!--ADD PARTY Modal Popup-->
    <div id="myModal" class="modal fade" ng-controller="partyCtrl as party">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Add Party </h4>
                </div>
                <div class="modal-body">
                    <form class="form-horizontal">
                        <fieldset>
                            <!-- Party Name-->
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="textinput">Party Name</label>
                                <div class="col-md-4">
                                    <input id="PartyName" name="textinput" type="text" placeholder="Enter Party Name" ng-model="party.partyDetails.PartyName" class="form-control-modal input-md" />
                                </div>
                            </div>

                            <!-- Party NickName-->
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="PartyNickName">Party NickName</label>
                                <div class="col-md-4">
                                    <input id="PartyNickName" name="PartyNickName" type="text" placeholder="Enter party nickname" ng-model="party.partyDetails.PartyNickName" class="form-control-modal input-md" />
                                </div>
                            </div>

                            <!-- GST / TIN NO-->
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="PartyGSTorTIN">GST/TIN NO</label>
                                <div class="col-md-4">
                                    <input id="PartyGSTorTIN" name="PartyGSTorTIN" type="text" placeholder="Enter GST or TIN NO." ng-model="party.partyDetails.PartyTinNo" class="form-control-modal input-md" />

                                </div>
                            </div>

                            <!-- Address -->
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="PartyAddress">Address</label>
                                <div class="col-md-4">
                                    <textarea class="form-control" id="PartyAddress" name="PartyAddress" style="margin: 0px -110.672px 0px 0px; width: 271px; height: 99px;" ng-model="party.partyDetails.PartyAddress"></textarea>
                                </div>
                            </div>

                            <!-- SAVE Details -->
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="SaveParty"></label>
                                <div class="col-md-4">
                                    <button id="SaveParty" name="SaveParty" ng-click="party.savePartyDetails(party.partyDetails)" class="btn btn-info pull-right">Save </button>
                                </div>
                            </div>

                        </fieldset>
                    </form>

                    <p class="text-warning"><small>If you don't save, your changes will be lost.</small></p>
                </div>

            </div>
        </div>
    </div>

    <div id="myModalDelete" class="modal fade" ng-controller="invoiceCtrl as invoice"">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title">Add Party </h4>
                </div>
                <div class="modal-body">
                    <form class="form-horizontal">
                        <fieldset>
                            
                            <!-- Select Party Name -->
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="Party">Select Party</label>
                                <div class="col-md-4">
                                    <!--   <select ng-model="d" ng-change="getEmployees(d)"
                         ng-options="dept.DepartmentId as dept.DepartmentName for dept in deptData"></select><br />-->
                                    <select id="partyName" name="Party" ng-model="PartyId" class="form-control"
                                        ng-options="party.PartyName for party in invoice.partyData track by party.PartyId">
                                    </select>
                                </div>
                                {{PartyId.PartyNickName}}
                            </div>

                            <!-- SAVE Details -->
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="SaveParty"></label>
                                <div class="col-md-4">
                                    <button id="deletePartyData" name="SaveParty" ng-click="" class="btn btn-warning">Delete </button>
                                </div>
                            </div>

                        </fieldset>
                    </form>

                    <p class="text-warning"><small>If you don't save, your changes will be lost.</small></p>
                </div>

            </div>
        </div>
    </div>


    <!--External Resources-->
    <script src="Scripts/angular.js"></script>
    <script src="Scripts/jquery-1.12.4.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <!--Project Resources-->
    <script src="ProjectResources/app.js"></script>
    <script src="ProjectResources/Controllers/invoiceCtrl.js"></script>
    <script src="ProjectResources/Controllers/partyCtrl.js"></script>
    <script src="ProjectResources/Factory/partyFactory.js"></script>
    <link href="Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>


    <script type="text/javascript">
        $(document).ready(function () {
            $("#DateOfBill").datepicker();
            //   $("#DateOfBill").datepicker({
            //     dateFormat: 'd-m-yy'
            // });
            $('#AddParty').on('click', function () {

                $("#myModal").modal('show');
            });
            $('#deleteParty').on('click', function () {

                $("#myModalDelete").modal('show');
            });
            $('#deletePartyData').on('click', function () {
                let partyid = $('#partyName').val();
                let partyName = $('#partyName option:selected').text();
                var isDelete = confirm(`Are you sure you want to delete ${partyName} ?`);
                if (isDelete) {
                    $.ajax({
                        type: "POST",
                        url: "/Invoice.aspx/DeletePartyDetails",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: JSON.stringify({ 'partyId': partyid }),
                        success: function (data) {
                            alert(data.d);
                            location.reload()
                        }
                    });
                }


                
            });
           

        });
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
</body>
</html>
