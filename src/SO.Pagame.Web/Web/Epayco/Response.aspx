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
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Response.aspx.cs" Inherits="Pagame.Web.Epayco.Response" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentMain" runat="server">

    <div class="container">

        <h1>Resultado Transacción ePayco</h1>

        <div class="alert alert-primary">
            Su transacción esta: <b><%: Request.Form["x_response"] != null ? Request.Form["x_response"]  : "" %></b> (<%: Request.Form["x_cod_response"] != null ? Request.Form["x_cod_response"]  : "" %>).
        </div>

        <table class="table table-striped">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Descripción</th>
                </tr>
            </thead>
            <tbody>

                <tr>
                    <th scope="row">1</th>
                    <td>Descripción</td>
                    <td><%: Request.Form["x_description"] != null ? Request.Form["x_description"]  : "" %></td>
                </tr>

                <tr>
                    <th scope="row">2</th>
                    <td>Total</td>
                    <td><%: Request.Form["x_amount_ok"] != null ? Request.Form["x_amount_ok"]  : "" %></td>
                </tr>

                <tr>
                    <th scope="row">3</th>
                    <td>Moneda</td>
                    <td><%: Request.Form["x_currency_code"] != null ? Request.Form["x_currency_code"]  : "" %></td>
                </tr>

                <tr>
                    <th scope="row">4</th>
                    <td>Franquicia</td>
                    <td><%: Request.Form["x_franchise"] != null ? Request.Form["x_franchise"]  : "" %></td>
                </tr>

                <tr>
                    <th scope="row">5</th>
                    <td>Fecha</td>
                    <td><%: Request.Form["x_transaction_date"] != null ? Request.Form["x_transaction_date"]  : "" %></td>
                </tr>


                <tr>
                    <th scope="row">6</th>
                    <td>ID Transacción</td>
                    <td><%: Request.Form["x_transaction_id"] != null ? Request.Form["x_transaction_id"]  : "" %></td>
                </tr>


                <tr>
                    <th scope="row">7</th>
                    <td>Descripción Respuesta</td>
                    <td><%: Request.Form["x_response_reason_text"] != null ? Request.Form["x_response_reason_text"]  : "" %></td>
                </tr>

            </tbody>
        </table>


    </div>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentMain2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentFooter" runat="server">
</asp:Content>
