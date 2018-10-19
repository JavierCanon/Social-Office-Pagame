

namespace Pagame
{
    public partial class Global : System.Web.HttpApplication
    {
        static string _versionapp = "";


        public static class Versions
        {
  
            public static string GetAppVersion()
            {
                if (!string.IsNullOrEmpty( _versionapp ))
                {

                    return _versionapp;
                }
                else
                {
                    
                    _versionapp = Pagame.Models.Versioning.DLLVersion.GetVersion();

                }

                return _versionapp;
            }







        }



    }
}
