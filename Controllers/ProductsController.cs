using AsHomeStore.Models;
using AsHomeStore.Models.ViewModels;
using AsHomeStore.Repository;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsHomeStore.Controllers
{
    public class ProductsController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        CategoryRepository categoryRepository = new CategoryRepository();


        // GET: Products
        public ActionResult Index()
        {
            List<ProductModel> products = productRepository.GetAllProducts();
            return View("AllProducts", products);
        }

        // GET: Products/Details/5
        public ActionResult Details(Guid id)
        {

            ProductModel productModel = productRepository.GetProductById(id);
            CategoryNameViewModel categoryNameViewModel = new CategoryNameViewModel();
            categoryNameViewModel.ProductName = productModel.ProductName;
            categoryNameViewModel.Description = productModel.ProductDescription;
            categoryNameViewModel.Price = productModel.UnitPrice;
            categoryNameViewModel.CategoryName = categoryRepository.GetCategoryById(productModel.IdCategory).CategoryName;
            categoryNameViewModel.PhotoUrl = productModel.PhotoUrl;
                
           
            return View("ProductDetails", categoryNameViewModel);
        }

        [Authorize(Roles = "Admin")]
        // GET: Products/Create
        public ActionResult Create()
        {
            var category = categoryRepository.GetAllCategories();
            SelectList categoryList = new SelectList(category, "IdCategory", "CategoryName");
            ViewData["categoryList"] = categoryList; 

            return View("CreateProduct");
        }


        // POST: Products/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ProductModel productModel = new ProductModel();

                UpdateModel(productModel);

                productRepository.InsertProduct(productModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        // GET: Products/Edit/5
        public ActionResult Edit(Guid id)
        {

            ProductModel productModel = productRepository.GetProductById(id);
            return View("EditProduct", productModel);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try 
            {
                ProductModel productModel = new ProductModel();

                UpdateModel(productModel);

                productRepository.UpdateProduct(productModel);
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditProduct");
            }
        }


        [Authorize(Roles = "Admin")]
        // GET: Products/Delete/5
        public ActionResult Delete(Guid id)
        {

            ProductModel productModel = productRepository.GetProductById(id);
            return View("DeleteProduct", productModel);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
               
                productRepository.DeleteProduct(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("AllProducts");
            }
        }

       
    }
}
