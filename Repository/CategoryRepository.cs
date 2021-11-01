using AsHomeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsHomeStore.Repository
{
    public class CategoryRepository
    {

        private Models.DBObjects.AsHomeStoreDataContext dbContext;

        public CategoryRepository()
        {
            this.dbContext = new Models.DBObjects.AsHomeStoreDataContext();
        }

        public CategoryRepository(Models.DBObjects.AsHomeStoreDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<CategoryModel> GetAllCategories()
        {
            List<CategoryModel> categoryList = new List<CategoryModel>();

            foreach (Models.DBObjects.Category dbCategory in dbContext.Categories )
            {
                categoryList.Add(MapDbObjectToModel(dbCategory));

            }

            return categoryList;
            
        }


        public List<CategoryModel> GetCategoriesById(Guid Id)
        {
            List<CategoryModel> categoryList= new List<CategoryModel>();

            foreach (Models.DBObjects.Category dbUserClient in dbContext.Categories.Where(x => x.IdCategory == Id))
            {
                categoryList.Add(MapDbObjectToModel(dbUserClient));
            }

            return categoryList;
        }



        public List<CategoryModel> GetCategoriesByName (string name)
        {
            List<CategoryModel> categoryList = new List<CategoryModel>();

            foreach (Models.DBObjects.Category dbCategory in dbContext.Categories.Where(x=>x.CategoryName == name) ) 
            {
                categoryList.Add(MapDbObjectToModel(dbCategory));
            
            }

            return categoryList;
            
        }


        private CategoryModel MapDbObjectToModel( Models.DBObjects.Category dbCategory)
        {
            CategoryModel categoryModel = new CategoryModel();

            if ( dbCategory != null) 
            {
                categoryModel.IdCategory = dbCategory.IdCategory;
                categoryModel.CategoryName = dbCategory.CategoryName;
                categoryModel.CategoryDescription = dbCategory.CategoryDescription;

                return categoryModel;
            }

            return null;


        }




        private Models.DBObjects.Category MapModelToDbObject(CategoryModel categoryModel)
        {
            Models.DBObjects.Category dbCategory = new Models.DBObjects.Category();

            if (categoryModel != null)
            {
                dbCategory.IdCategory = categoryModel.IdCategory;
                dbCategory.CategoryName = categoryModel.CategoryName;
                dbCategory.CategoryDescription = categoryModel.CategoryDescription;

                return dbCategory;
            }

            return null;


        }





    }
}