using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.Models.Dto.Quotation;

namespace Tragate.UI.Models.Quotation
{
    public class QuotationListViewModel :BaseListModel
    {
        public List<QuotationViewModel> QuotationList { get; set; }
    }
}
