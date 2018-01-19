using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftShopWebApi.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        
        public string Name { get; set; }

        public string ImageName { get; set; }

        public string Info { get; set; }

        public float price { get; set; }

        public int Quantity { get; set; }
    }
}