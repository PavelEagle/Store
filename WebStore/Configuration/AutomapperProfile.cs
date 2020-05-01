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

            CreateMap<OrderInfo, OrderInfoOutputModel>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Store.City.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Store.Address))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Product.Manufacturer))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Product.Model))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString("dd/MM/yyyy")));

            CreateMap<CountProductInCategory, CountProductInCategoryOutputModel>();

            CreateMap<Product, ShortProductOutputModel>();

        }
    }
}
