using Pagame;
using System;
using System.IO;
using System.Web;

namespace Models.Errors
{
	public sealed class ExceptionUtility
	{
		private ExceptionUtility()
		{
		}

		public static void LogException(Exception exc, string source)
		{

            if (!Global.LogErrorsToTXT()) return;


			var logFile = HttpContext.Current.Server.MapPath("~")
				+ "\\App_Data\\Logs\\Error_" + string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now) + ".txt";

			var sw = new StreamWriter(logFile, true);
			sw.WriteLine("********** {0}, {1} **********", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
			if (exc.InnerException != null)
			{
				sw.Write("Inner Exception Type: ");
				sw.WriteLine(exc.InnerException.GetType().ToString());
				sw.Write("Inner Exception: ");
				sw.WriteLine(exc.InnerException.Message);
				sw.Write("Inner Source: ");
				sw.WriteLine(exc.InnerException.Source);
				if (exc.InnerException.StackTrace != null)
				{
					sw.WriteLine("Inner Stack Trace: ");
					sw.WriteLine(exc.InnerException.StackTrace);
				}
			}
			sw.Write("Exception Type: ");
			sw.WriteLine(exc.GetType().ToString());
			sw.WriteLine("Exception: " + exc.Message);
			sw.WriteLine("Source: " + source);
			sw.WriteLine("Stack Trace: ");
			if (exc.StackTrace != null)
			{
				sw.WriteLine(exc.StackTrace);
				sw.WriteLine();
			}
			sw.Flush();
			sw.Close();
		}

		public static void NotifySystemOps(Exception exc)
		{
            // send email?.

		}
	}
}
