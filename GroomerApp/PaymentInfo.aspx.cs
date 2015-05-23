using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml.Linq;
using System.IO;
using CyberSource;
using BL.Admin.Groomer;
using GroomerApp.CyberSourceStore;

namespace GroomerApp
{
    public partial class PaymentInfo : System.Web.UI.Page
    {
        #region "Global Variable"

        string strGId;

        int DailyLogId;

        GroomerMgr objGroomer = new GroomerMgr();

        private ICSReply mReply;

        DataSet dsDtls;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(null == Session["GID"])) { strGId = Session["GID"].ToString(); } else { Response.Redirect("Default.aspx?Msg=Timeout", false); }
                if (null == Session["AptString"]) { Response.Redirect("dashboard.aspx", false); }
                if (!(null == Session["GID"]))
                {
                    strGId = Session["GID"].ToString();
                    if (!Page.IsPostBack)
                    {
                        AutofillDetails();

                        Session["Paycount"] = 1;

                        Session["IsExecuted"] = "0";
                    }
                }

                getAppointmentDtls();
            }
            finally
            {

            }
        }

        protected void AutofillDetails()
        {
            GroomerMgr objGroomer = null;

            try
            {
                DataSet Ds = new DataSet();

                objGroomer = new GroomerMgr();

                if (!(null == Session["DailyLogID"])) { DailyLogId = Convert.ToInt32(Session["DailyLogID"].ToString()); }

                decimal RevenueCost = 0, TipCost = 0, PriorRevenueCost = 0;

                Ds = objGroomer.GetAptdetails(DailyLogId);

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    if (!(String.IsNullOrEmpty(Ds.Tables[0].Rows[0]["RevenueCreditCard"].ToString())))
                    {
                        lblRevenueCost.Text = Math.Round(Convert.ToDouble(Ds.Tables[0].Rows[0]["RevenueCreditCard"].ToString()), 2).ToString();

                        RevenueCost = decimal.Parse(Ds.Tables[0].Rows[0]["RevenueCreditCard"].ToString());
                    }
                    if (!(String.IsNullOrEmpty(Ds.Tables[0].Rows[0]["TipCreditCard"].ToString())))
                    {
                        lblTipCost.Text = Math.Round(Convert.ToDouble(Ds.Tables[0].Rows[0]["TipCreditCard"].ToString()), 2).ToString();

                        TipCost = decimal.Parse(Ds.Tables[0].Rows[0]["TipCreditCard"].ToString());
                    }
                    if (!(String.IsNullOrEmpty(Ds.Tables[0].Rows[0]["PriorCreditCard"].ToString())))
                    {
                        lblPriorRevenueCost.Text = Math.Round(Convert.ToDouble(Ds.Tables[0].Rows[0]["PriorCreditCard"].ToString()), 2).ToString();

                        PriorRevenueCost = decimal.Parse(Ds.Tables[0].Rows[0]["PriorCreditCard"].ToString());
                    }

                    lblTotalCost.Text = Math.Round(Convert.ToDouble((RevenueCost + TipCost + PriorRevenueCost).ToString()), 2).ToString();

                    if (!(String.IsNullOrEmpty(Ds.Tables[0].Rows[0]["ZipCode"].ToString())))
                    {
                        txtZip.Text = Ds.Tables[0].Rows[0]["ZipCode"].ToString();

                    }
                    if (!(String.IsNullOrEmpty(Ds.Tables[0].Rows[0]["CustomerName"].ToString())))
                    {
                        string name = Ds.Tables[0].Rows[0]["CustomerName"].ToString();

                        txtLastName.Text = name;

                        txtCountry.Text = "USA";

                        txtState.Text = "CA";
                    }
                }
                if (!(null == Session["CardDetails"]))
                {

                    if (Session["CardDetails"] != "")
                    {
                        DataTable dtdetails = (DataTable)Session["CardDetails"];

                        foreach (DataRow dr in dtdetails.Rows)
                        {
                            txtFirstName.Text = dr[0].ToString();

                            txtLastName.Text = dr[1].ToString();

                            txtAddress1.Text = dr[2].ToString();

                            txtAddress2.Text = dr[3].ToString();

                            txtCity.Text = dr[4].ToString();

                            txtPhone.Text = dr[5].ToString();

                            drpCardType.SelectedValue = dr[6].ToString();

                            txtCardNumber.Text = dr[7].ToString();

                            drpMonth.SelectedValue = dr[8].ToString();

                            txtExpYear.Text = dr[9].ToString();

                            txtVerificationNo.Text = dr[10].ToString();
                        }
                    }
                }

            }
            finally
            {
                objGroomer = null;
            }
        }

        public void getAppointmentDtls()
        {
            try
            {
                if ((!(null == Session["AptDateFormat"])) && (!(null == Session["AptString"])))
                {
                    lbl_time.Text = Session["AptDateFormat"].ToString();

                    lbl_description.Text = Session["AptString"].ToString();
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

        protected string GetOrderRefNumber()
        {
            string OrdNumber = "";
            try
            {
                OrdNumber = (new Random()).Next().ToString();

                DataSet dsIsOrdnoPresent = objGroomer.CheckOrderRefNo(OrdNumber);

                if (dsIsOrdnoPresent.Tables[0].Rows.Count > 0)
                {
                    OrdNumber = GetOrderRefNumber();
                }

            }
            finally
            {

            }
            return OrdNumber;
        }

        protected void btnSubmitInfo_Click(object sender, EventArgs e)
        {
            string email = "info@fritzyspetcarepros.com";
            
            try
            {
                if (Page.IsValid.Equals(true))
                {
                    //check to avoid duplicate transactions.

                    if (!(null == Session["IsExecuted"]))
                    {
                        if (Session["IsExecuted"].Equals("0"))
                        {

                            Session["IsExecuted"] = "1";

                            if (!(null == Session["GID"]))
                            {

                                btnSubmitInfo.Enabled = false;
                                // set up Order number uniquely.
                                string OrderRefNo = GetOrderRefNumber();
                                Session["OrderNumber"] = OrderRefNo;

                                objGroomer.GetShopperInfo(GId, txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress1.Text.Trim(), txtAddress2.Text.Trim(), txtCity.Text.Trim(),
                                txtState.Text.Trim(), txtZip.Text.Trim(), txtCountry.Text.Trim(), txtPhone.Text.Trim(), email, drpCardType.SelectedItem.Text, txtCardNumber.Text.Trim(),
                                txtExpYear.Text.Trim(), drpMonth.SelectedValue, "", Convert.ToDecimal(lblTotalCost.Text),
                                decimal.Parse("0"), decimal.Parse("0"), OrderRefNo);

                                Session["emailid"] = email;
                                Session["totalprice"] = lblTotalCost.Text.Trim().ToString();
                                Session["CC_Name"] = txtFirstName.Text.Trim().ToString();
                                Session["CC_Name1"] = txtLastName.Text.Trim().ToString();

                                string errorMessage = (string)Session["ErrorMessage"];

                                Item[] shoppingCart = new Item[1];

                                shoppingCart[0].ProductName = "Pets Treatment";
                                shoppingCart[0].UnitPrice = Convert.ToDecimal(lblTotalCost.Text);
                                shoppingCart[0].Quantity = 1;
                                shoppingCart[0].TaxwareCode = "default";

                                Session["ShoppingCart"] = shoppingCart;

                                // set up customer info.
                                Shopper shopper;
                                shopper.FirstName = txtFirstName.Text.Trim();
                                shopper.LastName = txtLastName.Text.Trim();
                                // shopper.Email = txtEmail.Text.Trim();
                                shopper.Email = "info@fritzyspetcarepros.com";
                                Session["Shopper"] = shopper;
                                // set up address info.
                                Address address;
                                address.Address1 = txtAddress1.Text.Trim();
                                address.Address2 = txtAddress2.Text.Trim();
                                address.City = txtCity.Text.Trim();
                                address.State = txtState.Text.Trim();

                                address.Zip = txtZip.Text.Trim();
                                address.Country = txtCountry.Text.Trim();
                                address.Phone = txtPhone.Text.Trim();

                                Session["BillAddress"] = address;

                                // set up credit card info.
                                CreditCard card;
                                card.Number = txtCardNumber.Text.Trim();
                                card.ExpMonth = drpMonth.SelectedValue.ToString();
                                card.ExpYear = txtExpYear.Text.Trim();
                                card.CV = txtVerificationNo.Text.Trim();

                                GlobalManager global = (GlobalManager)Context.ApplicationInstance;

                                Authorize(global.icsClient, ref card);

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
                            }
                        }
                    }

                }
            }
            finally
            {

            }
        }

        private void Authorize(ICSClient client, ref CreditCard card)
        {
            try
            {
                // create request object
                ICSRequest request = new ICSRequest();

                // add general fields

                if (!(null == Session["OrderNumber"]))
                {
                    request["merchant_ref_number"] = (string)Session["OrderNumber"];
                }
                request["ics_applications"] = "ics_auth,ics_bill";
                request["currency"] = "USD";

                Shopper shopper = (Shopper)Session["Shopper"];
                Address billAddress = (Address)Session["BillAddress"];
                Address shipToAddress = (Address)Session["BillAddress"];

                // add shopper and address info
                GlobalManager.AddShopperFields(request, ref shopper);
                GlobalManager.AddBillAddressFields(request, ref billAddress);
                GlobalManager.AddShipToAddressFields(request, ref shipToAddress);

                // add an offer for the total amount
                if (lblTotalCost.Text != "")
                {
                    request["offer0"] = "amount:" + Convert.ToDecimal(lblTotalCost.Text);
                }
                // add credit card info
                request["customer_cc_number"] = card.Number;
                request["customer_cc_expmo"] = card.ExpMonth;
                request["customer_cc_expyr"] = card.ExpYear;
                request["customer_cc_cv_number"] = card.CV;

                // send request now

                mReply = client.Send(request);

                // extract needed information from mReply.  A couple of reply fields
                // are extracted below for example.

                //   string requestId = mReply["request_id"];


                // process the transaction as per response.
                HandleReply();

            }
            catch (BugException e)
            {
                Session["Exception"] = e;
                HandleReply();
                //  Response.Redirect("DisplayError.aspx", false);
            }
            catch (NonCriticalTransactionException e)
            {
                Session["Exception"] = e;
                HandleReply();
                //  Response.Redirect("DisplayError.aspx", false);
            }
            catch (CriticalTransactionException e)
            {
                // The transaction may have been successfully processed by
                // CyberSource.  Aside from redirecting to an error page, you should
                // make sure that someone gets notified of the occurrence of this
                // exception so that they could check the outcome of the transaction
                // on the CyberSource Support Screens.  For example, you could
                // post an event log or send an email to a monitored address.
                Session["Exception"] = e;
                HandleReply();
             
            }
        }

        protected int AddAppointmentDetails()
        {
            int ID = 0;

            try
            {

                DataSet dsapt = new DataSet();

                if (!(null == Session["DailyLogID"]))
                {
                    dsapt = objGroomer.GetAptdetails(Convert.ToInt32(Session["DailyLogID"].ToString()));
                }

                if (dsapt.Tables.Count > 0)
                {
                    if (dsapt.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow dr in dsapt.Tables[0].Rows)
                        {
                            try
                            {
                                ID = objGroomer.InsertDailyOperationLog(dr["Gid"].ToString(), dr["VanId"].ToString(), dr["BeginningMileage"].ToString(), dr["TotlaHours"].ToString(), dr["EndingMileage"].ToString(), dr["FuelPurchased"].ToString(), dr["PricePerGallon"].ToString(), dr["CustomerName"].ToString(), dr["Job"].ToString(), dr["ZipCode"].ToString(), dr["Pets"].ToString(), dr["Rebook"].ToString(), dr["FromRebook"].ToString(), dr["New"].ToString(), dr["TimeIn"].ToString(), dr["TimeOut"].ToString(), dr["PetTime"].ToString(), dr["ExtraServices"].ToString(), dr["Comments"].ToString(), dr["Drive_Time"].ToString(), dr["Pet_Time"].ToString(), Convert.ToInt32(dr["FleaandTick22"].ToString()), Convert.ToInt32(dr["FleaandTick44"].ToString()), Convert.ToInt32(dr["FleaandTick88"].ToString()), Convert.ToInt32(dr["FleaandTick132"].ToString()), Convert.ToInt32(dr["FleaandTickCat"].ToString()), Convert.ToInt32(dr["TB"].ToString()), Convert.ToInt32(dr["Wham"].ToString()), Convert.ToDouble(dr["RevenueCreditCard"].ToString()), Convert.ToDouble(dr["RevenueCheck"].ToString()), Convert.ToDouble(dr["RevenueCash"].ToString()), Convert.ToDouble(dr["RevenueInvoice"].ToString()), Convert.ToDouble(dr["RevenueCCY"].ToString()), Convert.ToDouble(dr["TipCreditCard"].ToString()), Convert.ToDouble(dr["TipCheck"].ToString()), Convert.ToDouble(dr["TipCash"].ToString()), Convert.ToDouble(dr["TipInvoice"].ToString()), Convert.ToDouble(dr["PriorCreditCard"].ToString()), Convert.ToDouble(dr["PriorCheck"].ToString()), Convert.ToDouble(dr["PriorCash"].ToString()), dr["CreditCardNo"].ToString(), dr["CreditCardExpir"].ToString(), dr["CreditCardORChkName"].ToString(), dr["CreditCardORChkAddr"].ToString(), dr["SecurityCode"].ToString(), dr["NextAppointmentDate"].ToString(), dr["NextAppointmentTime"].ToString(), dr["NextAppointmentEndTime"].ToString(), dr["ServicesForPet1"].ToString(), dr["ServicesForPet2"].ToString(), dr["ServicesForPet3"].ToString(), dr["ServicesForPet4"].ToString(), dr["ServicesForPet5"].ToString(), dr["ServicesForPet6"].ToString(), Convert.ToInt32(dr["AppointmentID"].ToString()), Session["AppointmentDate"].ToString(), Convert.ToDouble(dr["ProductPrice"].ToString()), Convert.ToDouble(dr["Salestax"].ToString()), Convert.ToInt32(dr["Rev01"].ToString()), dr["accholdername"].ToString(), dr["chequebank"].ToString());
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        int AppointmentID = 0;

                        if (Session["AppointmentID"] != null) { AppointmentID = Convert.ToInt32(Session["AppointmentID"].ToString()); }

                        objGroomer.Modify_AppointmentStatus(Convert.ToInt32(AppointmentID));

                        objGroomer.GroomerUpdatePresentedStatus(AppointmentID);

                        if (ID > 0)
                        {
                            Session["appt_end_time"] = null;

                            Session["appt_start_time"] = null;

                            Session["AptCompTime"] = null;

                            objGroomer.updateExcelExported(Convert.ToInt32(ID), 0);
                            objGroomer.updateExcelExportedEndingMileage(Convert.ToInt32(ID), 0);
                      
                            objGroomer.InsertAppDate(ID);

                        }

                    }
                }
            }
            finally
            {
            }
            return ID;
        }

        private void HandleReply()
        {
            try
            {

                string rFlag = "", ResponseID = "", Responsemsg = "", billtxnrefno = "", authCode = "";
                if (!(null == mReply))
                {
                    rFlag = mReply["ics_rflag"];
                    ResponseID = mReply["request_id"];
                    Responsemsg = mReply["ics_rmsg"];
                    billtxnrefno = mReply["bill_trans_ref_no"];
                    authCode = mReply["auth_auth_code"];
                }
                // For AVS Smart Authentication service.
                if (rFlag.Equals("DSETTINGS"))
                {
                    authCode = "SMART";
                }

                bool IsResponsefound = false;

                lblMessage.Text = "";
                lblReason.Text = "";
                string OrdNumber = (string)Session["OrderNumber"];
                int ID = 0;

                //DSETTINGS Response processed as a successfull transaction caused that will be captured by Merchant later by login through Cybersouce account.
                if (rFlag.Equals("SOK") || rFlag.Equals("DSETTINGS"))
                {
                    IsResponsefound = true;
                    ID = AddAppointmentDetails();
                    //new
                    Session["DailyLogID"] = "";
                }
                //update the response from payment gateway.
                objGroomer.UpdatePGResponseDetails(rFlag, ID.ToString(), ResponseID, Session["PayID"].ToString(), Responsemsg, billtxnrefno, authCode);

                if (rFlag.Equals("SOK") || rFlag.Equals("DSETTINGS"))
                {
                    IsResponsefound = true;
                    Session["AptString"] = null;
                    Response.Redirect("Dashboard.aspx?msg=P", false);
                }

                if (rFlag.Equals("DAVSNO"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Please verify that your address is correct.";

                }
                if (rFlag.Equals("DINVALIDADDRESS"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "City,state or postal code entered was invalid.";
                }
                else if (rFlag.Equals("DCALL"))
                {
                    IsResponsefound = true;
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    Session["ErrorMessage"] = "Your transaction can not be processed at this time,contact the payment processor to proceed with the transaction";
                    // handle DCALL appropriately.  You should at least notify someone
                    // so that they could call the payment processor.
                }
                else if (rFlag.Equals("DCARDEXPIRED"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Your card has expired.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);

                }
                else if (rFlag.Equals("DCARDREFUSED"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Card Authorization failed.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);

                }
                else if (rFlag.Equals("DCV"))
                {
                    IsResponsefound = true;
                    Session["ErrorMessage"] = "Incorrect Card Verification Number.";
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);

                }
                else if (rFlag.Equals("DINVALIDCARD"))
                {
                    IsResponsefound = true;
                   
                    Session["ErrorMessage"] = "Invalid credit card number.";
                    
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                   
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);

                }
                else if (rFlag.Equals("DRESTRICTED"))
                {
                    IsResponsefound = true;

                    Session["ErrorMessage"] = "declined restriced card.";
                   
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                   
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);

                }
                else if (rFlag.Equals("DSCORE"))
                {
                    IsResponsefound = true;

                    Session["ErrorMessage"] = "Card not successfully authenticated.";
                    
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                   
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);

                }
                else if (rFlag.Equals("ESYSTEM"))
                {
                    IsResponsefound = true;
                    
                    Session["ErrorMessage"] = "System Internal error.";
                   
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                   
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);

                }
                else if (rFlag.Equals("DINVALIDDATA"))
                {
                    IsResponsefound = true;
                   
                    Session["ErrorMessage"] = "Invalid Data";
                    
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                   
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);

                }
                else if (rFlag.Equals("ETIMEOUT"))
                {
                    IsResponsefound = true;
                   
                    Session["ErrorMessage"] = "Payment Transaction Timeout.";
                    
                    string msg = String.Format("Your payment transaction has been UnSuccessful. Your order number is {0}. Please keep it handy for your reference.", OrdNumber);
                    
                    string Transresult = String.Format("Transaction unsuccessful due to:" + (string)Session["ErrorMessage"]);


                }
                else if (rFlag.Equals(""))
                {
                    IsResponsefound = true;

                    Session["ErrorMessage"] = "Payment can not be processed please select another form of payment";
                }

                if (!(rFlag.Equals("SOK")))
                {
                    Session["IsExecuted"] = "0";
                    if (IsResponsefound.Equals(false))
                    {
                        Session["ErrorMessage"] = "Payment can not be processed please select another form of payment";
                    }

                    int PayCount = 0;
                    if (!(null == Session["Paycount"]))
                    {
                        PayCount = Convert.ToInt32(Session["Paycount"].ToString());
                    }

                    if (PayCount < 3)
                    {

                        btnSubmitInfo.Enabled = true;

                        txtFirstName.Focus();

                        if (!(null == Session["ErrorMessage"]))
                        {
                            lblMessage.Text = Session["ErrorMessage"].ToString() + " Please try again";

                            Session["Paycount"] = PayCount + 1;

                        }
                    }
                    else
                    {
                        int LogID = AddAppointmentDetails();

                        objGroomer.UpdateLogID(LogID, Session["PayID"].ToString());

                        Session["AptString"] = null;

                        Session["DailyLogID"] = "";

                        Response.Redirect("Dashboard.aspx?msg=U", false);

                    }
                }

            }
            finally
            {
            }
        }

        private void CalculateTax(ICSClient client)
        {
            try
            {
                // create request object
                ICSRequest request = new ICSRequest();

                // add general fields
                request["merchant_ref_number"] = (string)Session["OrderNumber"];
                request["ics_applications"] = "ics_tax";
                request["currency"] = "USD";

                Shopper shopper = (Shopper)Session["Shopper"];
                Address billAddress = (Address)Session["BillAddress"];
                Address shipToAddress = (Address)Session["BillAddress"];

                // add shopper and address info
                GlobalManager.AddShopperFields(request, ref shopper);
                GlobalManager.AddBillAddressFields(request, ref billAddress);
                GlobalManager.AddShipToAddressFields(request, ref shipToAddress);

                // add an offer for each item in the shopping cart
                ICSOffer offer;
                Item[] shoppingCart = (Item[])Session["ShoppingCart"];
                int i = 0;
                foreach (Item item in shoppingCart)
                {
                    offer = new ICSOffer();
                    offer["amount"] = item.UnitPrice.ToString();
                    offer["quantity"] = item.Quantity.ToString();
                    offer["product_code"] = item.TaxwareCode;
                    request.SetOffer(i++, offer);
                }

                // add another offer for shipping and handling
                offer = new ICSOffer();
                offer["amount"] = "0";
                // replace shipping_and_handling with a more appropriate
                // taxware S&H code.
                offer["product_code"] = "shipping_and_handling";
                request.SetOffer(i, offer);

                // send request now
                ICSReply reply = client.Send(request);

                // ics_rcode of 1 means the transaction was processed successfully.
                if (reply["ics_rcode"] != "1")
                {
                    Session["ErrorMessage"] = "Error calculating tax.";
                    Response.Redirect("DisplayError.aspx", false);
                }

                // extract information from reply

                decimal mTax = Decimal.Parse(reply["tax_total_tax"]);
                decimal mTotal = Decimal.Parse(reply["tax_total_grand"]);



            }
            catch (BugException e)
            {
                Session["Exception"] = e;
                Response.Redirect("DisplayError.aspx", false);
            }
            catch (NonCriticalTransactionException e)
            {
                Session["Exception"] = e;
                Response.Redirect("DisplayError.aspx", false);
            }
            catch (CriticalTransactionException e)
            {
                // no need to handle a CriticalTransactionException differently
                // for ics_tax.
                Session["Exception"] = e;
                Response.Redirect("DisplayError.aspx", false);
            }
        }


        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            lblTotalCost.Text = (decimal.Parse(lblRevenueCost.Text) + decimal.Parse(lblTipCost.Text) + decimal.Parse(lblPriorRevenueCost.Text)).ToString();

        }

        protected void btneditapt_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtdetails = new DataTable();
                dtdetails.Columns.Add("Firstname");
                dtdetails.Columns.Add("Lastname");
                dtdetails.Columns.Add("Address1");
                dtdetails.Columns.Add("Address2");
                dtdetails.Columns.Add("city");
                dtdetails.Columns.Add("phone");
                dtdetails.Columns.Add("cctype");
                dtdetails.Columns.Add("ccnumber");
                dtdetails.Columns.Add("expmonth");
                dtdetails.Columns.Add("expyear");
                dtdetails.Columns.Add("ccvno");

                DataRow dr = dtdetails.NewRow();
                dr[0] = txtFirstName.Text;
                dr[1] = txtLastName.Text;
                dr[2] = txtAddress1.Text;
                dr[3] = txtAddress2.Text;
                dr[4] = txtCity.Text;
                dr[5] = txtPhone.Text;
                dr[6] = drpCardType.SelectedValue.ToString();
                dr[7] = txtCardNumber.Text;
                dr[8] = drpMonth.SelectedValue.ToString();
                dr[9] = txtExpYear.Text;
                dr[10] = txtVerificationNo.Text;

                dtdetails.Rows.Add(dr);

                Session["CardDetails"] = dtdetails;

                Response.Redirect("Operations.aspx", false);
            }
            finally
            {
            }
        }
    }
}