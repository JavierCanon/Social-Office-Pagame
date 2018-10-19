using System;
using System.Web;
using Errors; 

namespace Errors
{
    public partial class ErrorPageHttp403 : System.Web.UI.Page
    {
        protected HttpException ex = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            /*
            ex = new HttpException("HTTP 403");
            ExceptionUtility.LogException(ex, "Caught in Http403ErrorPage");
            ExceptionUtility.NotifySystemOps(ex);
            */

            Pagame.Global.LogError(Context, Pagame.Global.EnumLogCategories.SECURITY, "HTTP 403: " + Request.RawUrl.ToString());

        }
    }
}
