using AsHomeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsHomeStore.Repository
{
    public class OrdersRepository
    {

        Models.DBObjects.AsHomeStoreDataContext dbContext;

        public OrdersRepository()
        {
            dbContext = new Models.DBObjects.AsHomeStoreDataContext();
        }

        public OrdersRepository(Models.DBObjects.AsHomeStoreDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<OrderModel> GetAllOrders()
        {
            List<OrderModel> orderList = new List<OrderModel>();
            foreach (Models.DBObjects.Order dbOrders in dbContext.Orders)
            {
                orderList.Add(MapDbObjectToModel(dbOrders));
            }

            return orderList;

        }

        public List<OrderModel> GetOrdersById(Guid Id)
        {
            List<OrderModel> orderList = new List<OrderModel>();
            foreach (Models.DBObjects.Order dbOrders in dbContext.Orders.Where(x => x.IdOrder == Id))
            {
                orderList.Add(MapDbObjectToModel(dbOrders));
            }

            return orderList;

        }


        public void InsertOrder(OrderModel orderModel)
        {
            orderModel.IdOrder = Guid.NewGuid();

            dbContext.Orders.InsertOnSubmit(MapModelToDbObject(orderModel));
            dbContext.SubmitChanges();

        }


        public void DeleteOrder(Guid Id)
        {
            Models.DBObjects.Order orderToDelete = dbContext.Orders.FirstOrDefault(x => x.IdOrder == Id);
            if(orderToDelete != null)
            {
                dbContext.Orders.DeleteOnSubmit(orderToDelete);
                dbContext.SubmitChanges();
            }

        }


//---------------------------------------------------------------------------------------------------------------------------

        private OrderModel MapDbObjectToModel(Models.DBObjects.Order dbUser)
        {
            OrderModel orderModel = new OrderModel();

            if (dbUser != null)
            {
                orderModel.IdOrder = dbUser.IdOrder;
                orderModel.IdUserClient = dbUser.IdUser;
                orderModel.IdProduct = dbUser.IdProduct;
                orderModel.OrderDate = dbUser.OrderDate;
                orderModel.ShippingDate = (DateTime)dbUser.ShippingDate;
                orderModel.ShippingAdress = dbUser.ShippingAdress;
                orderModel.ShippingCity = dbUser.ShippingCity;
                orderModel.ShippingRegion = dbUser.ShippingRegion;
                orderModel.ShippingCountry = dbUser.ShippingCountry;
                orderModel.Quantity = dbUser.Quantity;
                return orderModel;
            }

            return null;


        }




        private Models.DBObjects.Order MapModelToDbObject(OrderModel orderModel)
        {
            Models.DBObjects.Order dbUser = new Models.DBObjects.Order();

            if (orderModel != null)
            {
                dbUser.IdOrder = orderModel.IdOrder;
                dbUser.IdUser=orderModel.IdUserClient;
                dbUser.IdProduct=orderModel.IdProduct;
                dbUser.OrderDate=orderModel.OrderDate;
                dbUser.ShippingDate=orderModel.ShippingDate;
                dbUser.ShippingAdress=orderModel.ShippingAdress;
                dbUser.ShippingCity=orderModel.ShippingCity;
                dbUser.ShippingRegion=orderModel.ShippingRegion;
                dbUser.ShippingCountry=orderModel.ShippingCountry;
                dbUser.Quantity = orderModel.Quantity;

                return dbUser;
            }

            return null;


        }


    }
}