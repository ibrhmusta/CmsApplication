using System.Reflection;
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
using Module = Autofac.Module;

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

            builder.RegisterType<CampaignRewardManager>().As<ICampaignRewardService>().SingleInstance();
            builder.RegisterType<EfCampaignRewardDal>().As<ICampaignRewardDal>().SingleInstance();

            builder.RegisterType<CampaignRewardTypeManager>().As<ICampaignRewardTypeService>().SingleInstance();
            builder.RegisterType<EfCampaignRewardTypeDal>().As<ICampaignRewardTypeDal>().SingleInstance();

            builder.RegisterType<CampaignRuleManager>().As<ICampaignRuleService>().SingleInstance();
            builder.RegisterType<EfCampaignRuleDal>().As<ICampaignRuleDal>().SingleInstance();

            builder.RegisterType<CampaignRuleTypeManager>().As<ICampaignRuleTypeService>().SingleInstance();
            builder.RegisterType<EfCampaignRuleTypeDal>().As<ICampaignRuleTypeDal>().SingleInstance();

            builder.RegisterType<CampaignTypeManager>().As<ICampaignTypeService>().SingleInstance();
            builder.RegisterType<EfCampaignTypeDal>().As<ICampaignTypeDal>().SingleInstance();

            builder.RegisterType<CompanyManager>().As<ICompanyService>().SingleInstance();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();

            builder.RegisterType<TransactionManager>().As<ITransactionService>().SingleInstance();
            builder.RegisterType<EfTransactionDal>().As<ITransactionDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();

            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
