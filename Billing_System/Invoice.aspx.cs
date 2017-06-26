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

        }

        [WebMethod]
        public static string SavePartyDetails(string PartyName,string PartyNickName ,string PartyTinNo,string PartyAddress)
        {



            return "";
        }
    }
}