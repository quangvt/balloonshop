using System;
using System.Web;

namespace BalloonShop.Infrastructure.Handler
{
    /// <summary>
    /// Usually HandlerFactory is used for apply Constructor Arguments
    ///   or provide License
    /// Not Usual is generating and compiling
    /// </summary>
    public class CounterHandlerFactory : IHttpHandlerFactory
    {
        private int _counter = 0;

        public IHttpHandler GetHandler(HttpContext context, string requestType, 
            string url, string pathTranslated)
        {
            // fix generate handler by config
            // return new CounterHandler(++_counter);

            // dynamic generate handler
            if (context.Request.UserAgent.Contains("Chrome"))
            {
                return new SiteLengthHandler();
            }
            else
            {
                return new CounterHandler(++_counter);
            }
        }

        public void ReleaseHandler(IHttpHandler handler)
        {
            // do nothing - handlers are not reused
        }
    }
}