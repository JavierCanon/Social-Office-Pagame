<%@ Page Title="" Language="C#" MasterPageFile="~/DevTools/DevTools.Master" AutoEventWireup="true" CodeBehind="CultureInfo.aspx.cs" Inherits="SO.DevTools.CultureInfo" %>

<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .culture td {
            padding: 5px;
            border: 1px solid gray;
        }

        .culture thead th {
            font: bolder;
            text-align: center;
            border: 1px double gray;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>CULTURES INFO</h1>

    <h2>NEUTRAL CULTURES</h2>

    <table class="culture">
        <thead>
            <tr>
                <th>Name</th>
                <th>DisplayName</th>
                <th>EnglishName</th>
                <th>LCID</th>
                <th>NativeName</th>
                <th>Format Examples</th>

                <th>TwoLetterISOLanguageName</th>
                <th>ThreeLetterISOLanguageName</th>
                <th>ThreeLetterWindowsLanguageName</th>

            </tr>
        </thead>


        <%  
            
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.NeutralCultures))
            {
                Response.Write("<tr>");
                /*
                Console.Write("{0,-7}", ci.Name);
                Console.Write(" {0,-3}", ci.TwoLetterISOLanguageName);
                Console.Write(" {0,-3}", ci.ThreeLetterISOLanguageName);
                Console.Write(" {0,-3}", ci.ThreeLetterWindowsLanguageName);
                Console.Write(" {0,-40}", ci.DisplayName);
                Console.WriteLine(" {0,-40}", ci.EnglishName);
                */
                Response.Write(string.Format("<td>[{0}]</td>", ci.Name));
                Response.Write(string.Format("<td>{0}</td>", ci.DisplayName));
                Response.Write(string.Format("<td>{0}</td>", ci.EnglishName));
                Response.Write(string.Format("<td>{0}</td>", ci.LCID));
                Response.Write(string.Format("<td>{0}</td>", ci.NativeName));

                Response.Write("<td>");

                Response.Write(string.Format("<p><b>ShortDatePattern</b>: {0}</p>", ci.DateTimeFormat.ShortDatePattern));
                Response.Write(string.Format("<p><b>LongDatePattern</b>: {0}</p>", ci.DateTimeFormat.LongDatePattern));
                Response.Write(string.Format("<p><b>CurrencySymbol</b>: {0}</p>", ci.NumberFormat.CurrencySymbol));
                Response.Write(string.Format("<p><b>NumberDecimalSeparator</b>: {0}</p>", ci.NumberFormat.NumberDecimalSeparator));
                Response.Write(string.Format("<p><b>NumberGroupSeparator</b>: {0}</p>", ci.NumberFormat.NumberGroupSeparator));
                Response.Write(string.Format("<p><b>NumberDecimalDigits</b>: {0}</p>", ci.NumberFormat.NumberDecimalDigits)); 
                                                
                Response.Write("</td>");


                Response.Write(string.Format("<td>{0}</td>", ci.TwoLetterISOLanguageName));
                Response.Write(string.Format("<td>{0}</td>", ci.ThreeLetterISOLanguageName));
                Response.Write(string.Format("<td>{0}</td>", ci.ThreeLetterWindowsLanguageName));


                Response.Write("</tr>");


            }
        
        %>
    </table>

    <hr />


        <h2>SPECIFIC - COUNTRY - CULTURES</h2>

    <table class="culture">
        <thead>
            <tr>
                <th>Name</th>
                <th>DisplayName</th>
                <th>EnglishName</th>
                <th>LCID</th>
                <th>NativeName</th>
                <th>Format Examples</th>

                <th>TwoLetterISOLanguageName</th>
                <th>ThreeLetterISOLanguageName</th>
                <th>ThreeLetterWindowsLanguageName</th>

            </tr>
        </thead>


        <%  
            
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                Response.Write("<tr>");
                /*
                Console.Write("{0,-7}", ci.Name);
                Console.Write(" {0,-3}", ci.TwoLetterISOLanguageName);
                Console.Write(" {0,-3}", ci.ThreeLetterISOLanguageName);
                Console.Write(" {0,-3}", ci.ThreeLetterWindowsLanguageName);
                Console.Write(" {0,-40}", ci.DisplayName);
                Console.WriteLine(" {0,-40}", ci.EnglishName);
                */
                Response.Write(string.Format("<td>[{0}]</td>", ci.Name));
                Response.Write(string.Format("<td>{0}</td>", ci.DisplayName));
                Response.Write(string.Format("<td>{0}</td>", ci.EnglishName));
                Response.Write(string.Format("<td>{0}</td>", ci.LCID));
                Response.Write(string.Format("<td>{0}</td>", ci.NativeName));

                Response.Write("<td>");

                Response.Write(string.Format("<p><b>ShortDatePattern</b>: {0}</p>", ci.DateTimeFormat.ShortDatePattern));
                Response.Write(string.Format("<p><b>LongDatePattern</b>: {0}</p>", ci.DateTimeFormat.LongDatePattern));
                Response.Write(string.Format("<p><b>CurrencySymbol</b>: {0}</p>", ci.NumberFormat.CurrencySymbol));
                Response.Write(string.Format("<p><b>NumberDecimalSeparator</b>: {0}</p>", ci.NumberFormat.NumberDecimalSeparator));
                Response.Write(string.Format("<p><b>NumberGroupSeparator</b>: {0}</p>", ci.NumberFormat.NumberGroupSeparator));
                Response.Write(string.Format("<p><b>NumberDecimalDigits</b>: {0}</p>", ci.NumberFormat.NumberDecimalDigits)); 
                                                
                Response.Write("</td>");


                Response.Write(string.Format("<td>{0}</td>", ci.TwoLetterISOLanguageName));
                Response.Write(string.Format("<td>{0}</td>", ci.ThreeLetterISOLanguageName));
                Response.Write(string.Format("<td>{0}</td>", ci.ThreeLetterWindowsLanguageName));


                Response.Write("</tr>");


            }
        
        %>
    </table>


</asp:Content>
