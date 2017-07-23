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
                    <li><a href="#">Link</a></li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Dropdown <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="#">Action</a></li>
                            <li><a href="#">Another action</a></li>
                            <li><a href="#">Something else here</a></li>
                            <li role="separator" class="divider"></li>
                            <li><a href="#">Separated link</a></li>
                        </ul>
                    </li>
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

                <!-- Select Basic -->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="Party">Select Party</label>
                    <div class="col-md-4">
                        <select id="Party" name="Party" ng-model="PartyId"  class="form-control" 
                            ng-options="party.PartyName for party in invoice.partyData track by party.PartyId">
                        </select>
                    </div>
                      {{PartyId.PartyNickName}}
                </div>
               
                <!-- Button -->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="singlebutton">Add Party</label>
                    <div class="col-md-4">
                        <a id="AddParty" name="AddParty" class="btn btn-warning">Add Party</a>
                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="textinput">Date</label>
                    <div class="col-md-4">
                        <input id="DateOfBill" name="DateOfBill" type="text"  ng-model="DateOfInvoice" class="form-control input-md" />
                      
                </div>

                <legend>Add Products</legend>
                <!-- Multiple Radios -->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="radios">Product Type</label>
                    <div class="col-md-4">
                        <div class="radio">
                            <label for="radios-0">
                                <input type="radio" name="type" ng-model="ProductType" id="radios-0" value="Weight" checked="checked" />
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
                        <input id="Weight" name="textinput" type="text" onkeypress="return isNumberKey(event)"  ng-model="Qty" placeholder="Enter Weight/Pieces" class="form-control input-md" />

                    </div>
                </div>

                <!-- Text input-->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="Amount">Amount</label>
                    <div class="col-md-4">
                        <input id="Amount" name="Amount" type="text" onkeypress="return isNumberKey(event)"  ng-model="Amount" placeholder="Enter Amount" class="form-control input-md" />

                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-4 control-label" for="singlebutton">Add Product</label>
                    <div class="col-md-4">
                        <button id="AddProduct" name="singlebutton" ng-click="invoice.SaveProduct(ProductType,Qty,Amount)" class="btn btn-warning">Add Product</button>
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
    <!--Modal Popup-->
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



    <!--External Resources-->
    <script src="Scripts/angular.js"></script>
    <script src="Scripts/jquery-1.9.0.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <!--Project Resources-->
    <script src="ProjectResources/app.js"></script>
    <script src="ProjectResources/Controllers/invoiceCtrl.js"></script>
    <script src="ProjectResources/Controllers/partyCtrl.js"></script>
    <script src="ProjectResources/Factory/partyFactory.js"></script>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#DateOfBill").datepicker();
            $('#AddParty').on('click', function () {

                $("#myModal").modal('show');
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
