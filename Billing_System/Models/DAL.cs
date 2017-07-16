using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Billing_System.Models
{
    public class DAL
    {
      

        public string PicturePath { get; set; }
        public byte[] VisitorImage { get; set; }
        public int? LoginId { get; set; }


        string connString = ConfigurationManager.ConnectionStrings["InvoicingConnstring"].ConnectionString.ToString();
        SqlConnection con = null;

        void Connect()
        {
            con.Open();
        }
        void Disconnect()
        {
            con.Close();
        }
        public DataSet getEmployees()
        {
            con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("Proc_GetEmployee", con);
                //cmd.Parameters.Add(new SqlParameter("@EMPLOYEENO", employeeNo));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception x)
            {

            }
            finally
            {
                cmd.Dispose();
                //Disconnect();

            }
            return ds;
        }

        public DataSet getEmployeeById(int EmpId)
        {
            con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("Proc_GetEmployeeDetailsByEmpID", con);
                cmd.Parameters.Add(new SqlParameter("@EmpId", EmpId));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception x)
            {

            }
            finally
            {
                cmd.Dispose();
                //Disconnect();

            }
            return ds;
        }

        public DataSet getEmployeeByMobileNo(int EmpMobileNo)
        {
            con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("Proc_GetEmployeeDetailsByMobileNumber", con);
                cmd.Parameters.Add(new SqlParameter("@EmpMobileNo", EmpMobileNo));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception x)
            {

            }
            finally
            {
                cmd.Dispose();
                //Disconnect();

            }
            return ds;
        }

      

        public DataSet getActiveVistingVisitor()
        {
            con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("Proc_ActiveVistingVisitor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception x)
            {

            }
            finally
            {
                cmd.Dispose();
                Disconnect();

            }
            return ds;
        }

        public DataSet getAllVisitorsfromDB(DateTime? StartDate = null, DateTime? EndDate = null)
        {
            con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                if (StartDate == null && EndDate == null)
                {
                    cmd = new SqlCommand("select EntryId,VisitorName,Address,IssuedCardNo,MobileNo,PurposeOfVisit,WhomeToMeetName,WhomToMeetId,DateTimeIn,DateTimeOut,LoginId from GateEntryData", con);
                }
                else
                {
                    cmd = new SqlCommand("select EntryId,VisitorName,Address,IssuedCardNo,MobileNo,PurposeOfVisit,WhomeToMeetName,WhomToMeetId,DateTimeIn,DateTimeOut,LoginId  from GateEntryData where DateTimeIn >=@startDate and DateTimeOut <=@endDate", con);
                    cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = StartDate;
                    cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = EndDate;
                }

                // cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception x)
            {

            }
            finally
            {
                cmd.Dispose();
                Disconnect();

            }
            return ds;
        }

        public DataSet getSecificVisitorByEntryId(int EntryId)
        {
            con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("select * from GateEntryData where EntryId=" + EntryId + "", con);
                // cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception x)
            {

            }
            finally
            {
                cmd.Dispose();
                Disconnect();

            }
            return ds;
        }

        public DataSet getSecificVisitorByMobileNo(string MobileNo)
        {
            con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("select * from GateEntryData where MobileNo=" + MobileNo + "", con);
                // cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception x)
            {

            }
            finally
            {
                cmd.Dispose();
                Disconnect();

            }
            return ds;
        }

        public DataSet saveOutTime(int EntryId)
        {
            con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("Proc_SaveOutTime", con);
                cmd.Parameters.AddWithValue("@EntryId", EntryId);
                cmd.Parameters.AddWithValue("@DateTimeOut", DateTime.Now);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception x)
            {

            }
            finally
            {
                cmd.Dispose();
                Disconnect();

            }
            return ds;
        }

        public DataTable getInvoiceByInvoiceNo(string InvoiceNo)
        {
            con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("GetInvoiceDetails", con);
                cmd.Parameters.Add(new SqlParameter("@InvoiceNo", InvoiceNo));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception x)
            {
                throw new Exception("Error Occured");
            }
            finally
            {
                cmd.Dispose();
                //Disconnect();

            }
            return ds.Tables[0]; 
        }

        //GetPartyDetailsDetails
        public DataRow getPartyDetail(int PartyId)
        {
            con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("GetPartyDetail", con);
                cmd.Parameters.Add(new SqlParameter("@PartyId", PartyId));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception x)
            {
                throw new Exception("Error Occured");
            }
            finally
            {
                cmd.Dispose();
                //Disconnect();

            }

            return ds.Tables[0].Rows[0];
        }

        public DataTable getAllPartyDetail(int PartyId)
        {
            con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("GetPartyDetail", con);
                cmd.Parameters.Add(new SqlParameter("@PartyId", PartyId));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception x)
            {
                throw new Exception("Error Occured");
            }
            finally
            {
                cmd.Dispose();
                //Disconnect();

            }

            return ds.Tables[0];
        }

       

        public string LastestInoiceNoGeneration()
        {
            string LatestInoiceNo = string.Empty;
            string LastInvoiceNo =getLastInvoice();
            int TempInvoice = Convert.ToInt32(LastInvoiceNo)+1;
            if(TempInvoice >= 0 && TempInvoice < 10)
            {
                LatestInoiceNo = "00" + TempInvoice.ToString();
            }
            else if(TempInvoice >= 10 && TempInvoice <= 99)
            {
                LatestInoiceNo = "0" + TempInvoice.ToString();
            }
            else
            {
                LatestInoiceNo = TempInvoice.ToString();
            }

            return LatestInoiceNo;
        }
        public string getLastInvoice()
        {
            con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                cmd = new SqlCommand("procGetLastInvoice", con);
              
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception x)
            {
                throw new Exception("Error Occured");
            }
            finally
            {
                cmd.Dispose();
                //Disconnect();

            }

            return ds.Tables[0].Rows[0]["IvoiceNo"].ToString();
        }

        public int SavePartyDetails(Party obj)
        {
            int response = 0;
            con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
           
            try
            {
                cmd = new SqlCommand("SavePartyDetails", con);
                cmd.Parameters.Add(new SqlParameter("@PartyNickName", obj.PartyNickName));
                cmd.Parameters.Add(new SqlParameter("@PartyName", obj.PartyName));
                cmd.Parameters.Add(new SqlParameter("@PartyTinNO", obj.PartyTinNo));
                cmd.Parameters.Add(new SqlParameter("@PartyAddress", obj.PartyAddress));
                cmd.CommandType = CommandType.StoredProcedure;
                Connect();
                response= cmd.ExecuteNonQuery();
                Disconnect();
               

            }
            catch (Exception x)
            {
                throw new Exception("Error Occured");
            }
            finally
            {
                cmd.Dispose();
                Disconnect();

            }

            return response;
        }

        public int SaveInvoicwDetails(FinalInvoiceData obj)
        {
            int response = 0;
            con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd = new SqlCommand("SaveInvoiceDetails", con);
                cmd.Parameters.Add(new SqlParameter("@PartyId", obj.PartyId));
                cmd.Parameters.Add(new SqlParameter("@DateOfSell", obj.DateOfSell));
                cmd.Parameters.Add(new SqlParameter("@InvoiceNo", obj.InvoiceNo));
                cmd.Parameters.Add(new SqlParameter("@ProductName", obj.ProductName));
                cmd.Parameters.Add(new SqlParameter("@PackagingCost", obj.PackagingCost));
                cmd.Parameters.Add(new SqlParameter("@Qty", obj.Qty));
                cmd.Parameters.Add(new SqlParameter("@Rate", obj.Rate));
                cmd.Parameters.Add(new SqlParameter("@Amount", obj.Amount));
                cmd.Parameters.Add(new SqlParameter("@IsPiece", obj.IsPiece));
                cmd.CommandType = CommandType.StoredProcedure;
                Connect();
                response = cmd.ExecuteNonQuery();
                Disconnect();


            }
            catch (Exception x)
            {
                throw new Exception("Error Occured");
            }
            finally
            {
                cmd.Dispose();
                Disconnect();

            }

            return response;
        }

    }
}