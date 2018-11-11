using Autofac;
using CM.Services.Wallet.Views.Concrete.Domain.Services;
using CM.Services.Wallet.Views.Concrete.Presentation.Mappers;
using CM.Services.Wallet.Views.Contract.Domain.Services;
using CM.Shared.Kernel.Application.Interfaces;
using CM.Shared.Kernel.Application.Interfaces.Repository;
using CM.Shared.Kernel.Application.Repository;
using CM.Shared.Kernel.Others.Redis;
using System.Reflection;
using Module = Autofac.Module;

namespace CM.Services.Wallet.Views.Concrete
{
    public class ConcreteAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(UserMapper).GetTypeInfo().Assembly)
                .AsImplementedInterfaces()
                .AsClosedTypesOf(typeof(IMapper<,>));

            builder.RegisterType<UserService>()
                .As<IUserService>();
        }
    }
}