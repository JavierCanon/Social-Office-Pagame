using System;
using Errors;

namespace Errors
{
    public partial class ErrorPageGeneric : System.Web.UI.Page
    {
        protected Exception ex = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            


            var ex = Server.GetLastError();
            if (ex == null)
                return;

            var safeMsg = "A problem has occurred in the web site. ";

            if (ex.InnerException != null)
            {
                innerTrace.Text = ex.InnerException.StackTrace;
                InnerErrorPanel.Visible = Request.IsLocal;
                innerMessage.Text = ex.InnerException.Message;
            }
            if (Request.IsLocal)
            {
                exTrace.Visible = true;
            }
            else
            {
                ex = new Exception(safeMsg, ex);
            }
            exMessage.Text = ex.Message;
            exTrace.Text = ex.StackTrace;

            Models.Errors.ExceptionUtility.LogException(ex, "Generic Error Page");
            Models.Errors.ExceptionUtility.NotifySystemOps(ex);

            Server.ClearError();
        }
    }
}
