<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServerVariables.aspx.cs" Inherits="SO.DevTools.ServerVariables" Trace="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <% = Softcanon.Tools.Web.WebPaths.GetApplicationPath(this) %><br />
            <br />
            <% = Request.Url.Host %><br />
            <br />
            <%=HttpRuntime.AppDomainAppVirtualPath %><br />
            <br />
            <%=HttpRuntime.AppDomainAppPath %><br />
            <br />
            <%=HttpRuntime.AppDomainAppId %><br />
            <br />
            <%
                foreach (string x in Request.ServerVariables)
                    Response.Write("<b>" + x + "</b> = " + Request.ServerVariables[x].ToString() + "<br /><br />");
            %>
        </div>
    </form>
</body>
</html>
