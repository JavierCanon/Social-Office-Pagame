using Pagame;
using System;
using System.Web.UI;

namespace Web
{
    public partial class SiteMaster : Pagame.Views.MasterPagesBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = Global.Configuration.General.GetSiteTitlePages();
            TopMenu.Items.FindByName("About").NavigateUrl = Global.Configuration.General.GetSiteMenuAboutLink();
            TopMenu.Items.FindByName("Contact").NavigateUrl = Global.Configuration.General.GetSiteMenuContactLink();
        }

        public static string GetExternalCSS(Page page)
        {
            if (System.Web.HttpContext.Current.Request.IsLocal)
            {
                return page.ResolveUrl("~/Content/Css/bootstrap.min.css");
            }
            else
            {
                return "https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css";
            }
        }

        public static string GetMainStyleCSS(Page page)
        {
            if (System.Web.HttpContext.Current.Request.IsLocal)
            {
                return page.ResolveUrl("~/Content/Css/Site-1.0.0.css");
            }
            else
            {
                return page.ResolveUrl("~/Content/Css/Site-1.0.0.min.css");
            }
        }

    }
}