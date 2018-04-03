using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Billing_System.Models;
using Newtonsoft.Json;
using System.Data;
using System.Web.Services;


namespace Billing_System
{
    public partial class Records : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetMonthlySalesData(string StartDate ,string EndDate)
        {
            DAL objDAL = new DAL();
            DataSet ds = new DataSet();
            DateTime startDate = Convert.ToDateTime(StartDate);
            DateTime endDate = Convert.ToDateTime(EndDate);
            ds= objDAL.GetMonthlySalesData(startDate, endDate);
            string jsonString = DataTableToJson(ds.Tables[0]);
            return jsonString;
           
        }

        public static string DataTableToJson(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }

        //public static string GetDateRange(string Month)
        //{
        // DateRange objDateRange =new DateRange();
        //    switch (Month)
        //    {
        //        case "Jan":
        //            objDateRange.StartDate="1"
        //            break;
        //        case "Feb":
        //            break;
        //        case "Mar":
        //            break;
        //        case "April":
        //            break;
        //        case "May":
        //            break;
        //        case "June":
        //            break;
        //        case "July":
        //            break;
        //        case "Aug":
        //            break;
        //        case "Sept":
        //            break;
        //        case "Oct":
        //            break;
        //        case "Nov":
        //            break;
        //        case "Dec":
        //            break;

        //    }




        //}

        //public class DateRange
        //{
        //    public string StartDate { get; set; }
        //    public string EndDate { get; set; }
        //}
    }
}