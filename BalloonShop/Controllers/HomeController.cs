﻿using BalloonShop.Domain.Concrete;
using BalloonShop.Domain.Entities;
using System;
using System.Collections.Generic;
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

    }
}