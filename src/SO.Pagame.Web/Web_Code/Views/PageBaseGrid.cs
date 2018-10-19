using System;
using System.Web.UI.WebControls;

namespace Pagame.Views
{
    public abstract class PageBaseGrid : Views.PageBase
    {

        protected static string UniqueIdPageName, MasterTableName, MasterKeyFieldName, MasterGridCookieName, DetailGridCookieName;


        protected void Page_PreInit(object sender, EventArgs e)
        {

            //base.Page_PreInit( sender, e );
            
            UniqueIdPageName = Page.ToString().Replace(".", "_");
            MasterGridCookieName = UniqueIdPageName + "_MasterGrid";
            DetailGridCookieName = UniqueIdPageName + "_DetailGrid";

            //MasterTableName = "ticket";
            //MasterKeyFieldName = "ID";

        }


        protected void DBMainDataSources_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.CommandTimeout = 60 * 5;
        }


        protected void DBMainDataSources_Init(object sender, EventArgs e)
        {
            (sender as SqlDataSource).ConnectionString = Global.DAL.GetConnectionStringDBMain();

        }


    }
}
