<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Records.aspx.cs" Inherits="Billing_System.Records" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/main.css" rel="stylesheet" />
    <title></title>

</head>
<body ng-app="invoiceApp">
    <form>
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
        <div class="container" ng-controller="recordCtrl as record">
            <div class="col-md-12">
                <div class="row">
                    <div class="form-group">
                        <div class="col-md-4">
                            <label>Start Date:</label>

                            <input id="startDate" autocomplete="off" name="startDate" type="text" class="form-control" />
                        </div>
                        <div class="col-md-4">
                            <label>End Date:</label>

                            <input id="endDate" autocomplete="off" name="EndDate" type="text" class="form-control" />

                        </div>
                        <div class="col-md-4">
                            <label></label>

                            <button id="btnGetSearchRecords" class="btn btn-success form-control" ng-click="record.getRecordsData()">Search</button>
                        </div>
                    </div>
                </div>
            
                <br />
                <div class="row" style="display:none;" id="dvData">
                    <table class="table table-striped table-bordered table-hover table-condensed">
                        <tr>
                            <td>S.NO</td>
                            <td>Invoice No</td>
                            <td>Date</td>
                            <td>Product Name</td>
                            <td>Party Name</td>
                            <td>Party NickName</td>
                            <td>Amount</td>
                            <td>CGST</td>
                            <td>SGST</td>
                            <td>Total Amount</td>
                            

                        </tr>
                        <tr class="info" ng-repeat="record in record.recordData">
                            <td>{{$index +1 }}</td>
                            <td>{{record.InvoiceNo}}</td>
                            <td>{{record.Date}}</td>
                            <td>{{record.ProductName}}</td>
                            <td>{{record.PartyName }}</td>
                            <td>{{record.PartyNickName}}</td>
                            <td>{{record.Amount}}</td>
                            <td>{{record.CGST}}</td>
                            <td>{{record.SGST}}</td>
                            <td>{{record.TotalAmount}}</td>
                            <td><input type="button" class="btn btn-danger" value="Delete"  ng-click="deleteInvoice(record.InvoiceNo);" /></td>
                        </tr>
                    </table>
                </div>
                    <div class="row">
                    <div class="col-md-4 col-md-offset-8">
                        <input type="button" id="btnExport" style="display:none;" class="btn btn-success form-control" value="Download Report" />
                    </div>
                </div>
            </div>
        </div>
    </form>


    <!--External Resources-->
    <script src="Scripts/angular.js"></script>
    <script src="Scripts/jquery-1.12.4.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <!--Project Resources-->
    <script src="ProjectResources/app.js"></script>
    <script src="ProjectResources/Controllers/recordsCtrl.js"></script>
    <link href="Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <%--  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

   <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>--%>
    <script src="Scripts/jquery-ui-1.12.1.js"></script>
    <script>
        $(document).ready(function () {
            $("#startDate").datepicker({ dateFormat: 'dd-mm-yy' });
            $("#endDate").datepicker({ dateFormat: 'dd-mm-yy' });
            //Export To Excel
            $("#btnExport").click(function (e) {
            
                //window.open('data:application/vnd.ms-excel,'
                //    + $('#dvData').html());
                exportToExcel($('#dvData').html());
                e.preventDefault();
            });


        });

        function exportToExcel(html) {
            var htmls = "";
            var uri = 'data:application/vnd.ms-excel;base64,';
            var template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>';
            var base64 = function (s) {
                return window.btoa(unescape(encodeURIComponent(s)))
            };

            var format = function (s, c) {
                return s.replace(/{(\w+)}/g, function (m, p) {
                    return c[p];
                })
            };

            htmls = html;

            var ctx = {
                worksheet: 'Worksheet',
                table: htmls
            }


            var link = document.createElement("a");
            link.download = "export.xls";
            link.href = uri + base64(format(template, ctx));
            link.click();
        }

        
    </script>
</body>
</html>
