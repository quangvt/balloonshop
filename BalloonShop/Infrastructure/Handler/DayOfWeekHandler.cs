using BalloonShop.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BalloonShop.Infrastructure.Handler
{
    //public class DayOfWeekHandler : IHttpHandler
    public class DayOfWeekHandler : IHttpHandler, IRequiresDate //IRequiresDate to decouple design
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Items.Contains("DayModule_Time")
                && (context.Items["DayModule_Time"] is DateTime))
            {
                string day = ((DateTime)context.Items["DayModule_Time"])
                    .DayOfWeek.ToString();
                if (context.Request.CurrentExecutionFilePathExtension == ".json")
                {
                    context.Response.ContentType = "application/json";
                    context.Response.Write(string.Format("{{\"day\": \"{0}\"}}", day));
                }
                else
                {
                    context.Response.ContentType = "text/html";
                    context.Response.Write(string.Format("<span>It is: {0}</span>", day));
                }
            }
            else
            {
                context.Response.ContentType = "text/html";
                context.Response.Write("No Module Data Available");
            }
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
}