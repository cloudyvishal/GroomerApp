using BL.Admin.Groomer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroomerApp
{
    public partial class dashboard : System.Web.UI.Page
    {
        string strGroomerUserName, strGId;

        GroomerMgr objGroomer = new GroomerMgr();

        GroomerMgr objgroomer = new GroomerMgr();

        DataSet dsDtls = null;

        string strMsg;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                strMsg = Request.QueryString["msg"] != null ? Request.QueryString["msg"] : "";

                if (!IsPostBack)
                {

                    strGroomerUserName = Session["GroomerUserName"] != null ? Session["GroomerUserName"].ToString() : "";
                    strGId = Session["GId"] != null ? Session["GId"].ToString() : "";

                    if (strMsg == "S" && (!(null == Session["LogID"])))
                    {
                        SuccesfullMessage("Details Submitted Successfully !!!");
                    }
                    if (strMsg == "P" && (!(null == Session["DailyLogID"])))
                    {
                        SuccesfullMessage("Your payment transaction has been successful.Details Submitted Successfully !!!");
                    }
                    if (strMsg == "U" && (!(null == Session["DailyLogID"])))
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        SuccesfullMessage("Your payment transaction has been Unsuccessful.Details Submitted Successfully !!!");
                    }

                    getAppointmentDtls();
                }
            }
            finally
            {
 
            }
        }

        public void getAppointmentDtls()
        {
            try
            {
                if (strGId != "")
                {
                    dsDtls = objGroomer.getAppointmentDtls(strGId);

                    if (dsDtls.Tables.Count > 0)
                    {
                        if (dsDtls.Tables[0].Rows.Count > 0)
                        {
                            lbl_time.Text = dsDtls.Tables[0].Rows[0]["DateTimeFormat"].ToString().Trim();

                            lbl_description.Text = dsDtls.Tables[0].Rows[0]["Others"].ToString().Trim();

                            Session["AppointmentID"] = dsDtls.Tables[0].Rows[0]["AppointmentID"].ToString().Trim();

                            Session["Status"] = dsDtls.Tables[0].Rows[0]["Status"].ToString().Trim();

                            Session["AppointmentDate"] = dsDtls.Tables[0].Rows[0]["AppointmentDate"].ToString().Trim();

                            Session["ExpectedRev"] = dsDtls.Tables[0].Rows[0]["ExpectedTotalRevenue"].ToString().Trim();

                            Session["ExpectedPetTime"] = dsDtls.Tables[0].Rows[0]["ExpPetTime"].ToString().Trim();

                            divDetails.Visible = true;
                            
                            if (!(null == Session["AppointmentID"]) && !(null == Session["UserTimeZone"]))
                            {
                                string userZone = Session["UserTimeZone"].ToString();

                                var info = TimeZoneInfo.FindSystemTimeZoneById(userZone);

                                DateTimeOffset localServerTime = DateTimeOffset.Now;

                                DateTimeOffset usersTime = TimeZoneInfo.ConvertTime(localServerTime, info);

                                string convertedTime = usersTime.DateTime.ToLongTimeString();

                                objGroomer.GroomerUpdateApptPresentedStatus(Convert.ToInt32(Session["AppointmentID"]), convertedTime);
                            }
                        }
                        else
                        {
                            divDetails.Visible = false;

                            ErrMessage("Appointments Not Available");

                            Session["AppointmentID"] = null; Session["Status"] = null; Session["AppointmentDate"] = null; Session["ExpectedRev"] = null;
                        }
                    }
                }
            }
            finally
            {
                objGroomer = null;
            }
        }

        public void ErrMessage(string Message)
        {
            divMsg.Visible = true;
            divMsg.Attributes.Add("Class", "errorTable2");
            lblMsg.Visible = true;
            lblMsg.Text = Message;
        }

        public void SuccesfullMessage(string Message)
        {
            divError.Visible = true;
            divError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!(null == Session["PageFrom"]))
            {
                Response.Redirect("DailyOperationLog.aspx", false);
            }
            else
            {
                Session["PageFrom"] = null;

                Response.Redirect("DailyOperationLog.aspx", false);
            }

        }
    }
}