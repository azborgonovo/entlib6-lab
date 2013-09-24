using EntLib6Lab.Application.Dtos;
using EntLib6Lab.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntLib6Lab.Web.Controllers
{
    public class ProductsController : Controller
    {
        IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            if (productsService == null) throw new ArgumentNullException("productsService");

            _productsService = productsService;
        }

        //
        // GET: /Products/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductDto product)
        {
            _productsService.AddProduct(product);

            return View("Index");
        }

    }
}
