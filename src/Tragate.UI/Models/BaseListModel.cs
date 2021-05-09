namespace Tragate.UI.Models
{
    public class BaseListModel
    {
        public int TotalCount { get; set; }
        public string SearchKey { get; set; }
        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}