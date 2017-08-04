using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Newtonsoft.Json;
using System.Collections.Specialized;
using Realmdigital_Interview.Models;

namespace Retiremate_Integration_Services.Controllers
{
    public class ProductController
    {
        private Uri uri = new Uri("http://192.168.0.241/eanlist?type=Web");
        private NameValueCollection data = new NameValueCollection();
        private string contenttype = "application/json";



        [Route("product")]
        public Product GetProductById(string productId)
        {
            string response = "";
            data.Clear();

            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = contenttype;
                data.Add("id", productId);
                response = System.Text.Encoding.UTF8.GetString(client.UploadValues(uri, data));

            }
            List<Product> response_products = JsonConvert.DeserializeObject<List<Product>>(response);
            List<Product> result_products = getZAProducts(response_products);

            return result_products.Count > 0 ? result_products[0] : null;

        }

        [Route("product/search")]
        public List<Product> GetProductsByName(string productName)
        {
            string response = "";
            data.Clear();

            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = contenttype;
                data.Add("names", productName);
                response = System.Text.Encoding.UTF8.GetString(client.UploadValues(uri, data));
            }
           List<Product> response_products = JsonConvert.DeserializeObject<List<Product>>(response);

            return getZAProducts(response_products);

           
        }



        private List<Product> getZAProducts(List<Product> response_products)
        {
            List<Product> result_products = new List<Product>();
            foreach (Product prod in response_products)
            {
                Product za_product = prod;
                IEnumerable<Price> zar_prices = prod.PriceRecords.Where(p => p.CurrencyCode == "ZAR");
                za_product.PriceRecords = prod.PriceRecords.Where(p => p.CurrencyCode == "ZAR").ToList();
                result_products.Add(za_product);

            }

            return result_products;

        }
    }
}


   