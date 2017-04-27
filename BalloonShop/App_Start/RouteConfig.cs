using System;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
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
            // TODO: ERROR
            // Enable Attribute Routing
            //routes.MapMvcAttributeRoutes();
            // Suggest: Caution Be careful when applying constraints. The routes defined by the Route attribute work in just the same
            //way as those defined in the RouteConfig.cs file and a 404—Not Found result will be sent to the browser for URLs that
            //can't be matched to an action method. Always define a fallback route that will match irrespective of the values that
            //the URL contains.

            // TODO: Ignore for resource ?
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Handler Register By Route Configuration: Solution 1
            //routes.Add(new Route("handler/{*path}",
            //    new CustomRouteHandler { HandlerType = 
            //        typeof(Infrastructure.Handler.DayOfWeekHandler) }));
            // Handler Register By Web Config: Solution 2
            routes.IgnoreRoute("handler/{*path}");

            routes.MapRoute(
                "ShopSchema2",
                "Shop/OldAction",
                new { controller = "Product", action = "List" });

            routes.MapRoute(
                "ShopSchema",
                "Shop/{action}",
                new { controller = "Product" });

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

            routes.MapRoute("customSegmentVariable", "Custom/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = "DefaultId" } );
            routes.MapRoute("MyRoute", "Custom/{controller}/{action}/{id}/{*catchall}",
                new { controller = "Product", action = "List", id = UrlParameter.Optional },// Segment Variable Option
                new[] { "BalloonShop.Controllers", "ThirdParty.Controllers" }); // Prioritizing Controllers by Namespace

            // Can add more routes to resolve controllers from multi namespaces

            // Tell the MVC Fw to look only in the namespaces that I specify. Not search elsewhere
            Route myRoute = routes.MapRoute("AddContollerRoute",
                "Custom/Home/{action}/{id}/{*catchall}",
                new
                {
                    controller = "Product",
                    action = "List",
                    id = UrlParameter.Optional
                },
                //new { controller = "^H.*" }, // explain for contraining route by RegEx
                new
                {
                    controller = "^H.*",
                    action = "^Index$|^About$",
                    httpMethod = new HttpMethodConstraint("GET", "POST"),
                    id = new RangeRouteConstraint(10, 20)
                }, // Can use: CompoundRouteConstraint
                   // new { customConstraint = new UserAgentConstaint("Chrome") },
                new[] { "URLsAndRoutes.AdditionalControllers" });
            myRoute.DataTokens["UseNamespaceFallback"] = false;
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
