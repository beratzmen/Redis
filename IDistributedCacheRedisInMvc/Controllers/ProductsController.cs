using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace IDistributedCacheRedisInMvc.Controllers
{
    public class ProductsController : Controller
    {
        private IDistributedCache _distributedCache;

        public ProductsController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<IActionResult> Index()
        {
            var cacheEntryOptions = new DistributedCacheEntryOptions();

            //Cache üzerinde 5 dakika durması için.
            cacheEntryOptions.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5);

            ////_distributedCache.SetString("keysss", "valuesss", cacheEntryOptions);
            //await _distributedCache.SetStringAsync("keysss", "valuesss", cacheEntryOptions);

            var product = new Models.Product
            {
                Id = 2,
                Name = "Kalem2",
                Price = 5
            };

            //Cache üzerine json olarak da kayıt edilebilir.
            string jsonProduct = JsonSerializer.Serialize(product);

            //Byte array olarak cache kayıt etmek için.
            var byteProduct = Encoding.UTF8.GetBytes(jsonProduct);

            //Json olarak kayıt etmek için
            //await _distributedCache.SetStringAsync("product:2", jsonProduct, cacheEntryOptions);

            //Byte array olarak kayıt etmek için.
            await _distributedCache.SetAsync("product:2", byteProduct, cacheEntryOptions);

            return View();
        }

        public async Task<IActionResult> Show()
        {
            ////keysss keyine ait value görüntülenir.
            //string name = _distributedCache.GetString("keysss");

            var jsonProduct = await _distributedCache.GetStringAsync("product:2");

            var product = JsonSerializer.Deserialize<Models.Product>(jsonProduct);

            //Byte array'in cache üzerinden çekilmesi için.
            var byteProduct = _distributedCache.Get("product:2");
            var jsonProductToByteArray = Encoding.UTF8.GetString(byteProduct);

            //ViewBag.Name = name;
            ViewBag.Product = jsonProductToByteArray;

            return View();
        }

        public IActionResult Delete()
        {
            //Keysss keyindeki value silinir.
            _distributedCache.Remove("keysss");

            return View();
        }
    }
}
