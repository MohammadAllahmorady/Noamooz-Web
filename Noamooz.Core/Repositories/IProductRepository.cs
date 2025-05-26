using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noamooz.Core.Models;
namespace Noamooz.Core.Repositories
{
    public interface IProductRepository
    {
      List<Product> GetAll();
    }
}
