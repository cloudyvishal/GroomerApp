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
using BL.Admin.ContentManager;
using BL.Admin.SendMail;

namespace GroomerApp
{
    public partial class DisplaySuccess : System.Web.UI.Page
    {
        protected string mMessage;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GID"] != null)
            {
                string orderNumber = (string)Session["OrderNumber"];

                mMessage = String.Format("Thank you,Your payment transaction has been successful. Your payment number is {0}.  ", orderNumber);
            }
        }

        protected void btndone_Click(object sender, EventArgs e)
        {
            PaymentDoneMessage("Your payment is made for groomer service.");

            Session["OrderNumber"] = null;

            Session["AppointmentID"] = null;

            Response.Redirect("Dashboard.aspx");
        }

        private void PaymentDoneMessage(string body)
        {
            try
            {
                string Date_time = DateTime.Now.ToString();

                string datenew = Date_time.ToString();

                string Appoinment = Session["AppointmentID"].ToString();

                string Appoinment_Date = Session["AppointmentDate"].ToString();

                string emailadd = Session["emailid"].ToString();

                string totalprice = Session["totalprice"].ToString();

                string CC_Name1 = Session["CC_Name"].ToString();

                string CC_Name2 = Session["CC_Name1"].ToString();

                string CC_Name = CC_Name1 + "" + CC_Name2;

                string Mailbody = ContentManager.GetStaticeContentEmail("PaymentEmail.htm").Replace("~", "#");

                Mailbody = Mailbody.Replace("<!-- Date -->", Date_time);

                Mailbody = Mailbody.Replace("<!-- Appoinment -->", Appoinment);

                Mailbody = Mailbody.Replace("<!-- Appoinment_Date -->", Appoinment_Date);

                Mailbody = Mailbody.Replace("<!-- Total_Amount -->", totalprice);

                Mailbody = Mailbody.Replace("<!-- CC_Name -->", CC_Name);

                Mailbody = Mailbody.Replace("<!-- Details -->", mMessage);

                SendMail ObjMail = new SendMail();

                ObjMail.PaymentMail(ConfigurationManager.AppSettings["FromEmail"].ToString(), datenew, Appoinment, Appoinment_Date, emailadd, totalprice, CC_Name, mMessage, Mailbody);
            }
            finally
            {
 
            }
        }

        protected void Page_Init(object Sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            
            Response.Cache.SetNoStore();

            Response.Expires = -1500;
            
            Response.CacheControl = "no-cache";
            
            Response.Cache.SetExpires(DateTime.Now);
        }

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
    }
}