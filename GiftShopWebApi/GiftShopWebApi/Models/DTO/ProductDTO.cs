using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftShopWebApi.Models.DTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public string ImageName { get; set; }

        public float price { get; set; }
    }
}