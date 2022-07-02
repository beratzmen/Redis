using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryInMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        public ProductController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            ////1.Yol
            //if (string.IsNullOrEmpty(_memoryCache.Get<string>("Date")))
            //{
            //    ViewBag.dateCreateCache = _memoryCache.Set<string>("Date", DateTime.Now.ToString());
            //}

            //2.Yol
            //if (!_memoryCache.TryGetValue("Date", out var dateCache))
            //{
            MemoryCacheEntryOptions options = new();

            //10 saniye sonra cache den silinmesi için
            //options.AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(10);

            //10 saniye içerisinde cachedeki Date erişilirse, 10 saniye cachedeki ömrü uzayacak.
            //SlidingExpiration veriliyorsa, AbsoluteExpiration ile ayarlama da yapılmalı ve cachedeki verinin tazelendiğinden emin olunmalı.
            options.SlidingExpiration = TimeSpan.FromSeconds(10);
            options.AbsoluteExpiration = DateTime.Now.AddMinutes(1);
            //High = Cacheden asla silme, Low = Memory dolarsa sil, NeverRemove = Memory dolsa dahil silme, Normal = High ile Low arasında bir şey
            options.Priority = CacheItemPriority.Normal;

            _memoryCache.Set<string>("Date", DateTime.Now.ToString(), options);
            //}


            var product = new Models.Product
            {
                Id = 1,
                Name = "Product 1",
                Price = 5
            };

            _memoryCache.Set<Models.Product>("product:1", product);

            return View();
        }

        public IActionResult Show()
        {
            //_memoryCache.Remove("Date");

            //_memoryCache.GetOrCreate<string>("Date", entry =>
            //{
            //    return DateTime.Now.ToString();
            //});

            _memoryCache.TryGetValue("Date", out var dateCache);

            ViewBag.dateGetCache = dateCache;

            //ViewBag.dateGetCache = _memoryCache.Get<string>("Date");

            ViewBag.product = _memoryCache.Get<Models.Product>("product:1");

            return View();
        }
    }
}
