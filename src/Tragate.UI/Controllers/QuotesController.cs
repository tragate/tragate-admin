using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tragate.UI.Common.Enums;
using Tragate.UI.Models.Quotation;
using Tragate.UI.Models.User;
using Tragate.UI.Service.Quotation;

namespace Tragate.UI.Controllers
{
    [TragateAuthorize]
    [Route("quotes")]
    public class QuotesController : Controller
    {
        private readonly IQuotationService _quotationService;
        private readonly IMapper _mapper;

        public QuotesController(IQuotationService quotationService, IMapper mapper)
        {
            _quotationService = quotationService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("list-all")]
        public IActionResult Index([FromQuery] string searchKey, [FromQuery] int page = 1, [FromQuery] int quoteStatus = 0)
        {
            return View(ReturnQuotationListModel(searchKey, page, quoteStatus));
        }

        private QuotationListViewModel ReturnQuotationListModel(string searchKey, int page = 1, int quoteStatus = 0)
        {
            var result = _quotationService.GetQuotationList(page, 10, quoteStatus, null, null, null);
            QuotationListViewModel model = new QuotationListViewModel()
            {
                PageNumber = page,
                PageSize = Convert.ToInt32(Math.Ceiling(result.QuotationResponse.TotalCount / 10.0)),
                TotalCount = result.QuotationResponse.TotalCount,
                QuotationList = _mapper.Map<List<QuotationViewModel>>(result.QuotationResponse.QuotationList)
            };
            return model;
        }
        [HttpGet]
        [Route("quote-details/{id:int}")]
        public IActionResult Details(int id)
        {
            var result = _quotationService.GetQuotationById(id);
            var products = _quotationService.GetQuotationProducts(id);
            var histories = _quotationService.GetQuotationHistories(id);
            if (result == null)
            {
                return NotFound();
            }

            var model = new QuotationDetailViewModel();
            model = _mapper.Map<QuotationDetailViewModel>(result.Quotation);
            model.QuotationHistories = _mapper.Map<List<QuotationHistoryViewModel>>(histories.QuotationHistoryList);
            model.QuotationProductList = _mapper.Map<List<QuotationProductViewModel>>(products.QuotationProductsList);

            return PartialView(model);
        }
    }
}