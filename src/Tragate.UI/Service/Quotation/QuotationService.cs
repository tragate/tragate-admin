using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Models.Response;
using Tragate.UI.Models.Response.Quotation;

namespace Tragate.UI.Service.Quotation
{
    public class QuotationService : IQuotationService
    {
        private readonly IRestClient _restClient;
        private readonly ConfigSettings _settings;

        public QuotationService(IRestClient restClient, IOptionsSnapshot<ConfigSettings> settings)
        {
            _restClient = restClient;
            _settings = settings.Value;
        }

        public QuotationResponseMessage GetQuotationList(int page, int pageSize, int quoteStatusId, int? orderStatusId, int? sellerCompanyId,
            int? buyerUserId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"?quoteStatus={quoteStatusId}");

            if (orderStatusId.HasValue)
                sb.Append($"&orderStatus={orderStatusId}");

            if (sellerCompanyId.HasValue)
                sb.Append($"&sellerCompanyId={sellerCompanyId}");

            if (buyerUserId.HasValue)
                sb.Append($"&buyerUserId={buyerUserId}");

            var response = _restClient.Get<QuotationResponseMessage>($"{_settings.ApiUrl}/{string.Format(API.Quotation.GetQuotationList, page, pageSize, sb.ToString())}");
            return response;
        }

        public QuotationViewResponse GetQuotationById(int quoteId)
        {
            var response = _restClient.Get<QuotationViewResponse>($"{_settings.ApiUrl}/{string.Format(API.Quotation.GetQuotationById, quoteId)}");
            return response;
        }

        public QuotationProductResponse GetQuotationProducts(int quoteId)
        {
            var response = _restClient.Get<QuotationProductResponse>($"{_settings.ApiUrl}/{string.Format(API.Quotation.GetQuotationProducts, quoteId)}");
            return response;
        }

        public QuotationHistoryResponse GetQuotationHistories(int quoteId)
        {
            var response = _restClient.Get<QuotationHistoryResponse>($"{_settings.ApiUrl}/{string.Format(API.Quotation.GetQuotationHistories, quoteId)}");
            return response;
        }
    }
}
