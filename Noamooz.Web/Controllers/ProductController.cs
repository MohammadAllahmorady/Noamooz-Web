using Microsoft.AspNetCore.Mvc;
using Noamooz.Core.Repositories;

namespace Noamooz.Web.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        public IActionResult Index()
        {
            return View(_productRepo.GetAll());
        }

        public IActionResult List()
        {
            return View(_productRepo.GetAll());
        }
    }
}
