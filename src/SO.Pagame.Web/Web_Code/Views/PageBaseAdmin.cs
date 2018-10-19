using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Pagame.Views
{
    public class PageBaseAdmin: Views.PageBase
    {

        protected override void CheckSession()
        {
            if (Session["User.UserID"] == null)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("~/Web/Login.aspx?ReturnUrl=" + Request.RawUrl);
            }
            else {
                /*

                if (Session["User.ResellerGUID"].ToString() != AppConfiguration.Application.Reseller.GetResellerMainGUID()) {
                    Session.Clear();
                    Session.Abandon();
                    Response.Redirect("~/Web/Login.aspx?ReturnUrl=" + Request.RawUrl);               
                }
                */
            
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        protected override bool CheckIsValidSession()
        {
            if (Session["User.UserID"] != null)
            {
                /*
                if (Session["User.ResellerGUID"].ToString() != AppConfiguration.Application.Reseller.GetResellerMainGUID())
                    return false;
                else
                    return true;
                    */
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}