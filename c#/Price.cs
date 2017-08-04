using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Realmdigital_Interview.Models
{
    public class Price
    {
        [DataType(DataType.Currency)]
        public decimal SellingPrice { get; set; }

        [StringLength(3)]
        public string CurrencyCode { get; set; }
    }
}