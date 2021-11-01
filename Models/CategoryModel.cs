using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsHomeStore.Models
{
    public class CategoryModel
    {
        public Guid IdCategory { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

    }
}