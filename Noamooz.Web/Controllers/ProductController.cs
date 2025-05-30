using Microsoft.AspNetCore.Mvc;
using Noamooz.Core.Repositories;
using Noamooz.Core.Models.ViewModel;

namespace Noamooz.Web.Controllers
{
    public class ProductController : Controller
    {
        public int pageSize = 6;
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        public IActionResult Index()
        {
            return View(_productRepo.GetAll());
        }

        public IActionResult List(int categoryCode,int page = 1)
        {
            var result = _productRepo.GetProductByCategory(categoryCode);
        
            return View(new ProductViewModel
            {
                products = result.OrderBy(x => x.ProductId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize).ToList(),
                pagingInfo = new PagingInformation
                {
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalRecord = result.Count
                },
                CategoryCode=categoryCode

            });
        }
    }
}
