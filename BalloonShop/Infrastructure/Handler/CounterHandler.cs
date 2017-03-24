using System;
using System.Web;

namespace BalloonShop.Infrastructure.Handler
{
    public class CounterHandler : IHttpHandler
    {
        private int _handlerCounter;

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(string.Format("The counter value is {0}.",
                _handlerCounter));
        }

        public CounterHandler(int counter)
        {
            _handlerCounter = counter;
        }
    }
}