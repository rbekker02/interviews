using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Realmdigital_Interview.Models
{
    public class Product
    {
        [DisplayName("Bar Code")]
        public string BarCode { get; set; }

        [DisplayName("Product Name")]
        public string ItemName { get; set; }


        public List<Price> PriceRecords { get; set; }
    }
}