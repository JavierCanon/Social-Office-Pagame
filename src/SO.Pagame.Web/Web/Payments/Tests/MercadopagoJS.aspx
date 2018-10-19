<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MercadopagoJS.aspx.cs" Inherits="Pagame.Web.Payments.Tests.MercadopagoJS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://secure.mlstatic.com/sdk/javascript/v1/mercadopago.js"></script>
    <script>

        var tokenHandler, formhtml;

        function setupMP(){
            Mercadopago.setPublishableKey("TEST-e01c2d83-aa0f-4727-a941-88ce19043d5a");
            tokenHandler = Mercadopago.createToken();
            Mercadopago.createToken(formhtml, tokenHandler);
            document.getElementById("form1").innerHTML = formhtml;
        }
    </script>
</head>
<body onload="setupMP();">
    <form id="form1" runat="server">

    </form>
</body>
</html>
