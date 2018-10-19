using System;
using System.Collections.Generic;


namespace Pagame.Views
{

	/// <summary>
	/// Summary description for MasterPages
	/// </summary>
	public class MasterPagesBase : System.Web.UI.MasterPage
	{
		protected void Page_Init(object sender, EventArgs e)
		{
			Page.Header.DataBind();
		}
	}
}
