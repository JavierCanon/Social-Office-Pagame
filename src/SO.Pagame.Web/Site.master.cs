// Copyright (c) 2018 Javier Cañon 
// https://www.javiercanon.com 
// https://www.xn--javiercaon-09a.com
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
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