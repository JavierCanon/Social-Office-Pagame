using System;
using System.Configuration;

namespace Pagame
{

    // https://docs.microsoft.com/en-us/previous-versions/dotnet/netframework-4.0/ms229054(v=vs.100)
    // maybe you wan to store in another cache, db, complex validations, conversions, etc., so we use methods and not properties

    public partial class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Clase para retornar facilmente atributos del aplicativo.
        /// </summary>
        public static class Configuration
        {

            public static class Payments
            {

                public static string GetCurrencyDefault() {
                    return ConfigurationManager.AppSettings["Payment:Currency.Default"].ToString();

                }



                public static class Mercadopago {


                    public static bool GetIsEnabled() {

                        string config = ConfigurationManager.AppSettings["Payment:Mercadopago.Enabled"].ToString();

                        if (null != config)
                        {
                            return Convert.ToBoolean(config);
                        }
                        else
                        {
                            return false;
                        }

                    }


                    public static class Basic {

                        public static string GetShortName()
                        {

                            return ConfigurationManager.AppSettings["Payment:Mercadopago.Basic.ShortName"].ToString();

                        }

                        public static string GetClientID()
                        {

                            return ConfigurationManager.AppSettings["Payment:Mercadopago.Basic.ClientID"].ToString();

                        }


                        public static string GetClientSecret()
                        {

                            return ConfigurationManager.AppSettings["Payment:Mercadopago.Basic.ClientSecret"].ToString();

                        }


                    }


                }



                public static class Epayco
                {


                    public static bool GetIsEnabled()
                    {

                        string config = ConfigurationManager.AppSettings["Payment:Epayco.Enabled"].ToString();

                        if (null != config)
                        {
                            return Convert.ToBoolean(config);
                        }
                        else
                        {
                            return false;
                        }

                    }


                    public static class Basic
                    {
                        public static string GetClientID()
                        {

                            return ConfigurationManager.AppSettings["Payment:Epayco.Basic.ClientID"].ToString();

                        }
                        
                        public static string GetPublicKey()
                        {

                            return ConfigurationManager.AppSettings["Payment:Epayco.Basic.PublicKey"].ToString();

                        }


                    }


                }

            }



                public static class General
            {

                public static string GetSiteTitlePages()
                {

                    return ConfigurationManager.AppSettings["Site:Title.Pages"].ToString();

                }

                public static string GetSitesTitleMenuLogo() {
                    return ConfigurationManager.AppSettings["Site:Title.Menu.Logo"].ToString();
                }

                // Site:Menu.About.Link
                public static string GetSiteMenuAboutLink()
                {
                    return ConfigurationManager.AppSettings["Site:Menu.About.Link"].ToString();
                }

                // Site:Menu.Contact.Link
                public static string GetSiteMenuContactLink()
                {
                    return ConfigurationManager.AppSettings["Site:Menu.Contact.Link"].ToString();
                }
            }



            /// <summary>
            /// App config
            /// </summary>
            public static class Application
            {

                /// <summary>
                /// Widgets config
                /// </summary>
                public static class Widgets
                {
                }

                /// <summary>
                /// Validate browser version
                /// </summary>
                /// <returns></returns>
                public static bool GetIsEnabledBrowserValidation()
                {
                    string config = ConfigurationManager.AppSettings["Browsers:EnableBrowserValidation"].ToString();

                    if (null != config)
                    {
                        return Convert.ToBoolean(config);
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// return if the app run in wan with a domain name
                /// </summary>
                /// <returns></returns>
                public static bool GetInstallationIsInWanWithInternetDomainName()
                {
                    string config = ConfigurationManager.AppSettings["Installation:IsInWanWithInternetDomainName"].ToString();

                    if (null != config)
                    {
                        return Convert.ToBoolean(config);
                    }
                    else
                    {
                        return false;
                    }
                }


                /// <summary>
                /// return if the app run in lan without a domain name
                /// </summary>
                /// <returns></returns>
                public static bool GetInstallationIsInLanOrLocal()
                {
                    string config = ConfigurationManager.AppSettings["Installation:IsInLanOrLocal"].ToString();

                    if (null != config)
                    {
                        return Convert.ToBoolean(config);
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// return if the app run in lan without a domain name
                /// </summary>
                /// <returns></returns>
                public static bool GetInstallationIsCustom()
                {
                    string config = ConfigurationManager.AppSettings["Installation:IsCustom"].ToString();

                    if (null != config)
                    {
                        return Convert.ToBoolean(config);
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static string GetInstallationCustomFolder()
                {
                    string config = ConfigurationManager.AppSettings["Installation:Custom.Folder"].ToString();

                    if (null != config)
                    {
                        return config;
                    }
                    else
                    {
                        return null;
                    }
                }


            } //<<< aplication

            /// <summary>
            /// 
            /// </summary>
            public static class Optimization
            {

                /// <summary>
                /// return if use .min.js file version
                /// </summary>
                /// <returns></returns>
                public static bool GetIsEnabledOptimizationJavascriptUseMinifiedFiles()
                {
                    string config = ConfigurationManager.AppSettings["Optimization:Javascript.UseMinifiedFiles"].ToString();

                    if (null != config)
                    {
                        return Convert.ToBoolean(config);
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// return if use .min.css file version
                /// </summary>
                /// <returns></returns>
                public static bool GetIsEnabledOptimizationCSSUseMinifiedFiles()
                {
                    string config = ConfigurationManager.AppSettings["Optimization:CSS.UseMinifiedFiles"].ToString();

                    if (null != config)
                    {
                        return Convert.ToBoolean(config);
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static bool GetIsEnabledOptimizationBundling()
                {
                    string config = ConfigurationManager.AppSettings["Optimization:Bundling.Enabled"].ToString();

                    if (null != config)
                    {
                        return Convert.ToBoolean(config);
                    }
                    else
                    {
                        return false;
                    }
                }


            } //<<< optimization


            public static class Cache
            {

                /// <summary>
                /// Seconds to cache the page.
                /// </summary>
                /// <returns></returns>
                public static int GetCacheWeb4CMSPagesCacheDuration()
                {
                    string config = ConfigurationManager.AppSettings["Cache:Pages.CacheDuration"].ToString();

                    if (null != config)
                    {
                        return Convert.ToInt32(config);
                    }
                    else
                    {
                        return 10;
                    }
                }

            }

            /// <summary>
            /// Dev settings
            /// </summary>
            public static class Development
            {


                /// <summary>
                /// custom folder to use without use autodetect domain name
                /// </summary>
                /// <returns></returns>
                public static string GetDevelopmentCustomFolder()
                {
                    return ConfigurationManager.AppSettings["Development:Custom.Folder"].ToString();


                }


                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static bool GetIsEnabledDebugDeveloperModeShowGenericPageErrors()
                {
                    string config = ConfigurationManager.AppSettings["Development:DeveloperMode.ShowGenericPageErrors"].ToString();

                    if (null != config)
                    {
                        return Convert.ToBoolean(config);
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static bool GetIsEnabledDebugDeveloperModeShowGlobalPageError()
                {
                    string config = ConfigurationManager.AppSettings["Development:DeveloperMode.ShowGlobalPageError"].ToString();

                    if (null != config)
                    {
                        return Convert.ToBoolean(config);
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// retorna si esta en modo desarrollo, es decir se saltan muchas opciones de seguridad y
                /// se asigan variables y parametros del aplicativo manualmente.
                /// </summary>
                /// <returns></returns>
                public static bool GetIsEnabledDeveloperMode()
                {
                    string config = ConfigurationManager.AppSettings["Development:DeveloperMode.Enabled"].ToString();

                    if (null != config)
                    {
                        return Convert.ToBoolean(config);
                    }
                    else
                    {
                        return false;
                    }
                }


                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static string GetDebugWebsiteDomainName()
                {
                    return ConfigurationManager.AppSettings["Debug:Website.Domain.Name"].ToString();


                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static string GetDebugWebsiteDirectory()
                {
                    return ConfigurationManager.AppSettings["Debug:Website.Directory"].ToString();


                }





            } //<<< development

            /// <summary>
            /// log settings
            /// </summary>
            public static class Logger
            {

                /// <summary>
                /// retorna si esta activo el logger
                /// </summary>
                /// <returns></returns>
                public static bool GetIsEnabledCacheLogger()
                {
                    string sString = null;
                    string skey = "Logger:Cache.Enable";

                    sString = ConfigurationManager.AppSettings[skey].ToString();

                    if (null != sString)
                    {
                        return Convert.ToBoolean(sString);
                    }
                    else
                    {
                        return false;
                    }
                }



                /// <summary>
                /// return the type of logger to file or to db.
                /// </summary>
                /// <returns></returns>
                public static int GetLoggerToTypeMode()
                {
                    string config = ConfigurationManager.AppSettings["Logger:ToTypeMode"].ToString();

                    if (null != config)
                    {
                        return Convert.ToInt32(config);
                    }
                    else
                    {
                        return 1;
                    }
                }

                /// <summary>
                /// return the type of logger to file or to db.
                /// </summary>
                /// <returns></returns>
                public static int GetUserLoggerToTypeMode()
                {
                    string config = ConfigurationManager.AppSettings["Logger:User.ToTypeMode"].ToString();

                    if (null != config)
                    {
                        return Convert.ToInt32(config);
                    }
                    else
                    {
                        return 1;
                    }
                }


                /// <summary>
                /// retorna si esta activo el logger
                /// </summary>
                /// <returns></returns>
                public static bool GetIsEnabledLogger()
                {
                    string config = ConfigurationManager.AppSettings["Logger:Enable"].ToString();

                    if (null != config)
                    {
                        return Convert.ToBoolean(config);
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// retorna si esta activo el logger
                /// </summary>
                /// <returns></returns>
                public static bool GetIsEnabledUserLogger()
                {
                    string config = ConfigurationManager.AppSettings["Logger:User.Enable"].ToString();

                    if (null != config)
                    {
                        return Convert.ToBoolean(config);
                    }
                    else
                    {
                        return false;
                    }
                }


                /// <summary>
                /// retorna si esta activo el logger
                /// </summary>
                /// <returns></returns>
                public static bool GetIsEnabledDeveloperLogger()
                {
                    string config = ConfigurationManager.AppSettings["Logger:Developer.Enable"].ToString();

                    if (null != config)
                    {
                        return Convert.ToBoolean(config);
                    }
                    else
                    {
                        return false;
                    }
                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static bool GetIsEnabledLoggerErrorsToTextApp_Data()
                {
                    string config = ConfigurationManager.AppSettings["Logger:Errors.ToText.App_Data.Enable"].ToString();

                    if (null != config)
                    {
                        return Convert.ToBoolean(config);
                    }
                    else
                    {
                        return false;
                    }
                }


                /// <summary>
                /// Buffer size for log output messages.
                /// </summary>
                /// <returns></returns>
                public static int GetLoggerProductionBufferSize()
                {
                    string config = ConfigurationManager.AppSettings["Logger:ProductionBufferSize"].ToString();

                    if (null != config)
                    {
                        return Convert.ToInt32(config);
                    }
                    else
                    {
                        return 100;
                    }
                }


            } // <<< class logger

            /// <summary>
            /// 
            /// </summary>
            public static class Security
            {
                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static string GetMD5Key()
                {
                    return ConfigurationManager.AppSettings["Security:MD5.Key"].ToString();

                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static string SecurityLoginPageURL()
                {
                    return ConfigurationManager.AppSettings["Security:Login.Page.URL"].ToString();

                }

                public static string GetRecaptchaWebsiteKey()
                {
                    return ConfigurationManager.AppSettings["Security:Recaptcha.WebsiteKey"].ToString();

                }

                public static string GetRecaptchaSecretKey()
                {
                    return ConfigurationManager.AppSettings["Security:Recaptcha.SecretKey"].ToString();

                }



            } //<<< Security

            /// <summary>
            /// 
            /// </summary>
            public static class Mail
            {

                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static string GetMailServer()
                {
                    return ConfigurationManager.AppSettings["MailServer:Host"].ToString();


                }
                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static string GetMailServerLogin()
                {
                    return ConfigurationManager.AppSettings["MailServer:Login"].ToString();

                }
                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static string GetMailServerPassword()
                {
                    return ConfigurationManager.AppSettings["MailServer:Password"].ToString();

                }
                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static int GetMailServerPort()
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["MailServer:Port"].ToString());


                }
                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static bool GetMailServerIsEnableSSL()
                {
                    string config = ConfigurationManager.AppSettings["MailServer:SSL.Enable"].ToString();

                    if (null != config)
                    {
                        return Convert.ToBoolean(config);
                    }
                    else
                    {
                        return false;
                    }


                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static string GetEmailSoporte()
                {
                    return ConfigurationManager.AppSettings["Emails:Soporte"].ToString();


                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static string GetEmailContacto()
                {
                    return ConfigurationManager.AppSettings["Emails:Contacto"].ToString();


                }


            } // <<< mail

            /// <summary>
            /// 
            /// </summary>
            public static class DB
            {


                /// <summary>
                /// retorna la cadena de conexion principal
                /// </summary>
                /// <returns></returns>
                public static string GetConnectionStringDBMain()
                {
                    return ConfigurationManager.ConnectionStrings["MsSqlServer.Main"].ConnectionString;


                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static string GetConnectionStringDBMaster()
                {
                    return ConfigurationManager.ConnectionStrings["MsSqlServer.Master"].ConnectionString;


                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static string GetConnectionStringDBData()
                {
                    return ConfigurationManager.ConnectionStrings["MsSqlServer.Data"].ConnectionString;


                }


                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static string GetConnectionStringDBLogServer()
                {
                    return ConfigurationManager.ConnectionStrings["MsSqlServer.LogServer"].ConnectionString;


                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public static string GetConnectionStringDBUserLogServer()
                {
                    return ConfigurationManager.ConnectionStrings["MsSqlServer.UserLogServer"].ConnectionString;


                }

            } //<<< DB


        }






    }
}
