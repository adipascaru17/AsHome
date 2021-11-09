using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsHomeStore.Models.ViewModels
{
    public class CategoryNameViewModel
    {
        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        public int Price { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        public string PhotoUrl { get; set; }


    }
}