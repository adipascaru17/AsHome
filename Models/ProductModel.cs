using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsHomeStore.Models
{
    public class ProductModel
    {
        public Guid IdProduct { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int UnitPrice { get; set; }
        public Guid IdCategory { get; set; }
    }
}