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
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">

    <div class="jumbotron">
        <div class="container">
            <h1>Pagos Online</h1>
            <div class="row">
                <div class="col-auto"><i class="far fa-credit-card fa-4x"></i></div>
                <div class="col-auto">
                    <p class="shadow-lg">
                        Realice fácil y rápidamente el pago de su factura en solo 3 pasos.
                    </p>
                </div>
            </div>
            <div><a class="btn btn-primary btn-lg" href="Web/Payments/Anonymous.aspx">Comenzar</a></div>
        </div>
    </div>

    <div class="container">
        <div class="row">

            <div class="col-md-4 box-main-wraper">
                <div class="box-main">
                    <div class="box-icon"><i class="far fa-user fa-4x"></i></div>
                    <h2 class="box-title">Identifiquese en el sistema</h2>
                    <div class="bg-light">
                        Digite su codigo de cliente y el número de factura a pagar.
                    </div>
                    <div><a class="btn btn-primary btn-lg" href="Web/Payments/Anonymous.aspx">Comenzar</a></div>
                </div>
            </div>

            <div class="col-md-4 box-main-wraper">
                <div class="box-main">
                    <div class="box-icon"><i class="far fa-heart fa-4x"></i></div>
                    <h2 class="box-title">Seleccione el método de pago</h2>
                    <div class="bg-light">
                        Identifique la forma de pago de su preferencia, y seleccione una de las pasarelas de pago.
                        
                    </div>
                    <div><a class="btn btn-primary btn-lg" href="Web/Payments/Anonymous.aspx">Comenzar</a></div>

                </div>
            </div>

            <div class="col-md-4 box-main-wraper">
                <div class="box-main">
                    <div class="box-icon"><i class="far fa-money-bill-alt fa-3x"></i></div>
                    <h2 class="box-title">Realice el pago con la pasarela de pagos seleccionada</h2>
                    <div class="bg-light">
                        Pague seguro dentro de la plataforma seleccionada, si es exitoso o fallido el sistema le avisará.
                        
                    </div>
                    <div><a class="btn btn-primary btn-lg" href="Web/Payments/Anonymous.aspx">Comenzar</a></div>
                </div>
            </div>


        </div>
    </div>

</asp:Content>
