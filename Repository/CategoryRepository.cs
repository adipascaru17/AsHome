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


       public CategoryModel GetCategoryById( Guid Id)
        {
            return MapDbObjectToModel(dbContext.Categories.FirstOrDefault(x => x.IdCategory == Id));
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


        public void InsertCategory( CategoryModel categoryModel)
        {
            categoryModel.IdCategory = new Guid();
            dbContext.Categories.InsertOnSubmit(MapModelToDbObject(categoryModel));
            dbContext.SubmitChanges();

        }


        public void UpdateCategory (CategoryModel categoryModel)
        {
            Models.DBObjects.Category existingCategory = dbContext.Categories.FirstOrDefault(x => x.IdCategory == categoryModel.IdCategory);

            if (existingCategory != null)
            {
                existingCategory.IdCategory = categoryModel.IdCategory;
                existingCategory.CategoryName = categoryModel.CategoryName;
                existingCategory.CategoryDescription = categoryModel.CategoryDescription;
                dbContext.SubmitChanges();

            }

        }


        public void DeleteCategory (Guid Id)
        {
            Models.DBObjects.Category selectedCategory = dbContext.Categories.FirstOrDefault(x => x.IdCategory == Id);

            if (selectedCategory != null)
            {
                dbContext.Categories.DeleteOnSubmit(selectedCategory);
                dbContext.SubmitChanges();
            }

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