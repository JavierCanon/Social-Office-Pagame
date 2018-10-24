<%-- 
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
--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Epayco_Open.aspx.cs" Inherits="Pagame.Web.Epayco.Epayco_Open" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    <script async="async" src='https://www.google.com/recaptcha/api.js'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" runat="server">

    <div class="container">

        <h1>Otros Pagos con ePayco</h1>

        <div class="alert alert-info">
            <p>Utilice esta opción para pagos de montos variables, ingresando manualmente la referencia y monto total a pagar.</p>
        </div>

        <div class="form-group">
            <label>¿Código Captcha?</label>
            <div class="g-recaptcha" data-sitekey="<%= Pagame.Global.Configuration.Security.GetRecaptchaWebsiteKey() %>"></div>
            <small class="form-text text-muted">Verificando que no sea un robot.
            </small>
        </div>

        <div class="form-group">
            <dx:ASPxLabel runat="server" ID="labelValidateData" Text="Valide el captcha y luego presione continuar..." CssClass="alert alert-info"></dx:ASPxLabel>
        </div>

        <div class="form-group">
            <dx:BootstrapButton runat="server" ID="btnPay" Text="Continuar" CausesValidation="true"
                ValidationGroup="Gateway" SettingsBootstrap-RenderOption="Success"
                SettingsBootstrap-Sizing="Large"
                OnClick="BtnPay_Click">
            </dx:BootstrapButton>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentMain2" runat="server">

    <div class="container">

        <form id="frm_ePaycoCheckoutOpen" name="frm_ePaycoCheckoutOpen" method="post" action="https://secure.payco.co/checkoutopen.php">
            <input name="p_cust_id_cliente" type="hidden" value="<%: p_cust_id_cliente %>" />
            <input name="p_key" type="hidden" value="93347d3b4d5342960b4e166625fe88d51bd63ac9" />
            <input name="p_id_factura" type="hidden" value="" />
            <input name="p_description" type="hidden" value=" Factura Pendiente" />
            <input name="p_test_request" type="hidden" value="<%: p_test_request %>" />
            <input name="p_url_respuesta" type="hidden" value="<%: p_url_response %>" />
            <input name="p_url_confirmacion" type="hidden" value="<%: p_url_confirmation %>" />
             
            <input runat="server" visible="false" type="image" id="imagenePayco" src="https://369969691f476073508a-60bf0867add971908d4f26a64519c2aa.ssl.cf5.rackcdn.com/btns/btn4.png" />
            <input type="hidden" id="idboton" name="idboton" value="6521" />
                
        </form>


    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentFooter" runat="server">
</asp:Content>
