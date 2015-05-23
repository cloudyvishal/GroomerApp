using System;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.SessionState;
using System.Collections.Generic;

using CyberSource;
using BL.Admin.CheckBrowserOrigin;
using System.IO;
using System.Configuration;
using System.Text;

namespace GroomerApp.CyberSourceStore
{
    public struct Item
    {
        public string ProductName;
        public decimal UnitPrice;
        public int Quantity;
        public string TaxwareCode;
    }

    public struct Shopper
    {
        public string FirstName;
        public string LastName;
        public string Email;
    }

    public struct Address
    {
        public string Address1;
        public string Address2;
        public string City;
        public string State;
        public string Zip;
        public string Country;
        public string Phone;
    }

    public struct CreditCard
    {
        public string Number;
        public string ExpMonth;
        public string ExpYear;
        public string CV;
    }
    public class GlobalManager : System.Web.HttpApplication
    {
        public CyberSource.ICSClient icsClient;

		private System.ComponentModel.IContainer components;

        public GlobalManager()
		{
			InitializeComponent();
		}

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            if (Session["HomePath"] == null)
            {
                Session["HomePath"] = System.Configuration.ConfigurationManager.AppSettings["HomePath"];
            }


            if (CheckBrowser.isMobileBrowser())
            {
                Session["Style"] = CheckBrowser.MobileCss;
            }
            else
            {
                Session["Style"] = CheckBrowser.DeviceCss;
            }
        }

        public static string Amount2String(decimal amount)
        {
            return (String.Format("{0:c}", amount));
        }

        public static void AddShopperFields(ICSRequest request, ref Shopper shopper)
        {
            request["customer_firstname"] = shopper.FirstName;
            request["customer_lastname"] = shopper.LastName;
            request["customer_email"] = shopper.Email;
        }

        public static void AddBillAddressFields(
            ICSRequest request, ref Address billAddress)
        {
            request["bill_address1"] = billAddress.Address1;
            if (billAddress.Address2 != null &&
                billAddress.Address2.Length > 0)
            {
                request["bill_address2"] = billAddress.Address2;
            }
            request["bill_city"] = billAddress.City;
            request["bill_state"] = billAddress.State;
            request["bill_zip"] = billAddress.Zip;
            request["bill_country"] = billAddress.Country;
            request["customer_phone"] = billAddress.Phone;
        }

        public static void AddShipToAddressFields(
           ICSRequest request, ref Address shipToAddress)
        {
            request["ship_to_address1"] = shipToAddress.Address1;
            if (shipToAddress.Address2 != null &&
                shipToAddress.Address2.Length > 0)
            {
                request["ship_to_address2"] = shipToAddress.Address2;
            }
            request["ship_to_city"] = shipToAddress.City;
            request["ship_to_state"] = shipToAddress.State;
            request["ship_to_zip"] = shipToAddress.Zip;
            request["ship_to_country"] = shipToAddress.Country;
            request["ship_to_phone"] = shipToAddress.Phone;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Get exception
            Exception lastException = Server.GetLastError();

            // Check if exception is not null
            if (lastException != null)
            {
                // Get message from exception
                string error = lastException.Message;

                // Check if inner exception is not null
                if (lastException.InnerException != null)
                {
                    // Append message from inner exception to variable of type 'string' containing exception
                    error += lastException.InnerException.Message;

                    // Append stack trace from inner exception to variable of type 'string' containing exception
                    error += lastException.InnerException.StackTrace;
                }

                // Log exception details
                string fileName = "ErrorLogFile" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

                if (File.Exists(fileName))
                {
                    FileStream fs = File.Create(ConfigurationManager.AppSettings["ErrerLogPath"] + fileName);
                }

                StringBuilder inputParameter = null;

                try
                {
                    inputParameter = new StringBuilder();

                    inputParameter.Append("Error Message: ");

                    inputParameter.Append(error);

                    inputParameter.Append(Environment.NewLine);

                    inputParameter.Append(Environment.NewLine);

                    inputParameter.Append("  Error Timestamp: ");

                    inputParameter.Append(DateTime.Now.ToString());

                    inputParameter.Append(Environment.NewLine);

                    inputParameter.Append("------------------------------------------");

                    inputParameter.Append(Environment.NewLine);

                    //File.AppendAllText(ConfigurationManager.AppSettings["ErrerLogPath"] + fileName, inputParameter.ToString());
                }
                finally
                {
                    inputParameter = null;
                }
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            this.icsClient = new CyberSource.ICSClient(this.components);

            this.icsClient.HTTPProxyPassword = ((string)(configurationAppSettings.GetValue("icsClient.HTTPProxyPassword", typeof(string))));
            this.icsClient.HTTPProxyURL = ((string)(configurationAppSettings.GetValue("icsClient.HTTPProxyURL", typeof(string))));
            this.icsClient.HTTPProxyUsername = ((string)(configurationAppSettings.GetValue("icsClient.HTTPProxyUsername", typeof(string))));
            this.icsClient.KeysDir = ((string)(configurationAppSettings.GetValue("icsClient.KeysDir", typeof(string))));
            this.icsClient.LogFile = ((string)(configurationAppSettings.GetValue("icsClient.LogFile", typeof(string))));
            this.icsClient.LogLevel = ((string)(configurationAppSettings.GetValue("icsClient.LogLevel", typeof(string))));
            this.icsClient.LogMaxSize = ((int)(configurationAppSettings.GetValue("icsClient.LogMaxSize", typeof(int))));
            this.icsClient.MerchantId = ((string)(configurationAppSettings.GetValue("icsClient.MerchantId", typeof(string))));
            this.icsClient.RetryEnabled = ((string)(configurationAppSettings.GetValue("icsClient.RetryEnabled", typeof(string))));
            this.icsClient.RetryStart = ((int)(configurationAppSettings.GetValue("icsClient.RetryStart", typeof(int))));
            this.icsClient.ServerHost = ((string)(configurationAppSettings.GetValue("icsClient.ServerHost", typeof(string))));
            this.icsClient.ServerId = ((string)(configurationAppSettings.GetValue("icsClient.ServerId", typeof(string))));
            this.icsClient.ServerPort = ((int)(configurationAppSettings.GetValue("icsClient.ServerPort", typeof(int))));
            this.icsClient.ThrowLogException = ((string)(configurationAppSettings.GetValue("icsClient.ThrowLogException", typeof(string))));
            this.icsClient.Timeout = ((int)(configurationAppSettings.GetValue("icsClient.Timeout", typeof(int))));

        }
    }
}