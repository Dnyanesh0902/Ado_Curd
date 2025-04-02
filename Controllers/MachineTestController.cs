using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MachineTest.Models;

namespace MachineTest.Controllers
{
    public class MachineTestController : Controller
    {
        Category obj = new Category();
        // GET: Default
        public ActionResult Index()
        {
            var response = obj.GetCategories();
            return View(response);
        }
        public ActionResult Details(int id)
        {
            var response =obj.GetCategories().Single(a => a.CategoryId == id);
            return View(response);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category obj)
        {
            try
            {
                obj.AddCategory(obj);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult Edit(int id)
        {
            var response = obj.GetCategories().Single(a => a.CategoryId == id);
            return View(response);
        }
        [HttpPost]
        public ActionResult Edit(Category obj)
        {
            try
            {
                obj.EditCategory(obj);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult Delete(int id)
        {
            var response = obj.GetCategories().Single(a => a.CategoryId == id);
            return View(response);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                obj.DeleteCategory(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

    }
}