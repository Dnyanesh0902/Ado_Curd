using MachineTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MachineTest.Controllers
{
    public class ProductController : Controller
    {
        Product obj = new Product();
        public ActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var response = obj.GetProducts(pageNumber, pageSize);
            return View(response);
        }
        public ActionResult Details(int id)
        {
            var response = obj.GetProducts(1,100).Single(a => a.ProductId == id);
            return View(response);
        }
        public ActionResult Create()
        {
            Category objCategory = new Category();
            var categoryList = objCategory.GetCategories();
            ViewBag.Categories = new SelectList(categoryList, "CategoryId", "CategoryName"); 
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product obj)
        {
            try
            {
                obj.AddProduct(obj);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult Edit(int id)
        {
            Product objProduct = new Product();
            var product = objProduct.GetProducts(1,100).SingleOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return HttpNotFound();
            }

            Category objCategory = new Category();
            var categoryList = objCategory.GetCategories();

            ViewBag.Categories = new SelectList(categoryList, "CategoryId", "CategoryName", product.CategoryId); 
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product obj)
        {
            try
            {
                obj.UpdateProduct(obj);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult Delete(int id)
        {
            var response = obj.GetProducts(1, 100).Single(a => a.ProductId == id);
            return View(response);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                obj.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

    }
}