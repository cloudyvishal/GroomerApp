using BL.Admin.Groomer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroomerApp
{
    public partial class Operations : System.Web.UI.Page
    {
        protected DataSet dsAppointment;

        protected DataSet dsOldAppointment;

        GroomerMgr objgroomer = new GroomerMgr();

        int Revnue01;

        string strVanID, strBeginningMileage, strTotalHours, strEndingMileage, strPriceperGallon, strFuelPurchased;

        int FleaandTick22, FleaandTick44, FleaandTick88, FleaandTick132, FleaandTickCat, TB, Wham;

        double RevenueCreditCard, RevenueCheck, RevenueCash, RevenueInvoice, RevenueCCY, TipCreditCard, TipCheck, TipCash, TipInvoice, PriorCreditCard, PriorCheck, PriorCash;

        string strGId, CustomerName, Job, ZipCode, Pets, Rebook, FromRebook, New, TimeIn, TimeOut, PetTime, ExtraServices, comments, driveTime, rpetTime, CreditCardNo, CreditCardExpir, CreditCardORChkName, CreditCardORChkAddr, SecurityCode, NextAppomentDate, NextAppomentTime, NextAppointmentEndTime, ServicesForPet1, ServicesForPet2, ServicesForPet3, ServicesForPet4, ServicesForPet5, ServicesForPet6, NameOnCheque, Bankname;

        int AppointmentID;

        string revValidate = "";

        int DLId;

        int rdocnt;

        GroomerMgr ObjGroomer = new GroomerMgr();

        DataSet dsDtls;

        string sdt, edt;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(null == Session["PageFrom"]))
                {
                    txtCustLastName.Text = Session["CustLastName"].ToString();

                    txtJob.Text = Session["JobM"].ToString();

                    txtZipCode.Text = Session["zipCode"].ToString();

                    txtPets.Text = Session["Pet"].ToString();

                    txtFleaandTick22.Text = Session["FT22"].ToString();

                    txtFleaandTick44.Text = Session["FT44"].ToString();

                    txtFleaandTick88.Text = Session["FT88"].ToString();

                    txtFleaandTick132.Text = Session["FT132"].ToString();

                    txtFleaandTickCat.Text = Session["FTCat"].ToString();

                    txtTB.Text = Session["TB"].ToString();

                    txtWham.Text = Session["Wham"].ToString();

                    txtRevenue.Text = Session["RevenuAmt"].ToString();

                    txtExtraServices.Text = Session["ExtraServices"].ToString();

                    txtComments.Text = Session["Comments"].ToString();

                    rdoDriveTime.SelectedValue = Session["rdoDrive"].ToString();

                    rdoPetTime.SelectedValue = Session["rdoPet"].ToString();

                    txtProductPrice.Text = Session["productPrice"].ToString();

                    txtSalestax.Text = Session["SaleTax"].ToString();

                    txtTip.Text = Session["tipAmt"].ToString();

                    txtPriorRevenue.Text = Session["PriorRev"].ToString();

                    Session["PageFrom"] = null;
                }
                if (!(null == Session["AppointmentDate"]))
                {
                    DateTime AppointmentDate1;

                    AppointmentDate1 = Convert.ToDateTime(Session["AppointmentDate"].ToString());

                    txtDate.Text = AppointmentDate1.ToShortDateString();
                }
                if (!(null == Session["VanID"]) && !(null == Session["BeginningMileage"]) && !(null == Session["TotalHours"]) && !(null == Session["EndingMileage"]) && !(null == Session["PriceperGallon"]) && !(null == Session["FuelPurchased"]))
                {
                    strVanID = Session["VanID"].ToString();

                    strBeginningMileage = Session["BeginningMileage"].ToString();

                    strTotalHours = Session["TotalHours"].ToString();

                    strEndingMileage = Session["EndingMileage"].ToString();

                    strPriceperGallon = Session["PriceperGallon"].ToString();

                    strFuelPurchased = Session["FuelPurchased"].ToString();
                }

                if (!(null == Session["GID"])) { strGId = Session["GID"].ToString(); } else { Response.Redirect("Default.aspx?Msg=Timeout", false); }

                if (!(null == Session["AppointmentID"])) { AppointmentID = Convert.ToInt32(Session["AppointmentID"].ToString()); }

                if (!IsPostBack)
                {
                    try
                    {
                        if (!(null == Session["PageFrom"]))
                        {
                            if ("Yes" == Session["rdoRebookD"].ToString())
                            {
                                rdoRebook.SelectedValue = Session["rdoRebookD"].ToString();

                                rdoRebook.Items.FindByValue("Yes");

                                divNextAppoint.Visible = true;

                                dddDay.SelectedValue = Session["rday"].ToString();

                                ddlMonth.SelectedValue = Session["rmonth"].ToString();

                                ddlYear.SelectedValue = Session["ryear"].ToString();

                                ddlhr.SelectedValue = Session["rAppStartTimeHr"].ToString();

                                ddlMin1.SelectedValue = Session["rAppStartTimeMin1"].ToString();

                                ddlmin.SelectedValue = Session["rAppStartTimeMin"].ToString();

                                ddlEndTimeHrs.SelectedValue = Session["rAppEndTimeHr"].ToString();

                                ddlEndTimeMin1.SelectedValue = Session["rAppEndTimeMin1"].ToString();

                                ddlEndTimeMin.SelectedValue = Session["rAppEndTimeMin"].ToString();

                                txtServicesforPet1.Text = Session["ServicesforPet1"].ToString();

                                txtServicesforPet2.Text = Session["ServicesforPet2"].ToString();

                                txtServicesforPet3.Text = Session["ServicesforPet3"].ToString();

                                txtServicesforPet4.Text = Session["ServicesforPet4"].ToString();

                                txtServicesforPet5.Text = Session["ServicesforPet5"].ToString();

                                txtServicesforPet6.Text = Session["ServicesforPet6"].ToString();

                                Session["rdoRebookD"] = "";

                                Session["PageFrom"] = null;
                            }
                            else
                            {
                                rdoRebook.SelectedValue = Session["rdoRebookD"].ToString();

                                rdoRebook.Items.FindByValue("No");

                                divNextAppoint.Visible = false;

                                Session["rdoRebookD"] = "";

                                Session["PageFrom"] = null;
                            }
                        }
                        BindDayYear();

                        getAppointmentDtls();

                        divNextAppoint.Visible = false;

                        chkdetails.Visible = false;

                        FillAppointmentLogDetails();

                        SetApptCompTime();

                        if (lblApptStartTime.Text != "")
                        {
                            btnStartApt.Enabled = false;
                        }
                        else
                        {
                            btnStartApt.Enabled = true;
                        }

                        if (lblApptEndTime.Text != "")
                        {
                            btnEndApt.Enabled = false;
                        }
                        else
                        {
                            btnEndApt.Enabled = true;
                        }

                        if (lblApptStartTime.Text == "")
                        {
                            btnEndApt.Enabled = false;
                        }
                        txtDate.Focus();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            finally
            { }
        }

        public string getmonth(int mth)
        {
            string month = "";
            switch (mth)
            {
                case 1: month = "January";

                    break;
                case 2: month = "February";
                    break;
                case 3: month = "March";
                    break;
                case 4: month = "April";
                    break;
                case 5: month = "May";
                    break;
                case 6: month = "June";
                    break;
                case 7: month = "July";
                    break;
                case 8: month = "August";
                    break;
                case 9: month = "September";
                    break;
                case 10: month = "October";
                    break;
                case 11: month = "November";
                    break;
                case 12: month = "December";
                    break;
            }
            return month;
        }

        public void FillAppointmentLogDetails()
        {
            try
            {
                if (!(null == Session["DailyLogID"]))
                {
                    if (Session["DailyLogID"].ToString() != "")
                    {
                        btnStartApt.Enabled = false;

                        btnEndApt.Enabled = false;

                        DataSet dsapt = new DataSet();

                        dsapt = objgroomer.GetAptdetails(Convert.ToInt32(Session["DailyLogID"].ToString()));

                        if (dsapt.Tables.Count > 0)
                        {
                            if (dsapt.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in dsapt.Tables[0].Rows)
                                {
                                    txtCustLastName.Text = dr["CustomerName"].ToString();

                                    txtZipCode.Text = dr["ZipCode"].ToString().Trim();

                                    txtPets.Text = dr["Pets"].ToString();

                                    txtJob.Text = dr["Job"].ToString();

                                    if (Convert.ToInt32(dr["Rebook"].ToString()) == 1)
                                    {
                                        rdoRebook.SelectedValue = "1";

                                        if (dr["NextAppointmentDate"].ToString() != "")
                                        {
                                            DateTime dtnextapt = Convert.ToDateTime(dr["NextAppointmentDate"].ToString());

                                            if (dtnextapt.Month.ToString().Length == 1)
                                            {
                                                ddlMonth.SelectedValue = "0" + dtnextapt.Month.ToString();
                                            }
                                            else
                                            {
                                                ddlMonth.SelectedValue = dtnextapt.Month.ToString();
                                            }
                                            if (dtnextapt.Day.ToString().Length == 1)
                                            {
                                                dddDay.SelectedValue = "0" + dtnextapt.Day.ToString();
                                            }
                                            else
                                            {
                                                dddDay.SelectedValue = dtnextapt.Day.ToString();
                                            }
                                            ddlYear.SelectedValue = dtnextapt.Year.ToString();
                                        }

                                        if (dr["NextAppointmentTime"].ToString() != "")
                                        {
                                            if (dr["NextAppointmentTime"].ToString().Contains(":"))
                                            {
                                                string[] strtimein = new string[2];

                                                strtimein = dr["NextAppointmentTime"].ToString().Split(':');

                                                string[] strmin = new string[2];

                                                strmin = strtimein[1].ToString().Split(' ');

                                                string hrs = strtimein[0].ToString();

                                                string mins = strmin[0].ToString();

                                                string hoursslab = strmin[1].ToString();

                                                if (mins.Length == 1)
                                                {
                                                    mins = "0" + mins;
                                                }
                                                ddlhr.SelectedValue = hrs;

                                                ddlMin1.SelectedValue = mins;

                                                ddlmin.SelectedValue = hoursslab;
                                            }
                                        }
                                        if (dr["NextAppointmentEndTime"].ToString() != "")
                                        {
                                            if (dr["NextAppointmentEndTime"].ToString().Contains(":"))
                                            {
                                                string[] strtimein = new string[2];

                                                strtimein = dr["NextAppointmentEndTime"].ToString().Split(':');

                                                string[] strmin = new string[2];

                                                strmin = strtimein[1].ToString().Split(' ');

                                                string hrs = strtimein[0].ToString();

                                                string mins = strmin[0].ToString();

                                                string hoursslab = strmin[1].ToString();

                                                if (mins.Length == 1)
                                                {
                                                    mins = "0" + mins;
                                                }
                                                ddlEndTimeHrs.SelectedValue = hrs;

                                                ddlEndTimeMin1.SelectedValue = mins;

                                                ddlEndTimeMin.SelectedValue = hoursslab;
                                            }
                                        }
                                        txtServicesforPet1.Text = dr["ServicesForPet1"].ToString();

                                        txtServicesforPet2.Text = dr["ServicesForPet2"].ToString();

                                        txtServicesforPet3.Text = dr["ServicesForPet3"].ToString();

                                        txtServicesforPet4.Text = dr["ServicesForPet4"].ToString();

                                        txtServicesforPet5.Text = dr["ServicesForPet5"].ToString();

                                        txtServicesforPet6.Text = dr["ServicesForPet6"].ToString();
                                    }

                                    if (Convert.ToInt32(dr["FromRebook"].ToString()) == 1)
                                    {
                                        rdoFromRebook.SelectedValue = "1";
                                    }
                                    if (Convert.ToInt32(dr["New"].ToString()) == 1)
                                    {
                                        rdoNew.SelectedValue = "1";
                                    }

                                    txtFleaandTick22.Text = dr["FleaandTick22"].ToString();

                                    txtFleaandTick44.Text = dr["FleaandTick44"].ToString();

                                    txtFleaandTick88.Text = dr["FleaandTick88"].ToString();

                                    txtFleaandTick132.Text = dr["FleaandTick132"].ToString();

                                    txtFleaandTickCat.Text = dr["FleaandTickCat"].ToString();

                                    txtTB.Text = dr["TB"].ToString();

                                    txtWham.Text = dr["Wham"].ToString();

                                    txtPetTime.Text = dr["PetTime"].ToString();

                                    txtExtraServices.Text = dr["ExtraServices"].ToString();

                                    txtComments.Text = dr["Comments"].ToString();

                                    if (Convert.ToInt32(dr["Drive_Time"].ToString()) == 1)
                                    {
                                        rdoDriveTime.SelectedValue = "1";
                                    }
                                    else
                                    {
                                        rdoDriveTime.SelectedValue = "0";
                                    }
                                    if (Convert.ToInt32(dr["Pet_Time"].ToString()) == 1)
                                    {
                                        rdoPetTime.SelectedValue = "1";
                                    }
                                    else
                                    {
                                        rdoPetTime.SelectedValue = "0";
                                    }
                                    if (Convert.ToDouble(dr["RevenueCreditCard"].ToString()) > 0)
                                    {
                                        txtRevenue.Text = Math.Round(Convert.ToDouble(dr["RevenueCreditCard"].ToString()), 2).ToString();

                                        rdoRevenue.SelectedValue = "0";
                                    }

                                    if (Convert.ToDouble(dr["RevenueCCY"].ToString()) > 0)
                                    {
                                        txtRevenue.Text = Math.Round(Convert.ToDouble(dr["RevenueCCY"].ToString()), 2).ToString();

                                        rdoRevenue.SelectedValue = "1";
                                    }

                                    if (Convert.ToDouble(dr["RevenueCheck"].ToString()) > 0)
                                    {
                                        txtRevenue.Text = Math.Round(Convert.ToDouble(dr["RevenueCheck"].ToString()), 2).ToString();

                                        rdoRevenue.SelectedValue = "2";
                                    }

                                    if (Convert.ToDouble(dr["RevenueCash"].ToString()) > 0)
                                    {
                                        txtRevenue.Text = Math.Round(Convert.ToDouble(dr["RevenueCash"].ToString()), 2).ToString();

                                        rdoRevenue.SelectedValue = "3";
                                    }

                                    if (Convert.ToDouble(dr["RevenueInvoice"].ToString()) > 0)
                                    {
                                        txtRevenue.Text = Math.Round(Convert.ToDouble(dr["RevenueInvoice"].ToString()), 2).ToString();

                                        rdoRevenue.SelectedValue = "4";
                                    }
                                    txtProductPrice.Text = Math.Round(Convert.ToDouble(dr["ProductPrice"].ToString()), 2).ToString();

                                    txtSalestax.Text = Math.Round(Convert.ToDouble(dr["Salestax"].ToString()), 2).ToString();

                                    if (Convert.ToDouble(dr["TipCreditCard"].ToString()) > 0)
                                    {
                                        txtTip.Text = Math.Round(Convert.ToDouble(dr["TipCreditCard"].ToString()), 2).ToString();

                                        rdoTip.SelectedValue = "0";
                                    }
                                    if (Convert.ToDouble(dr["TipCheck"].ToString()) > 0)
                                    {
                                        txtTip.Text = Math.Round(Convert.ToDouble(dr["TipCheck"].ToString()), 2).ToString();

                                        rdoTip.SelectedValue = "1";
                                    }

                                    if (Convert.ToDouble(dr["TipCash"].ToString()) > 0)
                                    {
                                        txtTip.Text = Math.Round(Convert.ToDouble(dr["TipCash"].ToString()), 2).ToString();

                                        rdoTip.SelectedValue = "2";
                                    }

                                    if (Convert.ToDouble(dr["TipInvoice"].ToString()) > 0)
                                    {
                                        txtTip.Text = Math.Round(Convert.ToDouble(dr["TipInvoice"].ToString()), 2).ToString();

                                        rdoTip.SelectedValue = "3";
                                    }

                                    if (Convert.ToDouble(dr["PriorCreditCard"].ToString()) > 0)
                                    {
                                        txtPriorRevenue.Text = Math.Round(Convert.ToDouble(dr["PriorCreditCard"].ToString()), 2).ToString();

                                        rdoPrior.SelectedValue = "0";
                                    }

                                    if (Convert.ToDouble(dr["PriorCheck"].ToString()) > 0)
                                    {
                                        txtPriorRevenue.Text = Math.Round(Convert.ToDouble(dr["PriorCheck"].ToString()), 2).ToString();

                                        rdoPrior.SelectedValue = "1";
                                    }
                                    if (Convert.ToDouble(dr["PriorCash"].ToString()) > 0)
                                    {
                                        txtPriorRevenue.Text = Math.Round(Convert.ToDouble(dr["PriorCash"].ToString()), 2).ToString();

                                        rdoPrior.SelectedValue = "2";
                                    }

                                    if (dr["accholdername"].ToString() != "" || dr["chequebank"].ToString() != "")
                                    {
                                        chkdetails.Visible = true;

                                        txtcname.Text = dr["accholdername"].ToString();

                                        txtcaddr.Text = dr["chequebank"].ToString();
                                    }

                                    if (dr["TimeIn"].ToString() != "")
                                    {
                                        lblApptStartTime.Text = dr["TimeIn"].ToString();

                                        Session["Last_appt_InTime"] = dr["TimeIn"].ToString();
                                    }
                                    if (dr["TimeOut"].ToString() != "")
                                    {
                                        lblApptEndTime.Text = dr["TimeOut"].ToString();

                                        Session["Last_Appt_OutTime"] = dr["TimeOut"].ToString();
                                    }

                                    if (!(null == Session["AptCompTime"]))
                                    {
                                        lblApptCompleteTime.Text = Session["AptCompTime"].ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            { }
        }

        public void SetApptCompTime()
        {
            try
            {
                if (lblApptCompleteTime.Text == "" && lblApptStartTime.Text != "" && lblApptEndTime.Text != "")
                {
                    string[] tmInlastpart = new string[2];

                    string[] tmOutlastpart = new string[2];

                    string[] arrcalcinhours = new string[3];

                    string[] arrcalcouthours = new string[3];

                    arrcalcinhours = lblApptStartTime.Text.Split(':');

                    arrcalcouthours = lblApptEndTime.Text.Split(':');

                    string time_in_hr = arrcalcinhours[0].ToString();

                    string time_in_mm = arrcalcinhours[1].ToString();

                    tmInlastpart = arrcalcinhours[2].ToString().Split(' ');

                    string time_in_ss = tmInlastpart[0].ToString();

                    string time_in_pref = tmInlastpart[1].ToString();

                    string time_out_hr = arrcalcouthours[0].ToString();

                    string time_out_min = arrcalcouthours[1].ToString();

                    tmOutlastpart = arrcalcouthours[2].ToString().Split(' ');

                    string time_out_ss = tmOutlastpart[0].ToString();

                    string time_out_pref = tmOutlastpart[1].ToString();

                    string CalcInTime = String.Format("{0}:{1}:{2}{3}", time_in_hr, time_in_mm, time_in_ss, time_in_pref);

                    string CalcOutTime = String.Format("{0}:{1}:{2}{3}", time_out_hr, time_out_min, time_out_ss, time_out_pref);

                    TimeSpan tmDifference = DateTime.Parse(CalcOutTime) - DateTime.Parse(CalcInTime);

                    decimal time = Convert.ToDecimal(new TimeSpan(tmDifference.Hours, tmDifference.Minutes, 0).TotalHours);

                    lblApptCompleteTime.Text = Math.Round(time, 2).ToString();

                    Session["AptCompTime"] = lblApptCompleteTime.Text;
                }
            }
            finally
            { }
        }

        public void getAppointmentDtls()
        {
            try
            {
                if (strGId != "")
                {
                    dsDtls = ObjGroomer.getAppointmentDtls(strGId);

                    if (dsDtls.Tables[0].Rows.Count > 0)
                    {
                        lbl_time.Text = dsDtls.Tables[0].Rows[0]["DateTimeFormat"].ToString().Trim();

                        lbl_description.Text = dsDtls.Tables[0].Rows[0]["Others"].ToString().Trim();

                        string Appt_Status = dsDtls.Tables[0].Rows[0]["StatusPresented"].ToString();

                        string ApptStartTime = dsDtls.Tables[0].Rows[0]["StartTime"].ToString();

                        string ApptEndTime = dsDtls.Tables[0].Rows[0]["EndTime"].ToString();

                        lblApptStartTime.Text = ApptStartTime;

                        lblApptEndTime.Text = ApptEndTime;

                        divDetails.Visible = true;
                    }
                    else
                    {
                        divDetails.Visible = false;

                        divDetails.Visible = true;
                    }
                }
            }
            finally
            {

            }
        }

        private int GId
        {
            get
            {
                if (Session["GId"] != null)
                {
                    return int.Parse(Session["GId"].ToString());
                }
                else
                    return 0;
            }
        }

        public void BindDayYear()
        {
            try
            {
                string[] day = new string[31];

                for (int i = 0; i < 31; i++)
                {
                    day[i] = (i + 1).ToString();
                }
                string[] Years = new string[10];

                for (int i = 0; i < 10; i++)
                {
                    Years[i] = (DateTime.Now.Year + i).ToString();
                }
            }
            finally
            { }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lblAppSubmit.Text = "";

                if (lblApptStartTime.Text != "" && lblApptEndTime.Text != "")
                {
                    lbldatevalmsg.Text = "";

                    bool IsValidApt = true;

                    string AptID = null;

                    if (!(null == Session["AppointmentID"])) { AptID = Session["AppointmentID"].ToString(); }

                    if (txtRevenue.Text != "")
                    {
                        DataSet dsDetails = ObjGroomer.getAppointmentDetails(AptID);

                        string[] tmInlastpart = new string[2];

                        string[] tmOutlastpart = new string[2];

                        string[] arrcalcinhours = new string[3];

                        string[] arrcalcouthours = new string[3];

                        arrcalcinhours = lblApptStartTime.Text.Split(':');

                        arrcalcouthours = lblApptEndTime.Text.Split(':');

                        string time_in_hr = arrcalcinhours[0].ToString();

                        string time_in_mm = arrcalcinhours[1].ToString();

                        tmInlastpart = arrcalcinhours[2].ToString().Split(' ');

                        string time_in_ss = tmInlastpart[0].ToString();

                        string time_in_pref = tmInlastpart[1].ToString();

                        string time_out_hr = arrcalcouthours[0].ToString();

                        string time_out_min = arrcalcouthours[1].ToString();

                        tmOutlastpart = arrcalcouthours[2].ToString().Split(' ');

                        string time_out_ss = tmOutlastpart[0].ToString();

                        string time_out_pref = tmOutlastpart[1].ToString();

                        string CalcInTime = String.Format("{0}:{1}:{2}{3}", time_in_hr, time_in_mm, time_in_ss, time_in_pref);

                        string CalcOutTime = String.Format("{0}:{1}:{2}{3}", time_out_hr, time_out_min, time_out_ss, time_out_pref);

                        TimeSpan tmDifference = DateTime.Parse(CalcOutTime) - DateTime.Parse(CalcInTime);

                        if (dsDetails.Tables.Count > 0)
                        {
                            if (dsDetails.Tables[0].Rows.Count > 0)
                            {
                                string exprevamt = dsDetails.Tables[0].Rows[0]["ExpectedTotalRevenue"].ToString();

                                string exppettimeout = dsDetails.Tables[0].Rows[0]["ExpPetTime"].ToString();

                                decimal Revenue_Amount = 0;

                                Revenue_Amount = Math.Round(Convert.ToDecimal(exprevamt), 0);

                                bool IsAllocatedTime = false;

                                if (exppettimeout.Contains("."))
                                {
                                    string[] arrpetotime = new string[2];

                                    arrpetotime = exppettimeout.Split('.');

                                    int arrhr = Convert.ToInt32(arrpetotime[0].ToString());

                                    decimal arrmin = Convert.ToDecimal(arrpetotime[1].ToString());

                                    string ExpPetTime = exppettimeout.ToString();

                                    decimal testexp = Convert.ToDecimal(ExpPetTime);

                                    decimal CalcExpTime = Convert.ToDecimal((Convert.ToDecimal(arrmin) / 100) * 60);//Convert Percentage time into real time

                                    int hrs = 0, mins = 0;

                                    hrs = Convert.ToInt32(CalcExpTime / 60);

                                    mins = Convert.ToInt32(CalcExpTime);

                                    DateTime dt1 = new DateTime(1900, 1, 1, arrhr, mins, 00);

                                    DateTime dt2 = new DateTime(1900, 1, 1, tmDifference.Hours, tmDifference.Minutes, 00);

                                    TimeSpan ts = new TimeSpan();
                                    if (dt1 > dt2)
                                    {
                                        ts = dt1.Subtract(dt2);
                                    }
                                    else
                                    {
                                        ts = dt2.Subtract(dt1);
                                    }

                                    int diffhours = ts.Hours;
                                    int diffmins = ts.Minutes;

                                    if (diffhours == 0 && diffmins <= 15)
                                    {
                                        IsAllocatedTime = true;
                                    }
                                }
                                decimal Rev_Amount = Convert.ToDecimal(txtRevenue.Text.Trim());

                                if ((Rev_Amount != Revenue_Amount && txtExtraServices.Text.Trim() == "") || (IsAllocatedTime.Equals(false) && txtExtraServices.Text == ""))
                                {
                                    IsValidApt = false;
                                }
                            }
                        }
                    }
                    if (IsValidApt.Equals(false))
                    {
                        ScriptManager.RegisterClientScriptBlock(btnSubmit, this.GetType(), "AlertMsg", "AppChangesError();", true);

                        txtExtraServices.Focus();
                    }
                    else
                    {
                        divaptchangesrequired.Visible = false;

                        lblaptchangesreq.Visible = false;
                    }

                    if (IsValid && IsValidApt.Equals(true))
                    {
                        if (rdoRebook.SelectedValue.Equals("1"))
                        {
                            Regex regexDt = new Regex("(^(((([1-9])|([0][1-9])|([1-2][0-9])|(30))\\-([A,a][P,p][R,r][I,i][L,l]|[J,j][U,u][N,n][E,e]|[S,s][E,e][P,p][T,t][E,e][M,m][B,b][E,e][R,r]|[N,n][O,o][V,v][E,e][M,m][B,b][E,e][R,r]))|((([1-9])|([0][1-9])|([1-2][0-9])|([3][0-1]))\\-([J,j][A,a][N,n][U,u][A,a][R,r][Y,y]|[M,m][A,a][R,r][C,c][H,h]|[M,m][A,a][Y,y]|[J,j][U,u][L,l][Y,y]|[A,a][U,u][G,g][U,u][S,s][T,t]|[O,o][C,c][T,t][O,o][B,b][E,e][R,r]|[D,d][E,e][C,c][E,e][M,m][B,b][E,e][R,r])))\\-[0-9]{4}$)|(^(([1-9])|([0][1-9])|([1][0-9])|([2][0-8]))\\-([F,f][E,e][B,b][R,r][U,u][A,a][R,r][Y,y])\\-[0-9]{2}(([02468][1235679])|([13579][01345789]))$)|(^(([1-9])|([0][1-9])|([1][0-9])|([2][0-9]))\\-([F,f][E,e][B,b][R,r][U,u][A,a][R,r][Y,y])\\-[0-9]{2}(([02468][048])|([13579][26]))$)");

                            string strDate = (Convert.ToInt32(dddDay.SelectedValue) + "-" + ddlMonth.SelectedItem.Text + "-" + Convert.ToInt32(ddlYear.SelectedValue)).ToString();//txtDateofJourney.Text;

                            Match mtEndDt = Regex.Match(strDate, regexDt.ToString());

                            if (!(mtEndDt.Success))
                            {
                                ErrMessage("Please select Valid Date.");

                                lbldatevalmsg.Text = "";

                                return;
                            }
                            else
                            {
                                if (Convert.ToDateTime(DateTime.Now.Date) >= Convert.ToDateTime(strDate))
                                {
                                    ErrMessage("Next Appointment date should be future date");

                                    lbldatevalmsg.Text = "";

                                    ddlMonth.Focus();

                                    return;
                                }
                                else
                                {
                                    if (((Convert.ToInt32(ddlEndTimeHrs.SelectedValue.ToString()) < Convert.ToInt32(ddlhr.SelectedValue.ToString()))

                                       && (ddlmin.SelectedItem.Text.Equals(ddlEndTimeMin.SelectedItem.Text))
                                       && Convert.ToInt32(ddlhr.SelectedValue) != 12)
                                       || (Convert.ToInt32(ddlhr.SelectedValue) > 7
                                       && Convert.ToInt32(ddlhr.SelectedValue) < 12
                                       && ddlmin.SelectedItem.Text.Equals("PM"))
                                       || (Convert.ToInt32(ddlEndTimeHrs.SelectedValue) > 10
                                       && Convert.ToInt32(ddlMinOUT.SelectedValue) > 0
                                       && ddlEndTimeMin.SelectedItem.Text.Equals("PM") &&
                                       (Convert.ToInt32(ddlEndTimeHrs.SelectedValue) != 12))
                                       || (Convert.ToInt32(ddlhr.SelectedValue) == 12
                                       && ddlmin.SelectedItem.Text.Equals("AM"))
                                       || (Convert.ToInt32(ddlEndTimeHrs.SelectedValue) == 12
                                       && ddlEndTimeMin.SelectedItem.Text.Equals("AM"))
                                       || (ddlmin.SelectedItem.Text.Equals("PM")
                                       && ddlEndTimeMin.SelectedItem.Text.Equals("AM"))
                                       || (ddlmin.SelectedItem.Text.Equals("AM")
                                       && Convert.ToInt32(ddlhr.SelectedValue.ToString()) < 7)
                                       || ddlmin.SelectedItem.Text.Equals(ddlEndTimeMin.SelectedItem.Text) &&
                                       Convert.ToInt32(ddlhr.SelectedValue) == Convert.ToInt32(ddlEndTimeHrs.SelectedValue)
                                       && Convert.ToInt32(ddlEndTimeMin1.SelectedValue) < Convert.ToInt32(ddlMin1.SelectedValue)
                                       || Convert.ToInt32(ddlhr.SelectedValue) == Convert.ToInt32(ddlEndTimeHrs.SelectedValue)
                                       && ddlmin.SelectedItem.Text.Equals("AM")
                                       && ddlEndTimeMin.SelectedItem.Text.Equals("PM")
                                       && Convert.ToInt32(ddlEndTimeMin1.SelectedValue) > 0
                                       )
                                    {
                                        ErrMessage("Please Specify Proper Rebook Time.");

                                        lbldatevalmsg.Text = "";

                                        ddlhr.Focus();

                                        return;
                                    }
                                }
                            }
                        }

                        if (!(null == Session["GID"]))
                        {
                            if (txtJob.Text.Trim() != "")
                            {
                                DataSet dsIsAppointmentExists = ObjGroomer.CheckAppointment(AppointmentID);

                                Job = txtJob.Text;

                                ExtraServices = txtExtraServices.Text;

                                comments = txtComments.Text;

                                driveTime = rdoDriveTime.SelectedValue;

                                rpetTime = rdoPetTime.SelectedValue;

                                CustomerName = txtCustLastName.Text;

                                ZipCode = txtZipCode.Text;

                                Pets = txtPets.Text;

                                PetTime = lblApptCompleteTime.Text;

                                TimeIn = lblApptStartTime.Text;

                                TimeOut = lblApptEndTime.Text;

                                DataSet dsIsAppExists = ObjGroomer.CheckAppRecordinDB(strGId, strVanID, strBeginningMileage, ExtraServices, CustomerName, Job, ZipCode, Pets, PetTime, Session["AppointmentDate"].ToString(), TimeIn, TimeOut);

                                if (dsIsAppointmentExists.Tables[0].Rows.Count > 0 && dsIsAppExists.Tables[0].Rows.Count > 0)
                                {
                                    InsertDailyOperationLog();
                                }
                                else
                                {
                                    ErrMessage("Appointment already submitted Please Login again to proceed Next Appointment.");

                                    lblAppSubmit.Text = "";

                                    lblAppSubmit1.Text = "";
                                }
                            }
                        }

                        if (rdoRevenue.SelectedItem.Value != "1" && (rdoRevenue.SelectedItem.Value == "0" || rdoTip.SelectedItem.Value == "0" || rdoPrior.SelectedItem.Value == "0"))
                        {
                            Session["AptDateFormat"] = lbl_time.Text;

                            Session["AptString"] = lbl_description.Text;

                            Response.Redirect("PaymentInfo.aspx", false);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(btnSubmit, this.GetType(), "AlertMsg", "AppTimeError();", true);

                    lblAppSubmit.Focus();
                }
            }
            finally
            {
                ObjGroomer = null;
            }
        }

        protected void InsertLog()
        {
            try
            {
                #region InsertDailyOperationLog code

                CreditCardNo = "";

                CreditCardExpir = "";

                CreditCardORChkName = "";

                CreditCardORChkAddr = "";

                SecurityCode = "";

                DLId = objgroomer.InsertDailyOperationLog(strGId, strVanID, strBeginningMileage, strTotalHours, strEndingMileage, strFuelPurchased, strPriceperGallon, CustomerName, Job, ZipCode, Pets, Rebook, FromRebook, New, TimeIn, TimeOut, PetTime, ExtraServices, comments, driveTime, rpetTime, FleaandTick22, FleaandTick44, FleaandTick88, FleaandTick132, FleaandTickCat, TB, Wham, RevenueCreditCard, RevenueCheck, RevenueCash, RevenueInvoice, RevenueCCY, TipCreditCard, TipCheck, TipCash, TipInvoice, PriorCreditCard, PriorCheck, PriorCash, CreditCardNo, CreditCardExpir, CreditCardORChkName, CreditCardORChkAddr, SecurityCode, NextAppomentDate, NextAppomentTime, NextAppointmentEndTime, ServicesForPet1, ServicesForPet2, ServicesForPet3, ServicesForPet4, ServicesForPet5, ServicesForPet6, Convert.ToInt32(AppointmentID), Session["AppointmentDate"].ToString(), Convert.ToDouble(txtProductPrice.Text), Convert.ToDouble(txtSalestax.Text), Revnue01, NameOnCheque, Bankname);
                
                objgroomer.Modify_AppointmentStatus(Convert.ToInt32(AppointmentID));
                
                objgroomer.GroomerUpdatePresentedStatus(AppointmentID);

                if (DLId > 0)
                {
                    Session["appt_end_time"] = null;

                    Session["appt_start_time"] = null;

                    Session["AptCompTime"] = null;

                    ObjGroomer.updateExcelExported(Convert.ToInt32(DLId), 0);

                    ObjGroomer.updateExcelExportedEndingMileage(Convert.ToInt32(DLId), 0);

                    ObjGroomer.InsertAppDate(DLId);

                    Session["LogID"] = DLId.ToString();

                    Session["CustLastName"] = "";

                    Session["JobM"] = "";

                    Session["zipCode"] = "";

                    Session["Pet"] = "";

                    Session["FT22"] = "";

                    Session["FT44"] = "";

                    Session["FT88"] = "";

                    Session["FT132"] = "";

                    Session["FTCat"] = "";

                    Session["TB"] = "";

                    Session["Wham"] = "";

                    Session["rdoRevenue"] = "";

                    Session["RevenuAmt"] = "";

                    Session["ExtraServices"] = "";

                    Session["Comments"] = "";

                    Session["rdoDrive"] = "";

                    Session["rdoPet"] = "";

                    Session["productPrice"] = "";

                    Session["SaleTax"] = "";

                    Session["rdoTip"] = "";

                    Session["tipAmt"] = "";

                    Session["rdoPrior"] = "";

                    Session["PriorRev"] = "";

                    Session["rdoRebookD"] = "";

                    Session["rday"] = "";

                    Session["rmonth"] = "";

                    Session["ryear"] = "";

                    Session["rAppStartTimeHr"] = "";

                    Session["rAppStartTimeMin1"] = "";

                    Session["rAppStartTimeMin"] = "";

                    Session["rAppEndTimeHr"] = "";

                    Session["rAppEndTimeMin1"] = "";

                    Session["rAppEndTimeMin"] = "";

                    Session["PageFrom"] = null;

                    Response.Redirect("Dashboard.aspx?msg=S", false);
                }
                #endregion
            }
            finally
            { }
        }

        protected void ProcessLogforNonRebook()
        {
            try
            {
                #region InsertDailyOperationLog code

                CreditCardNo = "";

                CreditCardExpir = "";

                CreditCardORChkName = "";

                CreditCardORChkAddr = "";

                SecurityCode = "";

                DLId = objgroomer.InsertDailyOperationLog(strGId, strVanID, strBeginningMileage, strTotalHours, strEndingMileage, strFuelPurchased, strPriceperGallon, CustomerName, Job, ZipCode, Pets, Rebook, FromRebook, New, TimeIn, TimeOut, PetTime, ExtraServices, comments, driveTime, rpetTime, FleaandTick22, FleaandTick44, FleaandTick88, FleaandTick132, FleaandTickCat, TB, Wham, RevenueCreditCard, RevenueCheck, RevenueCash, RevenueInvoice, RevenueCCY, TipCreditCard, TipCheck, TipCash, TipInvoice, PriorCreditCard, PriorCheck, PriorCash, CreditCardNo, CreditCardExpir, CreditCardORChkName, CreditCardORChkAddr, SecurityCode, NextAppomentDate, NextAppomentTime, NextAppointmentEndTime, ServicesForPet1, ServicesForPet2, ServicesForPet3, ServicesForPet4, ServicesForPet5, ServicesForPet6, Convert.ToInt32(AppointmentID), Session["AppointmentDate"].ToString(), Convert.ToDouble(txtProductPrice.Text), Convert.ToDouble(txtSalestax.Text), Revnue01, NameOnCheque, Bankname);
                
                objgroomer.Modify_AppointmentStatus(Convert.ToInt32(AppointmentID));

                objgroomer.GroomerUpdatePresentedStatus(AppointmentID);
                
                if (DLId > 0)
                {
                    Session["appt_end_time"] = null;

                    Session["appt_start_time"] = null;

                    Session["AptCompTime"] = null;

                    ObjGroomer.updateExcelExported(Convert.ToInt32(DLId), 0);

                    ObjGroomer.updateExcelExportedEndingMileage(Convert.ToInt32(DLId), 0);

                    ObjGroomer.InsertAppDate(DLId);

                    Session["LogID"] = DLId.ToString();

                    Session["CustLastName"] = "";

                    Session["JobM"] = "";

                    Session["zipCode"] = "";

                    Session["Pet"] = "";

                    Session["FT22"] = "";

                    Session["FT44"] = "";

                    Session["FT88"] = "";

                    Session["FT132"] = "";

                    Session["FTCat"] = "";

                    Session["TB"] = "";

                    Session["Wham"] = "";

                    Session["rdoRevenue"] = "";

                    Session["RevenuAmt"] = "";

                    Session["ExtraServices"] = "";

                    Session["Comments"] = "";

                    Session["rdoDrive"] = "";

                    Session["rdoPet"] = "";

                    Session["productPrice"] = "";

                    Session["SaleTax"] = "";

                    Session["rdoTip"] = "";

                    Session["tipAmt"] = "";

                    Session["rdoPrior"] = "";

                    Session["PriorRev"] = "";

                    Session["rdoRebookD"] = "";

                    Session["rday"] = "";

                    Session["rmonth"] = "";

                    Session["ryear"] = "";

                    Session["rAppStartTimeHr"] = "";

                    Session["rAppStartTimeMin1"] = "";

                    Session["rAppStartTimeMin"] = "";

                    Session["rAppEndTimeHr"] = "";

                    Session["rAppEndTimeMin1"] = "";

                    Session["rAppEndTimeMin"] = "";

                    Session["PageFrom"] = null;

                    Response.Redirect("Dashboard.aspx?msg=S", false);
                }
                #endregion
            }
            finally
            { }
        }

        public void InsertDailyOperationLog()
        {
            try
            {
                CustomerName = txtCustLastName.Text.Trim();

                Job = txtJob.Text.Trim();

                ZipCode = txtZipCode.Text.Trim();

                Pets = txtPets.Text.Trim();

                Rebook = rdoRebook.SelectedValue;

                string lbldesc = lbl_description.Text;

                string searchstring = lbldesc.Substring(0, 7);

                if (searchstring.Contains("RBK") || searchstring.Contains("REC"))
                {
                    FromRebook = "1";
                }
                else
                {
                    FromRebook = "0";
                }
                if (searchstring.Contains("*"))
                {
                    New = "1";
                }
                else
                {
                    New = "0";
                }

                TimeIn = lblApptStartTime.Text;

                TimeOut = lblApptEndTime.Text;

                PetTime = txtPetTime.Text;

                PetTime = lblApptCompleteTime.Text;

                ExtraServices = txtExtraServices.Text.Trim();

                comments = txtComments.Text.Trim();

                driveTime = rdoDriveTime.SelectedValue;

                rpetTime = rdoPetTime.SelectedValue;

                if (txtFleaandTick22.Text.Trim() != "") { FleaandTick22 = Convert.ToInt32(txtFleaandTick22.Text.Trim()); }
                if (txtFleaandTick44.Text.Trim() != "") { FleaandTick44 = Convert.ToInt32(txtFleaandTick44.Text.Trim()); }
                if (txtFleaandTick88.Text.Trim() != "") { FleaandTick88 = Convert.ToInt32(txtFleaandTick88.Text.Trim()); }
                if (txtFleaandTick132.Text.Trim() != "") { FleaandTick132 = Convert.ToInt32(txtFleaandTick132.Text.Trim()); }
                if (txtFleaandTickCat.Text.Trim() != "") { FleaandTickCat = Convert.ToInt32(txtFleaandTickCat.Text.Trim()); }
                if (txtTB.Text.Trim() != "") { TB = Convert.ToInt32(txtTB.Text.Trim()); }
                if (txtWham.Text.Trim() != "") { Wham = Convert.ToInt32(txtWham.Text.Trim()); }

                if (rdoRevenue.SelectedValue != "0") { RevenueCreditCard = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueCreditCard = Convert.ToDouble(txtRevenue.Text.Trim()); } }
                if (rdoRevenue.SelectedValue != "1") { RevenueCCY = 0; } else { if (txtRevenue.Text != "") { RevenueCCY = Convert.ToDouble(txtRevenue.Text.Trim()); } }
                if (rdoRevenue.SelectedValue != "2") { RevenueCheck = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueCheck = Convert.ToDouble(txtRevenue.Text.Trim()); } NameOnCheque = txtcname.Text.Trim(); Bankname = txtcaddr.Text.Trim(); }
                if (rdoRevenue.SelectedValue != "3") { RevenueCash = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueCash = Convert.ToDouble(txtRevenue.Text.Trim()); } }
                if (rdoRevenue.SelectedValue != "4") { RevenueInvoice = 0; } else { if (txtRevenue.Text.Trim() != "") { RevenueInvoice = Convert.ToDouble(txtRevenue.Text.Trim()); } }

                if (rdoTip.SelectedValue != "0") { TipCreditCard = 0; } else { if (txtTip.Text.Trim() != "") { TipCreditCard = Convert.ToDouble(txtTip.Text.Trim()); } }
                if (rdoTip.SelectedValue != "1") { TipCheck = 0; } else { if (txtTip.Text.Trim() != "") { TipCheck = Convert.ToDouble(txtTip.Text.Trim()); } NameOnCheque = txtcname.Text.Trim(); Bankname = txtcaddr.Text.Trim(); }
                if (rdoTip.SelectedValue != "2") { TipCash = 0; } else { if (txtTip.Text.Trim() != "") { TipCash = Convert.ToDouble(txtTip.Text.Trim()); } }
                if (rdoTip.SelectedValue != "3") { TipInvoice = 0; } else { if (txtTip.Text.Trim() != "") { TipInvoice = Convert.ToDouble(txtTip.Text.Trim()); } }

                if (rdoPrior.SelectedValue != "0") { PriorCreditCard = 0; } else { if (txtPriorRevenue.Text.Trim() != "") { PriorCreditCard = Convert.ToDouble(txtPriorRevenue.Text.Trim()); } }
                if (rdoPrior.SelectedValue != "1") { PriorCheck = 0; } else { if (txtPriorRevenue.Text.Trim() != "") { PriorCheck = Convert.ToDouble(txtPriorRevenue.Text.Trim()); } NameOnCheque = txtcname.Text.Trim(); Bankname = txtcaddr.Text.Trim(); }
                if (rdoPrior.SelectedValue != "2") { PriorCash = 0; } else { if (txtPriorRevenue.Text.Trim() != "") { PriorCash = Convert.ToDouble(txtPriorRevenue.Text.Trim()); } }

                if (txtProductPrice.Text == "")
                    txtProductPrice.Text = "0.0";
                if (txtSalestax.Text == "")
                    txtSalestax.Text = "0.0";

                if (rdoRevenue.SelectedValue == "0" || rdoRevenue.SelectedValue == "3")
                    Revnue01 = 0;
                else
                    Revnue01 = 1;

                if (rdoRevenue.SelectedValue == "0" || rdoTip.SelectedValue == "0" || rdoPrior.SelectedValue == "0")
                {
                }
                else
                {
                    CreditCardExpir = "";
                }

                if (rdoRebook.SelectedValue == "1")
                {
                    NextAppomentDate = ddlMonth.SelectedValue + "/" + dddDay.SelectedValue + "/" + ddlYear.SelectedValue;

                    NextAppomentTime = ddlhr.SelectedItem.Value + ":" + ddlMin1.SelectedValue + " " + ddlmin.SelectedItem.Value;

                    NextAppointmentEndTime = ddlEndTimeHrs.SelectedItem.Value + ":" + ddlEndTimeMin1.SelectedValue + " " + ddlEndTimeMin.SelectedItem.Value;

                    ServicesForPet1 = txtServicesforPet1.Text.Trim();

                    ServicesForPet2 = txtServicesforPet2.Text.Trim();

                    ServicesForPet3 = txtServicesforPet3.Text.Trim();

                    ServicesForPet4 = txtServicesforPet4.Text.Trim();

                    ServicesForPet5 = txtServicesforPet5.Text.Trim();

                    ServicesForPet6 = txtServicesforPet6.Text.Trim();
                }
                else
                {
                    NextAppomentDate = "";

                    NextAppomentTime = "";

                    NextAppointmentEndTime = "";

                    ServicesForPet1 = txtServicesforPet1.Text.Trim();

                    ServicesForPet2 = txtServicesforPet2.Text.Trim();

                    ServicesForPet3 = txtServicesforPet3.Text.Trim();

                    ServicesForPet4 = txtServicesforPet4.Text.Trim();

                    ServicesForPet5 = txtServicesforPet5.Text.Trim();

                    ServicesForPet6 = txtServicesforPet6.Text.Trim();
                }
                #region insert operations
                if (rdoRebook.SelectedValue == "1")
                {
                    if (rdoRevenue.SelectedValue.ToString() != "1")
                    {
                        if (rdoRevenue.SelectedValue.ToString() == "0" || rdoTip.SelectedValue.ToString() == "0" || rdoPrior.SelectedValue.ToString() == "0")
                        {
                            CreditCardNo = "";

                            CreditCardExpir = "";

                            CreditCardORChkName = "";

                            CreditCardORChkAddr = "";

                            SecurityCode = "";
                           
                            int RecID = objgroomer.InsertTempDailyOperationLog(strGId, strVanID, strBeginningMileage, strTotalHours, strEndingMileage, strFuelPurchased, strPriceperGallon, CustomerName, Job, ZipCode, Pets, Rebook, FromRebook, New, TimeIn, TimeOut, PetTime, ExtraServices, comments, driveTime, rpetTime, FleaandTick22, FleaandTick44, FleaandTick88, FleaandTick132, FleaandTickCat, TB, Wham, RevenueCreditCard, RevenueCheck, RevenueCash, RevenueInvoice, RevenueCCY, TipCreditCard, TipCheck, TipCash, TipInvoice, PriorCreditCard, PriorCheck, PriorCash, CreditCardNo, CreditCardExpir, CreditCardORChkName, CreditCardORChkAddr, SecurityCode, NextAppomentDate, NextAppomentTime, NextAppointmentEndTime, ServicesForPet1, ServicesForPet2, ServicesForPet3, ServicesForPet4, ServicesForPet5, ServicesForPet6, Convert.ToInt32(AppointmentID), Session["AppointmentDate"].ToString(), Convert.ToDouble(txtProductPrice.Text), Convert.ToDouble(txtSalestax.Text), Revnue01, NameOnCheque, Bankname);
                            
                            if (RecID > 0)
                            {
                                Session["AptDateFormat"] = lbl_time.Text;

                                Session["AptString"] = lbl_description.Text;

                                Session["DailyLogID"] = RecID.ToString();

                                Session["ApptTimings"] = ddlIN.SelectedItem.Text + "," + ddlOUT.SelectedItem.Text;

                                Response.Redirect("PaymentInfo.aspx", false);
                            }
                        }
                        else
                        {
                            InsertLog();
                        }
                    }
                    else
                    {
                        InsertLog();
                    }
                }
                else
                {
                    if (rdoRevenue.SelectedValue.ToString() != "1")
                    {
                        if (rdoRevenue.SelectedValue.ToString() == "0" || rdoTip.SelectedValue.ToString() == "0" || rdoPrior.SelectedValue.ToString() == "0")
                        {
                            CreditCardNo = "";

                            CreditCardExpir = "";

                            CreditCardORChkName = "";

                            CreditCardORChkAddr = "";

                            SecurityCode = "";

                            int RecID = objgroomer.InsertTempDailyOperationLog(strGId, strVanID, strBeginningMileage, strTotalHours, strEndingMileage, strFuelPurchased, strPriceperGallon, CustomerName, Job, ZipCode, Pets, Rebook, FromRebook, New, TimeIn, TimeOut, PetTime, ExtraServices, comments, driveTime, rpetTime, FleaandTick22, FleaandTick44, FleaandTick88, FleaandTick132, FleaandTickCat, TB, Wham, RevenueCreditCard, RevenueCheck, RevenueCash, RevenueInvoice, RevenueCCY, TipCreditCard, TipCheck, TipCash, TipInvoice, PriorCreditCard, PriorCheck, PriorCash, CreditCardNo, CreditCardExpir, CreditCardORChkName, CreditCardORChkAddr, SecurityCode, NextAppomentDate, NextAppomentTime, NextAppointmentEndTime, ServicesForPet1, ServicesForPet2, ServicesForPet3, ServicesForPet4, ServicesForPet5, ServicesForPet6, Convert.ToInt32(AppointmentID), Session["AppointmentDate"].ToString(), Convert.ToDouble(txtProductPrice.Text), Convert.ToDouble(txtSalestax.Text), Revnue01, NameOnCheque, Bankname);
                            
                            if (RecID > 0)
                            {
                                Session["AptDateFormat"] = lbl_time.Text;

                                Session["AptString"] = lbl_description.Text;

                                Session["DailyLogID"] = RecID.ToString();

                                Session["ApptTimings"] = ddlIN.SelectedItem.Text + "," + ddlOUT.SelectedItem.Text;

                                Response.Redirect("PaymentInfo.aspx", false);
                            }
                        }
                        else
                        {
                            ProcessLogforNonRebook();
                        }
                    }
                    else
                    {
                        ProcessLogforNonRebook();
                    }
                }
                #endregion
            }
            finally
            { }
        }

        public void clear()
        {
            txtFleaandTick22.Text = "";

            txtFleaandTick44.Text = "";

            txtFleaandTick88.Text = "";

            txtFleaandTick132.Text = "";

            txtFleaandTickCat.Text = "";

            txtTB.Text = "";

            txtWham.Text = "";

            txtJob.Text = ""; txtZipCode.Text = ""; txtPets.Text = "";

            ddlTimeIn.SelectedIndex = 0; ddlTimeout.SelectedIndex = 0; ddlMinIN.SelectedIndex = 0; ddlMinOUT.SelectedIndex = 0;

            txtPetTime.Text = "";

            ddlMonth.SelectedIndex = 0; ddlMonth.SelectedIndex = 0; ddlYear.SelectedIndex = 0;

            ddlhr.SelectedIndex = 0; ddlMin1.SelectedIndex = 0;

            txtServicesforPet1.Text = "";

            txtServicesforPet2.Text = "";

            txtServicesforPet3.Text = "";

            txtServicesforPet4.Text = "";

            txtServicesforPet5.Text = "";

            txtServicesforPet6.Text = "";

            btnSubmit.Enabled = false;
        }

        protected void rdoRevenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoRevenue.SelectedIndex == 2)
                {
                    chkdetails.Visible = true;

                    txtcname.TabIndex = 30;

                    txtcaddr.TabIndex = 31;

                    btnSubmit.TabIndex = 32;

                    rdoRevenue.Focus();
                }
                else if (rdoRevenue.SelectedIndex != 2 && rdoTip.SelectedIndex != 1 && rdoPrior.SelectedIndex != 1)
                {
                    chkdetails.Visible = false;

                    txtcname.TabIndex = 0;

                    txtcaddr.TabIndex = 0;

                    btnSubmit.TabIndex = 30;
                }
                ((RadioButtonList)sender).Focus();

                txtRevenue.Focus();
            }
            finally
            { }
        }

        protected void rdoTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoTip.SelectedIndex == 1)
                {
                    chkdetails.Visible = true;

                    txtcname.TabIndex = 30;

                    txtcaddr.TabIndex = 31;

                    btnSubmit.TabIndex = 32;
                }
                else if (rdoRevenue.SelectedIndex != 2 && rdoTip.SelectedIndex != 1 && rdoPrior.SelectedIndex != 1)
                {
                    chkdetails.Visible = false;

                    txtcname.TabIndex = 0;

                    txtcaddr.TabIndex = 0;

                    btnSubmit.TabIndex = 30;
                }
            }
            finally
            { }
        }

        protected void rdoPrior_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoPrior.SelectedIndex == 1)
                {
                    chkdetails.Visible = true;

                    txtcname.TabIndex = 30;

                    txtcaddr.TabIndex = 31;

                    btnSubmit.TabIndex = 32;
                }
                else if (rdoRevenue.SelectedIndex != 2 && rdoTip.SelectedIndex != 1 && rdoPrior.SelectedIndex != 1)
                {
                    chkdetails.Visible = false;

                    txtcname.TabIndex = 0;

                    txtcaddr.TabIndex = 0;

                    btnSubmit.TabIndex = 30;
                }
            }
            finally
            { }
        }

        protected void rdoRebook_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoRebook.SelectedValue.Equals("1"))
                {
                    divNextAppoint.Visible = true;

                    rdocnt = 1;
                }
                else
                {
                    divNextAppoint.Visible = false;

                    btnConfirm_Click(sender, EventArgs.Empty);

                    rdocnt = 0;
                }
            }
            finally
            { }
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

        protected void btnStartApt_Click(object sender, EventArgs e)
        {
            string appt_start_time = DateTime.Now.ToString("hh:mm:ss tt");

            Session["appt_start_time"] = appt_start_time;

            lblApptStartTime.Text = appt_start_time.ToString();

            btnStartApt.Enabled = false;

            btnEndApt.Enabled = true;

            GroomerMgr objGroomer = null;

            try
            {
                if (!(null == Session["AppointmentID"]))
                {
                    objGroomer = new GroomerMgr();

                    objGroomer.GroomerUpdateApptSTime(Convert.ToInt32(Session["AppointmentID"]), appt_start_time);
                }
            }
            finally
            {
                objGroomer = null;
            }
        }

        protected void btnEndApt_Click(object sender, EventArgs e)
        {
            string appt_end_time = "";
            try
            {
                lblAppSubmit.Text = "";
               
                appt_end_time = DateTime.Now.ToString("hh:mm:ss tt");

                Session["appt_end_time"] = appt_end_time;

                lblApptEndTime.Text = appt_end_time;

                if (lblApptStartTime.Text != "")
                {
                    string time_in = lblApptStartTime.Text;
     
                    string[] tmInlastpart = new string[2];

                    string[] tmOutlastpart = new string[2];

                    string[] arrcalcinhours = new string[3];

                    string[] arrcalcouthours = new string[3];

                    arrcalcinhours = lblApptStartTime.Text.Split(':');

                    arrcalcouthours = Session["appt_end_time"].ToString().Split(':');

                    string time_in_hr = arrcalcinhours[0].ToString();

                    string time_in_mm = arrcalcinhours[1].ToString();

                    tmInlastpart = arrcalcinhours[2].ToString().Split(' ');

                    string time_in_ss = tmInlastpart[0].ToString();

                    string time_in_pref = tmInlastpart[1].ToString();

                    string time_out_hr = arrcalcouthours[0].ToString();

                    string time_out_min = arrcalcouthours[1].ToString();

                    tmOutlastpart = arrcalcouthours[2].ToString().Split(' ');

                    string time_out_ss = tmOutlastpart[0].ToString();

                    string time_out_pref = tmOutlastpart[1].ToString();

                    string CalcInTime = String.Format("{0}:{1}:{2}{3}", time_in_hr, time_in_mm, time_in_ss, time_in_pref);

                    string CalcOutTime = String.Format("{0}:{1}:{2}{3}", time_out_hr, time_out_min, time_out_ss, time_out_pref);

                    TimeSpan tmDifference = DateTime.Parse(CalcOutTime) - DateTime.Parse(CalcInTime);

                    decimal time = Convert.ToDecimal(new TimeSpan(tmDifference.Hours, tmDifference.Minutes, 0).TotalHours);

                    lblApptCompleteTime.Text = Math.Round(time, 2).ToString();

                    Session["AptCompTime"] = lblApptCompleteTime.Text;

                    btnEndApt.Enabled = false;
                }
            }
            catch (Exception ex)
            {
            }

            GroomerMgr objGroomer = null;

            try
            {
                if (!(null == Session["AppointmentID"]))
                {
                    objGroomer = new GroomerMgr();

                    objGroomer.GroomerUpdateApptETime(Convert.ToInt32(Session["AppointmentID"]), appt_end_time);
                }
            }
            finally
            {
                objGroomer = null;
            }
        }

        protected void btnCheckAppointmentTime_Click(object sender, EventArgs e)
        {
            Response.Redirect("CalendarView.aspx");
        }

        public DataSet loadOldApp()
        {
            DataSet dsApps = new DataSet();

            dsApps = objgroomer.getOldApp(Session["GID"].ToString(), Convert.ToInt32(Session["AppointmentID"].ToString()));

            return dsApps;
        }

        protected void btnReschedule_Click(object sender, EventArgs e)
        {
            Response.Redirect("CalendarView.aspx?From=OP");
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Session["CustLastName"] = txtCustLastName.Text;

            Session["JobM"] = txtJob.Text;

            Session["zipCode"] = txtZipCode.Text;

            Session["Pet"] = txtPets.Text;

            Session["FT22"] = txtFleaandTick22.Text;

            Session["FT44"] = txtFleaandTick44.Text;

            Session["FT88"] = txtFleaandTick88.Text;

            Session["FT132"] = txtFleaandTick132.Text;

            Session["FTCat"] = txtFleaandTickCat.Text;

            Session["TB"] = txtTB.Text;

            Session["Wham"] = txtWham.Text;

            Session["RevenuAmt"] = txtRevenue.Text;

            Session["ExtraServices"] = txtExtraServices.Text;

            Session["Comments"] = txtComments.Text;

            Session["rdoDrive"] = rdoDriveTime.SelectedValue;

            Session["rdoPet"] = rdoPetTime.SelectedValue;

            Session["productPrice"] = txtProductPrice.Text;

            Session["SaleTax"] = txtSalestax.Text;

            Session["tipAmt"] = txtTip.Text;

            Session["PriorRev"] = txtPriorRevenue.Text;

            Session["rdoRebookD"] = rdoRebook.SelectedValue;

            Session["rday"] = dddDay.SelectedValue;

            Session["rmonth"] = ddlMonth.SelectedValue;

            Session["ryear"] = ddlYear.SelectedValue;

            Session["rAppStartTimeHr"] = ddlhr.SelectedValue;

            Session["rAppStartTimeMin1"] = ddlMin1.SelectedValue;

            Session["rAppStartTimeMin"] = ddlmin.SelectedValue;

            Session["rAppEndTimeHr"] = ddlEndTimeHrs.SelectedValue;

            Session["rAppEndTimeMin1"] = ddlEndTimeMin1.SelectedValue;

            Session["rAppEndTimeMin"] = ddlEndTimeMin.SelectedValue;

            Session["ServicesforPet1"] = txtServicesforPet1.Text;

            Session["ServicesforPet2"] = txtServicesforPet2.Text;

            Session["ServicesforPet3"] = txtServicesforPet3.Text;

            Session["ServicesforPet4"] = txtServicesforPet4.Text;

            Session["ServicesforPet5"] = txtServicesforPet5.Text;

            Session["ServicesforPet6"] = txtServicesforPet6.Text;

            Session["PageFrom"] = "Home";
        }
        protected void rdoDriveTime_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
        protected void rdoPetTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}