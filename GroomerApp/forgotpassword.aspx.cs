using BL.Admin.Groomer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroomerApp
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            stylesheet.Href = Convert.ToString(Session["Style"]);

            if (!IsPostBack)
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                GroomerMgr ObjGroomer = new GroomerMgr();

                DataSet ds = new DataSet();

                ds = ObjGroomer.GrmmoerGetPassword(txtEmail.Text.Trim());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Sendmail(ds.Tables[0].Rows[0]["Name"].ToString(), ds.Tables[0].Rows[0]["UserName"].ToString(), ds.Tables[0].Rows[0]["UserName"].ToString(), ds.Tables[0].Rows[0]["Password"].ToString());
                    
                    SuccesfullMessage("Please check your mail account for username and password");
                    
                    txtEmail.Text = "";
                }
                else
                {
                    ErrMessage("Please enter correct email id.");

                    txtEmail.Text = "";
                }
            }
        }

        public void Sendmail(string FullName, string Email, string Username, string Password)
        {
            string Message = " <table cellpadding='5' cellspacing='0' width='50%' border='1' style='background:#F1EBE2;'>" +
              "<tr><td colspan='2'> Hello " + FullName.ToString() + ",<br> Your login details are as follows:.</td>" +
              "</tr><tr><td style='width:20%;'>Username :</td>" +
              "<td> " + Username + "</td>" +
              "</tr><tr><td>Password :</td>" +
              "<td> " + Password + "</td></tr>" +
              "<tr></tr></table>";

            MailMessage msg = new MailMessage();

            msg.From = ConfigurationManager.AppSettings["FromEmail"];

            msg.To = Email.ToString();

            msg.Subject = "Forgot Password";

            msg.BodyFormat = MailFormat.Html;

            msg.Priority = MailPriority.Normal;

            string message = Message;
            msg.Body = message;

            SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];

            SmtpMail.Send(msg);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
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