using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Net;
using System.Security.Permissions;
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

        // See All Brand

        [HttpGet]
        public IActionResult Brand()
        {
            var url = "https://localhost:7099/api/Brand/AllBrands";
            using (WebClient web = new WebClient())
            {
                string jsonStr = web.DownloadString(url);
                List<Brand> brand = JsonConvert.DeserializeObject<List<Brand>>(jsonStr);
                return View(brand);
            }
        }

        // Create Brand

        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBrand(BrandDTO brand)
        {
            var url = "https://localhost:7099/api/Brand/AddBrand";
            using (WebClient web = new WebClient())
            {
                web.Headers[HttpRequestHeader.ContentType] = "application/json";
                string jsonStr = JsonConvert.SerializeObject(brand);
                string response = web.UploadString(url, "POST", jsonStr);

                return RedirectToAction("Brand");
            }
        }

        // Update Brand
        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {

            var url = $"https://localhost:7099/api/Brand/GetUpdatedata /{id}";
            using (WebClient web = new WebClient())
            {
                string jsonStr = web.DownloadString(url);

                Brand brand = JsonConvert.DeserializeObject<Brand>(jsonStr);

                ViewBag.id = id;
                ViewBag.Name = brand.Name;
                ViewBag.Descroption = brand.Description;


                return View();
            }
        }

        // Update Brand (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateBrand(BrandDTO brand)
        {
            var url = "https://localhost:7099/api/Brand/Update";
            using (WebClient web = new WebClient())
            {
                web.Headers[HttpRequestHeader.ContentType] = "application/json";

                // Serialize the brand data to JSON
                string jsonStr = JsonConvert.SerializeObject(brand);

                // Send a PUT request to update the brand
                string response = web.UploadString(url, "PUT", jsonStr);

                // Redirect to the Brand listing page after update
                return RedirectToAction("Brand");
            }
        }

        // get Brand For Delete Data
        [HttpGet]
        public IActionResult DeleteBrand(int id)
        {

            var url = $"https://localhost:7099/api/Brand/GetUpdatedata /{id}";
            using (WebClient web = new WebClient())
            {
                string jsonStr = web.DownloadString(url);

                Brand brand = JsonConvert.DeserializeObject<Brand>(jsonStr);

                return View(brand);
            }
        }

        // Delete Brand
        [HttpPost]
        public IActionResult DeleteBrand(BrandDTO brand)
        {
            var url = $"https://localhost:7099/api/Brand/Delete/{brand.Id}";
            using (WebClient web = new WebClient())
            {
                web.UploadString(url, "DELETE", string.Empty);

                return RedirectToAction("Brand");
            }
        }

        // See All Product

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

        // Create Product

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

        // Update Product
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var url = $"https://localhost:7099/api/Products/GetUpdatedata /{id}";
            using (WebClient web = new WebClient())
            {
                string jsonStr = web.DownloadString(url);

                Product product = JsonConvert.DeserializeObject<Product>(jsonStr);

                ViewBag.id = id;
                ViewBag.Name = product.Name;
                ViewBag.Descroption = product.Description;
                ViewBag.Price = product.Price;
                ViewBag.BrandId = product.BrandId;

                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProduct(ProductDTO prod)
        {
            var url = "https://localhost:7099/api/Products/Update";
            using (WebClient web = new WebClient())
            {
                web.Headers[HttpRequestHeader.ContentType] = "application/json";

                string jsonStr = JsonConvert.SerializeObject(prod);

                string response = web.UploadString(url, "PUT", jsonStr);

                return RedirectToAction("Product");
            }
        }

        // get Product For Delete Data
        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {

            var url = $"https://localhost:7099/api/Brand/GetUpdatedata /{id}";
            using (WebClient web = new WebClient())
            {
                string jsonStr = web.DownloadString(url);

                Product product = JsonConvert.DeserializeObject<Product>(jsonStr);

                return View(product);
            }
        }

        // Delete Product
        [HttpPost]
        public IActionResult DeleteProduct(ProductDTO product)
        {
            var url = $"https://localhost:7099/api/Products/Delete/{product.Id}";
            using (WebClient web = new WebClient())
            {
                web.UploadString(url, "DELETE", string.Empty);

                return RedirectToAction("Product");
            }
        }

    }
}