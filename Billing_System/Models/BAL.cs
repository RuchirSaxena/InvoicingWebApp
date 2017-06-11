using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Billing_System.Models
{
    public class InvoiceDetail
    {
        public int PartyId { get; set; }
        public string DateOfSell { get; set; }
        public string IvoiceNo { get; set; }
        public List<Product> Product { get; set; }

    }

    public class Product
    {
        public string ProductName { get; set; }
        public double PackagingCost { get; set; }
        public double Price { get; set; }
        public double Qty { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string AmountDisplay { get; set; }
        public bool IsPice { get; set; }
        public string ProductType { get; set; }



    }

    public class Party
    {
        public string PartyName { get; set; }
        public string PartyAddress { get; set; }
        public string PartyTinNo { get; set; }
    }

    public class AmountTaxCalculation
    {
        public string Vat { get; set; }
        public string Total { get; set; }
        public string GrandTotal { get; set; }
        public string GTotalInWords { get; set; }

        public string PackagingCost
        {
            get { return PackagingCost.ToString(); }
            set
            {
                value = "0.00";
            }
        }


    }



   
}