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

        public DateTime OrderDate { get; set; }

        public DateTime ShippingDate { get; set; }

        public string ShippingAdress { get; set; }

        public string ShippingCity { get; set; }

        public string ShippingRegion { get; set; }

        public string ShippingCountry { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Total + VAT")]
        public double TotalPrice { get; set; }
    }
}