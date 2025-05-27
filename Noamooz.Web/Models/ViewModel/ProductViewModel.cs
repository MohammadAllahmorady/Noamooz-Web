using Microsoft.Graph.Models;
using Noamooz.Core.Models;

namespace Noamooz.Web.Models.ViewModel
{
    public class ProductViewModel
    {
        public List<Product> products { get; set; }
        public PagingInformation pagingInfo { get; set; }

    }
}
