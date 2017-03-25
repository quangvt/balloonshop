using BalloonShop.Domain.Concrete;
using BalloonShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;

namespace BalloonShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ////Database.SetInitializer(new Initializer());

            //using (var context = new AppDbContext())
            //{
            //    // context.Database.Initialize(true);
            //    //List<Department> depts = context.Department.ToList();
            //    //if (depts.Count > 0) return View(depts);
            //}
            return View((object)null);
        }

        public ActionResult AddData()
        {
            using (var context = new AppDbContext())
            {
                //// Sample Data
                //var depts = new Department[]
                //{
                //    new Department() { Name = "Family Events", Description = "For Family Events" },
                //    new Department() { Name = "Company Events", Description = "For Company Events" },
                //    new Department() { Name = "School Events", Description = "For School Events" }
                //};

                //context.Department.AddRange(depts);
                ////context.SaveChanges();

                //// Sample Data
                //var cats = new Category[]
                //{
                //    new Category() { DepartmentId = 1, Name = "Birthday",
                //        Description = "For Family Events", DateAdded = DateTime.Today.AddDays(-1) },
                //    new Category() { DepartmentId = 2, Name = "Birthday",
                //        Description = "For Family Events", DateAdded = DateTime.Today.AddDays(-1) },
                //    new Category() { DepartmentId = 1, Name = "Wedding Anniversary",
                //        Description = "For Family Events", DateAdded = DateTime.Today.AddDays(-1) },
                //    new Category() { DepartmentId = 2, Name = "Promotion",
                //        Description = "For Family Events", DateAdded = DateTime.Today.AddDays(-1) },
                //    new Category() { DepartmentId = 2, Name = "Farewell",
                //        Description = "For Family Events", DateAdded = DateTime.Today.AddDays(-1) },
                //    new Category() { DepartmentId = 3, Name = "Graduate",
                //        Description = "For Family Events", DateAdded = DateTime.Today.AddDays(-1) },
                //};

                //context.Category.AddRange(cats);
                //context.SaveChanges();

                // Sample Data: Object Graph
                // ...
            }
            return RedirectToAction("Index");
        }

        #region Test Modules
        public ActionResult ModuleIndex()
        {
            return View(GetTimeStamps());
        }

        [HttpPost]
        public ActionResult ModuleIndex(Color color)
        {
            //Color? oldColor = Session["color"] as Color?;
            //if (oldColor != null)
            //{
            //    Votes.ChangeVote(color, (Color)oldColor);
            //}
            //else
            //{
            //    Votes.RecordVote(color);
            //}
            //ViewBag.SelectedColor = Session["color"] = color;
            //return View(GetTimeStamps());
            return null;
        }

        public ActionResult Modules()
        {
            var modules = HttpContext.ApplicationInstance.Modules;
            Tuple<string, string>[] data =
            modules.AllKeys
                .Select(x => new Tuple<string, string>(
                    x.StartsWith("__Dynamic") ? x.Split('_', ',')[3] : x,
                    modules[x].GetType().Name))
                .OrderBy(x => x.Item1).ToArray();
            return View(data);
        }

        private List<string> GetTimeStamps()
        {
            return new List<string> {
                string.Format("App timestamp: {0}",
                HttpContext.Application["app_timestamp"]),
                string.Format("Request timestamp: {0}", Session["request_timestamp"]),
                };
        }
        #endregion Test Module

        #region Trace
        private Dictionary<string, string> progs = new Dictionary<string, string> {
            { "A", "AlanSmith" },
            { "B", "Bonano" },
            { "C", "Cristian" }
            };
        public ActionResult IndexTrace()
        {
            HttpContext.Trace.Write("HomeController", "Index Method Started");
            HttpContext.Trace.Write("HomeController",
                string.Format("There are {0} programmers", progs.Keys.Count));
            ActionResult result = View(progs);
            HttpContext.Trace.Write("HomeController", "Index Trace Method Completed");
            return result;
        }
        #endregion Trace
    }
}