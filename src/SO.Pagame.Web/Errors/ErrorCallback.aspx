<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Errors/ErrorMasterPage.Master" Inherits="Errors.ErrorCallback" CodeBehind="ErrorCallback.aspx.cs" %>

<%@ Import Namespace="SO" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    <title>Error Callback <%: Pagame.Global.AppComercialName %></title>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <div class="content">
        <img src="<%= Global.Utils.Webpath.GetRequestApplicationUrlPath() %>Content/Icons/alert.gif" alt="" width="16" height="16" />
        <div style="padding: 10px; border: 1px solid #FF6600">
            <h2>Error en la solicitud. <%: Pagame.Global.AppComercialName %>.</h2>
            <p>Ha ocurrido un problema con la solicitud actual, la cual puede ser por alguna de estas razones:</p>
            <ul>
                <li>Si esta consultando un reporte o gráfico, verifique que los parámetros sean validos o seleccione otros.
                </li>
                <li>Su sesión ya no es valida, cierre el aplicativo y vuelva a ingresar.</li>
            </ul>
            <p>Por favor utilice el botón volver atras de su navegador, o haga click en el siguiente link: <a href="javascript:history.back()">volver</a>.</p>
            <hr />
            <p>Detalle Técnico:</p>
            <p><%=Request.QueryString["DXCallbackErrorMessage"]%></p>
        </div>
    </div>
</asp:Content>



