using System;
using System.Web;
using Errors; 

namespace Errors
{
    //! Todo: custom error page for each website
    /// <summary>
    /// 
    /// </summary>
    public partial class ErrorPageHttp404 : System.Web.UI.Page
    {
        protected HttpException ex = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            ex = new HttpException("HTTP 404");
            ExceptionUtility.LogException(ex, "Caught in Http404ErrorPage");
            ExceptionUtility.NotifySystemOps(ex);
            */

            Pagame.Global.LogError(Context, Pagame.Global.EnumLogCategories.CONTENT, "HTTP 404: " + Request.RawUrl.ToString());

        }
    }
}
