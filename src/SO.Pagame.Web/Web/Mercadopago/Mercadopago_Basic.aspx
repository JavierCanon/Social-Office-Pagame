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
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Mercadopago_Basic.aspx.cs"
    Inherits="Pagame.Web.Mercadopago.Mercadopago_Basic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <div class="container">

        <div runat="server" id="alert" class="alert alert-dismissible alert-warning"></div>

        <h1>Confirmar Pagar con Mercadopago</h1>

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
            <label class="col-sm-2 col-form-label">Total $:</label>
            <div class="col-sm-10">
                <p><%: Session["Payment_Total"] %></p>
            </div>
        </div>

        <p>
            Para confirmar haga click en el botón pagar, y será redirigido a la pasarela
       para que realice un pago seguro, no almacenamos ningún dato confidencial.
        </p>
        <a class="btn btn-lg btn-info" href="Anonymous.aspx">Volver</a>
        <a class="btn btn-lg btn-success" href="<%//= mercadoPreference["response"]["sandbox_init_point"] %>" target="_blank">Pagar</a>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
</asp:Content>
