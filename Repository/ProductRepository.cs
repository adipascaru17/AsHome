using AsHomeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsHomeStore.Repository
{
    public class ProductRepository
    {
        private Models.DBObjects.AsHomeStoreDataContext dbContext;

        public ProductRepository()
        {
            dbContext = new Models.DBObjects.AsHomeStoreDataContext();
        }

        public ProductRepository(Models.DBObjects.AsHomeStoreDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> productList = new List<ProductModel>();
            foreach (Models.DBObjects.Product dbProducts in dbContext.Products)
            {
                productList.Add(MapDbObjectToModel(dbProducts));
            }

            return productList;

        }


        public List<ProductModel> GetProductsById(Guid Id)
        {
            List<ProductModel> productList = new List<ProductModel>();
            foreach (Models.DBObjects.Product dbProducts in dbContext.Products.Where(x=>x.IdProduct==Id))
            {
                productList.Add(MapDbObjectToModel(dbProducts));
            }

            return productList;

        }

        public ProductModel GetProductById(Guid Id)
        {
            return MapDbObjectToModel(dbContext.Products.FirstOrDefault(x => x.IdProduct == Id));
        }


        public List<ProductModel> GetProductsByName(string name)
        {
            List<ProductModel> productList = new List<ProductModel>();

            foreach (Models.DBObjects.Product dbProducts in dbContext.Products.Where(x=>x.ProductName==name))
            {
                productList.Add(MapDbObjectToModel(dbProducts));
            }

            return productList;

        }

















        private ProductModel MapDbObjectToModel(Models.DBObjects.Product dbUser)
        {
            ProductModel productModel = new ProductModel();

            if (dbUser != null)
            {
                productModel.IdProduct= dbUser.IdProduct;
                productModel.IdCategory = dbUser.IdCategory;
                productModel.ProductDescription = dbUser.ProductDescription;
                productModel.ProductName = dbUser.ProductName;
                productModel.UnitPrice = dbUser.UnitPrice;
                return productModel;
            }

            return null;


        }




        private Models.DBObjects.Product MapModelToDbObject(ProductModel productModel)
        {
            Models.DBObjects.Product dbUser = new Models.DBObjects.Product();

            if (productModel != null)
            {
                dbUser.IdProduct = productModel.IdProduct;
                dbUser.IdCategory = productModel.IdCategory;
                dbUser.ProductDescription = productModel.ProductDescription;
                dbUser.ProductName = productModel.ProductName;
                dbUser.UnitPrice = productModel.UnitPrice;

                return dbUser;
            }

            return null;


        }




    }
}