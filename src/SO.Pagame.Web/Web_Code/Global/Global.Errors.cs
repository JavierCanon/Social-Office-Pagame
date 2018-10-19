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


        #region Errors utils

        public static bool LogErrorsToTXT()
        {

            return Configuration.Logger.GetIsEnabledLoggerErrorsToTextApp_Data();
        }
        public static void Log_File_Write_Error(string sError)
        {
            var strFileName = "Err_dt_" + DateTime.Now.Month + "_" + DateTime.Now.Day
                                + "_" + DateTime.Now.Year + "_Time_" + DateTime.Now.Hour + "_" +
                                DateTime.Now.Minute + "_" + DateTime.Now.Second + "_"
                                + DateTime.Now.Millisecond + ".txt";

            strFileName = sDirLogs + strFileName;
            var fsOut = File.Create(strFileName);
            var sw = new StreamWriter(fsOut);

            sw.WriteLine(sError);
            sw.Flush();
            sw.Close();
            fsOut.Close();
        }
        #endregion Errors utils



    }
}
