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
        private IRepository<Department> _repository;
        public DepartmentController(IRepository<Department> repo)
        {
            _repository = repo;
        }

        public ActionResult Index()
        {
            return View(_repository.list);
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