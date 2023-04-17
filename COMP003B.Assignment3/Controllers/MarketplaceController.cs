using COMP003B.Assignment3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment3.Controllers
{
    public class MarketplaceController : Controller
    {
        private static List<MarketPrice> marketItem = new List<MarketPrice>();
        // GET: MarketplaceController
        [HttpGet]
        public ActionResult Index()
        {
            return View(marketItem);
        }

        // GET: MarketplaceController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarketplaceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarketPrice marketPrice)
        {
            if (ModelState.IsValid)
            {
                if (!marketItem.Any(i => i.Id == marketPrice.Id))
                {
                    marketItem.Add(marketPrice);
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: MarketplaceController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marketPrice = marketItem.FirstOrDefault(i => i.Id == id);

            if (marketPrice == null)
            {
                return NotFound();
            }
            return View(marketPrice);
        }


        // POST: MarketplaceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MarketPrice marketPrice)
        {
            if (id != marketPrice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var marketSell = marketItem.FirstOrDefault(i => i.Id == marketPrice.Id);

                if (marketSell != null)
                {
                    marketSell.Name = marketPrice.Name;
                    marketSell.Price = marketPrice.Price;
                }

                return RedirectToAction(nameof(Index));
            }
            return View(marketPrice);
        }

        // GET: MarketplaceController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marketPrice = marketItem.FirstOrDefault(i => i.Id == id);

            if (marketPrice == null)
            {
                return NotFound();
            }
            return View(marketPrice);
        }

        // POST: MarketplaceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletion(int id)
        {
            var marketPrice = marketItem.FirstOrDefault(i => i.Id == id);
            if (marketPrice != null)
            {
                marketItem.Remove(marketItem);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
