using System;
using System.Web;
using System.Text;
using DataBaseHandler35;
using System.Configuration;
using System.Collections.Generic;

namespace BL.Common.BasseDataAccess
{
    public class BaseData
    {
        # region Member variables

        // Declare variable of type 'BusinessDataAccess' to hold reference to the class present in 'DatabaseHandler'
        public BusinessDataAccess databaseObj = null;

        # endregion

        # region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BaseData()
        {
            try
            {
                // Check if context and session are not equal to null
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                {
                    // Check if session is not equal to null
                    if (HttpContext.Current.Session != null)
                    {
                        // Get the reference of type 'BusinessDataAccess' from session
                        databaseObj = (BusinessDataAccess)HttpContext.Current.Session["databaseObj"];
                    }
                }

                // Check if reference of type 'BusinessDataAccess' is equal to null
                if (databaseObj == null)
                {
                    // Declare variable of type string and initialize it with the value (connection string) read from config value
                    string connectionString = ConfigurationManager.AppSettings["FritzysDataBaseConnectionProvider"].ToString();

                    // Initialize variable of type 'BusinessDataAccess' with reference of class present in 'DatabaseHandler'
                    databaseObj = new BusinessDataAccess(connectionString);

                    // Check if context and session are not equal to null
                    if (HttpContext.Current != null && HttpContext.Current.Session != null)
                    {
                        // Set the reference of type 'BusinessDataAccess' in session
                        HttpContext.Current.Session["databaseObj"] = databaseObj;
                    }
                }
            }
            finally
            {

            }
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="databaseObj">Reference of type 'BusinessDataAccess'</param>
        public BaseData(BusinessDataAccess databaseObj)
        {
            try
            {
                // Set reference of type 'BusinessDataAccess'
                this.databaseObj = databaseObj;
            }
            finally
            {

            }
        }

        # endregion

        /// <summary>
        /// Method to release the memory allocated to reference of type 'BusinessDataAccess' and close database connection
        /// </summary>
        public void Dispose()
        {
            try
            {
                // Call 'Dispose' method with 'false' value (indicating that dispose should not be forceful)
                Dispose(false);
            }
            finally
            {

            }
        }

        /// <summary>
        /// Method to release the memory allocated to reference of type 'BusinessDataAccess' and close database connection
        /// </summary>
        /// <param name="force">Indicating that dispose should not be forceful</param>
        public void Dispose(bool force)
        {
            try
            {
                // Check if context or session are equal to null or condition that dispose should be forceful
                if (HttpContext.Current == null || HttpContext.Current.Session == null || force)
                {
                    // Check if reference of type 'BusinessDataAccess' is not equal to null
                    if (databaseObj != null)
                    {
                        // Call method to close connection
                        databaseObj.CloseConnection();

                        // Call method to dispose object
                        databaseObj.Dispose();

                        // Release memory allocated to reference of type 'BusinessDataAccess'
                        databaseObj = null;
                    }
                }
            }
            finally
            {

            }
        }
    }
}
