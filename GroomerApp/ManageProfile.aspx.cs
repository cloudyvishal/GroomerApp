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
    public partial class ManageProfile : System.Web.UI.Page
    {
        static string currPass = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            GroomerGetProfile();
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

        public void GroomerGetProfile()
        {
            GroomerMgr ObjUser = null;

            DataSet ds = null;

            try
            {
                ds = new DataSet();

                ObjUser = new GroomerMgr();

                ds = ObjUser.GroomerGetProfile(GId);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtEmailID.Text = ds.Tables[0].Rows[0]["UserName"].ToString();

                    txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();

                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();

                    txtHomePhone.Text = ds.Tables[0].Rows[0]["HomePhone"].ToString();

                    txtPersonalCellPhone.Text = ds.Tables[0].Rows[0]["PersonalCellPhone"].ToString();

                    txtCurrentPassword.Text = ds.Tables[0].Rows[0]["password"].ToString().Trim();

                    currPass = ds.Tables[0].Rows[0]["password"].ToString().Trim();

                    txtBaseCity.Text = ds.Tables[0].Rows[0]["BaseCity"].ToString().Trim();

                    txtState.Text = ds.Tables[0].Rows[0]["State"].ToString().Trim();

                    txtZipcode.Text = ds.Tables[0].Rows[0]["Zipcode"].ToString().Trim();

                    lblTimeZone.Text = ds.Tables[0].Rows[0]["GTimeZone"].ToString().Trim();
                }
            }
            finally
            {
                ObjUser = null;

                ds.Dispose();
            }
        }

        public void GroomerUpdateProfile()
        {
            GroomerMgr ObjUser = null;
            try
            {
                if (currPass == txtCurrentPassword.Text.Trim())
                {
                    if (txtCurrentPassword.Text.Trim() == txtNewPassword.Text.Trim())
                    {
                        ErrMessage("New Password cant be a Current password");
                    }
                    else
                    {
                        if (txtNewPassword.Text.Trim() == txtConfirmPassword.Text.Trim())
                        {
                            ObjUser = new GroomerMgr();

                            ObjUser.GroomerUpdateProfile(GId, txtEmailID.Text, txtNewPassword.Text.Trim(), txtName.Text, txtAddress.Text, txtHomePhone.Text, txtPersonalCellPhone.Text, txtBaseCity.Text, txtState.Text, txtZipcode.Text);

                            GroomerGetProfile();

                            SuccesfullMessage("Password updated successfully");
                        }
                        else
                        {
                            ErrMessage("Confirm Password Not matches with New Password");
                        }

                    }
                }
                else
                {
                    ErrMessage("Current Password is wrong!!!");
                }
            }
            finally
            {
                ObjUser = null;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                GroomerUpdateProfile();
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            GroomerMgr ObjUser = null;
            try
            {
                ObjUser = new GroomerMgr();

                ObjUser.GroomerUpdateProfile(GId, txtEmailID.Text, "", txtName.Text, txtAddress.Text, txtHomePhone.Text, txtPersonalCellPhone.Text, txtBaseCity.Text, txtState.Text, txtZipcode.Text);

                SuccesfullMessage("Profile updated successfully");
            }
            finally
            {
                ObjUser = null;
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