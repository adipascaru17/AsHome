using AsHomeStore.Models.ViewModels;
using AsHomeStore.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace AsHomeStore.Controllers
{
    public class AllOrdersController : Controller
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

        public AllOrdersController() { }

        public AllOrdersController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        [Authorize]
        // GET: AllOrders
        public ActionResult Index()
        {
            var currentUser = UserManager.FindByName(HttpContext.User.Identity.Name);

            List<OrderViewModel> orders = ordersRepository.GetAllOrders().Where(order => order.IdUserClient == currentUser.Id).Select(order => new OrderViewModel
            {
                ClientName = currentUser.FirstName + ' ' + currentUser.LastName,
                ProductName = productRepository.GetProductById(order.IdProduct).ProductName,
                OrderDate = order.OrderDate,
                ShippingDate = order.ShippingDate,
                ShippingAdress = order.ShippingAdress,
                ShippingCity = order.ShippingCity,
                ShippingRegion = order.ShippingRegion,
                ShippingCountry = order.ShippingCountry,
                Quantity = order.Quantity,
                TotalPrice = (order.Quantity * productRepository.GetProductById(order.IdProduct).UnitPrice) + (order.Quantity * productRepository.GetProductById(order.IdProduct).UnitPrice) * (16 / 100d)
            }).ToList();
                
            return View("AllOrders", orders);
        }

        // GET: AllOrders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AllOrders/Create
        public ActionResult Create()
        {
            return RedirectToAction("Create", "Order"); // "on create" send to createOrder controller 
        }

        // POST: AllOrders/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AllOrders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AllOrders/Edit/5
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

        // GET: AllOrders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AllOrders/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
