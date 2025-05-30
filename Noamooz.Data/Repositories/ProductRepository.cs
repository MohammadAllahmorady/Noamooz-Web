using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noamooz.Core.Repositories;
using Noamooz.Core.Models;
using Noamooz.Core.Models.ViewModel;
using Noamooz.Data.Models;

namespace Noamooz.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        public readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context=context;
        }
        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public List<Product> GetProductByCategory(int categoryId)
        {
            return _context.Products.Where(x=> categoryId==0 || x.CategoryId==categoryId).ToList();
        }

        public List<Category> GetAllCategory()
        {
            return _context.Categories.ToList();
        }

        public List<CategoryViewModel> GetCategoryByCountProducts()
        {
            var result = from CategoryItem in _context.Categories
                join ProductItem in _context.Products
                    on CategoryItem.CategoryId equals ProductItem.CategoryId into groupItem
                orderby groupItem.Count() descending, CategoryItem.Name descending
                select new CategoryViewModel
                {
                    CategorId = CategoryItem.CategoryId,
                    CategorName = CategoryItem.Name,
                    CountProduct = groupItem.Count()
                };
            return result.ToList();
        }
    }
}
