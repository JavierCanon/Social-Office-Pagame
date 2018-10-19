<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Errors/ErrorMasterPage.Master" Inherits="Errors.ErrorInstallation" CodeBehind="ErrorInstallation.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">

    <title>Error Instalacion <%: Pagame.Global.AppComercialName %></title>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <div class="content">
        <div class="error">
            <h2><%: Pagame.Global.AppComercialName %>: El aplicativo no se encuentra correctamente instalado y configurado, contáctese con soporte. </h2>
            <h3>Servidor:
                <% = Request.Url.Authority.ToLower() %>
            </h3>
        </div>
    </div>
</asp:Content>

