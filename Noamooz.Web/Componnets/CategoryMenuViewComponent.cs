using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noamooz.Core.Repositories;
using Noamooz.Data.Repository;
using Noamooz.Core.Models.ViewModel;

namespace Noamooz.Web.Componnets
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly IProductRepository _productRepository;
        public CategoryMenuViewComponent(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.CurrentCategory = RouteData?.Values["categoryCode"];
            var listCategory = _productRepository.GetAllCategory();
            List<CategoryViewModel> result = new List<CategoryViewModel>();
            for (int i = 0; i < listCategory.Count; i++)
            {
                CategoryViewModel item = new CategoryViewModel();
                result = _productRepository.GetCategoryByCountProducts();
            }
            return View(result);
        }
    }
}
