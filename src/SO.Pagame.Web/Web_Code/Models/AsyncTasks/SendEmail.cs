﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
using System.Net.Mail;
using System.Web.UI;

// http://www.codeproject.com/Articles/667461/Send-asynchronous-mail-using-asp-net

// https://blogs.msdn.microsoft.com/pfxteam/2011/09/28/task-exception-handling-in-net-4-5/

namespace Pagame.Models.AsyncTasks
{
    public class SendEmail
    {

        private string _toEmailAddress, _emailSubject, _emailMessage;
        private bool _isBodyHtml;


        private string _taskprogress;
        private AsyncTaskDelegate _dlgt;

        // Create delegate.
        protected delegate void AsyncTaskDelegate();

        public SendEmail( string toEmailAddress, string emailSubject, string emailMessage, bool isBodyHtml )
        {

            _toEmailAddress = toEmailAddress;
            _emailSubject = emailSubject;
            _emailMessage = emailMessage;
            _isBodyHtml = isBodyHtml;

        }


        public string GetAsyncTaskProgress()
        {
            return _taskprogress;
        }
        public async void DoTheAsyncTask()
        {
            // Introduce an artificial delay to simulate a delayed 
            // asynchronous task. Make this greater than the 
            // AsyncTimeout property.
            // Thread.Sleep( TimeSpan.FromSeconds( 5.0 ) );


            var message = new MailMessage();
            message.To.Add( _toEmailAddress );

            message.Subject = _emailSubject;
            message.Body = _emailMessage;
            message.IsBodyHtml = _isBodyHtml;

            message.From = new MailAddress( Global.Configuration.Mail.GetMailServerLogin() );


            //Proper Authentication Details need to be passed when sending email from gmail
            NetworkCredential mailAuthentication = new NetworkCredential( Global.Configuration.Mail.GetMailServerLogin()
                , Global.Configuration.Mail.GetMailServerPassword() );

            using (var smtpClient = new SmtpClient())
            {

                // server
                smtpClient.Host = Global.Configuration.Mail.GetMailServer();
                smtpClient.Port = Global.Configuration.Mail.GetMailServerPort();
                smtpClient.EnableSsl = Global.Configuration.Mail.GetMailServerIsEnableSSL();
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = mailAuthentication;


                if (Global.Configuration.Development.GetIsEnabledDeveloperMode())
                    smtpClient.Timeout = 5000;
                else
                    smtpClient.Timeout = 180000;  //An Int32 that specifies the time-out value in milliseconds. The default value is 100,000 (100 seconds).

                // send
                await smtpClient.SendMailAsync( message );


            }
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