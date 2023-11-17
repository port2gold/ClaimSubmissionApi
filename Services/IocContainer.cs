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
            builder.RegisterType<ClaimsRepository>().As<IClaimRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();


            #endregion
            #region Services
            builder.RegisterType<AuthServices>().As<IAuthServices>().InstancePerLifetimeScope();
            #endregion

            
            builder.Build();
        }
    }
}
