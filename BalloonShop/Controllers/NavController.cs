using BalloonShop.Domain.Abstract;
using BalloonShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BalloonShop.Controllers
{
    public class NavController : Controller
    {
        //private IRepository<Product> _repository;
        private IProductRepository _repository;

        //public NavController(IRepository<Product> repo)
        public NavController(IProductRepository repo)
        {
            _repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories =
                _repository.list.ToList().Select(x => x.Category.Name)
                    .Distinct()
                    .OrderBy(x => x);
            return PartialView("FlexMenu", categories);
        }
    }
}