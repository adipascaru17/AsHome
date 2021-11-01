using System;
using System.ComponentModel.DataAnnotations;

namespace AsHomeStore.Models.ViewModels
{
    public class OrderViewModel
    {
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        
        [Display(Name = "Shipping Date")]
        public DateTime ShippingDate { get; set; }

        [Display(Name = "Shipping Adress")]
        public string ShippingAdress { get; set; }

        [Display(Name = "Shipping City")]
        public string ShippingCity { get; set; }

        [Display(Name = "Shipping Region")]
        public string ShippingRegion { get; set; }

        [Display(Name = "Shipping Country")]
        public string ShippingCountry { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Total + VAT")]
        public double TotalPrice { get; set; }
    }
}