using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsHomeStore.Models
{
    public class ProductModel
    {
        public Guid IdProduct { get; set; }

        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Display(Name = "Description")]
        public string ProductDescription { get; set; }

        [Display(Name = "Price")]
        public int UnitPrice { get; set; }
        public Guid IdCategory { get; set; }

        [Display(Name = "Choose the picture for your product ")]
        public string PhotoUrl { get; set; }
    }
}