using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noamooz.Core.Repositories;
using Noamooz.Core.Models;
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
    }
}
