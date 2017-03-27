using BalloonShop.Domain.Abstract;
using BalloonShop.Domain.Concrete;
using BalloonShop.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace BalloonShop.Controllers
{
    public class DepartmentController : Controller
    {
        private IRepository<Department> _repository;
        public DepartmentController(IRepository<Department> repo)
        {
            _repository = repo;
        }

        public ActionResult Index()
        {
            // Lazy Loading
            //return View(_repository.list.ToList());

            // Eager Loading    
            return View(((IQueryable<Department>)(_repository.list)).Include(t => t.Categories));

            // Explicit Loading (You'd use this when Lazy Loading is turned off
            // Department depts = context.Departments.ToList(); // Note: ToList() must be here
            // foreach (var dept in depts)
            // {
            //     Context.Entry(d).Collection(x => x.Categories).Load(); // Collection
            //     // Context.Entry(d).Reference(x => x.Administrator).Load(); // Single Element
            //     foreach (var cat in dept.Categories)
            //     {
            //         categoryList.Add(cat.Name);
            //     }
            // }
            // 
        }

        [HttpPost]
        public ActionResult Delete(int DepartmentId)
        {
            Department item = _repository.Delete(DepartmentId);
            if (item != null)
            {
                TempData["message"] = string.Format("{0} was deleted.",
                    item.Name);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View("Edit", new Department());
        }

        public ActionResult Edit(int DepartmentId)
        {
            Department obj = _repository.list
                .FirstOrDefault(p => p.DepartmentId == DepartmentId);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(Department item)
        {
            if(ModelState.IsValid)
            {
                _repository.Save(item);
                /** Tip
                //The key difference from session data is
                //  that temp data is deleted at the end of the HTTP request.
                //I cannot use ViewBag in this situation because the user is being redirected.
                //  ViewBag passes data between the
                //  controller and view, and it cannot hold data for longer than the current HTTP request.
                //I could have used the session data feature, but then the message would be persistent until
                //  I explicitly removed it, which I would rather not have to do
                **/
                TempData["message"] = string.Format("{0} has been save.", item.Name);
                return RedirectToAction("Index");
            } else
            {
                // there is something wrong with the data values
                return View(item);
            }
        }

        public ActionResult DepartmentViewInfoList()
        {
            IList<DepartmentViewInfo> deptAll;
            using (var context = new AppDbContext())
            {
                deptAll = context.DepartmentViewInfo
                    .Where(p => p.DeptId > 0)
                    .ToList();
            }
            return View(deptAll);
        }
    }
}