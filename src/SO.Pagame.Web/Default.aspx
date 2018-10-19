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
