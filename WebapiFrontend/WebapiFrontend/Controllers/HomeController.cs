using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using System.Diagnostics;
using System.Net;
using System.Text.Json.Serialization;

using WebapiFrontend.Models;

namespace WebapiFrontend.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Product()
        {
            var url = "https://localhost:7099/api/Products/AllProducts";
            using (WebClient web = new WebClient())
            {
                string jsonStr = web.DownloadString(url);
                List<Product> product = JsonConvert.DeserializeObject<List<Product>>(jsonStr);
                return View(product);
            }
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(ProductDTO prod)
        {
            var url = "https://localhost:7099/api/Products/AddProduct";
            using (WebClient web = new WebClient())
            {
                web.Headers[HttpRequestHeader.ContentType] = "application/json";
                // Serialize the product to JSON
                string jsonStr = JsonConvert.SerializeObject(prod);

                // Post the JSON string to the API
                string response = web.UploadString(url, "POST", jsonStr);

                return RedirectToAction("Product");
            }
        }



    }
}