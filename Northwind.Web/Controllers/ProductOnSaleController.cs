using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.Services.Abstraction;
using System.Threading.Tasks;

namespace Northwind.Web.Controllers
{
    public class ProductOnSaleController : Controller
    {
        private IServiceManager _serviceManajer;

        public ProductOnSaleController(IServiceManager serviceManajer)
        {
            _serviceManajer = serviceManajer;
        }

        // GET: ProductOnSaleControlles
        public async Task<ActionResult> Index()
        {
            //return View();
            var productSale = await _serviceManajer.ProductService.GetProductOneSales(false);
            return View(productSale);
        }

        // GET: ProductOnSaleControlles/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //return View();
            if (id == null)
            {
                return NotFound();
            }
            var product = await _serviceManajer.ProductService.GetProductById((int)id, false);

            return View(product);
        }

        // GET: ProductOnSaleControlles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductOnSaleControlles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductOnSaleControlles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductOnSaleControlles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductOnSaleControlles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductOnSaleControlles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
