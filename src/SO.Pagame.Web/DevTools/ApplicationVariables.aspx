<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplicationVariables.aspx.cs" Inherits="SO.DevTools.ApplicationVariables" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <%
                foreach (string x in Application.AllKeys)
                    Response.Write("<b>" + x + "</b> = " + Application[x].ToString() + "<br /><br />");
            %>
        </div>
    </form>
</body>
</html>
