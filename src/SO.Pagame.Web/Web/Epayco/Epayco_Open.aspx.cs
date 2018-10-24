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
using Pagame.Models.Security.Recaptcha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pagame.Web.Epayco
{
    public partial class Epayco_Open : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SetupForm();
        }

        protected string
        p_cust_id_cliente,
        p_key,
        p_id_invoice,
        p_description,
        p_amount,
        p_amount_base,
        p_tax,
        p_email,
        p_currency_code,
        p_signature,
        p_test_request,
        p_url_response,
        p_url_confirmation
        ;

        void SetupForm()
        {

            //TODO: get data from db. Custom reponse and confirmation URL's.
            //TODO: IVA

            p_cust_id_cliente = Global.Configuration.Payments.Epayco.Basic.GetClientID();
            //p_key = Global.Configuration.Payments.Epayco.Basic.GetPublicKey();
            //p_id_invoice = Session["Payment_ID"].ToString();
            //p_description = "Factura " + Session["Payment_ID"].ToString();
            //p_amount = Session["Payment_Total"].ToString();
            //p_amount_base = "0";
            //p_tax = "0";
            //p_email = Session["Payment_Email"].ToString();
            //p_currency_code = Global.Configuration.Payments.GetCurrencyDefault();
            p_test_request = Global.Configuration.Development.GetIsEnabledDeveloperMode() ? "true" : "false";

            p_url_response = Global.Configuration.Payments.Epayco.GetURLResponse();
            p_url_confirmation = Global.Configuration.Payments.Epayco.GetURLConfirmation();

            //p_signature = GenerateSignature(p_cust_id_cliente, p_key, p_id_invoice, p_amount, p_currency_code);



        }

        protected void BtnPay_Click(object sender, EventArgs e)
        {
            labelValidateData.CssClass = "alert alert-danger";

            // validate captcha:
            if (Request["g-recaptcha-response"] == null)
            {
                labelValidateData.Text = "Error no Captcha field form.";
                return;

            }
            var Recaptcha1 = new Recaptcha2VerificationHelper();
            RecaptchaVerificationResult captchaResult;

            if (string.IsNullOrEmpty(Request["g-recaptcha-response"].ToString()))
            {
                labelValidateData.Text = "El Captcha no puede estar vacio.";
                return;
            }
            else
            {

                string secretkey = Global.Configuration.Security.GetRecaptchaSecretKey();

                captchaResult = Recaptcha1.VerifyRecaptchaResponse(secretkey, Request["g-recaptcha-response"].ToString());

                if (captchaResult == RecaptchaVerificationResult.Success)
                {
                    //Response.Redirect( "Welcome.aspx" );
                    //labelValidateData.Text = "Captcha OK :D";

                    string s = @"
if (window.addEventListener) {
      window.addEventListener('load', go, false);
} else {
      window.attachEvent('onload', go);
}                     
function go(){
    document.getElementById('frm_ePaycoCheckoutOpen').submit();
}
                        ";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "formpost", s, true);

                    imagenePayco.Visible = true; // if autosubmit dont work, show button.



                }
                else if (captchaResult == RecaptchaVerificationResult.IncorrectCaptchaSolution)
                {
                    labelValidateData.Text = "Valor de Captcha NO Valido.";
                    return;
                }
                else
                {
                    labelValidateData.Text = "Existe un problema para validar el captcha, intente mas tarde o por favor contacte a soporte.";
                    return;
                }

            }


        }


    }
}