using BalloonShop.Domain.Abstract;
using BalloonShop.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BalloonShop.Controllers
{
    public class CategoryController : Controller
    {
        //private IRepository<Category> _repository;
        private ICategoryRepository _repository;
        //public CategoryController(IRepository<Category> repo)
        public CategoryController(ICategoryRepository repo)
        {
            _repository = repo;
        }

        public ActionResult Index()
        {
            return View(_repository.list); // => Eagerly Loading
            //return View(_repository.list.ToList()); // => Lazy Loading
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
            PopulateDepartmentsDropDownList();
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

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var depts = _repository.GetDepartments();
            ViewBag.DepartmentId = new SelectList(depts, "DepartmentId", "Name", selectedDepartment); 
        }
        
    }
}