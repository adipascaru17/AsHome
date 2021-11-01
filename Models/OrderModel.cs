using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsHomeStore.Models
{
    public class OrderModel
    {
        public Guid IdOrder { get; set; }
        public string IdUserClient { get; set; }
        public Guid IdProduct { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        public DateTime ShippingDate { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        public string ShippingAdress { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        public string ShippingCity { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        public string ShippingRegion { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        public string ShippingCountry { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        public int Quantity { get; set; }

    }
}