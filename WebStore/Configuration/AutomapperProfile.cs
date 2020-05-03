using AutoMapper;
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
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Store.Address))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Product.Manufacturer))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Product.Model))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString("dd/MM/yyyy")));
            CreateMap<MoneyInCity, MoneyInCityOutputModel>();
            CreateMap<CountProductInCategory, CountProductInCategoryOutputModel>();
        }
    }
}
