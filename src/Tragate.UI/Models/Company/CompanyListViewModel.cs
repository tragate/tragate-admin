using System.Collections.Generic;
using Newtonsoft.Json;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Response;

namespace Tragate.UI.Models.Company
{
    public class CompanyListViewModel : BaseListModel
    {
        public List<CompanyDto> CompanyList { get; set; }
        public int Status { get; set; }
        public int? CategoryGroupId { get; set; }

        public string WebSiteUrl { get; set; }
    }
}