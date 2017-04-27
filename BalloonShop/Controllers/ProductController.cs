using BalloonShop.Domain.Abstract;
using BalloonShop.Domain.Entities;
using BalloonShop.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BalloonShop.Controllers
{
    //[RoutePrefix("Product")]
    public class ProductController : Controller
    {
        //private IRepository<Product> _repository;
        private IProductRepository _repository;
        public int PageSize = 4;
        //public ProductController(IRepository<Product> repo)
        public ProductController(IProductRepository repo)
        {
            _repository = repo;
        }

        //[Route("~/Test")] // ~/ => don't apply RoutePrefix
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = _repository.list
                    .Where(p => category == null ||
                        p.Category.ToString() == category)
                    .OrderBy(p => p.ProductId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = (category == null) ? _repository.list.Count()
                                    : _repository.list.Where(e => e.Category.ToString() == category).Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }

        [Authorize]
        public ActionResult Index()
        {
            return View(_repository.list);
        }

        //[Route("Add/{product}/{id:int}")]
        //[Route("Add/{product}/{name:alpha:length(6)}")]
        public ActionResult Create()
        {
            PopulateCategoriesDropDownList();
            return View("Edit", new Product());
        }

        public ActionResult Edit(int ProductId)
        {
            Product obj = _repository.list
                .FirstOrDefault(p => p.ProductId == ProductId);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(Product inObj, HttpPostedFileBase image = null)
        {
            //if (checked somecondition)
            //{
            //    ModelState.AddModelError("FieldName", "Invalid data in FieldName."); // => Property-level error
            //    ModelState.AddModelError("", "Joe cannot book appointments on Mondays"); // => Model-level error
            //}

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    inObj.ImageMimeType = image.ContentType;
                    inObj.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(inObj.ImageData, 0, image.ContentLength);
                }

                _repository.Save(inObj);
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
            }
            else
            {
                // there is something wrong with the data values
                return View(inObj);
            }
        }

        [HttpPost]
        public ActionResult Delete(int ProductId)
        {
            Product deletedProduct = _repository.Delete(ProductId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted.",
                    deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int productId)
        {   
            Product obj = _repository.list
                .FirstOrDefault(p => p.ProductId == productId);
            if (obj != null)
            {
                return File(obj.ImageData, obj.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Remote validation: Sample
        /// Validate by Server but via Json (Ajax)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public JsonResult ValidateName(string Name)
        {
            if(Name == "Phantom")
            {
                // JsonRequestBehavior.AllowGet: This is because the 
                //   MVC Framework disallows GET requests that produce JSON by default,
                return Json("Sorry, this name is not allow!",
                    JsonRequestBehavior.AllowGet);
            } else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        
        private void PopulateCategoriesDropDownList(object selectedCategory = null)
        {
            var cats = _repository.GetCategories();
            ViewBag.CategoryId = new SelectList(cats, "CategoryId", "Name", selectedCategory);
        }
    }
}