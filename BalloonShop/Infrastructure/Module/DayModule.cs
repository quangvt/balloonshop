using BalloonShop.Infrastructure.Abstract;
using BalloonShop.Infrastructure.Handler;
using System;
using System.Web;

namespace BalloonShop.Infrastructure.Module
{
    public class DayModule : IHttpModule
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication app)
        {
            // To apply all handler
            //app.BeginRequest += (src, args) =>
            //{
            //    app.Context.Items["DayModule_Time"] = DateTime.Now;
            //};

            // To apply specific handler
            app.PostMapRequestHandler +=
                (src, args) =>
                {
                    //if (app.Context.Handler is DayOfWeekHandler) // Tightly coupling
                    if (app.Context.Handler is IRequiresDate) // Loosely coupling
                    {
                        app.Context.Items["DayModule_Time"] = DateTime.Now;
                    }
                };
        }
    }
}