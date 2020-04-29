using Autofac;
using Store.API.Controllers;
using Store.DB.Storages;
using Store.Repository;

namespace Store.API.Configuration
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductController>().As<IProductController>();
            builder.RegisterType<ProductStorage>().As<IProductStorage>();
            builder.RegisterType<StoreStorage>().As<IStoreStorage>();
            builder.RegisterType<StoreController>().As<IStoreController>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ReportStorage>().As<IReportStorage>();
            builder.RegisterType<ReportRepository>().As<IReportRepository>();
        }
    }
}
