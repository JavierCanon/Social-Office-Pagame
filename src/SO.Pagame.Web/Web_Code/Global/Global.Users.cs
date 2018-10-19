using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.Routing;

using System.Web.SessionState;
using log4net.Appender;

using Models.Errors;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;

namespace Pagame
{
    public partial class Global : System.Web.HttpApplication
    {


        #region User Settings


        public class Users
        {

            /// <summary>
            /// Get a user setting stored in DB or Cache
            /// </summary>
            /// <param name="sname">Name of setting</param>
            /// <returns></returns>
            public static string GetUserSetting(string suserID, string sname)
            {

                string key = "UserSetting_" + sname;

                // in cache?
                if (HttpRuntime.Cache[key] == null)
                {
                    string tsql = "EXEC [User_Settings_GetValue_ByName] " + suserID + ", '" + sname + "'";
                    return Softcanon.DAL.SqlApiSqlClient.GetStringRecordValue(tsql, Global.DAL.GetConnectionStringDBMain());

                }
                else
                {
                    return HttpRuntime.Cache[key].ToString();

                }

            }

            /// <summary>
            /// Set or create a new user setting in DB
            /// </summary>
            public static void SetUserSetting(string suserID, string sname, string svalue)
            {
                // save
                string tsql = "EXEC [User_Settings_Update_Value]  " + suserID + ", '" + sname + "', '" + svalue + "'";
                Softcanon.DAL.SqlApiSqlClient.ExecuteSqlString(tsql, Global.DAL.GetConnectionStringDBMain());

                // store in cache
                string key = "UserSetting_" + sname;
                HttpRuntime.Cache.Insert(key, svalue, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5));

            }

        }
        #endregion User Settings





    }
}
