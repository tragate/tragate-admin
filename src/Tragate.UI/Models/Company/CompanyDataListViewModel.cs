using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Response;

namespace Tragate.UI.Models.Company
{
    public class CompanyDataListViewModel : BaseListModel
    {
        public List<CompanyDataDto> CompanyDataList { get; set; }
        public int? Status { get; set; }
        public string WebsiteUrl { get; set; }
    }
}