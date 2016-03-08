using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpandedDetailView.Models.BaseModels
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }

        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime DateAdded { get; set; }
        public bool OnSale { get; set; }
        public float  SalePrice { get; set; }
        public string Image { get; set; }

        public int StorageAmount { get; set; }
    }
}