using BalloonShop.Domain.Abstract;
using BalloonShop.Domain.Concrete;
using BalloonShop.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BalloonShop.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository repository;
        public DepartmentController(IDepartmentRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            return View(repository.Departments);
        }

        [HttpPost]
        public ActionResult Delete(int DepartmentId)
        {
            Department deletedDepartment = repository.Delete(DepartmentId);
            if (deletedDepartment != null)
            {
                TempData["message"] = string.Format("{0} was deleted.",
                    deletedDepartment.Name);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View("Edit", new Department());
        }

        public ActionResult Edit(int DepartmentId)
        {
            Department obj = repository.Departments
                .FirstOrDefault(p => p.DepartmentId == DepartmentId);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(Department inObj)
        {
            if(ModelState.IsValid)
            {
                repository.Save(inObj);
                /** Tip
                //The key difference from session data is
                //  that temp data is deleted at the end of the HTTP request.
                //I cannot use ViewBag in this situation because the user is being redirected.
                //  ViewBag passes data between the
                //  controller and view, and it cannot hold data for longer than the current HTTP request.
                //I could have used the session data feature, but then the message would be persistent until
                //  I explicitly removed it, which I would rather not have to do
                **/
                TempData["message"] = string.Format("{0} has been save.", inObj.Name);
                return RedirectToAction("Index");
            } else
            {
                // there is something wrong with the data values
                return View(inObj);
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