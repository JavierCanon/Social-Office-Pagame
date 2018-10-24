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
using Pagame.Models.Security;
using System;

namespace Pagame.Web.Epayco
{
    public partial class Epayco_Basic : System.Web.UI.Page
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
            p_key = Global.Configuration.Payments.Epayco.Basic.GetPublicKey();
            p_id_invoice = Session["Payment_ID"].ToString();
            p_description = "Factura " + Session["Payment_ID"].ToString();
            p_amount = Session["Payment_Total"].ToString();
            p_amount_base = "0";
            p_tax = "0";
            p_email = Session["Payment_Email"].ToString();
            p_currency_code = Global.Configuration.Payments.GetCurrencyDefault();
            p_test_request = Global.Configuration.Development.GetIsEnabledDeveloperMode() ? "true" : "false";

            p_url_response = Global.Configuration.Payments.Epayco.GetURLResponse();
            p_url_confirmation = Global.Configuration.Payments.Epayco.GetURLConfirmation();

            p_signature = GenerateSignature(p_cust_id_cliente, p_key, p_id_invoice, p_amount, p_currency_code);

            // https://epayco.co/docs/standard_checkout/#introduction
            /*
            Solicitud HTTP
POST https://secure.payco.co/checkout.php

Variables
Campo	Requerido	Descripción
p_cust_id_cliente	Si	Id del comercio
p_key	Si	Llave de seguridad del comercio
p_id_invoice	Si	Id de la factura
p_description	Si	Descripción del producto
p_amount	Si	Valor total del producto
p_amount_base	Si	Valor sin IVA
p_tax	Si	IVA
p_email	Si	Email del cliente que realizara la transacción
p_currency_code	Si	Código de la moneda (COP,USD)
p_signature	Si	Firma de seguridad para validar que los datos enviados en el formulario no hayan sido modificados por el cliente o mientras viajan a nuestra plataforma asegurando la integridad de los datos.
p_test_request	Si	Fase de integración (TRUE: en pruebas, FALSE: en producción)
p_customer_ip	No	Dirección IP del cliente que realizara la transacción
p_url_response	No	url donde retornaran los datos después de la transacción
p_url_confirmation	No	url donde confirman los datos de la transacción a nivel de servidor a servidor.
p_confirm_method	No	Método de confirmación (POST O GET)
p_extra1	No	Dato extra 1
p_extra2	No	Dato extra 2
p_extra3	No	Dato extra 3
p_billing_document	No	Documento comprador
p_billing_name	No	Nombre comprador
p_billing_lastname	No	Apellido comprador
p_billing_address	No	Dirección comprador
p_billing_country	No	País comprador
p_billing_email	No	Email comprador
p_billing_phone	No	Teléfono comprador
p_billing_cellphone	No	Celular comprador
            */

        }


        string GenerateSignature(string p_cust_id_cliente, string p_key, string p_id_invoice, string p_amount, string p_currency_code)
        {
            //  https://epayco.co/docs/standard_checkout/#llaves
            /*
            Para generar esta firma es necesario encriptar con md5 las siguiente variables:
             (p_cust_id_cliente + p_key + p_id_invoice + p_amount + p_currency_code)
             separadas por el carácter '^'
             */

            return MD5HashAlgorithm.CreateMD5Hash(
                p_cust_id_cliente + "^" + p_key + "^" + p_id_invoice + "^" + p_amount + "^" + p_currency_code);

        }


    }
}