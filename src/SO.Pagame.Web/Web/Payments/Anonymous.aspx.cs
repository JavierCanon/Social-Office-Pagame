using Pagame.Models.Security.Recaptcha;
using Softcanon.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pagame.Web.Payments
{
    public partial class Anonymous : System.Web.UI.Page
    {

        protected void Page_Init(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            SetupGateways();

        }

        void SetupGateways() {

            //radioPaymentGateway.Items.Clear();

            if (ViewState["setuppg"] != null)
            {
                if (Global.Configuration.Payments.Mercadopago.GetIsEnabled())
                {
                    radioPaymentGateway.Items.Add("MercadoPago", "Mercadopago");
                    imgMercadopago.Visible = false;
                    lnkMercadopago.Visible = false;
                }

                if (Global.Configuration.Payments.Epayco.GetIsEnabled())
                {
                    radioPaymentGateway.Items.Add("ePayco", "Epayco");
                    imgEpayco.Visible = false;
                    lnkEpayco.Visible = false;
                }
            }
            ViewState["setuppg"] = "1";
        }


        protected void BtnValidateData_Click(object sender, EventArgs e)
        {
            labelValidateData.CssClass = "alert alert-danger";

            // validate captcha:
            if (Request["g-recaptcha-response"] == null)
            {
                labelValidateData.Text = "Error no Captcha field form.";
                return;

            }
            
            if (txtCodCliente.Value == null || txtCodPago.Value == null) {

                labelValidateData.Text = "Parametros no pueden estar en blanco.";
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
                                 
            string CodCliente = txtCodCliente.Value.ToString();
            string CodPago = txtCodPago.Value.ToString();

            /*
            */
            string tsql = @"
EXEC Factura_Get_Total @CodCliente, @Numero;
";
            SqlParameter[] params1 ={
                new SqlParameter { ParameterName="@CodCliente", DbType=DbType.String, Size=60, Value= CodCliente }
               ,new SqlParameter { ParameterName="@Numero", DbType=DbType.String, Size=30, Value= CodPago  }
        };

            decimal? result = SqlApiSqlClient.GetNumericRecordValue(tsql, params1, Global.DAL.GetConnectionStringDBMain(), 60);

            if (result == null)
            {

                labelValidateData.Text = "No se encuentran datos coincidentes para el pago.";
                labelValidateData.CssClass = "alert alert-warning";

            }
            else {

                txtMontoPago.Value = result.Value;
                labelValidateData.Text = "Comprobante encontrado, seleccione forma de pago...";
                labelValidateData.CssClass = "alert alert-success";
            }
                                          
        }

        protected void BtnPay_Click(object sender, EventArgs e)
        {

            Session["Payment_ID"] = txtCodPago.Value.ToString();
            Session["Payment_Total"] = txtMontoPago.Value.ToString();
            Session["Payment_Email"] = txtEmail.Value.ToString();

            if (radioPaymentGateway.SelectedItem == null) return; //TODO: show alert.
            string pay = radioPaymentGateway.SelectedItem.Value.ToString();

            if (pay == "Mercadopago")
                Response.Redirect("Mercadopago_Basic.aspx");
            else if (pay == "Epayco")
                Response.Redirect("Epayco_Basic.aspx");
            else
                return; //TODO: show alert.
        }
    }
}