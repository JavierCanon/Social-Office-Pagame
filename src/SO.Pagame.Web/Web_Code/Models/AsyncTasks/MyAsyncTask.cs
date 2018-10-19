using System;
using System.Web;
using System.Web.UI;
using System.Threading;

namespace Web4Helpdesk.AsyncTasks
{
    // https://msdn.microsoft.com/en-us/library/mt674882.aspx
    // https://msdn.microsoft.com/en-us/library/system.web.ui.page.registerasynctask(v=vs.110).aspx

    /*
     <%@ Page Language="C#" AsyncTimeout="2"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    // Define the asynchronuous task.
    Samples.AspNet.CS.Controls.MyAsyncTask mytask =    
      new Samples.AspNet.CS.Controls.MyAsyncTask();
    PageAsyncTask asynctask = new PageAsyncTask(mytask.OnBegin, mytask.OnEnd, mytask.OnTimeout, null);

    // Register the asynchronous task.
    Page.RegisterAsyncTask(asynctask);

    // Execute the register asynchronous task.
    Page.ExecuteRegisteredAsyncTasks();

    TaskMessage.InnerHtml = mytask.GetAsyncTaskProgress();

  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Asynchronous Task Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <span id="TaskMessage" runat="server">
      </span>
    </div>
    </form>
</body>
         
         
         
         
         */


    public class MyAsyncTask
    {

        private String _taskprogress;
        private AsyncTaskDelegate _dlgt;

        // Create delegate.
        protected delegate void AsyncTaskDelegate();

        public String GetAsyncTaskProgress()
        {
            return _taskprogress;
        }
        public void DoTheAsyncTask()
        {
            // Introduce an artificial delay to simulate a delayed 
            // asynchronous task. Make this greater than the 
            // AsyncTimeout property.
            Thread.Sleep( TimeSpan.FromSeconds( 5.0 ) );
        }

        // Define the method that will get called to
        // start the asynchronous task.
        public IAsyncResult OnBegin( object sender, EventArgs e,
            AsyncCallback cb, object extraData )
        {
            _taskprogress = "Beginning async task.";

            _dlgt = new AsyncTaskDelegate( DoTheAsyncTask );
            IAsyncResult result = _dlgt.BeginInvoke( cb, extraData );

            return result;
        }

        // Define the method that will get called when
        // the asynchronous task is ended.
        public void OnEnd( IAsyncResult ar )
        {
            _taskprogress = "Asynchronous task completed.";
            _dlgt.EndInvoke( ar );
        }

        // Define the method that will get called if the task
        // is not completed within the asynchronous timeout interval.
        public void OnTimeout( IAsyncResult ar )
        {
            _taskprogress = "Ansynchronous task failed to complete " +
                "because it exceeded the AsyncTimeout parameter.";
        }


    }
}