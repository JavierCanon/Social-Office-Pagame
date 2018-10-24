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
using mercadopago;
using System;
using System.Collections;

namespace Pagame.Web.Mercadopago
{
    public partial class Mercadopago_Basic : System.Web.UI.Page
    {

        protected string paylinkURL;

        protected void Page_Load(object sender, EventArgs e)
        {
            // https://github.com/mercadopago/sdk-dotnet

            // tests - sandbox
            // https://www.mercadopago.com.co/developers/en/solutions/payments/basic-checkout/test/basic-sandbox/
            // <a href="<% Response.Write(preference["response"]["sandbox_init_point"]); %>">Pay</a>
            // production
            // href="<%= mercadoPreference["response"]["init_point"] %>"

            if (Session["Payment_ID"] == null || Session["Payment_Total"] == null)
            {

                alert.InnerText = "Información de pago no encontrada.";

            }
            else
            {

                MP mp = new MP(Global.Configuration.Payments.Mercadopago.Basic.GetClientID()
                    , Global.Configuration.Payments.Mercadopago.Basic.GetClientSecret());


                if (Global.Configuration.Development.GetIsEnabledDeveloperMode())
                {
                    mp.sandboxMode(true);
                }


                string accessToken = mp.getAccessToken();


                // https://www.mercadopago.com.co/developers/es/solutions/payments/basic-checkout/receive-payments/additional-info/
                // Available currencies at: https://api.mercadopago.com/currencies 
                string preferenceData = "{\"items\":" +
                    "[{" +
                        "\"title\":\"Factura\"," +
                        "\"quantity\":1," +
                        "\"currency_id\":\"COP\"," +
                "\"unit_price\":100.0" +
            "}]" +
        "}";
                               
                Hashtable preference = mp.createPreference(preferenceData);

                //paylinkURL = preference["response"]["sandbox_init_point"];
                alert.InnerText = Server.HtmlEncode(preference["response"].ToString());

                if (Global.Configuration.Development.GetIsEnabledDeveloperMode())
                {


                }
                else
                {



                }


            }
        }
    }
}