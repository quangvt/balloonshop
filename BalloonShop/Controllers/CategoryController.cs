﻿using BalloonShop.Domain.Abstract;
using BalloonShop.Domain.Entities;
using System.Linq;
using System.Web.Mvc;

namespace BalloonShop.Controllers
{
    public class CategoryController : Controller
    {
        private IRepository<Category> _repository;
        public CategoryController(IRepository<Category> repo)
        {
            _repository = repo;
        }

        public ActionResult Index()
        {
            return View(_repository.list);
        }

        [HttpPost]
        public ActionResult Delete(int CategoryId)
        {
            Category item = _repository.Delete(CategoryId);
            if (item != null)
            {
                TempData["message"] = string.Format("{0} was deleted.",
                    item.Name);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View("Edit", new Category());
        }

        public ActionResult Edit(int CategoryId)
        {
            Category obj = _repository.list
                .FirstOrDefault(p => p.CategoryId == CategoryId);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(Category item)
        {
            if (ModelState.IsValid)
            {
                _repository.Save(item);
                TempData["message"] = string.Format("{0} has been save.", item.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(item);
            }
        }

        
    }
}