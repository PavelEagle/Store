using AutoMapper;
using System;
using System.Globalization;
using WebStore.API.Models.InputModels;
using WebStore.API.Models.OutputModels;
using WebStore.DB.Models;
using WebStore.DB.Models.Reports;

namespace WebStore.API.Configuration
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Product, ProductOutputModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Subcategory.Category.Name))
                .ForMember(dest => dest.Subcategory, opt => opt.MapFrom(src => src.Subcategory.Name));

            CreateMap<MoneyInCity, MoneyInCityOutputModel>();
            CreateMap<ProductInStore, ProductInStoreOutputModel>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Store.City.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Store.Address));

            CreateMap<DateOrderInputModel, DateOrder>()
                 .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.StartDate, "dd.MM.yyyy", CultureInfo.InvariantCulture)))
                 .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.EndDate, "dd.MM.yyyy", CultureInfo.InvariantCulture)));



        }
    }
}
