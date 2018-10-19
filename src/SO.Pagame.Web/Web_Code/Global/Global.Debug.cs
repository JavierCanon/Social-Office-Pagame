

namespace Pagame
{
    public partial class Global : System.Web.HttpApplication
    {
        public static class Debug
        {

            public static void SetUserTestSessionVariables()
            {

                if(Global.Configuration.Development.GetIsEnabledDeveloperMode()){


                    Sessions.SetDeveloperUserSessionVariables();

                }

            }
            

        }

    }
}
