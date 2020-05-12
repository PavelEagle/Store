using Autofac;
using WebStore.API.Controllers;
using WebStore.Controllers;
using WebStore.Core;
using WebStore.DB.Storages;
using WebStore.Repository.Repositories;

namespace WebStore.API.Configuration
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductController>().As<IProductController>();
            builder.RegisterType<ProductStorage>().As<IProductStorage>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ReportStorage>().As<IReportStorage>();
            builder.RegisterType<ReportRepository>().As<IReportRepository>();
            builder.RegisterType<ReportController>().As<IReportController>();
            builder.RegisterType<OrderStorage>().As<IOrderStorage>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<OrderController>().As<IOrderController>();
            builder.RegisterType<BaseStorage>().As<IBaseStorage>();
            builder.RegisterType<HomeController>().As<IHomeController>();
        }
    }
}
