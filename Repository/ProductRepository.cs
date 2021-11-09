using AsHomeStore.Models;
using AsHomeStore.Models.ViewModels;
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




        public void InsertProduct(ProductModel productModel)
        {
            productModel.IdProduct = Guid.NewGuid();
            dbContext.Products.InsertOnSubmit(MapModelToDbObject(productModel));
            dbContext.SubmitChanges();

        }



        public void UpdateProduct( ProductModel productModel)
        {
            Models.DBObjects.Product existingProduct = dbContext.Products.FirstOrDefault(x => x.IdProduct == productModel.IdProduct);
            if (existingProduct != null)
            {
                existingProduct.IdProduct = productModel.IdProduct;
                existingProduct.ProductName = productModel.ProductName;
                existingProduct.ProductDescription = productModel.ProductDescription;
                existingProduct.UnitPrice = productModel.UnitPrice;
                existingProduct.IdCategory = productModel.IdCategory;
                existingProduct.PhotoUrl = productModel.PhotoUrl;
                dbContext.SubmitChanges();
            }

        }

        public void DeleteProduct(Guid Id)
        {
            Models.DBObjects.Product selectedProduct = dbContext.Products.FirstOrDefault(x => x.IdProduct == Id);
            if(selectedProduct != null)
            {
                dbContext.Products.DeleteOnSubmit(selectedProduct);
                dbContext.SubmitChanges();
            }
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
                productModel.PhotoUrl = dbUser.PhotoUrl;
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
                dbUser.PhotoUrl = productModel.PhotoUrl;

                return dbUser;
            }

            return null;


        }




    }
}