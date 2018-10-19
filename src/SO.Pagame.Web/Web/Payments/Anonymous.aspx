<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Anonymous.aspx.cs" Inherits="Pagame.Web.Payments.Anonymous" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    <script async="async" src='https://www.google.com/recaptcha/api.js'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">

    <div class="container payment">
        <div class="row">
            <h1>Realizar el Pago</h1>

            <dx:BootstrapFormLayout ID="BootstrapFormLayout1" runat="server"
                AlignItemCaptionsInAllGroups="True">
                <Items>

                    <dx:BootstrapLayoutGroup Caption="1. Identificación del pago">
                        <Items>

                            <dx:BootstrapLayoutItem Caption="Código Cliente" ColSpanMd="12">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:BootstrapTextBox runat="server" ID="txtCodCliente" MaxLength="60"
                                            HelpText="Código unico del cliente en el sistema">

                                            <ValidationSettings CausesValidation="true" RequiredField-IsRequired="true"
                                                ValidationGroup="Pay">
                                            </ValidationSettings>
                                        </dx:BootstrapTextBox>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem Caption="Referencia Pago" BeginRow="true" ColSpanMd="12">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <dx:BootstrapTextBox runat="server" ID="txtCodPago" MaxLength="30"
                                            HelpText="Número de factura, recibo, comprobante, etc. a pagar.">

                                            <ValidationSettings CausesValidation="true" RequiredField-IsRequired="true"
                                                ValidationGroup="Pay">
                                            </ValidationSettings>
                                        </dx:BootstrapTextBox>

                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem Caption="Total Pago" BeginRow="true" ColSpanMd="12">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">

                                        <dx:BootstrapTextBox runat="server" ID="txtMontoPago"
                                            HelpText="Monto total a pagar, presione validar para consultar." ReadOnly="true" DisplayFormatString="n0">
                                            <ValidationSettings RequiredField-IsRequired="true" ValidationGroup="Gateway"></ValidationSettings>
                                        </dx:BootstrapTextBox>

                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem Caption="¿Código Captcha?" ColSpanMd="6" ColSpanXs="12" ColSpanLg="4" Name="captcha" HelpText="Verificando que no sea un robot.">
                                <ContentCollection>
                                    <dx:ContentControl>

                                        <div class="g-recaptcha" data-sitekey="<%= Pagame.Global.Configuration.Security.GetRecaptchaWebsiteKey() %>"></div>

                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem ShowCaption="False" BeginRow="true" ColSpanMd="12">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">

                                        <dx:ASPxLabel runat="server" ID="labelValidateData" Text="Presione validar..." CssClass="alert alert-info"></dx:ASPxLabel>

                                        <dx:BootstrapButton runat="server" ID="btnValidateData" Text="Validar" CausesValidation="true" SettingsBootstrap-Sizing="Large"
                                            SettingsBootstrap-RenderOption="Warning" ValidationGroup="Pay" OnClick="BtnValidateData_Click" AutoPostBack="false">
                                            <ClientSideEvents Click="function(s, e) {
       
        e.processOnServer = true; 
     }" />
                                        </dx:BootstrapButton>



                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>


                        </Items>
                    </dx:BootstrapLayoutGroup>

                    <dx:BootstrapLayoutGroup Caption="2. Pasarela y forma de pago">
                        <Items>

                            <dx:BootstrapLayoutItem ColSpanMd="12" ShowCaption="False">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">

                                        <dx:BootstrapImage runat="server" ID="imgEpayco" EnableViewState="false" CssClasses-Control="img-payment"
                                            ImageUrl="~/Content/Img/epayco-pago-seguro.png" Width="538" Height="100">
                                        </dx:BootstrapImage>

                                        <dx:BootstrapHyperLink runat="server" ID="lnkEpayco" EnableViewState="false" NavigateUrl="https://epayco.co/"
                                            Target="_blank"
                                            Text="Todas las formas de pago Payco" Badge-IconCssClass="fas fa-external-link-alt">
                                        </dx:BootstrapHyperLink>

                                        <dx:BootstrapImage runat="server" ID="imgMercadopago" EnableViewState="false" CssClasses-Control="img-payment"
                                            ImageUrl="~/Content/Img/mercadopago-pago-seguro.png" Width="538" Height="159">
                                        </dx:BootstrapImage>

                                        <dx:BootstrapHyperLink runat="server" ID="lnkMercadopago" EnableViewState="false" NavigateUrl="https://www.mercadopago.com.co/ayuda/medios-de-pago-tarjeta-credito-cuotas_1795"
                                            Target="_blank"
                                            Text="Todas las formas y límites montos de pago en Mercadopago" Badge-IconCssClass="fas fa-external-link-alt">
                                        </dx:BootstrapHyperLink>


                                        <dx:BootstrapRadioButtonList runat="server" ID="radioPaymentGateway" Caption="Seleccione">
                                            <Items>
                                                <%-- 
                                                <dx:BootstrapListEditItem Text="MercadoPago" Value="Mercadopago">
                                                </dx:BootstrapListEditItem>

                                                <dx:BootstrapListEditItem Text="ePayco" Value="Epayco">
                                                </dx:BootstrapListEditItem>
                                                    --%>
                                            </Items>
                                            <ValidationSettings CausesValidation="true" ValidationGroup="Gateway" RequiredField-IsRequired="true">
                                            </ValidationSettings>
                                        </dx:BootstrapRadioButtonList>

                                        <dx:BootstrapTextBox ID="txtEmail" runat="server" Caption="Email" MaxLength="120"
                                            HelpText="Email de aviso y registro en la pasalera, debe de usar el mismo para evitar fraudes.">
                                            <ValidationSettings ValidationGroup="Gateway" ValidateOnLeave="true" EnableCustomValidation="true"
                                                CausesValidation="True">
                                                <RequiredField IsRequired="true" ErrorText="Email, Valor requerido." />
                                                <RegularExpression ErrorText="Email no válido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                            </ValidationSettings>
                                        </dx:BootstrapTextBox>


                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>

                            <dx:BootstrapLayoutItem ShowCaption="False" BeginRow="true" ColSpanMd="12">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">

                                        <dx:BootstrapButton runat="server" ID="btnPay" Text="Pagar" CausesValidation="true"
                                            ValidationGroup="Gateway" SettingsBootstrap-RenderOption="Success"
                                            SettingsBootstrap-Sizing="Large"
                                            OnClick="BtnPay_Click">
                                        </dx:BootstrapButton>

                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:BootstrapLayoutItem>


                        </Items>
                    </dx:BootstrapLayoutGroup>

                </Items>
            </dx:BootstrapFormLayout>

        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
</asp:Content>
