<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Mercadopago_Basic.aspx.cs"
    Inherits="Pagame.Web.Payments.Mercadopago_Basic" %>

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
