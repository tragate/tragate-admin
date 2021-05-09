using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tragate.UI.Models.Response.Quotation;

namespace Tragate.UI.Service.Quotation
{
    public interface IQuotationService
    {
        QuotationResponseMessage GetQuotationList(int page, int pageSize, int quoteStatusId, int? orderStatusId,
            int? sellerCompanyId, int? buyerUserId);

        QuotationViewResponse GetQuotationById(int quoteId);
        QuotationProductResponse GetQuotationProducts(int quoteId);

        QuotationHistoryResponse GetQuotationHistories(int quoteId);
    }
}
