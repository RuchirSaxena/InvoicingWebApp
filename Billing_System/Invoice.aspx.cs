using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Billing_System.Models;
using Newtonsoft.Json;
using System.Data;

namespace Billing_System
{
    public partial class Invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            short s = 400;
            int[,] intarry = { { 7, 9, 0 }, { 8, 7, 9 } };

        }

        [WebMethod]
        public static string SavePartyDetails(Party party)
        {
            DAL objDal = new DAL();
           string jsonResponse= objDal.SavePartyDetails(party).ToString();


            return jsonResponse;
        }
        [WebMethod]
        public static string SaveInvoiceData(InvoiceData invoiceData)
        {
            string responseData = "0";
            FinalInvoiceData objInvoiceData = new FinalInvoiceData();
            DAL objDal = new DAL();
            string InvoiceNo = objDal.LastestInoiceNoGeneration();
            HttpContext.Current.Session["InvoiceNo"] = InvoiceNo;
            for (int i = 0; i < invoiceData.Products.Count; i++)
            {
                objInvoiceData.PartyId =Convert.ToInt32( invoiceData.PartyId);
                objInvoiceData.DateOfSell= Convert.ToDateTime(invoiceData.InvoiceDate);
                objInvoiceData.InvoiceNo = InvoiceNo;
                objInvoiceData.ProductName = "S.S.UTENSILS";
                objInvoiceData.PackagingCost = 0.0;
                objInvoiceData.Qty = Convert.ToDouble(invoiceData.Products[i].Quantity);
                objInvoiceData.Rate = Convert.ToDouble(invoiceData.Products[i].Amount);
                objInvoiceData.Amount = objInvoiceData.Qty * objInvoiceData.Rate;
                objInvoiceData.IsPiece = invoiceData.Products[i].Type == "Weight" ? false : true;
                responseData = objDal.SaveInvoicwDetails(objInvoiceData).ToString();
            }

            return responseData;
        }

        [WebMethod]
        public static string GetPartyDetail()
        {
            DAL objDal = new DAL();
            DataTable dt = new DataTable();
            dt = objDal.getAllPartyDetail(0);
            string jsonString = DataTableToJson(dt);
            return jsonString;
        }

        public static string DataTableToJson(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }



        public class InvoiceData
        {
            public string PartyId { get; set; }
            public string InvoiceDate { get; set; }

            public List<Products> Products { get; set; }

        }
        public class Products
        {
            public string Type { get; set; }
            public string Quantity { get; set; }
            public string Amount { get; set; }
        }
    }
}