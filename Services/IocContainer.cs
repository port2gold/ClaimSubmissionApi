using Autofac;
using ClaimSubmissionApi.Repository;
using ClaimSubmissionApi.Repository.Interfaces;
using ClaimSubmissionApi.Services.Interfaces;

namespace ClaimSubmissionApi.Services
{
    public static class IocContainer
    {
        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();
            #region Repository
            builder.RegisterType<IClaimRepository>().As<ClaimsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<IUserRepository>().As<UserRepository>().InstancePerLifetimeScope();


            #endregion
            #region Services
            builder.RegisterType<IAuthServices>().As<AuthServices>().InstancePerLifetimeScope();
            #endregion
            builder.Build();
        }
    }
}
