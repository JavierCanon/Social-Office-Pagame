<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Errors/ErrorMasterPage.Master" Inherits="Errors.ErrorPageHttp404" CodeBehind="ErrorPageHttp404.aspx.cs"
    Trace="false" TraceMode="SortByCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    <title>HTTP 404 Error Page</title>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <div>
        <h2>HTTP 404 Error Page - <%: Pagame.Global.AppComercialName %></h2>
        <%= Resources.Error.SorryPageNotFound %>
        <br />
        <br />
        <%= Resources.Error.Returntothe %>
        <asp:HyperLink runat="server" Target="_self" Text="<%$ Resources:Error, DefaultPage %>" NavigateUrl="~/Default.aspx"></asp:HyperLink>

    </div>
</asp:Content>



