using mercadopago;
using System;
using System.Collections;

namespace Pagame.Web.Payments
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