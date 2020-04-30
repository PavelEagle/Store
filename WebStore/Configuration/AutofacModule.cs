using Autofac;
using WebStore.API.Controllers;
using WebStore.DB.Storages;
using WebStore.Repository;

namespace WebStore.API.Configuration
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
