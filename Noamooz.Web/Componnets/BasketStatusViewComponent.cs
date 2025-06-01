using Microsoft.AspNetCore.Mvc;
using Noamooz.Core.Models.ViewModel;
using Noamooz.Web.Infrastructure;

namespace Noamooz.Web.Componnets
{
    public class BasketStatusViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var basket = HttpContext.Session.GetJson<List<BasketViewModel>>("ses_basket");
            if (basket == null)
                return View(0);
            else
                return View(basket.Sum(m => m.Quantity));
        }
    }
}
