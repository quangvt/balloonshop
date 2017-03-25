using BalloonShop.Domain.Entities;
using BalloonShop.Infrastructure.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BalloonShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            BeginRequest += RecordEvent;
            AuthenticateRequest += RecordEvent;
            PostAuthenticateRequest += RecordEvent;

            AuthorizeRequest += RecordEvent;
            PostAuthorizeRequest += RecordEvent;

            ResolveRequestCache += RecordEvent;
            PostResolveRequestCache += RecordEvent;

            MapRequestHandler += RecordEvent;
            PostMapRequestHandler += RecordEvent;

            AcquireRequestState += RecordEvent;
            PostAcquireRequestState += RecordEvent;

            PreRequestHandlerExecute += RecordEvent;
            PostRequestHandlerExecute += RecordEvent;

            ReleaseRequestState += RecordEvent;
            PostReleaseRequestState += RecordEvent;

            UpdateRequestCache += RecordEvent;
            PostUpdateRequestCache += RecordEvent;

            LogRequest += RecordEvent;
            PostLogRequest += RecordEvent;

            EndRequest += RecordEvent;
            
            PreSendRequestContent += RecordEvent;
            PreSendRequestHeaders += RecordEvent;
            
            Error += RecordEvent;
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }

        void Application_Error(Object sender, EventArgs e)
        {
            // Log all unhandled errors
            Common.Utilities.LogError(Server.GetLastError());
        }

        // Request Life Cycle
        private void RecordEvent(object src, EventArgs args)
        {
            List<string> eventList = Application["events"] as List<string>;
            if (eventList == null)
            {
                Application["events"] = eventList = new List<string>();
            }
            string name = Context.CurrentNotification.ToString();
            if (Context.IsPostNotification)
            {
                name = "Post" + name;
            }
            eventList.Add(name);
        }

    }
}
