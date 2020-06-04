using AutoMapper;
using System;
using System.Globalization;
using WebStore.API.Models.InputModels;
using WebStore.API.Models.OutputModels;
using WebStore.DB.Models;

namespace WebStore.API.Configuration
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            // Mapping for product CRUD
            CreateMap<Product, ProductOutputModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Subcategory.Category.Name))
                .ForMember(dest => dest.Subcategory, opt => opt.MapFrom(src => src.Subcategory.Name));
            CreateMap<ProductInputModel, Product>()
               .ForMember(dest => dest.Subcategory, opt => opt.MapFrom(src => new Subcategory { Id = src.SubcategoryId }));

            // Mapping for reports
            CreateMap<Product, ShortProductOutputModel>();
            CreateMap<ProductInStore, ProductInStoreOutputModel>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Store.City.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Store.Address));
            CreateMap<OrderInfo, OrderInfoOutputModel>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Store.City.Name))
                .ForMember(dest => dest.StoreAddress, opt => opt.MapFrom(src => src.Store.Address))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString("dd/MM/yyyy")));
            CreateMap<City, MoneyInCityOutputModel>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.TotalMoney));
            CreateMap<Category, CountProductInCategoryOutputModel>()
                 .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Name));
            CreateMap<SalesByWorldAndRF, SalesByWorldAndRFOutputModel> ();
            CreateMap<InputDateModel, DateModel>()
                .ForMember(dest => dest.startDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.startDate, "ddMMyyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.endDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.endDate, "ddMMyyyy", CultureInfo.InvariantCulture)));
        }
    }
}

