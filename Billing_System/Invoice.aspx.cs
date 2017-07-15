using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Billing_System.Models;

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
            


            return "";
        }
        [WebMethod]
        public static string SaveInvoiceData(InvoiceData invoiceData)
        {



            return "";
        }

       public class InvoiceData
        {
            public string PartyId { get; set; }
            public string InvoiceDate { get; set; }

            public List<Products> Products { get; set; }

        }
       public  class Products
        {
            public string Type { get; set; }
            public string Quantity { get; set; }
            public string Amount { get; set; }
        }
    }
}