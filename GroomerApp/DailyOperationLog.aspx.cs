using BL.Admin.ContentManager;
using BL.Admin.Groomer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BL.Admin.SendMail;

namespace GroomerApp
{
    public partial class DailyOperationLog : System.Web.UI.Page
    {
        GroomerMgr objgroomer = new GroomerMgr();

        string strGID, AppointmentID, Status, AppointmentDate, errorMsg;

        static string Flag, PFieldID;

        int iGId;

        GroomerMgr ObjGroomer = new GroomerMgr();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(null == Session["GID"]))
                {
                    strGID = Session["GID"].ToString();

                    iGId = Convert.ToInt32(Session["GID"].ToString());
                }
                else
                {
                    Response.Redirect("Default.aspx?Msg=Timeout", false);
                }

                if (!(null == Session["AppointmentID"]))
                {
                    AppointmentID = Session["AppointmentID"].ToString();
                }
                if (!(null == Session["Status"]))
                {
                    Status = Session["Status"].ToString();
                }
                if (!(null == Session["AppointmentDate"]))
                {
                    AppointmentDate = Session["AppointmentDate"].ToString();
                }
                if (!IsPostBack)
                {
                    if (Session["GID"] != null)
                    {
                        getParantFields();
                    }

                    GetgroomerTodaysAppointment();

                    Session["ApptTimings"] = "";

                    Session["CardDetails"] = "";
                }
            }
            finally
            {
 
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(txtDate.Text.Trim()) > DateTime.Now.Date)
                {
                    ErrMessage("Future entries are not allowed");
                }
                else
                {
                    Session["VanID"] = txtVanID.Text.Trim();

                    Session["BeginningMileage"] = txtBeginningMileage.Text.Trim();

                    Session["TotalHours"] = txtTotalHours.Text.Trim();

                    Session["EndingMileage"] = txtEndingMileage.Text.Trim();

                    Session["FuelPurchased"] = txtFuelPurchased.Text.Trim();

                    Session["PriceperGallon"] = txtPriceperGallon.Text.Trim();

                    insertParantFields();

                }
            }
            finally
            {
 
            }
        }

        public void insertParantFields()
        {
            try
            {

                if (!(null == Session["GID"]))
                {
                    errorMsg = GetGroomerYesterdayMileage();

                    if (errorMsg == "Beginning")
                    {
                        ErrMessage("Beginning mileage should be greater than or equal to yesterday's ending mileage unless van ID has changed");
                    }
                    if (txtEndingMileage.Text != "")
                    {
                        if (Convert.ToInt32(txtEndingMileage.Text) <= Convert.ToInt32(txtBeginningMileage.Text))
                        {
                            ErrMessage("Ending mileage should be greater than beginning mileage unless van ID has changed");

                            return;
                        }
                    }
                    if (errorMsg == "SendMail")
                    {   
                        objgroomer.insertParantFields(strGID, txtVanID.Text.Trim(), txtBeginningMileage.Text.Trim(), txtTotalHours.Text.Trim(), txtEndingMileage.Text.Trim(), txtFuelPurchased.Text.Trim(), txtPriceperGallon.Text.Trim(), txtDate.Text, Flag, PFieldID);
                        
                        if (!(null == Session["AppointmentDate"]))
                        {

                            Response.Redirect("Operations.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("Dashboard.aspx", false);
                        }
                    }
                    if (errorMsg == "")
                    {

                        objgroomer.insertParantFields(strGID, txtVanID.Text.Trim(), txtBeginningMileage.Text.Trim(), txtTotalHours.Text.Trim(), txtEndingMileage.Text.Trim(), txtFuelPurchased.Text.Trim(), txtPriceperGallon.Text.Trim(), txtDate.Text, Flag, PFieldID);
                        
                        if (!(null == Session["AppointmentDate"]))
                        {
                            Response.Redirect("Operations.aspx", false);

                        }
                        else
                        {
                            Response.Redirect("Dashboard.aspx", false);
                        }
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx?Msg=Timeout", false);
                }
            }
            finally
            {
                objgroomer = null;
            }
        }

        public void getParantFields()
        {
            try
            {
                string AddedonDate = "";

                if (!(null == Session["AppointmentDate"]))
                {
                    AppointmentDate = Session["AppointmentDate"].ToString();

                    txtDate.Text = AppointmentDate.Replace("12:00:00 AM", "");

                    AddedonDate = Session["AppointmentDate"].ToString();
                }

                DataSet ds = new DataSet();

                ds = objgroomer.getParantFields(strGID, AddedonDate);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    txtVanID.Text = ds.Tables[0].Rows[0]["VanID"].ToString();

                    txtBeginningMileage.Text = ds.Tables[0].Rows[0]["BeginningMileage"].ToString();

                    txtTotalHours.Text = ds.Tables[0].Rows[0]["TotalHours"].ToString();

                    txtEndingMileage.Text = ds.Tables[0].Rows[0]["EndingMileage"].ToString();

                    if (txtEndingMileage.Text == "0") { txtEndingMileage.Text = ""; }

                    txtFuelPurchased.Text = ds.Tables[0].Rows[0]["FuelPurchased"].ToString(); if (txtFuelPurchased.Text == "0") { txtFuelPurchased.Text = ""; }

                    txtPriceperGallon.Text = ds.Tables[0].Rows[0]["PriceperGallon"].ToString();

                    PFieldID = ds.Tables[0].Rows[0]["PFieldID"].ToString();

                    Flag = "U";

                    DateTime AppointmentDate1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["Addedon"].ToString());

                    txtDate.Text = AppointmentDate1.ToShortDateString();

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        txtVanID.Text = ds.Tables[1].Rows[0]["VanID"].ToString();

                        txtBeginningMileage.Text = ds.Tables[1].Rows[0]["BeginningMileage"].ToString();

                        txtFuelPurchased.Text = ds.Tables[1].Rows[0]["FuelPurchased"].ToString(); if (txtFuelPurchased.Text == "0") { txtFuelPurchased.Text = ""; }

                        txtPriceperGallon.Text = ds.Tables[1].Rows[0]["PriceperGallon"].ToString();
                    }

                }
                else
                {
                    Flag = "I"; PFieldID = "";

                }

                if (txtDate.Text == "")
                {
                    Response.Redirect("Dashboard.aspx?msg=S", false);
                }
            }
            finally
            {
                objgroomer = null;
            }
        }

        public string GetGroomerYesterdayMileage()
        {
            try
            {
                DateTime dt = Convert.ToDateTime(txtDate.Text);

                dt = dt.AddDays(-1);

                DataSet ds = new DataSet();

                if (!(null == Session["GID"]))
                {
                    ds = objgroomer.GetGroomerYesterdayMileage(dt.ToShortDateString(), Session["GID"].ToString(), txtVanID.Text.Trim());
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(txtBeginningMileage.Text) < Convert.ToInt32(ds.Tables[0].Rows[0]["EndingMileage"]))
                        {
                            return "Beginning";

                        }

                        int diff = 0;
                        int endmileage = Convert.ToInt32(ds.Tables[0].Rows[0]["EndingMileage"]);
                        if (endmileage > 0)
                        {
                            diff = Convert.ToInt32(txtBeginningMileage.Text) - endmileage;
                        }
                        if (diff > 2)
                        {
                            GroomerBegningMileageMail("Beginning mileage is more than 2 miles than yesterday’s ending mileage");

                            return "SendMail";

                        }
                    }
                }
            }
            finally
            {
                objgroomer = null;
            }
            return "";
        }

        public void GroomerBegningMileageMail(string body)
        {
            try
            {
                string Mailbody = ContentManager.GetStaticeContentEmail("GroomerBegningMileage.htm").Replace("~", "#");

                Mailbody = Mailbody.Replace("<!-- Update -->", body);

                Mailbody = Mailbody.Replace("<!-- UserName -->", Session["GroomerUserName"].ToString());

                SendMail ObjMail = new SendMail();

                ObjMail.AppointmentMail(ConfigurationManager.AppSettings["ToEmail"].ToString(), Convert.ToString(Session["GroomerUserName"]) + " begning mileage mismatch yesterdays ending mileage", Mailbody);
            }
            finally
            { }
        }

        protected void GetgroomerTodaysAppointment()
        {
            try
            {
                if (!(null == Session["AppointmentDate"]))
                {
                    DataSet ds1 = new DataSet();

                    ds1 = objgroomer.GetgroomerTodaysAppointment(iGId, Session["AppointmentDate"].ToString());

                    if (ds1.Tables[0].Rows.Count > 1)
                    {
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                if (AppointmentID == ds1.Tables[0].Rows[0]["AppointmentID"].ToString())
                                {
                                    txtEndingMileage.Enabled = false;

                                    txtTotalHours.Enabled = false;
                                }
                                else
                                {
                                    txtEndingMileage.Enabled = false;

                                    txtTotalHours.Enabled = false;

                                }
                            }
                        }

                    }
                    else
                    {
                        txtEndingMileage.Enabled = false;

                        txtTotalHours.Enabled = false;
                    }
                }
                else
                {
                    txtEndingMileage.Enabled = true;

                    txtTotalHours.Enabled = true;

                    txtBeginningMileage.Enabled = false;
                }
            }
            finally
            {
                objgroomer = null;
            }
        }

        public void ErrMessage(string Message)
        {
            divError.Visible = true;

            divError.Attributes.Add("Class", "errorTable");

            lblError.Visible = true;

            lblError.Text = Message;
        }

        public void SuccesfullMessage(string Message)
        {
            divError.Visible = true;

            divError.Attributes.Add("Class", "successTable");

            lblError.Visible = true;

            lblError.Text = Message;
        }
    }
}