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
