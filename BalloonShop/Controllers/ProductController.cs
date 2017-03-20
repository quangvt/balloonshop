using BalloonShop.Domain.Abstract;
using BalloonShop.Domain.Entities;
using BalloonShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BalloonShop.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null ||
                        p.Category == category)
                    .OrderBy(p => p.ProductId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = (category == null) ? repository.Products.Count()
                                    : repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int ProductId)
        {
            Product deletedProduct = repository.Delete(ProductId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted.",
                    deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View("Edit", new Product());
        }

        public ActionResult Edit(int ProductId)
        {
            Product obj = repository.Products
                .FirstOrDefault(p => p.ProductId == ProductId);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(Product inObj, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    inObj.ImageMimeType = image.ContentType;
                    inObj.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(inObj.ImageData, 0, image.ContentLength);
                }

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
            }
            else
            {
                // there is something wrong with the data values
                return View(inObj);
            }
        }

        public FileContentResult GetImage(int productId)
        {
            Product obj = repository.Products
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
    }
}