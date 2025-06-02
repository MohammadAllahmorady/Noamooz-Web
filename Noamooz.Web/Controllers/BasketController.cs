using Microsoft.AspNetCore.Mvc;
using Noamooz.Core.Models;
using Noamooz.Core.Models.ViewModel;
using Noamooz.Core.Repositories;
using Noamooz.Web.Infrastructure;

namespace Noamooz.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProductRepository _context;

        public BasketController(IProductRepository context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(GetBasketSession());
        }

        public IActionResult AddToBasket(int productId)
        {
            var item = _context.GetItemProduct(productId);
            if (item != null)
            {
                SaveInSession(item);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromBasket(int productid)
        {
            var item = _context.GetItemProduct(productid);

            if (item != null)
            {
                DeleteFromSession(item);
            }
            return RedirectToAction("Index");
        }
        private void SaveInSession(Product item)
        {
            var basket = GetBasketSession();
            int index = basket.FindIndex(x => x.Product.ProductId == item.ProductId);
            if (index != -1)
            {
                basket[index].Quantity += 1;
            }
            else
            {
                basket.Add(new BasketViewModel
                {
                    Product = item,
                    Quantity = 1
                });
            }
            HttpContext.Session.SetJson("ses_basket", basket);
        }

        private void DeleteFromSession(Product item)
        {
            var basket = GetBasketSession();
            int index = basket.FindIndex(x => x.Product.ProductId == item.ProductId);
            if (index != -1)
            {
                basket.RemoveAt(index);
            }
            HttpContext.Session.SetJson("ses_basket", basket);
        }

        private List<BasketViewModel> GetBasketSession()
        {
            var result = HttpContext.Session.GetJson<List<BasketViewModel>>("ses_basket");
            if (result == null)
            {
                return new List<BasketViewModel>();
            }

            return result;
        }
    }
}
