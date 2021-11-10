using AsHomeStore.Models;
using AsHomeStore.Repository;
using System.Web.Mvc;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;

namespace AsHomeStore.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        OrdersRepository ordersRepository = new OrdersRepository();
        ProductRepository productRepository = new ProductRepository();

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public OrderController() { }

        public OrderController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        // GET: Order
        public ActionResult Index()
        {
            return Redirect("/AllOrders");
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            var products = productRepository.GetAllProducts();
            SelectList productsList = new SelectList(products, "IdProduct", "ProductName");
            ViewData["productsList"] = productsList;

            return View("CreateOrder");
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                OrderModel orderModel = new OrderModel();

                UpdateModel(orderModel);
                orderModel.IdUserClient = UserManager.FindByName(HttpContext.User.Identity.Name).Id;

                ordersRepository.InsertOrder(orderModel);

                return Redirect("/AllOrders");
            }
            catch(Exception ex)
            {
                var test = ex;
                return View("CreateOrder");
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(Guid id)
        {
           
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View("AllOrders");
            }
        }
    }
}
