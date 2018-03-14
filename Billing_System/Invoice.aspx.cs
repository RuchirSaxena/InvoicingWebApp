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

        }

        [WebMethod]
        public static string SavePartyDetails(Party party)
        {
            DAL objDal = new DAL();
            string jsonResponse = objDal.SavePartyDetails(party).ToString();
            return jsonResponse;
        }
        [WebMethod]
        public static string SaveInvoiceData(InvoiceData invoiceData)
        {
          
            int _billType = Convert.ToInt32(invoiceData.Products[0].BillType);
            if (_billType == 0)
            {
                BillType.Type = 1;
                BillType.Name = "S.S.UTENSILS";
                BillType.HSNCode = "7323.99.20";
                BillType.TaxRate = 6.00;

            }else if (_billType == 1)
            {
                BillType.Type = 2;
                BillType.Name = "S.S.SCRAP";
                BillType.HSNCode = "7204";
                BillType.TaxRate = 9.00;
            }
            else
            {
                BillType.Type = 3;
                BillType.Name = "S.S.PATTA";
                BillType.HSNCode = "7220";
                BillType.TaxRate = 9.00;
            }

            string responseData = "0";
            FinalInvoiceData objInvoiceData = new FinalInvoiceData();
            DAL objDal = new DAL();
            string InvoiceNo = objDal.LastestInoiceNoGeneration();
            HttpContext.Current.Session["InvoiceNo"] = InvoiceNo;
            for (int i = 0; i < invoiceData.Products.Count; i++)
            {
                HttpContext.Current.Session["BillType"] = invoiceData.Products[i].BillType;
                objInvoiceData.PartyId = Convert.ToInt32(invoiceData.PartyId);
                objInvoiceData.DateOfSell = Convert.ToDateTime(invoiceData.InvoiceDate);
                objInvoiceData.InvoiceNo = InvoiceNo;
                //Adding the different Type of Product Name (ie.S.s Utensils , S.S.Patta,S.S.Scrap)
                objInvoiceData.ProductName = BillType.Name;
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
            public string BillType { get; set; }
        }
    }
}