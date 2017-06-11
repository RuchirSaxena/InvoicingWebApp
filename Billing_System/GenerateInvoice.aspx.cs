using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using Billing_System.Models;
using System.Collections.Generic;

namespace Billing_System
{
    public partial class GenerateInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetInvoiceDetails("007");
        }

        //public void test()
        //{
        //    try
        //    {
        //        StringBuilder sbTemp = new StringBuilder();
        //        string strTemplatePath = Server.MapPath(@"~\Form\HtmlForPdf\safari.htm");
        //        StringBuilder mainhtml = new StringBuilder();
        //        string htmlTemp = File.ReadAllText(strTemplatePath);
        //        mainhtml.Append(htmlTemp);
        //        //Section0
        //        DataSet ds = new DataSet();
        //        ds = (DataSet)HttpContext.Current.Items["dsUser"];
        //        if (ds != null && ds.Tables.Count > 0)
        //        {
        //            //Logo
        //            mainhtml = mainhtml.Replace("@Sec0_RfbIco", "<img src='" + Server.MapPath(@"~\Form\HtmlForPdf\RFBLogo.PNG") + "' width='190' height='100' />");
        //            if (WorkItemId != null)
        //            {
        //                if (!String.IsNullOrEmpty(WorkItemId.Text))
        //                {
        //                    mainhtml = mainhtml.Replace("@WorkItemId", clsGeneralUtil.GetPdfText(WorkItemId.Text));
        //                }
        //            }
        //            //Section 0
        //            Sec0Pdf(mainhtml);

        //            List<DataRow> drSec2 = null;
        //            sbTemp.Clear();
        //            if (ds.Tables.Count > 1)
        //            {
        //                drSec2 = ds.Tables[1].Select("").ToList<DataRow>();
        //                if (ds.Tables[1].Rows.Count > 0)
        //                {
        //                    //sbTemp.Append("<table width='100%'>");
        //                    //  DataRow drSec2 = ds.Tables[1].Rows[0];
        //                    for (int counter = 0; counter < ds.Tables[1].Rows.Count; counter++)
        //                    {
        //                        sbTemp.Append("<tr><td class='notop tblheader' valign='middle' align='center' >" + (counter + 1).ToString() + "</td>");
        //                        sbTemp.Append("<td class='noleftandtop' valign='middle' align='center' >" + clsGeneralUtil.GetPdfText(Convert.ToString(drSec2[counter]["DepartureDate"])) + "</td>");
        //                        sbTemp.Append("<td class='noleftandtop' valign='middle' align='center' >" + clsGeneralUtil.GetPdfText(Convert.ToString(drSec2[counter]["DeparturePlace"])) + "</td>");
        //                        sbTemp.Append("<td class='noleftandtop' valign='middle' align='center' >" + clsGeneralUtil.GetPdfText(Convert.ToString(drSec2[counter]["ArrivalDate"])) + "</td>");
        //                        sbTemp.Append("<td class='noleftandtop' valign='middle' align='center' >" + clsGeneralUtil.GetPdfText(Convert.ToString(drSec2[counter]["ArrivalPlace"])) + "</td>");
        //                        sbTemp.Append("<td class='noleftandtop' valign='middle' align='center' >" + clsGeneralUtil.GetPdfText(Convert.ToString(drSec2[counter]["NoOfNights"])) + "</td>");
        //                        sbTemp.Append("<td class='noleftandtop' valign='middle' align='center' >" + clsGeneralUtil.GetPdfText(Convert.ToString(drSec2[counter]["RateOfAllowance"])) + "</td>");
        //                        //sbTemp.Append("<td valign='top' class='noleftandtop'>" + Convert.ToString(drSec2[counter]["GrandTotal"]) + "</td>");
        //                        sbTemp.Append("<td class='noleftandtop' valign='middle' align='center' >" + clsGeneralUtil.GetPdfText(Convert.ToString(drSec2[counter]["RowTotal"])) + "</td></tr>");
        //                    }
        //                    //sbTemp.Append("</table>");
        //                }
        //            }
        //            //Dynamic Table Sec0 Replace
        //            mainhtml = mainhtml.Replace("@tblAddNewRow", sbTemp.ToString());

        //            //These parameter is only used For Print Button at Accountant Step
        //            mainhtml = mainhtml.Replace("@PartB", "");
        //            mainhtml = mainhtml.Replace("@PartC", "");
        //            mainhtml = mainhtml.Replace("@PartD", "");

        //            List<DataRow> drSecOthers = null;
        //            sbTemp.Clear();
        //            if (ds.Tables.Count > 2)
        //            {
        //                drSecOthers = ds.Tables[2].Select("").ToList<DataRow>();
        //                if (ds.Tables[2].Rows.Count > 0)
        //                {
        //                    //sbTemp.Append("<table width='100%'>");
        //                    //  DataRow drSec2 = ds.Tables[1].Rows[0];
        //                    for (int counter = 0; counter < ds.Tables[2].Rows.Count; counter++)
        //                    {
        //                        sbTemp.Append("<tr><td class='notop tblheader' valign='middle' align='center' width='50px'>" + (counter + 1).ToString() + "</td>");
        //                        sbTemp.Append("<td class='noleftandtop tblheader1'  valign='middle' align='center' width='200px'>" + clsGeneralUtil.GetPdfText(Convert.ToString(drSecOthers[counter]["Other_Description"])) + "</td>");
        //                        sbTemp.Append("<td class='noleftandtop tblheader1' valign='middle' align='center'>" + clsGeneralUtil.GetPdfText(Convert.ToString(drSecOthers[counter]["Other_Charges"])) + "</td></tr>");
        //                    }
        //                    //sbTemp.Append("</table>");
        //                }
        //            }
        //            //Dynamic Other Incidents Table Sec0 Replace
        //            mainhtml = mainhtml.Replace("@tblOtherIncidents", sbTemp.ToString());
        //            //Section 1
        //            Sec1Pdf(mainhtml);

        //            //Section 2
        //            Sec2Pdf(mainhtml);

        //            //Sec3 Replace
        //            mainhtml = mainhtml.Replace("@InvoiceNo", clsGeneralUtil.GetPdfText(uc_safari_sec3.lblInvoiceNo.Text));
        //            mainhtml = mainhtml.Replace("@PVNo", clsGeneralUtil.GetPdfText(uc_safari_sec3.lblPVNo.Text));
        //            mainhtml = mainhtml.Replace("@ChequeNo", clsGeneralUtil.GetPdfText(uc_safari_sec3.lblChequeNo.Text));
        //            mainhtml = mainhtml.Replace("@ChequeDated", clsGeneralUtil.GetPdfText(uc_safari_sec3.lblChequeDated.Text));
        //            mainhtml = mainhtml.Replace("@AmountPaid", clsGeneralUtil.GetPdfText(uc_safari_sec3.lblAmountPaid.Text));
        //            Sec3Pdf(mainhtml);
        //        }
        //        string fileName = "Safari_" + ds.Tables[0].Rows[0]["Safari_REF"].ToString() + ".pdf";
        //        FineDocsECM.HtmlToPfdUtil.DownloadAsPdf(mainhtml.ToString(), fileName);
        //    }
        //    catch (Exception ex)
        //    {
        //        clsErrorLog.WriteLog(ex.Message, "Safari lnkDownLoad_click");
        //    }
        //}


        private static void DownloadAsPdf(MemoryStream msPdf, string fileName)
        {
            fileName = Path.GetFileNameWithoutExtension(fileName) + ".PDF";
            msPdf.Position = 0;
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentEncoding = System.Text.UTF8Encoding.UTF8;
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName.Replace(" ", "_"), System.Text.Encoding.UTF8));
            HttpContext.Current.Response.AddHeader("Content-Length", msPdf.Length.ToString());
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.BinaryWrite(msPdf.ToArray());
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        private static void WriteFile(MemoryStream ms, string path)
        {
            ms.Position = 0;
            FileStream file = new FileStream(path, FileMode.Create, System.IO.FileAccess.Write);
            byte[] bytes = new byte[ms.Length];
            ms.Read(bytes, 0, (int)ms.Length);
            file.Write(bytes, 0, bytes.Length);
            file.Close();
            ms.Close();
        }
        private static MemoryStream ConvertHtmlToPdf(string htmlString)
        {
            StringReader sr = new StringReader(htmlString);
            MemoryStream msOutput = new MemoryStream();
            Document document = new Document(PageSize.A4, 30, 30, 50, 50);
            PdfWriter writer = PdfWriter.GetInstance(document, msOutput);
            pdfPage objPage = new pdfPage();
            writer.PageEvent = objPage;
            document.Open();
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);
            writer.CloseStream = false;
            document.Close();
            msOutput.Position = 0;
            return msOutput;
        }
        protected void GenerateInvoicePDF(object sender, EventArgs e)
        {
 
        }

        private void GenerateInvoicePDF(Party objPartyDetail, InvoiceDetail objInvDetail,AmountTaxCalculation objAmounts)
        {
            string strTemplatePath = Server.MapPath(@"~\Invoice.html");
            StringBuilder mainhtml = new StringBuilder();
            string htmlTemp = File.ReadAllText(strTemplatePath);

            mainhtml.Append(htmlTemp);
            mainhtml = mainhtml.Replace("@PARTY NAME",objPartyDetail.PartyName );
            mainhtml = mainhtml.Replace("@Address",objPartyDetail.PartyAddress );
            mainhtml = mainhtml.Replace("@InvoiceNO",objInvDetail.IvoiceNo);
            mainhtml = mainhtml.Replace("@Date",objInvDetail.DateOfSell);
            mainhtml = mainhtml.Replace("@Tinno",objPartyDetail.PartyTinNo);
            mainhtml = mainhtml.Replace("@Logo", "<img src='" + Server.MapPath(@"~/Logo.PNG") + "' width='150' height='100' />");
            StringBuilder sbProducts = new StringBuilder();
            for(int i = 0; i < objInvDetail.Product.Count; i++)
            {
                sbProducts.Append("<tr class='borderBottomRemove'>");
                sbProducts.Append("<td class='borderleft PartyInfo' style='height:40px;' align='center'>"+(i+1)+".</td>");
                sbProducts.Append("<td class='borderleft PartyInfo' style='height:40px;' align='center'>"+ objInvDetail.Product[i].ProductName +"</td>");
                sbProducts.Append("<td class='borderleft PartyInfo' style='height:40px;' align='center'>" + objInvDetail.Product[i].Qty + "</td>");
                string  Type= objInvDetail.Product[i].ProductType == "per kg" ? "Piece" : "Kgs";
                sbProducts.Append("<td class='borderleft PartyInfo' style='height:40px;' align='center'>" + Type + "</td>");
                sbProducts.Append("<td class='borderleft PartyInfo' style='height:40px;' align='center'>"+(objInvDetail.Product[i].Rate.ToString() + objInvDetail.Product[i].ProductType.ToString())+"</td>");
                sbProducts.Append("<td class='borderleft PartyInfo borderright' style='height:40px;' align='center'>" + objInvDetail.Product[i].AmountDisplay+"</td>");
                sbProducts.Append("</tr>");                                                                                                                 

            }
            mainhtml = mainhtml.Replace("@TableData", sbProducts.ToString());
            mainhtml = mainhtml.Replace("@PackingCost", "0.00");
            mainhtml = mainhtml.Replace("@Total", objAmounts.Total);
            mainhtml = mainhtml.Replace("@Vat", objAmounts.Vat);
            mainhtml = mainhtml.Replace("@GradTotal", objAmounts.GrandTotal);
            mainhtml = mainhtml.Replace("@TInWords", objAmounts.GTotalInWords);
            string downloadedFileName = objInvDetail.IvoiceNo + "_" + objPartyDetail.PartyName;
            MemoryStream ms = ConvertHtmlToPdf(mainhtml.ToString());
            DownloadAsPdf(ms, downloadedFileName);
        }
        
        private void GetInvoiceDetails(string InvoiceNo)
        {
            
            DAL objDal = new DAL();
            InvoiceDetail objInvoiceDetail = new InvoiceDetail();
            AmountTaxCalculation objAmountTaxCalculation = new AmountTaxCalculation();
            Party objParty = new Party();
            List<Product> liProduct = new List<Product>();
            DataTable dtInvoiceData = new DataTable();
            dtInvoiceData = objDal.getInvoiceByInvoiceNo(InvoiceNo);
            if (dtInvoiceData.Rows.Count > 0)
            {
                objInvoiceDetail.PartyId = Convert.ToInt32(dtInvoiceData.Rows[0]["PartyId"]);
                objInvoiceDetail.DateOfSell = Convert.ToDateTime( dtInvoiceData.Rows[0]["DateOfSell"]).ToString("dd/MM/yyyy");
                objInvoiceDetail.IvoiceNo = dtInvoiceData.Rows[0]["IvoiceNo"].ToString();
                
                for (int i = 0; i < dtInvoiceData.Rows.Count; i++)
                {
                   
                    liProduct.Add(new Product()
                    {
                        ProductName = dtInvoiceData.Rows[i]["ProductName"].ToString(),
                        Qty = Convert.ToDouble(dtInvoiceData.Rows[i]["Qty"]),
                        PackagingCost=Convert.ToDouble(dtInvoiceData.Rows[i]["PackagingCost"]),
                        //Price= Convert.ToDouble(dtInvoiceData.Rows[i]["PackagingCost"]),
                        Rate =Convert.ToDouble(dtInvoiceData.Rows[i]["Rate"]),
                        Amount= Convert.ToDouble(dtInvoiceData.Rows[i]["Amount"]),
                        AmountDisplay= Math.Round(Convert.ToDouble(dtInvoiceData.Rows[i]["Amount"]),0,MidpointRounding.AwayFromZero).ToString("n2"),
                        IsPice = Convert.ToBoolean(dtInvoiceData.Rows[i]["IsPiece"]),
                        ProductType= Convert.ToBoolean(dtInvoiceData.Rows[i]["IsPiece"])==true? "/per piece" : "/per kg"

                    });

                }
                objInvoiceDetail.Product = liProduct;
            }
            objAmountTaxCalculation.Total = CalcuateTotal(objInvoiceDetail).ToString("n2");
            objAmountTaxCalculation.Vat = CalculateVat(Convert.ToDouble(objAmountTaxCalculation.Total)).ToString("n2");
            objAmountTaxCalculation.GrandTotal = (Convert.ToDouble(objAmountTaxCalculation.Total) + Convert.ToDouble(objAmountTaxCalculation.Vat)).ToString("n2");
            objAmountTaxCalculation.GTotalInWords = NumbersToWords(Convert.ToInt32(Convert.ToDouble(objAmountTaxCalculation.GrandTotal)));
            DataRow dr = objDal.getPartyDetail(objInvoiceDetail.PartyId);
            objParty.PartyName = dr["PartyName"].ToString();
            objParty.PartyTinNo = dr["PartyTinNo"].ToString();
            objParty.PartyAddress = dr["PartyAddress"].ToString();

            GenerateInvoicePDF(objParty, objInvoiceDetail,objAmountTaxCalculation);
        }

        public double CalculateVat(double TotalAmount)
        {
            double Vat = 0.0;
            Vat = (TotalAmount * 5) / 100;
            return Math.Round(Vat, 0, MidpointRounding.AwayFromZero);
        }
        public double CalcuateTotal(InvoiceDetail objInvoice)
        {
            double Total = 0.0;
            List<Product> objProductList = objInvoice.Product;
            for(int i = 0; i < objProductList.Count; i++)
            {
                Total += (objProductList[i].Amount + objProductList[i].PackagingCost);
            }
            return Math.Round(Total, 0, MidpointRounding.AwayFromZero); 

        }
        public static string NumbersToWords(int inputNumber)
        {
            int inputNo = inputNumber;

            if (inputNo == 0)
                return "Zero";

            int[] numbers = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (inputNo < 0)
            {
                sb.Append("Minus ");
                inputNo = -inputNo;
            }

            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ",
            "Five " ,"Six ", "Seven ", "Eight ", "Nine "};
            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ",
            "Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ",
            "Seventy ","Eighty ", "Ninety "};
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };

            numbers[0] = inputNo % 1000; // units
            numbers[1] = inputNo / 1000;
            numbers[2] = inputNo / 100000;
            numbers[1] = numbers[1] - 100 * numbers[2]; // thousands
            numbers[3] = inputNo / 10000000; // crores
            numbers[2] = numbers[2] - 100 * numbers[3]; // lakhs

            for (int i = 3; i > 0; i--)
            {
                if (numbers[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (numbers[i] == 0) continue;
                u = numbers[i] % 10; // ones
                t = numbers[i] / 10;
                h = numbers[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i == 0) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.Append(" Only.").ToString().TrimEnd();
        }




    }
}
