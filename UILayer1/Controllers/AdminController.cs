using AspNetCoreHero.ToastNotification.Abstractions;
using DomainLayer;
using DomainLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using UIlayer.Data.ApiServices;


namespace UIlayer.Controllers
{

    public class AdminController : Controller
    {
        Product data = null;
        IConfiguration Configuration { get; }
        ProductApi pr;
        private readonly INotyfService _notyf;
        public AdminController(IConfiguration configuration, INotyfService notyf)
        {
            _notyf = notyf;
            Configuration = configuration;
            pr = new ProductApi(Configuration);
            data = new Product();
        }
        public ActionResult Index(int? i)
        {
            /*IEnumerable<Product> products = pr.GetProduct();*/
            _notyf.Success("Success Notification");

            return View();
        }

        public ActionResult Details(int id)
        {
            Product product = pr.GetProduct(id);
            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ViewProductModel product)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                data.Id = 0;
                data.Name = product.Name;
                data.Model = product.Model;
                data.Price = product.Price;
                data.Description = product.Description;
                result = pr.CreateProduct(data);
                if (result)
                {
                   
                    return Json(new { data = "success" });
                }
                else
                {
                    return Json(new { data = "failed" });
                }
            }
            else
            {
                return Json(new { data = "failed" });
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = pr.GetProduct(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                bool result = pr.EditProduct(product);
            }
            return RedirectToAction("");
        }
        public ActionResult Delete(int id)
        {
            bool result = pr.DeleteProduct(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
