using System.Runtime.InteropServices;

namespace WebStore.API.Models.InputModels
{
    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int MaxPages { get; set; }
    }
}