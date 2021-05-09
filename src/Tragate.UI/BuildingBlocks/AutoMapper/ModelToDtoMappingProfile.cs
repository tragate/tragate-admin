using AutoMapper;
using Tragate.UI.Models.Dto;
using Tragate.UI.Models.Company;
using Tragate.UI.Models.Category;

namespace Tragate.UI.BuildingBlocks.AutoMapper
{
    public class ModelToDtoMappingProfile : Profile
    {
        public ModelToDtoMappingProfile()
        {
            CreateMap<CompanyViewModel, CompanyDto>();
            CreateMap<CompanyDataViewModel, CompanyDataDto>();
        }
    }
}