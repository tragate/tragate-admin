using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Tragate.UI.Models.Company
{
    public class CompanyAdminListViewModel :BaseListModel
    {
        public List<CompanyAdminViewModel> CompanyAdminList  { get; set; }

        public int CompanyId { get; set; }
    }
}