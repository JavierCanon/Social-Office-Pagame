using System;
using System.Configuration;
using System.Web;
using Softcanon.DAL;

namespace Pagame
{
    public partial class Global : System.Web.HttpApplication
    {


        public static class DAL
        {


            #region Connection DB Utils


            /// <summary>
            /// Connection to the CRM database.
            /// The DB of the clients need to be the same name of the domain.
            /// </summary>
            /// <returns></returns>
            public static string GetConnectionStringDBMain()
            {
                if (ConnectionStringDBMain != null)
                {
                    return ConnectionStringDBMain;
                }
                else
                {

                    ConnectionStringDBMain = Configuration.DB.GetConnectionStringDBMain();

                    /*
                    if (Configuration.Development.GetIsEnabledDeveloperMode())
                    {
                        var config = WebConfigurationManager.OpenWebConfiguration("~/Sites/" + Configuration.GetDevelopmentCustomFolder() + "/");
                        ConnectionStringDBMain = config.ConnectionStrings.ConnectionStrings["MsSqlServer.SO"].ConnectionString;
                    }
                    else
                    {
                        string folder = "";
                        if (Configuration.Application.GetInstallationIsCustom())
                        {
                            folder = Configuration.GetInstallationCustomFolder();
                        }

                        if (string.IsNullOrEmpty(folder)) folder = GetRequestDomainName().Replace(".", "_");

                        var config = WebConfigurationManager.OpenWebConfiguration("~/Sites/" + folder + "/");
                        ConnectionStringDBMain = config.ConnectionStrings.ConnectionStrings["MsSqlServer.SO"].ConnectionString;
                    }
                    */

                    /*
                    var builder =
                    new SqlConnectionStringBuilder(Configuration.DB.GetConnectionStringDBSO());

                    // builder["Database"] = "SO" + GetRequestDomainName().Replace(".", string.Empty);
                    builder.InitialCatalog = "SO" + GetRequestDomainName().Replace(".", "_");
                    ConnectionStringDB = builder.ConnectionString;
                    */

                    return ConnectionStringDBMain;
                }
            }




        }
        #endregion Connection DB Utils


        #region Configuration




        /// <summary>
        /// Parametros que se cargan de la DB para evitar tener que reiniciar el App.
        /// y que puedan ser actualizados en vivo y consultados por cada petición, ej. cambio del dolar.
        /// !!! DEBE DE COINCIDIR LOS IDS CON LOS DE LA BASE DE DATOS !!!.
        /// </summary>
        public static class ParametersAppClients
        {
            public enum ParamIdEnum : int
            {
                EMAIL_AVISO = 1
            }

            public enum GetValueByEnum : int
            {
                GetValueByID = 1
                ,
                GetValueByName = 2
            }

            public static string GetParameterForClient( GetValueByEnum getValueByEnum, ParamIdEnum parameter, string cacheKey, string strDBConnection )
            {
                if (getValueByEnum.Equals( GetValueByEnum.GetValueByID ))
                {
                    return GetParameterClientById( parameter, cacheKey, strDBConnection );
                }
                if (getValueByEnum.Equals( GetValueByEnum.GetValueByName ))
                {
                    return GetParameterClientByName( parameter, cacheKey, strDBConnection );
                }
                return null;
            }

            private static string GetParameterClientById( ParamIdEnum parameter, string cacheKey, string strDBConnection )
            {
                var result = (string)HttpRuntime.Cache["GetParameterClientById_" + parameter.ToString() + "_" + cacheKey];
                if (result == null)
                {
                    result = SqlApiSqlClient.GetStringRecordValue( "EXEC PARAMETROS_CLIENTS_GET_VALUE_BY_ID " + Convert.ToInt32( parameter ).ToString(), strDBConnection );
                    HttpRuntime.Cache.Insert( "GetParameterClientById" + parameter.ToString() + cacheKey, result,
                                                                                    null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes( 5 ) );
                }
                return result;
            }

            private static string GetParameterClientByName( ParamIdEnum parameter, string cacheKey, string strDBConnection )
            {
                var result = (string)HttpRuntime.Cache["GetParameterClientByName_" + parameter.ToString() + "_" + cacheKey];
                if (result == null)
                {
                    result = SqlApiSqlClient.GetStringRecordValue( "EXEC PARAMETROS_CLIENTS_GET_VALUE_BY_NAME '" + parameter.ToString() + "'", strDBConnection );
                    HttpRuntime.Cache.Insert( "GetParameterClientByName" + parameter.ToString() + cacheKey, result,
                                                                        null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes( 5 ) );
                }
                return result;
            }
        }



        #endregion Configuration


    }
}
