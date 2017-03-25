using System;
using System.Diagnostics;
using System.IO;
using System.Web;

namespace BalloonShop.Infrastructure.Module
{
    //public class LogModule : IHttpModule
    //{
    //    private static int _sharedCounter = 0;
    //    private int _requestCounter;

    //    private static object _lockObject = new object();
    //    private Exception _requestException = null;

    //    public void Dispose()
    //    {
    //        // do nothing
    //    }

    //    public void Init(HttpApplication app)
    //    {
    //        app.BeginRequest += (src, args) =>
    //        {
    //            _requestCounter = ++_sharedCounter;
    //        };
    //        app.Error += (src, args) =>
    //        {
    //            _requestException = HttpContext.Current.Error;
    //        };
    //        app.LogRequest += (src, args) => WriteLogMessage(HttpContext.Current);
    //    }

    //    private void WriteLogMessage(HttpContext ctx)
    //    {
    //        StringWriter sr = new StringWriter();
    //        sr.WriteLine("-------------------");
    //        sr.WriteLine("Request: {0} for {1}", _requestCounter, ctx.Request.RawUrl);
    //        if (ctx.Handler != null)
    //        {
    //            sr.WriteLine("Handler: {0}", ctx.Handler.GetType());
    //        }
    //        sr.WriteLine("Status Code: {0}, Message: {1}", ctx.Response.Status,
    //            ctx.Response.StatusDescription);
    //        sr.WriteLine("Elapse time: {0} ms",
    //            DateTime.Now.Subtract(ctx.Timestamp).Milliseconds);
    //        if (_requestException != null)
    //        {
    //            sr.WriteLine("Error: {0}", _requestException.GetType());
    //        }
    //        lock (_lockObject)
    //        {
    //            Debug.Write(sr.ToString());
    //        }
    //    }
    //}

    public class LogModule : IHttpModule
    {
        private const string traceCategory = "LogModule";
        public void Init(HttpApplication app)
        {
            app.BeginRequest += (src, args) =>
            {
                HttpContext.Current.Trace.Write(traceCategory, "BeginRequest");
            };
            app.EndRequest += (src, args) =>
            {
                HttpContext.Current.Trace.Write(traceCategory, "EndRequest");
            };
            app.PostMapRequestHandler += (src, args) =>
            {
                HttpContext.Current.Trace.Write(traceCategory,
                string.Format("Handler: {0}",
                HttpContext.Current.Handler));
            };
            app.Error += (src, args) =>
            {
                HttpContext.Current.Trace.Warn(traceCategory, string.Format("Error: {0}",
                HttpContext.Current.Error.GetType().Name));
            };
        }
        public void Dispose()
        {
            // do nothing
        }
    }
}