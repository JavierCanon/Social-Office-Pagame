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
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Epayco_Basic.aspx.cs" Inherits="Pagame.Web.Epayco.Epayco_Basic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain2" runat="server">
    <div class="container">

        <form id="formPay" method="post" action="https://secure.payco.co/checkout.php">
            <input name="p_cust_id_cliente" id="p_cust_id_cliente" type="hidden" value="<%: p_cust_id_cliente %>" />
            <input name="p_key" id="p_key" type="hidden" value="<%: p_key %>" />
            <input name="p_id_invoice" id="p_id_invoice" type="hidden" value="<%: p_id_invoice %>" />
            <input name="p_description" id="p_description" type="hidden" value="<%: p_description %>" />
            <input name="p_currency_code" id="p_currency_code" type="hidden" value="<%: p_currency_code %>" />
            <input name="p_amount" id="p_amount" type="hidden" value="<%: p_amount %>" />
            <input name="p_tax" id="p_tax" type="hidden" value="<%: p_tax %>" />
            <input name="p_amount_base" id="p_amount_base" type="hidden" value="<%: p_amount_base %>" />
            <input name="p_email" id="p_email" type="hidden" value="<%: p_email %>" />
            <input name="p_test_request" id="p_test_request" type="hidden" value="<%: p_test_request %>" />
            <input name="p_signature" id="p_signature" type="hidden" value="<%: p_signature %>" />
            <input name="p_url_response" id="p_url_response" type="hidden" value="<%: p_url_response %>" />
            <input name="p_url_confirmation" id="p_url_confirmation" type="hidden" value="<%: p_url_confirmation %>" />
            <%-- 
            <input name="p_url_response" id="p_url_response" type="hidden" value="" />
            <input name="p_url_confirmation" id="p_url_confirmation" type="hidden" value="" /> --%>

            <div runat="server" id="alert" visible="false" class="alert alert-dismissible alert-warning"></div>

            <h1>Confirmar Pagar con ePayco</h1>

            <div class="form-group row">
                <label class="col-sm-2 col-form-label">Email de aviso y registro pasarela:</label>
                <div class="col-sm-10">
                    <p><%: Session["Payment_Email"] %></p>
                </div>
            </div>

            <div class="form-group row">
                <label class="col-sm-2 col-form-label">Referencia de pago:</label>
                <div class="col-sm-10">
                    <p><%: Session["Payment_ID"] %></p>
                </div>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 col-form-label">Monto Total:</label>
                <div class="col-sm-10">
                    <p><%: Convert.ToDecimal(Session["Payment_Total"].ToString()).ToString("c2") %></p>
                </div>
            </div>

            <p>
                Para confirmar haga click en el siguiente botón, y será redirigido a la pasarela
                para que realice un pago seguro, no almacenamos ningún dato confidencial.
            </p>
            <a class="btn btn-lg btn-info" href="<%: ResolveUrl("~/") %>">Volver</a>
            <button type="submit" class="btn btn-lg btn-success" >Pagar</button>
        </form>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
</asp:Content>
