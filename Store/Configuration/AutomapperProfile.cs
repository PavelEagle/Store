using AutoMapper;
using Store.API.Models.OutputModels;
using Store.DB.Models;

namespace Store.API.Configuration
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Product, ProductOutputModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(scr => scr.Subcategory.Category.Name))
                .ForMember(dest => dest.Subcategory, opt => opt.MapFrom(scr => scr.Subcategory.Name));

        }
    }
}
