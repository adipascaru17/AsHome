using AsHomeStore.Models;
using AsHomeStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsHomeStore.Controllers
{
    public class CategoriesController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository(); 
        // GET: Categories
        public ActionResult Index()
        {
            List<CategoryModel> categories = categoryRepository.GetAllCategories();
            return View("AllCategories", categories);
        }

        // GET: Categories/Details/5
        public ActionResult Details(Guid id)
        {

            CategoryModel categoryModel = categoryRepository.GetCategoryById(id);
            return View("CategoryDetails", categoryModel);
        }

        [Authorize (Roles ="Admin")]
        // GET: Categories/Create
        public ActionResult Create()
        {

            return View("CreateCategory");
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CategoryModel categoryModel = new CategoryModel();

                UpdateModel(categoryModel);

                categoryRepository.InsertCategory(categoryModel);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id)
        {

            CategoryModel categoryModel = categoryRepository.GetCategoryById(id);
            return View("EditCategory", categoryModel);
        }

        // POST: Categories/Edit/5
        [HttpPost]

        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                CategoryModel categoryModel = new CategoryModel();

                UpdateModel(categoryModel);

                categoryRepository.UpdateCategory(categoryModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("AllCategories");
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Categories/Delete/5
        public ActionResult Delete(Guid id)
        {

            CategoryModel categoryModel = categoryRepository.GetCategoryById(id);
            return View("DeleteCategory", categoryModel);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                categoryRepository.DeleteCategory(id);
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteCategory");
            }
        }
    }
}
