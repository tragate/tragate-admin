using AutoMapper;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.Category;
using Tragate.UI.Models.User;
using System.Collections.Generic;
using Tragate.UI.Models.Dto.Quotation;
using Tragate.UI.Models.Quotation;

namespace Tragate.UI.BuildingBlocks.AutoMapper
{
    public class DtoToModelMappingProfile : Profile
    {
        public DtoToModelMappingProfile()
        {
            CreateMap<CompanyDto, CompanyViewModel>()
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.User.Email));
            CreateMap<CompanyDto, CompanyDetailViewModel>();
            CreateMap<CompanyDataDto, CompanyDataViewModel>();
            CreateMap<CategoryDto, CategoryViewModel>();
            CreateMap<UserDto, UserViewModel>();
            CreateMap<CompanyAdminDto, CompanyAdminViewModel>();
            CreateMap<CompanyTaskDto, CompanyTaskViewModel>();
            CreateMap<CompanyProductDto, CompanyProductViewModel>();
            CreateMap<UserCompanyDto, UserCompanyViewModel>();
            CreateMap<CompanyMembershipDto, CompanyMembershipViewModel>();
            CreateMap<UserProductDto, UserProductViewModel>();
            CreateMap<UserTaskDto, UserTaskViewModel>();
            CreateMap<UserNoteDto, UserNoteViewModel>();
            CreateMap<CompanyMembershipDto, CompanyMembershipViewModel>();
            CreateMap<DashboardDto, DashboardViewModel>();
            CreateMap<QuotationDto, QuotationViewModel>();
            CreateMap<QuotationDto, QuotationDetailViewModel>();
            CreateMap<QuotationHistoryDto, QuotationHistoryViewModel>();
            CreateMap<QuotationProductDto, QuotationProductViewModel>();
            CreateMap<QuotationDto, QuotationCompanyBuyerViewModel>()
                .ForMember(x => x.BuyerUser, opt => opt.MapFrom(x => x.BuyerUser.FullName))
                .ForMember(x => x.SellerCompany, opt => opt.MapFrom(x => x.SellerCompany.FullName))
                .ForMember(x => x.SellerCompanyProfileImage, opt => opt.MapFrom(x => x.SellerCompany.ProfileImagePath))
                .ForMember(x => x.SellerUser, opt => opt.MapFrom(x => x.SellerUser.FullName));

            CreateMap<QuotationDto, QuotationCompanySellerViewModel>()
                .ForMember(x => x.SellerUser, opt => opt.MapFrom(x => x.SellerUser.FullName))
                .ForMember(x => x.BuyerUser, opt => opt.MapFrom(x => x.BuyerUser.FullName))
                .ForMember(x => x.BuyerUserProfileImage, opt => opt.MapFrom(x => x.BuyerUser.ProfileImagePath));

            CreateMap<QuotationDto, QuotationUserBuyerViewModel>()
                .ForMember(x => x.SellerUser, opt => opt.MapFrom(x => x.SellerUser.FullName))
                .ForMember(x => x.SellerCompany, opt => opt.MapFrom(x => x.SellerCompany.FullName))
                .ForMember(x => x.SellerCompanyProfileImage, opt => opt.MapFrom(x => x.SellerCompany.ProfileImagePath));

            CreateMap<QuotationDto, QuotationUserSellerViewModel>()
                .ForMember(x => x.SellerCompany, opt => opt.MapFrom(x => x.SellerCompany.FullName))
                .ForMember(x => x.BuyerUserProfileImage, opt => opt.MapFrom(x => x.BuyerUser.ProfileImagePath))
                .ForMember(x => x.BuyerUser, opt => opt.MapFrom(x => x.BuyerUser.FullName))
                .ForMember(x => x.BuyerUserCountry, opt => opt.MapFrom(x => x.BuyerUser.Country))
                .ForMember(x => x.BuyerUserEmail, opt => opt.MapFrom(x => x.BuyerUser.Email));
        }
    }
}