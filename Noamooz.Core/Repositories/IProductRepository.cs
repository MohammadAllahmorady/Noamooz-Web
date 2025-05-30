using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noamooz.Core.Models;
using Noamooz.Core.Models.ViewModel;
namespace Noamooz.Core.Repositories
{
    public interface IProductRepository
    {
      List<Product> GetAll();
      List<Product> GetProductByCategory(int categoryId);
      public List<Category> GetAllCategory();
      public List<CategoryViewModel> GetCategoryByCountProducts();
    }
}
