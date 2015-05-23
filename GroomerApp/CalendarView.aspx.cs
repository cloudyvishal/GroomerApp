using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BL.Admin.Groomer;

namespace GroomerApp
{
    public partial class CalendarView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void calDate_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now.Date)
            {
            }
        }

        protected void calDate_SelectionChanged(object sender, EventArgs e)
        {
            GroomerMgr objGroomer = null;

            try
            {
                lbldtval.Text = Convert.ToDateTime(calapptDate.SelectedDate.Date.ToString()).Date.ToString("dd-MMM-yyyy");

                objGroomer = new GroomerMgr();

                PnldispAppt.Visible = true;

                Pnldispapptdet.Visible = false;

                DataTable dtAppts = new DataTable();

                dtAppts.Columns.Add("TIME");

                dtAppts.Columns.Add("ZIPCODE");

                dtAppts.Columns.Add("CNAME");

                dtAppts.Columns.Add("APPOINTMENTID");

                int iGId = 0;

                if (!(null == Session["GID"]))
                {
                    iGId = Convert.ToInt32(Session["GID"].ToString());
                }

                int tm_min = 0;

                string Start_Index = "";

                for (int time = 6; time <= 21; time++)
                {
                    DataSet dsAppt = new DataSet();

                    dsAppt = objGroomer.GetApptSchedules(Convert.ToDateTime(calapptDate.SelectedDate.Date.ToString()), time, iGId);

                    string ampm = " AM";

                    string STime = time.ToString();

                    string MTime = time.ToString();
                    if (time >= 12)
                    {
                        ampm = " PM";

                        if (time != 12)
                        {
                            MTime = (time - 12).ToString();
                        }
                    }

                    string tm = MTime.ToString() + ":00" + ampm;

                    if (dsAppt.Tables.Count > 0)
                    {
                        if (dsAppt.Tables[0].Rows.Count > 0)
                        {
                            int Record_Count = 0;

                            int RowsAdded = 0;

                            tm_min = 0;

                            foreach (DataRow dr in dsAppt.Tables[0].Rows)
                            {
                                Record_Count++;

                                tm_min = 0;

                                string fromhh = "", fromm = "", tohh = "", tomm = "";

                                if (dr["FROMHOURS"].ToString() != "" && dr["FROMMINUTES"].ToString() != "" && dr["TOHOURS"].ToString() != "" && dr["TOMINUTES"].ToString() != "")
                                {

                                    fromhh = dr["FROMHOURS"].ToString();

                                    fromm = dr["FROMMINUTES"].ToString();

                                    tohh = dr["TOHOURS"].ToString();

                                    tomm = dr["TOMINUTES"].ToString();


                                }
                                string NextFromHours = "", NextFromMins = "", NextToHours = "", NextToMins = "";

                                int Nextrowid = Record_Count;

                                if (Record_Count < dsAppt.Tables[0].Rows.Count)
                                {
                                    NextFromHours = dsAppt.Tables[0].Rows[Nextrowid]["FROMHOURS"].ToString();

                                    NextFromMins = dsAppt.Tables[0].Rows[Nextrowid]["FROMMINUTES"].ToString();

                                    NextToHours = dsAppt.Tables[0].Rows[Nextrowid]["TOHOURS"].ToString();

                                    NextToMins = dsAppt.Tables[0].Rows[Nextrowid]["TOMINUTES"].ToString();
                                }

                                bool IsValidEntry = true;

                                if (dsAppt.Tables[0].Rows.Count > 0 && Record_Count > 1 && Convert.ToInt32(STime) == Convert.ToInt32(fromhh))
                                {
                                    int rcount = 1;

                                    foreach (DataRow datarows in dsAppt.Tables[0].Rows)
                                    {
                                        if (rcount < Record_Count)
                                        {
                                            if (Convert.ToInt32(fromhh) == Convert.ToInt32(datarows["FROMHOURS"]) && Convert.ToInt32(fromhh) <= Convert.ToInt32(datarows["TOHOURS"])
                                            && Convert.ToInt32(fromm) >= Convert.ToInt32(datarows["FROMMINUTES"]) && Convert.ToInt32(fromm) <= 60
                                                && (Convert.ToInt32(tohh) > Convert.ToInt32(fromhh) && Convert.ToInt32(tomm) > 0 && Convert.ToInt32(fromm) > 0) && Convert.ToInt32(fromm) != 45)
                                            {
                                                IsValidEntry = false;

                                                break;
                                            }
                                        }
                                        rcount++;
                                    }
                                }

                                if (!(null == Session["STIME"]) && !(null == Session["RowsAdded"]))
                                {
                                    int radded = Convert.ToInt32(Session["RowsAdded"]);

                                    string ST = Session["STIME"].ToString();

                                    if (radded == 4 && ST.Equals(STime))
                                    {
                                        IsValidEntry = false;
                                    }

                                    Session["RowsAdded"] = null;

                                    Session["STIME"] = null;
                                }


                                if (IsValidEntry.Equals(false))
                                {
                                    break;
                                }
                                int range1 = 0, range2 = 15;

                                for (int i = 0; i < 4; i++)
                                {
                                    Session["IsNextRowValue"] = "";
                                    if (fromm != "")
                                    {
                                        bool IsBlankRow = true;

                                        if (!(null == Session["RangeOne"]) && !(null == Session["RangeTwo"]) && !(null == Session["Loop-Range"]))
                                        {
                                            if (Session["RangeOne"].ToString() != "")
                                            {
                                                range1 = Convert.ToInt32(Session["RangeOne"].ToString());

                                                Session["RangeOne"] = "";

                                            }
                                            if (Session["RangeTwo"].ToString() != "")
                                            {
                                                range2 = Convert.ToInt32(Session["RangeTwo"].ToString());

                                                Session["RangeTwo"] = "";

                                            }
                                            if (Session["Loop-Range"].ToString() != "")
                                            {
                                                i = Convert.ToInt32(Session["Loop-Range"].ToString());

                                                Session["Loop-Range"] = "";
                                            }
                                        }
                                        int counter = Record_Count;

                                        while (counter < dsAppt.Tables[0].Rows.Count)
                                        {
                                            string NextFHours = dsAppt.Tables[0].Rows[counter]["FROMHOURS"].ToString();

                                            string NextFMins = dsAppt.Tables[0].Rows[counter]["FROMMINUTES"].ToString();

                                            string NextTHours = dsAppt.Tables[0].Rows[counter]["TOHOURS"].ToString();

                                            string NextTMins = dsAppt.Tables[0].Rows[counter]["TOMINUTES"].ToString();

                                            if ((Convert.ToInt32(NextFMins) >= range1 && Convert.ToInt32(NextFMins) < range2 && NextFHours.Equals(fromhh) && NextTHours.Equals(fromhh)))
                                            {
                                                IsBlankRow = false;

                                                Session["IsNextRowValue"] = "1";

                                                break;
                                            }
                                            counter++;
                                        }
                                        if ((Convert.ToInt32(fromm) < range2 && Convert.ToInt32(fromhh) == Convert.ToInt32(STime)) || (Convert.ToInt32(fromm) <= range1 && range2 <= 60 && Convert.ToInt32(fromhh) == Convert.ToInt32(STime)))
                                        {
                                            IsBlankRow = false;
                                        }

                                        bool IsValidRec = true;

                                        if ((Convert.ToInt32(fromhh) != Convert.ToInt32(STime) && Convert.ToInt32(tohh) != Convert.ToInt32(STime))
                                            || (Convert.ToInt32(tohh) == Convert.ToInt32(STime) && tomm.Equals("0")))
                                        {
                                            IsValidRec = false;
                                        }

                                        if ((Convert.ToInt32(fromhh) <= Convert.ToInt32(STime) && Convert.ToInt32(tomm) > range1 && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && range1 > Convert.ToInt32(fromm)) || (Convert.ToInt32(fromhh) <= Convert.ToInt32(STime) && Convert.ToInt32(tomm) > range1 && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Convert.ToInt32(fromhh) != Convert.ToInt32(tohh)))
                                        {
                                            IsBlankRow = false;

                                        }

                                        bool IsNextr = false;
                                        if (!(null == Session["IsNextRowValue"]))
                                        {
                                            if (Session["IsNextRowValue"].ToString().Equals("1"))
                                            {
                                                IsNextr = true;
                                            }
                                        }
                                        if (Convert.ToInt32(fromhh) == Convert.ToInt32(STime) && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Convert.ToInt32(fromm) > range1 && Convert.ToInt32(fromm) > range2 && IsNextr.Equals(false))
                                        {
                                            IsBlankRow = true;
                                        }

                                        if ((Convert.ToInt32(fromhh) < Convert.ToInt32(STime) && Convert.ToInt32(tohh) > Convert.ToInt32(STime)))
                                        {
                                            IsBlankRow = false;

                                            IsValidRec = true;
                                        }

                                        if ((Convert.ToInt32(tomm) <= range1 && IsNextr.Equals(false) || Convert.ToInt32(fromm) > range2) && Convert.ToInt32(fromhh) == Convert.ToInt32(STime) && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && IsNextr.Equals(false))
                                        {
                                            IsBlankRow = true;
                                        }
                                        if (i <= 3 && IsValidRec.Equals(false) && dsAppt.Tables[0].Rows.Count == Record_Count)
                                        {
                                            IsValidRec = true;
                                        }

                                        if (Record_Count < dsAppt.Tables[0].Rows.Count)
                                        {
                                            if ((Convert.ToInt32(NextFromHours) == Convert.ToInt32(fromhh) && Convert.ToInt32(NextFromMins) == 45
                                  && Convert.ToInt32(NextToHours) == Convert.ToInt32(fromhh) + 1 &&
                                    Convert.ToInt32(NextToMins) == 0 && range1 >= 45) || (Convert.ToInt32(NextFromHours) == Convert.ToInt32(fromhh)
                                                && range1 >= Convert.ToInt32(NextFromMins) && Convert.ToInt32(NextToHours) == Convert.ToInt32(fromhh)
                                                && Convert.ToInt32(NextFromMins) > 0))
                                            {

                                                IsValidRec = false;

                                                Session["RangeOne"] = range1.ToString();

                                                Session["RangeTwo"] = range2.ToString();

                                                i = i + 1;

                                                Session["Loop-Range"] = i.ToString();

                                                break;

                                            }
                                        }

                                        if (IsBlankRow.Equals(true))
                                        {
                                            if (IsValidRec.Equals(true))
                                            {
                                                DataRow dtrow = dtAppts.NewRow();

                                                if (i == 0)
                                                {
                                                    dtrow[0] = tm;

                                                    Start_Index = tm;
                                                }
                                                else
                                                {
                                                    dtrow[0] = "";
                                                }
                                                dtrow[1] = "";

                                                dtrow[2] = "";

                                                dtrow[3] = "";

                                                dtAppts.Rows.Add(dtrow);

                                                RowsAdded++;

                                                Session["IsNextRowValue"] = "";

                                                Session["STIME"] = STime;

                                                Session["RowsAdded"] = RowsAdded.ToString();
                                            }
                                        }
                                        else
                                        {
                                            if (IsValidRec.Equals(true))
                                            {
                                                DataRow dtrow = dtAppts.NewRow();

                                                if (i == 0)
                                                {
                                                    dtrow[0] = tm;
                                                }
                                                else
                                                {
                                                    dtrow[0] = "";
                                                }

                                                if (!(null == Session["IsNextRowValue"]))
                                                {
                                                    if (Session["IsNextRowValue"].ToString() != "")
                                                    {
                                                        dtrow[1] = dsAppt.Tables[0].Rows[Nextrowid][1].ToString();

                                                        dtrow[2] = dsAppt.Tables[0].Rows[Nextrowid][2].ToString();

                                                        dtrow[3] = dsAppt.Tables[0].Rows[Nextrowid][9].ToString();
                                                    }
                                                    else
                                                    {
                                                        dtrow[1] = dr[1].ToString();

                                                        dtrow[2] = dr[2].ToString();

                                                        dtrow[3] = dr[9].ToString();
                                                    }
                                                }
                                                else
                                                {
                                                    dtrow[1] = dr[1].ToString();

                                                    dtrow[2] = dr[2].ToString();

                                                    dtrow[3] = dr[9].ToString();
                                                }
                                                dtAppts.Rows.Add(dtrow);

                                                RowsAdded++;

                                                Session["IsNextRowValue"] = "";

                                                Session["STIME"] = STime;

                                                Session["RowsAdded"] = RowsAdded.ToString();
                                            }
                                        }
                                        if (Convert.ToInt32(tomm) == range2 && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Record_Count < dsAppt.Tables[0].Rows.Count)
                                        {
                                            range1 = range1 + 15;

                                            range2 = range2 + 15;

                                            Session["RangeOne"] = range1.ToString();

                                            Session["RangeTwo"] = range2.ToString();

                                            i = i + 1;

                                            Session["Loop-Range"] = i.ToString();

                                            break;
                                        }
                                        if (Convert.ToInt32(tomm) <= range2 && Convert.ToInt32(tohh) == Convert.ToInt32(STime) && Convert.ToInt32(fromhh) == Convert.ToInt32(STime) && Record_Count < dsAppt.Tables[0].Rows.Count)
                                        {
                                            range1 = range1 + 15;

                                            range2 = range2 + 15;

                                            Session["RangeOne"] = range1.ToString();

                                            Session["RangeTwo"] = range2.ToString();

                                            i = i + 1;

                                            tm_min = 0;

                                            Session["Loop-Range"] = i.ToString();

                                            break;

                                        }

                                        bool IsValidRange = true;

                                        int row = 0;

                                        int rindx = 0;

                                        int rcnt = 0;

                                        if (Convert.ToInt32(STime) == Convert.ToInt32(tohh))
                                        {

                                            foreach (DataRow drs in dsAppt.Tables[0].Rows)
                                            {
                                                if (Convert.ToInt32(STime) == Convert.ToInt32(drs["FROMHOURS"].ToString()))
                                                {
                                                    rindx = rcnt;
                                                }
                                                rcnt++;
                                            }

                                            foreach (DataRow drs in dsAppt.Tables[0].Rows)
                                            {
                                                if (row > rindx)
                                                {
                                                    if (Convert.ToInt32(drs["TOHOURS"].ToString()) >= Convert.ToInt32(fromhh)
                                                          && Convert.ToInt32(drs["TOMINUTES"].ToString()) > Convert.ToInt32(tomm)
                                                        && Convert.ToInt32(STime) == Convert.ToInt32(drs["TOHOURS"].ToString()) && Convert.ToInt32(tomm) > 0)
                                                    {
                                                        range1 = range1 + 15;

                                                        range2 = range2 + 15;

                                                        Session["RangeOne"] = range1.ToString();

                                                        Session["RangeTwo"] = range2.ToString();

                                                        i = i + 1;

                                                        Session["Loop-Range"] = i.ToString();

                                                        IsValidRange = false;
                                                    }

                                                }
                                                row++;
                                            }
                                        }
                                        if (IsValidRange.Equals(false))
                                        {
                                            break;
                                        }

                                        if (IsValidRec.Equals(true))
                                        {
                                            range1 = range1 + 15;
                                            range2 = range2 + 15;
                                        }

                                        if (RowsAdded == 3 && i == RowsAdded)
                                        {
                                            i = i - 1;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                DataRow dtrow = dtAppts.NewRow();

                                if (i == 0)
                                {
                                    dtrow[0] = tm;
                                }
                                else
                                {
                                    dtrow[0] = "";
                                }

                                dtrow[1] = "";

                                dtrow[2] = "";

                                dtrow[3] = "";

                                dtAppts.Rows.Add(dtrow);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {

                            DataRow dtrow = dtAppts.NewRow();
                            if (i == 0)
                            {
                                dtrow[0] = tm;
                            }
                            else
                            {
                                dtrow[0] = "";
                            }
                            dtrow[1] = "";
                            dtrow[2] = "";
                            dtrow[3] = "";
                            dtAppts.Rows.Add(dtrow);
                        }
                    }
                }
                if (dtAppts.Rows.Count > 0)
                {
                    gvapptdet.DataSource = dtAppts;
                    gvapptdet.DataBind();
                }
            }
            finally
            {

            }
        }

        protected void lnkbtntime_Click(object sender, EventArgs e)
        {

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Pnldispapptdet.Visible = false;
            PnldispAppt.Visible = true;
        }

        protected void gvapptdet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("View"))
            {
                string AptID = e.CommandArgument.ToString();

                if (AptID != "")
                {
                    GroomerMgr objGroomer = new GroomerMgr();

                    DataSet dsAptDetails = objGroomer.getAppointmentAllDetails(AptID);
                    if (dsAptDetails.Tables.Count > 0)
                    {
                        if (dsAptDetails.Tables[0].Rows.Count > 0)
                        {
                            lblcustnameval.Text = dsAptDetails.Tables[0].Rows[0]["CUSTOMERNAME"].ToString();

                            lblapptstrval.Text = dsAptDetails.Tables[0].Rows[0]["OTHERS"].ToString();

                            if (dsAptDetails.Tables[0].Rows[0]["EXPSTARTTIME"].ToString() != "")
                            {
                                if (dsAptDetails.Tables[0].Rows[0]["EXPSTARTTIME"].ToString().Contains(":"))
                                {
                                    string[] arrstime = new string[3];

                                    string[] arrtttime = new string[2];

                                    arrstime = dsAptDetails.Tables[0].Rows[0]["EXPSTARTTIME"].ToString().Split(':');

                                    arrtttime = arrstime[2].Split(' ');

                                    lblapptexpstimeval.Text = arrstime[0].ToString() + ":" + arrstime[1].ToString() + " " + arrtttime[1].ToString();
                                }
                            }
                            if (dsAptDetails.Tables[0].Rows[0]["EXPENDTIME"].ToString() != "")
                            {
                                if (dsAptDetails.Tables[0].Rows[0]["EXPENDTIME"].ToString().Contains(":"))
                                {
                                    string[] arrstime = new string[3];

                                    string[] arrtttime = new string[2];

                                    arrstime = dsAptDetails.Tables[0].Rows[0]["EXPENDTIME"].ToString().Split(':');

                                    string min = "";

                                    if (arrstime[1].ToString().Contains(" "))
                                    {
                                        arrtttime = arrstime[1].ToString().Split(' ');

                                        min = arrtttime[0].ToString();

                                        if (min.Length == 1)
                                        {
                                            min = "0" + min;
                                        }
                                    }

                                    lblapptexpetimeval.Text = arrstime[0].ToString() + ":" + min + " " + arrtttime[1].ToString();
                                }
                            }
                            if (dsAptDetails.Tables[0].Rows[0]["STATUS"].ToString() != "")
                            {
                                string Status = "";

                                if (dsAptDetails.Tables[0].Rows[0]["STATUS"].ToString().Equals("Completed"))
                                {
                                    Status = "Complete";
                                }
                                else
                                {
                                    Status = "InComplete";
                                }
                                lblapptstatusval.Text = Status;
                            }

                        }
                    }

                    PnldispAppt.Visible = false;

                    Pnldispapptdet.Visible = true;
                }

            }
        }
    }
}