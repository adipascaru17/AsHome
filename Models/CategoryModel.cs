using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsHomeStore.Models
{
    public class CategoryModel
    {
        public Guid IdCategory { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Description")]
        public string CategoryDescription { get; set; }

    }
}