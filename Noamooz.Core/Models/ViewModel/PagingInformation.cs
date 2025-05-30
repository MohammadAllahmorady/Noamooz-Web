namespace Noamooz.Core.Models.ViewModel
{
    public class PagingInformation
    {
        public int TotalRecord { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPage => (int)Math.Ceiling((decimal)TotalRecord / PageSize);
    }
}
