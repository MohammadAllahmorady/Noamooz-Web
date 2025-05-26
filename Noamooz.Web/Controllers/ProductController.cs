using Microsoft.AspNetCore.Mvc;
using Noamooz.Core.Repositories;

namespace Noamooz.Web.Controllers
{
    public class ProductController : Controller
    {
        public int pageSize = 2;
        public readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        public IActionResult Index()
        {
            return View(_productRepo.GetAll());
        }

        public IActionResult List(int page = 1)
        {
            return View(_productRepo.GetAll().OrderBy(x=> x.ProductId).Skip((page-1)*pageSize).Take(pageSize).ToList());
        }
    }
}
