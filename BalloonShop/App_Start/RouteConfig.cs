using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace BalloonShop
{
    public class RouteConfig
    {
        //public static void RegisterRoutesOld(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    routes.MapRoute(
        //        name: "Default",
        //        url: "{controller}/{action}/{id}",
        //        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        //    );
        //}

        /// <summary>
        /// Link Factory.
        /// <!-- Friendly to search engine, with customer viewing -->
        /// <!-- Certain pages need HTTPS accessibility -->
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            // TODO: Ignore for resource ?
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Handler Register By Route Configuration: Solution 1
            //routes.Add(new Route("handler/{*path}",
            //    new CustomRouteHandler { HandlerType = 
            //        typeof(Infrastructure.Handler.DayOfWeekHandler) }));
            // Handler Register By Web Config: Solution 2
            routes.IgnoreRoute("handler/{*path}");

            routes.MapRoute(
                null, // name
                "",   // url
                new
                {
                    controller = "Product",
                    action = "List",
                    category = (string)null,
                    page = 1
                }    // default
            );

            routes.MapRoute(
                null, // name
                "Page{page}", // url
                new
                {
                    controller = "Product",
                    action = "List",
                    category = (string)null
                }, // default
                new { page = @"\d+" } // constrain
            );

            // Note: consider to ordering
            //   this map will be used after check abow route
            routes.MapRoute(
                null, // name
                "{category}", // url
                new
                {
                    controller = "Product",
                    action = "List",
                    page = 1
                } // default
            );

            routes.MapRoute(
                null,
                "{category}/Page{page}",
                new
                {
                    controller = "Product",
                    action = "List"
                },
                new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }

        class CustomRouteHandler : IRouteHandler
        {
            public Type HandlerType { get; set; }
            public System.Web.IHttpHandler GetHttpHandler(RequestContext requestContext)
            {
                return (System.Web.IHttpHandler)Activator.CreateInstance(HandlerType);
            }
        }
    }
}
