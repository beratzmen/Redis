using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

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

            //_distributedCache.SetString("keysss", "valuesss", cacheEntryOptions);
            await _distributedCache.SetStringAsync("keysss", "valuesss", cacheEntryOptions);

            return View();
        }

        public IActionResult Show()
        {
            //keysss keyine ait value görüntülenir.
            string name = _distributedCache.GetString("keysss");

            ViewBag.Name = name;

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
