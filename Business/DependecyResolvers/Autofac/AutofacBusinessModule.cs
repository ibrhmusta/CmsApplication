using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CampaignDayManager>().As<ICampaignDayService>().SingleInstance();
            builder.RegisterType<EfCampaignDayDal>().As<ICampaignDayDal>().SingleInstance();

            builder.RegisterType<CampaignHourManager>().As<ICampaignHourService>().SingleInstance();
            builder.RegisterType<EfCampaignHourDal>().As<ICampaignHourDal>().SingleInstance();

            builder.RegisterType<CampaignManager>().As<ICampaignService>().SingleInstance();
            builder.RegisterType<EfCampaignDal>().As<ICampaignDal>().SingleInstance();

            builder.RegisterType<CampaignTypeManager>().As<ICampaignTypeService>().SingleInstance();
            builder.RegisterType<EfCampaignTypeDal>().As<ICampaignTypeDal>().SingleInstance();

            builder.RegisterType<CompanyManager>().As<ICompanyService>().SingleInstance();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<TransactionManager>().As<ITransactionService>().SingleInstance();
            builder.RegisterType<EfTransactionDal>().As<ITransactionDal>().SingleInstance();
   
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
