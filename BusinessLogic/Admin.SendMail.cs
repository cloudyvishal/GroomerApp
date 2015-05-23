using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Mail;

namespace BL.Admin.SendMail
{
    public class SendMail
    {
        public void AppointmentMail(string ToMail, string subject, string MailBody)
        {
            MailMessage msg = new MailMessage();

            msg.From = ConfigurationManager.AppSettings["FromEmail"];

            msg.To = ToMail;

            msg.Subject = subject;

            msg.BodyFormat = MailFormat.Html;

            msg.Priority = MailPriority.Normal;

            string message = MailBody;

            msg.Body = message;

            SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];

            SmtpMail.Send(msg);
        }

        public void PaymentMail(string p, string datenew, string Appoinment, string Appoinment_Date, string emailadd, string totalprice, string CC_Name, string mMessage, string Mailbody)
        {
            try
            {
                MailMessage msgpayment = new MailMessage();

                msgpayment.From = ConfigurationManager.AppSettings["FromEmail"];

                msgpayment.To = emailadd;

                msgpayment.Subject = "Payment Details For Fritzys Pet Care Pros Mobile Grooming Services";

                msgpayment.BodyFormat = MailFormat.Html;

                msgpayment.Priority = MailPriority.Normal;

                string payment_message = Mailbody;

                msgpayment.Body = payment_message;

                SmtpMail.SmtpServer = ConfigurationManager.AppSettings["SmtpServer"];

                SmtpMail.Send(msgpayment);
            }
            finally
            {
 
            }
        }
    }
}
