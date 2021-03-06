﻿// Copyright (c) 2018 Javier Cañon 
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