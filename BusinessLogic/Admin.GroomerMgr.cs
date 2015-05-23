using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;

using DataBaseHandler35;
using BL.Common.StoreProcedure;
using BL.Common.BasseDataAccess;

namespace BL.Admin.Groomer
{
    public class GroomerMgr : BaseData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public DataSet GetGroomerUser(string UserName, string Password)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserName", "@PassWord" };

                paramValues = new object[] { UserName, Password };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMER_USER, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="appId"></param>
        /// <returns></returns>
        public DataSet getOldApp(string gid, int appId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@AppointmentID" };

                paramValues = new object[] { gid, appId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_GET_NEXT_APPOINTMENT_DETAILS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GId"></param>
        /// <returns></returns>
        public DataSet GroomerGetProfile(int GId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GId" };

                paramValues = new object[] { GId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GROOMER_GET_PROFILE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GId"></param>
        /// <param name="VanId"></param>
        /// <param name="BeginningMileage"></param>
        /// <param name="TotlaHours"></param>
        /// <param name="EndingMileage"></param>
        /// <param name="FuelPurchased"></param>
        /// <param name="PricePerGallon"></param>
        /// <param name="CustomerName"></param>
        /// <param name="Job"></param>
        /// <param name="ZipCode"></param>
        /// <param name="Pets"></param>
        /// <param name="Rebook"></param>
        /// <param name="FromRebook"></param>
        /// <param name="New"></param>
        /// <param name="TimeIn"></param>
        /// <param name="TimeOut"></param>
        /// <param name="PetTime"></param>
        /// <param name="ExtraServices"></param>
        /// <param name="FleaandTick22"></param>
        /// <param name="FleaandTick44"></param>
        /// <param name="FleaandTick88"></param>
        /// <param name="FleaandTick132"></param>
        /// <param name="FleaandTickCat"></param>
        /// <param name="TB"></param>
        /// <param name="Wham"></param>
        /// <param name="RevenueCreditCard"></param>
        /// <param name="RevenueCheck"></param>
        /// <param name="RevenueCash"></param>
        /// <param name="RevenueInvoice"></param>
        /// <param name="TipCreditCard"></param>
        /// <param name="TipCheck"></param>
        /// <param name="TipCash"></param>
        /// <param name="TipInvoice"></param>
        /// <param name="PriorCreditCard"></param>
        /// <param name="PriorCheck"></param>
        /// <param name="PriorCash"></param>
        /// <param name="NextAppointmentDate"></param>
        /// <param name="NextAppointmentTime"></param>
        /// <param name="ServicesForPet1"></param>
        /// <param name="ServicesForPet2"></param>
        /// <param name="ServicesForPet3"></param>
        /// <param name="ServicesForPet4"></param>
        /// <param name="ServicesForPet5"></param>
        /// <param name="ServicesForPet6"></param>
        /// <returns></returns>
        public int GroomerDailyOperationsLog(int GId, string VanId, int BeginningMileage, string TotlaHours, int EndingMileage, double FuelPurchased,
       double PricePerGallon, string CustomerName, string Job, string ZipCode, int Pets, int Rebook, int FromRebook, int New, string TimeIn, string TimeOut,
       string PetTime, string ExtraServices, int FleaandTick22, int FleaandTick44, int FleaandTick88, int FleaandTick132, int FleaandTickCat,
       int TB, int Wham, double RevenueCreditCard, double RevenueCheck, double RevenueCash, double RevenueInvoice, double TipCreditCard, double TipCheck,
       double TipCash, double TipInvoice, double PriorCreditCard, double PriorCheck, double PriorCash, DateTime NextAppointmentDate, string NextAppointmentTime,
       string ServicesForPet1, string ServicesForPet2, string ServicesForPet3, string ServicesForPet4, string ServicesForPet5, string ServicesForPet6)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GId", "@VanId", "@BeginningMileage", "@TotlaHours", "@EndingMileage", "@FuelPurchased", "@PricePerGallon", "@CustomerName", "@Job", "@ZipCode", "@Pets", "@Rebook", "@FromRebook", "@New", "@TimeIn", "@TimeOut", "@PetTime", "@ExtraServices", "@FleaandTick22", "@FleaandTick44", "@FleaandTick88", "@FleaandTick132", "@FleaandTickCat", "@TB", "@Wham", "@RevenueCreditCard", "@RevenueCheck", "@RevenueCash", "@RevenueInvoice", "@TipCreditCard", "@TipCheck", "@TipCash", "@TipInvoice", "@PriorCreditCard", "@PriorCheck", "@PriorCash", "@NextAppointmentDate", "@NextAppointmentTime", "@ServicesForPet1", "@ServicesForPet2", "@ServicesForPet3", "@ServicesForPet4", "@ServicesForPet5", "@ServicesForPet6" };

                paramValues = new object[] { GId, VanId, BeginningMileage, TotlaHours, EndingMileage, FuelPurchased, PricePerGallon, CustomerName, Job, ZipCode, Pets, Rebook, FromRebook, New, TimeIn, TimeOut, PetTime, ExtraServices, FleaandTick22, FleaandTick44, FleaandTick88, FleaandTick132, FleaandTickCat, TB, Wham, RevenueCreditCard, RevenueCheck, RevenueCash, RevenueInvoice, TipCreditCard, TipCheck, TipCash, TipInvoice, PriorCreditCard, PriorCheck, PriorCash, NextAppointmentDate, NextAppointmentTime, ServicesForPet1, ServicesForPet2, ServicesForPet3, ServicesForPet4, ServicesForPet5, ServicesForPet6 };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.GROOMER_DAILY_OPERATIONS_LOG, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GId"></param>
        /// <param name="FleaTick22"></param>
        /// <param name="FleaTick44"></param>
        /// <param name="FleaTick88"></param>
        /// <param name="FleaTick132"></param>
        /// <param name="FleaTickcAT"></param>
        /// <param name="Toothbrushes"></param>
        /// <param name="Wham"></param>
        /// <param name="Towels"></param>
        /// <param name="CottonPads"></param>
        /// <param name="CottonSwabs"></param>
        /// <param name="PaperTowels"></param>
        /// <param name="GarbageBags"></param>
        /// <param name="Treats"></param>
        /// <param name="VetWrap"></param>
        /// <param name="Wipes"></param>
        /// <param name="QuickStop"></param>
        /// <param name="LiquidBandaid"></param>
        /// <param name="Envelopes"></param>
        /// <param name="Receipts"></param>
        /// <param name="BusinessCards"></param>
        /// <param name="BladesSharpened"></param>
        /// <param name="ScissorsSharpened"></param>
        /// <param name="SunGuard"></param>
        /// <param name="EZShed"></param>
        /// <param name="EZDematt"></param>
        /// <param name="SkunkKit"></param>
        /// <param name="Other"></param>
        /// <param name="Other1"></param>
        /// <param name="Other2"></param>
        /// <param name="Other3"></param>
        /// <param name="Other4"></param>
        /// <param name="Other5"></param>
        /// <param name="Marketing1"></param>
        /// <param name="Marketing2"></param>
        /// <param name="Marketing3"></param>
        /// <param name="Marketing4"></param>
        /// <param name="Marketing5"></param>
        /// <param name="Liquid1"></param>
        /// <param name="Liquid2"></param>
        /// <param name="Liquid3"></param>
        /// <param name="Liquid4"></param>
        /// <param name="Liquid5"></param>
        /// <param name="Liquid6"></param>
        /// <param name="Liquid7"></param>
        /// <param name="Liquid8"></param>
        /// <param name="Liquid9"></param>
        /// <param name="Liquid10"></param>
        /// <param name="Liquid11"></param>
        /// <param name="Liquid12"></param>
        /// <param name="Liquid13"></param>
        /// <param name="Liquid14"></param>
        /// <param name="Liquid15"></param>
        /// <param name="Liquid16"></param>
        /// <param name="Liquid17"></param>
        /// <param name="Liquid18"></param>
        /// <param name="Liquid19"></param>
        /// <param name="Liquid20"></param>
        /// <param name="Liquid21"></param>
        /// <param name="Liquid22"></param>
        /// <param name="Liquid23"></param>
        /// <param name="Liquid24"></param>
        /// <param name="Liquid25"></param>
        /// <returns></returns>
        public int GroomerAddInventroyRequest(int GId, string FleaTick22, string FleaTick44, string FleaTick88, string FleaTick132, string FleaTickcAT,
        string Toothbrushes, string Wham, string Towels, string CottonPads, string CottonSwabs, string PaperTowels, string GarbageBags, string Treats, string VetWrap,
        string Wipes, string QuickStop, string LiquidBandaid, string Envelopes, string Receipts, string BusinessCards, string BladesSharpened,
        string ScissorsSharpened, string SunGuard, string EZShed, string EZDematt, string SkunkKit, string Other, string Other1,
string Other2, string Other3, string Other4, string Other5, string Marketing1, string Marketing2, string Marketing3, string Marketing4, string Marketing5, string Liquid1, string Liquid2, string Liquid3, string Liquid4, string Liquid5, string Liquid6, string Liquid7, string Liquid8, string Liquid9, string Liquid10, string Liquid11, string Liquid12, string Liquid13, string Liquid14, string Liquid15, string Liquid16, string Liquid17, string Liquid18, string Liquid19, string Liquid20, string Liquid21, string Liquid22, string Liquid23, string Liquid24, string Liquid25)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GId", "@FleaTick22", "@FleaTick44", "@FleaTick88", "@FleaTick132", "@FleaTickcAT", "@Toothbrushes", "@Wham", "@Towels", "@CottonPads", "@CottonSwabs", "@PaperTowels", "@GarbageBags", "@Treats", "@VetWrap", "@Wipes", "@QuickStop", "@LiquidBandaid", "@Envelopes", "@Receipts", "@BusinessCards", "@BladesSharpened", "@ScissorsSharpened", "@SunGuard", "@EZShed", "@EZDematt", "@SkunkKit", "@Other", "@Other1", "@Other2", "@Other3", "@Other4", "@Other5", "@Marketing1", "@Marketing2", "@Marketing3", "@Marketing4", "@Marketing5", "@Liquid1", "@Liquid2", "@Liquid3", "@Liquid4", "@Liquid5", "@Liquid6", "@Liquid7", "@Liquid8", "@Liquid9", "@Liquid10", "@Liquid11", "@Liquid12", "@Liquid13", "@Liquid14", "@Liquid15", "@Liquid16", "@Liquid17", "@Liquid18", "@Liquid19", "@Liquid20", "@Liquid21", "@Liquid22", "@Liquid23", "@Liquid24", "@Liquid25" };

                paramValues = new object[] { GId, FleaTick22, FleaTick44, FleaTick88, FleaTick132, FleaTickcAT, Toothbrushes, Wham, Towels, CottonPads, CottonSwabs, PaperTowels, GarbageBags, Treats, VetWrap, Wipes, QuickStop, LiquidBandaid, Envelopes, Receipts, BusinessCards, BladesSharpened, ScissorsSharpened, SunGuard, EZShed, EZDematt, SkunkKit, Other, Other1, Other2, Other3, Other4, Other5, Marketing1, Marketing2, Marketing3, Marketing4, Marketing5, Liquid1, Liquid2, Liquid3, Liquid4, Liquid5, Liquid6, Liquid7, Liquid8, Liquid9, Liquid10, Liquid11, Liquid12, Liquid13, Liquid14, Liquid15, Liquid16, Liquid17, Liquid18, Liquid19, Liquid20, Liquid21, Liquid22, Liquid23, Liquid24, Liquid25 };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.GROOMER_DAILY_OPERATIONS_LOG, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public DataSet getInventoryData(int gid)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GId" };

                paramValues = new object[] { gid };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_INVENTORY_DATA, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet getInventoryLabels()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_INVENTORY_LABELS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GId"></param>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <param name="Name"></param>
        /// <param name="Address"></param>
        /// <param name="HomePhone"></param>
        /// <param name="PersonalCellPhone"></param>
        /// <param name="BaseCity"></param>
        /// <param name="State"></param>
        /// <param name="Zipcode"></param>
        public void GroomerUpdateProfile(int GId, string UserName, string password, string Name, string Address, string HomePhone, string PersonalCellPhone, string BaseCity, string State, string Zipcode)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GId", "@UserName", "@Name", "@Address", "@HomePhone", "@password", "@PersonalCellPhone", "@BaseCity", "@State", "@Zipcode" };

                paramValues = new object[] { GId, UserName, Name, Address, HomePhone, password, PersonalCellPhone, BaseCity, State, Zipcode };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.InsertData(StoreProcedure.GROOMER_UPDATE_PROFILE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public DataSet GrmmoerGetPassword(string UserName)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@UserName" };

                paramValues = new object[] { UserName };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GRMMOER_GET_PASSWORD, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public DataSet GetGroomersMileage(string Date)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Date" };

                paramValues = new object[] { Date };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMERS_MILEAGE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Date"></param>
        /// <param name="GID"></param>
        /// <param name="VanID"></param>
        /// <returns></returns>
        public DataSet GetGroomerYesterdayMileage(string Date, string GID, string VanID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Date", "@GID", "@VanID" };

                paramValues = new object[] { Date, GID, VanID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMER_YESTERDAY_MILEAGE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strGID"></param>
        /// <returns></returns>
        public DataSet getAppointmentDtls(string strGID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID" };

                paramValues = new object[] { strGID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_GET_APPOINTMENT_DTLS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AptID"></param>
        /// <returns></returns>
        public DataSet getAppointmentDetails(string AptID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentID" };

                paramValues = new object[] { AptID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_GET_APPOINTMENT_DETAILS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AptID"></param>
        /// <returns></returns>
        public DataSet getAppointmentAllDetails(string AptID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentID" };

                paramValues = new object[] { AptID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_GET_APPOINTMENT_ALL_DETAILS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <param name="Addedon"></param>
        /// <returns></returns>
        public DataSet getParantFields(string GID, string Addedon)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                Addedon = System.DateTime.Today.ToString("yyyy/M/d");

                paramNames = new string[] { "@GId", "@Addedon" };

                paramValues = new object[] { GID, Addedon };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_GET_DAILY_OPERATION_LOG, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppointmentID"></param>
        /// <returns></returns>
        public DataSet CheckAppointment(int AppointmentID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentID" };

                paramValues = new object[] { AppointmentID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_CHECK_APPOINTMENT_EXISTS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <param name="VanID"></param>
        /// <param name="BeginningMileage"></param>
        /// <param name="ExtraServices"></param>
        /// <param name="CustomerName"></param>
        /// <param name="Job"></param>
        /// <param name="ZipCode"></param>
        /// <param name="Pets"></param>
        /// <param name="PetTime"></param>
        /// <param name="addeon"></param>
        /// <param name="TimeIn"></param>
        /// <param name="TimeOut"></param>
        /// <returns></returns>
        public DataSet CheckAppRecordinDB(string GID, string VanID, string BeginningMileage, string ExtraServices, string CustomerName, string Job, string ZipCode, string Pets, string PetTime, string addeon, string TimeIn, string TimeOut)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@VanID", "@BeginningMileage", "@ExtraServices", "@CustomerName", "@Job", "@ExtraServices", "@CustomerName", "@Job", "@ZipCode", "@Pets", "@PetTime", "@Addedon", "@TimeIn", "@TimeOut", };

                paramValues = new object[] { GID, VanID, BeginningMileage, ExtraServices, CustomerName, Job, ZipCode, Pets, PetTime, addeon, TimeIn, TimeOut };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_CHECK_APPT_RECORD_EXISTS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GId"></param>
        /// <param name="VanId"></param>
        /// <param name="BeginningMileage"></param>
        /// <param name="TotlaHours"></param>
        /// <param name="EndingMileage"></param>
        /// <param name="FuelPurchased"></param>
        /// <param name="PricePerGallon"></param>
        /// <param name="CustomerName"></param>
        /// <param name="Job"></param>
        /// <param name="ZipCode"></param>
        /// <param name="Pets"></param>
        /// <param name="Rebook"></param>
        /// <param name="FromRebook"></param>
        /// <param name="New"></param>
        /// <param name="TimeIn"></param>
        /// <param name="TimeOut"></param>
        /// <param name="PetTime"></param>
        /// <param name="ExtraServices"></param>
        /// <param name="comments"></param>
        /// <param name="driveTime"></param>
        /// <param name="rPetTime"></param>
        /// <param name="FleaandTick22"></param>
        /// <param name="FleaandTick44"></param>
        /// <param name="FleaandTick88"></param>
        /// <param name="FleaandTick132"></param>
        /// <param name="FleaandTickCat"></param>
        /// <param name="TB"></param>
        /// <param name="Wham"></param>
        /// <param name="RevenueCreditCard"></param>
        /// <param name="RevenueCheck"></param>
        /// <param name="RevenueCash"></param>
        /// <param name="RevenueInvoice"></param>
        /// <param name="RevenueCCY"></param>
        /// <param name="TipCreditCard"></param>
        /// <param name="TipCheck"></param>
        /// <param name="TipCash"></param>
        /// <param name="TipInvoice"></param>
        /// <param name="PriorCreditCard"></param>
        /// <param name="PriorCheck"></param>
        /// <param name="PriorCash"></param>
        /// <param name="CreditCardNo"></param>
        /// <param name="CreditCardExpir"></param>
        /// <param name="CreditCardORChkName"></param>
        /// <param name="CreditCardORChkAddr"></param>
        /// <param name="SecurityCode"></param>
        /// <param name="NextAppointmentDate"></param>
        /// <param name="NextAppointmentTime"></param>
        /// <param name="NextAppointmentEndTime"></param>
        /// <param name="ServicesForPet1"></param>
        /// <param name="ServicesForPet2"></param>
        /// <param name="ServicesForPet3"></param>
        /// <param name="ServicesForPet4"></param>
        /// <param name="ServicesForPet5"></param>
        /// <param name="ServicesForPet6"></param>
        /// <param name="AppointmentID"></param>
        /// <param name="Addedon"></param>
        /// <param name="ProductPrice"></param>
        /// <param name="Salestax"></param>
        /// <param name="Rev01"></param>
        /// <param name="CustNameOnCheque"></param>
        /// <param name="BankOnCheque"></param>
        /// <returns></returns>
        public int InsertTempDailyOperationLog(string GId, string VanId, string BeginningMileage, string TotlaHours, string EndingMileage, string FuelPurchased, string PricePerGallon, string CustomerName, string Job, string ZipCode, string Pets, string Rebook, string FromRebook, string New, string TimeIn, string TimeOut, string PetTime, string ExtraServices, string comments, string driveTime, string rPetTime, int FleaandTick22, int FleaandTick44, int FleaandTick88, int FleaandTick132, int FleaandTickCat, int TB, int Wham, double RevenueCreditCard, double RevenueCheck, double RevenueCash, double RevenueInvoice, double RevenueCCY, double TipCreditCard, double TipCheck, double TipCash, double TipInvoice, double PriorCreditCard, double PriorCheck, double PriorCash, string CreditCardNo, string CreditCardExpir, string CreditCardORChkName, string CreditCardORChkAddr, string SecurityCode, string NextAppointmentDate, string NextAppointmentTime, string NextAppointmentEndTime, string ServicesForPet1, string ServicesForPet2, string ServicesForPet3, string ServicesForPet4, string ServicesForPet5, string ServicesForPet6, int AppointmentID, string @Addedon, double ProductPrice, double Salestax, int Rev01, string CustNameOnCheque, string BankOnCheque)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GId", "@VanId", "@BeginningMileage", "@TotlaHours", "@EndingMileage", "@FuelPurchased", "@PricePerGallon", "@CustomerName", "@Job", "@ZipCode", "@Pets", "@Rebook", "@FromRebook", "@New", "@TimeIn", "@TimeOut", "@PetTime", "@ExtraServices", "@Comments", "@Drive_Time", "@Pet_Time", "@FleaandTick22", "@FleaandTick44", "@FleaandTick88", "@FleaandTick132", "@FleaandTickCat", "@TB", "@Wham", "@RevenueCreditCard", "@RevenueCheck", "@RevenueCash", "@RevenueInvoice", "@RevenueCCY", "@TipCreditCard", "@TipCheck", "@TipCash", "@TipInvoice", "@PriorCreditCard", "@PriorCheck", "@PriorCash", "@CreditCardNo", "@CreditCardExpir", "@CreditCardORChkName", "@CreditCardORChkAddr", "@SecurityCode", "@NextAppointmentDate", "@NextAppointmentTime", "@NextAppointmentEndTime", "@ServicesForPet1", "@ServicesForPet2", "@ServicesForPet3", "@ServicesForPet4", "@ServicesForPet5", "@ServicesForPet6", "@AppointmentID", "@Addedon", "@ProductPrice", "@Salestax", "@Rev01", "@NameOnCheque", "@BankOnCheque", };

                paramValues = new object[] { GId, VanId, BeginningMileage, TotlaHours, EndingMileage, FuelPurchased, PricePerGallon, CustomerName, Job, ZipCode, Pets, Rebook, FromRebook, New, TimeIn, TimeOut, PetTime, ExtraServices, comments, driveTime, rPetTime, FleaandTick22, FleaandTick44, FleaandTick88, FleaandTick132, FleaandTickCat, TB, Wham, RevenueCreditCard, RevenueCheck, RevenueCash, RevenueInvoice, RevenueCCY, TipCreditCard, TipCheck, TipCash, TipInvoice, PriorCreditCard, PriorCheck, PriorCash, CreditCardNo, CreditCardExpir, CreditCardORChkName, CreditCardORChkAddr, SecurityCode, NextAppointmentDate, NextAppointmentTime, NextAppointmentEndTime, ServicesForPet1, ServicesForPet2, ServicesForPet3, ServicesForPet4, ServicesForPet5, ServicesForPet6, AppointmentID, @Addedon, ProductPrice, Salestax, Rev01, CustNameOnCheque, BankOnCheque, };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.SP_INSERT_TEMP_DAILY_OPERATION_LOG, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GId"></param>
        /// <param name="VanId"></param>
        /// <param name="BeginningMileage"></param>
        /// <param name="TotlaHours"></param>
        /// <param name="EndingMileage"></param>
        /// <param name="FuelPurchased"></param>
        /// <param name="PricePerGallon"></param>
        /// <param name="CustomerName"></param>
        /// <param name="Job"></param>
        /// <param name="ZipCode"></param>
        /// <param name="Pets"></param>
        /// <param name="Rebook"></param>
        /// <param name="FromRebook"></param>
        /// <param name="New"></param>
        /// <param name="TimeIn"></param>
        /// <param name="TimeOut"></param>
        /// <param name="PetTime"></param>
        /// <param name="ExtraServices"></param>
        /// <param name="comments"></param>
        /// <param name="driveTime"></param>
        /// <param name="rPetTime"></param>
        /// <param name="FleaandTick22"></param>
        /// <param name="FleaandTick44"></param>
        /// <param name="FleaandTick88"></param>
        /// <param name="FleaandTick132"></param>
        /// <param name="FleaandTickCat"></param>
        /// <param name="TB"></param>
        /// <param name="Wham"></param>
        /// <param name="RevenueCreditCard"></param>
        /// <param name="RevenueCheck"></param>
        /// <param name="RevenueCash"></param>
        /// <param name="RevenueInvoice"></param>
        /// <param name="RevenueCCY"></param>
        /// <param name="TipCreditCard"></param>
        /// <param name="TipCheck"></param>
        /// <param name="TipCash"></param>
        /// <param name="TipInvoice"></param>
        /// <param name="PriorCreditCard"></param>
        /// <param name="PriorCheck"></param>
        /// <param name="PriorCash"></param>
        /// <param name="CreditCardNo"></param>
        /// <param name="CreditCardExpir"></param>
        /// <param name="CreditCardORChkName"></param>
        /// <param name="CreditCardORChkAddr"></param>
        /// <param name="SecurityCode"></param>
        /// <param name="NextAppointmentDate"></param>
        /// <param name="NextAppointmentTime"></param>
        /// <param name="NextAppointmentEndTime"></param>
        /// <param name="ServicesForPet1"></param>
        /// <param name="ServicesForPet2"></param>
        /// <param name="ServicesForPet3"></param>
        /// <param name="ServicesForPet4"></param>
        /// <param name="ServicesForPet5"></param>
        /// <param name="ServicesForPet6"></param>
        /// <param name="AppointmentID"></param>
        /// <param name="Addedon"></param>
        /// <param name="ProductPrice"></param>
        /// <param name="Salestax"></param>
        /// <param name="Rev01"></param>
        /// <param name="CustNameOnCheque"></param>
        /// <param name="BankOnCheque"></param>
        /// <returns></returns>
        public int InsertDailyOperationLog(string GId, string VanId, string BeginningMileage, string TotlaHours, string EndingMileage, string FuelPurchased, string PricePerGallon, string CustomerName, string Job, string ZipCode, string Pets, string Rebook, string FromRebook, string New, string TimeIn, string TimeOut, string PetTime, string ExtraServices, string comments, string driveTime, string rPetTime, int FleaandTick22, int FleaandTick44, int FleaandTick88, int FleaandTick132, int FleaandTickCat, int TB, int Wham, double RevenueCreditCard, double RevenueCheck, double RevenueCash, double RevenueInvoice, double RevenueCCY, double TipCreditCard, double TipCheck, double TipCash, double TipInvoice, double PriorCreditCard, double PriorCheck, double PriorCash, string CreditCardNo, string CreditCardExpir, string CreditCardORChkName, string CreditCardORChkAddr, string SecurityCode, string NextAppointmentDate, string NextAppointmentTime, string NextAppointmentEndTime, string ServicesForPet1, string ServicesForPet2, string ServicesForPet3, string ServicesForPet4, string ServicesForPet5, string ServicesForPet6, int AppointmentID, string @Addedon, double ProductPrice, double Salestax, int Rev01, string CustNameOnCheque, string BankOnCheque)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GId", "@VanId", "@BeginningMileage", "@TotlaHours", "@EndingMileage", "@FuelPurchased", "@PricePerGallon", "@CustomerName", "@Job", "@ZipCode", "@Pets", "@Rebook", "@FromRebook", "@New", "@TimeIn", "@TimeOut", "@PetTime", "@ExtraServices", "@Comments", "@Drive_Time", "@Pet_Time", "@FleaandTick22", "@FleaandTick44", "@FleaandTick88", "@FleaandTick132", "@FleaandTickCat", "@TB", "@Wham", "@RevenueCreditCard", "@RevenueCheck", "@RevenueCash", "@RevenueInvoice", "@RevenueCCY", "@TipCreditCard", "@TipCheck", "@TipCash", "@TipInvoice", "@PriorCreditCard", "@PriorCheck", "@PriorCash", "@CreditCardNo", "@CreditCardExpir", "@CreditCardORChkName", "@CreditCardORChkAddr", "@SecurityCode", "@NextAppointmentDate", "@NextAppointmentTime", "@NextAppointmentEndTime", "@ServicesForPet1", "@ServicesForPet2", "@ServicesForPet3", "@ServicesForPet4", "@ServicesForPet5", "@ServicesForPet6", "@AppointmentID", "@Addedon", "@ProductPrice", "@Salestax", "@Rev01", "@NameOnCheque", "@BankOnCheque", };

                paramValues = new object[] { GId, VanId, BeginningMileage, TotlaHours, EndingMileage, FuelPurchased, PricePerGallon, CustomerName, Job, ZipCode, Pets, Rebook, FromRebook, New, TimeIn, TimeOut, PetTime, ExtraServices, comments, driveTime, rPetTime, FleaandTick22, FleaandTick44, FleaandTick88, FleaandTick132, FleaandTickCat, TB, Wham, RevenueCreditCard, RevenueCheck, RevenueCash, RevenueInvoice, RevenueCCY, TipCreditCard, TipCheck, TipCash, TipInvoice, PriorCreditCard, PriorCheck, PriorCash, CreditCardNo, CreditCardExpir, CreditCardORChkName, CreditCardORChkAddr, SecurityCode, NextAppointmentDate, NextAppointmentTime, NextAppointmentEndTime, ServicesForPet1, ServicesForPet2, ServicesForPet3, ServicesForPet4, ServicesForPet5, ServicesForPet6, AppointmentID, @Addedon, ProductPrice, Salestax, Rev01, CustNameOnCheque, BankOnCheque, };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.InsertData(StoreProcedure.SP_INSERT_DAILY_OPERATION_LOG, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppointmentID"></param>
        public void Modify_AppointmentStatus(int AppointmentID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentID" };

                paramValues = new object[] { AppointmentID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.SP_MODIFY_APPOINTMENT_STATUS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <param name="VanId"></param>
        /// <param name="BeginningMileage"></param>
        /// <param name="TotlaHours"></param>
        /// <param name="EndingMileage"></param>
        /// <param name="FuelPurchased"></param>
        /// <param name="PricePerGallon"></param>
        /// <param name="Addedon"></param>
        /// <param name="flag"></param>
        /// <param name="PfieldId"></param>
        public void insertParantFields(string @GID, string @VanId, string @BeginningMileage, string @TotlaHours, string @EndingMileage, string @FuelPurchased, string @PricePerGallon, string Addedon, string @flag, string @PfieldId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GId", "@VanId", "@BeginningMileage", "@TotalHours", "@EndingMileage", "@FuelPurchased", "@PricePerGallon", "@Addedon", "@PfieldId", "@flag" };

                paramValues = new object[] { @GID, @VanId, @BeginningMileage, @TotlaHours, @EndingMileage, @FuelPurchased, @PricePerGallon, @Addedon, @PfieldId, @flag };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.SP_MANAGE_PARANT_FIELDS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <param name="AppointmentDate"></param>
        /// <returns></returns>
        public DataSet GetgroomerTodaysAppointment(int GID, string AppointmentDate)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GId", "@AppointmentDate" };

                paramValues = new object[] { GID, AppointmentDate };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMER_TODAYS_APPOINTMENT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppointmentID"></param>
        public void GroomerUpdatePresentedStatus(int AppointmentID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentID" };

                paramValues = new object[] { AppointmentID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.InsertData(StoreProcedure.GROOMER_UPDATE_PRESENTED_STATUS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppointmentID"></param>
        /// <param name="LoggedInTime"></param>
        public void GroomerUpdateApptPresentedStatus(int AppointmentID, string LoggedInTime)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentID", "@PresentedTime" };

                paramValues = new object[] { AppointmentID, LoggedInTime };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.InsertData(StoreProcedure.GROOMER_UPDATE_APPT_PRESENTED_STATUS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppointmentID"></param>
        /// <param name="STime"></param>
        public void GroomerUpdateApptSTime(int AppointmentID, string STime)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentID", "@StartTime" };

                paramValues = new object[] { AppointmentID, STime };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.InsertData(StoreProcedure.GROOMER_UPDATE_APPT_START_TIME, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AppointmentID"></param>
        /// <param name="ETime"></param>
        public void GroomerUpdateApptETime(int AppointmentID, string ETime)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@AppointmentID", "@EndTime" };

                paramValues = new object[] { AppointmentID, ETime };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.InsertData(StoreProcedure.GROOMER_UPDATE_APPT_END_TIME, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <param name="DailyLogID"></param>
        /// <returns></returns>
        public DataSet getGroomercurrentoperationlog(string @GID, string @DailyLogID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Gid", "@DailyLogID" };

                paramValues = new object[] { @GID, @DailyLogID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMER_CURRENT_OPERATION_LOG, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet getExcelData()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_GE_TEXCEL_DATA, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetUnlockExcelFileName()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_UNLOCK_EXCEL_FILE_NAME, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <returns></returns>
        public DataSet getGroomeroperationlogForEndingMileage(int @GID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID" };

                paramValues = new object[] { @GID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMER_OPERATION_LOG_FOR_ENDING_MILEAGE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DailyLogId"></param>
        /// <param name="Flag"></param>
        public void updateExcelExported(int DailyLogId, int Flag)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@DailyLogId", "@Flag" };

                paramValues = new object[] { DailyLogId, Flag };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_EXCEL_EXPORTED, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DLId"></param>
        public void InsertAppDate(int DLId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@DailyLogID" };

                paramValues = new object[] { DLId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.INSERT_APP_TXN_DATE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DailyLogId"></param>
        /// <param name="Flag"></param>
        public void updateExcelExportedEndingMileage(int DailyLogId, int Flag)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@DailyLogId", "@Flag" };

                paramValues = new object[] { DailyLogId, Flag };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_EXCEL_EXPORTED_ENDING_MILEAGE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GID"></param>
        /// <param name="InvId"></param>
        /// <returns></returns>
        public DataSet getGroomercurrentInventorylogForExport(int @GID, int @InvId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Gid", "@InvId" };

                paramValues = new object[] { @GID, @InvId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_GROOMER_CURRENT_INVENTORY_LOG_FOR_EXPORT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InvId"></param>
        /// <param name="Flag"></param>
        public void updateExcelExportedInventory(int InvId, int Flag)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@InvId", "@Flag" };

                paramValues = new object[] { InvId, Flag };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_EXCEL_EXPORTED_INVENTORY, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetQueueExportdata()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_QUEUE_EXPORT_DATA, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void sp_GroomerData()
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { };

                paramValues = new object[] { };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.InsertData(StoreProcedure.SP_CYBER_SOURCE_DATA, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LogID"></param>
        /// <param name="recid"></param>
        public void UpdateLogID(int LogID, string recid)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@DailyLogID", "@RecID" };

                paramValues = new object[] { LogID, recid };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_PAYMENT_LOG_ID, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="dailylogid"></param>
        /// <param name="responseid"></param>
        /// <param name="PayID"></param>
        /// <param name="Response"></param>
        /// <param name="BillTxnRefNumber"></param>
        /// <param name="AuthCode"></param>
        public void UpdatePGResponseDetails(string result, string dailylogid, string responseid, string PayID, string Response, string BillTxnRefNumber, string AuthCode)
        {
            bool IsPaySuccess = false;

            if (result.Equals("SOK") || result.Equals("DSETTINGS"))
            {
                IsPaySuccess = true;
            }

            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Result", "@DailyLogID", "@ResponseID", "@PaymentID", "@Response", "@BillTxnRefno", "@Authcode", "@IsSucceded" };

                paramValues = new object[] { result, dailylogid, responseid, PayID, Response, BillTxnRefNumber, AuthCode, IsPaySuccess };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.UPDATE_SHOPPER_RESPONSE, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GId"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Address1"></param>
        /// <param name="Address2"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="Zip"></param>
        /// <param name="Country"></param>
        /// <param name="Phone"></param>
        /// <param name="Email"></param>
        /// <param name="CardType"></param>
        /// <param name="CreditCardNo"></param>
        /// <param name="ValidYear"></param>
        /// <param name="ValidMonth"></param>
        /// <param name="VerificationCode"></param>
        /// <param name="Payment_Amount"></param>
        /// <param name="SandH"></param>
        /// <param name="Tax"></param>
        /// <param name="ordno"></param>
        public void GetShopperInfo(int GId, string FirstName, string LastName, string Address1, string Address2, string City, string State, string Zip, string Country, string Phone, string Email
        , string CardType, string CreditCardNo, string ValidYear, string ValidMonth, string VerificationCode, decimal Payment_Amount, decimal SandH, decimal Tax, string ordno)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            string card = CreditCardNo;

            string cardno = card.Substring(card.Length - 4);

            try
            {
                paramNames = new string[] { "@GID", "@FirstName", "@LastName", "@Address1", "@Address2", "@City", "@State", "@Zip", "@Country", "@Phone", "@Email", "@Cardtype", "@CreditCardNo", "@ValidYear", "@ValidMonth", "@VerificationCode", "@Payment_Amount", "@SandH", "@Tax", "@OrdRefNo" };

                paramValues = new object[] { GId, FirstName, LastName, Address1, Address2, City, State, Zip, Country, Phone, Email, CardType, cardno, ValidYear, ValidMonth, VerificationCode, Payment_Amount, SandH, Tax, ordno, };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.GET_SHOPPER_INFO, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="GId"></param>
        /// <param name="CreditCardNo"></param>
        /// <param name="ValidYear"></param>
        /// <param name="ValidMonth"></param>
        /// <param name="VerificationCode"></param>
        public void GetCreditCardInfo(int GId, string CreditCardNo, string ValidYear, string ValidMonth, string VerificationCode)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@GID", "@CreditCardNo", "@ValidYear", "@ValidMonth", "@VerificationCode"};

                paramValues = new object[] { GId, CreditCardNo, ValidYear, ValidMonth, VerificationCode };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.GET_CREDIT_CARD_INFO, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrdNumber"></param>
        /// <returns></returns>
        public DataSet CheckOrderRefNo(string OrdNumber)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@OrdNumber" };

                paramValues = new object[] { OrdNumber };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.GET_CREDIT_CARD_INFO, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DailyLogId"></param>
        /// <returns></returns>
        public DataSet GetAptdetails(int DailyLogId)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@DailyLogId" };

                paramValues = new object[] { DailyLogId };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_GET_APTT_EMP_LOG_DETAILS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="DailyLogId"></param>
        /// <param name="Gid"></param>
        /// <returns></returns>
        public DataSet GetSubmitOrder(int DailyLogId, int Gid)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@DailyLogId", "@GId" };

                paramValues = new object[] { DailyLogId, Gid };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_GET_APTT_EMP_LOG_DETAILS, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DailyLogId"></param>
        /// <param name="Payment_ID"></param>
        /// <returns></returns>
        public DataSet GetFinalPaymentInfo(int DailyLogId, int @Payment_ID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Payment_ID", "@DailyLogId" };

                paramValues = new object[] { DailyLogId, @Payment_ID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_FINAL_PAYMENT_INFO, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Payment_Amount"></param>
        /// <param name="SandH"></param>
        /// <param name="Tax"></param>
        /// <param name="Payment_ID"></param>
        public void UpdatePaymentAmount(decimal Payment_Amount, decimal SandH, decimal Tax, int Payment_ID)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@Payment_Amount", "@SandH", "@Tax", "@Payment_ID" };

                paramValues = new object[] { Payment_Amount, SandH, Tax, Payment_ID };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                databaseObj.UpdateData(StoreProcedure.SP_INSER_PAYMENT_AMOUNT, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Apptdt"></param>
        /// <param name="time"></param>
        /// <param name="gid"></param>
        /// <returns></returns>
        public DataSet GetApptSchedules(DateTime Apptdt, int time, int gid)
        {
            string[] paramNames = null;

            object[] paramValues = null;

            IDataParameter[] paramList = null;

            try
            {
                paramNames = new string[] { "@ApptDate", "@TIME", "@GID" };

                paramValues = new object[] { Apptdt, time, gid };

                paramList = databaseObj.BuildParameterArray(paramNames, paramValues);

                return databaseObj.GetDataSet(StoreProcedure.SP_GET_APPT_SCHEDULES, Enumerations.Command_Type.StoredProcedure, paramList);
            }
            finally
            {
                paramNames = null;

                paramValues = null;

                paramList = null;
            }
        }
    }
}
