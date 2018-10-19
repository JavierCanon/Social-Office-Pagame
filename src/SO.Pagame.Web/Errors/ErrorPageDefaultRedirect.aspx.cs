using System;
using System.Web;

namespace Errors
{
    public partial class ErrorPageDefaultRedirect : System.Web.UI.Page
    {
        protected HttpException ex = null;
        protected void Page_Load(object sender, EventArgs e)
        {            

            ex = new HttpException("defaultRedirect");
            Models.Errors.ExceptionUtility.LogException(ex, "Caught in DefaultRedirectErrorPage");
            Models.Errors.ExceptionUtility.NotifySystemOps(ex);
        }
    }
}
