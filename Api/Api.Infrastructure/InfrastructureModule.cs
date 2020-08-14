using Api.Infrastructure.AutofacModules;
using Autofac;

namespace Api.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<EntityFrameworkModule>();
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(d => d.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
