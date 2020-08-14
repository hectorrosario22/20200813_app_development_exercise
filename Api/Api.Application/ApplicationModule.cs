using Api.Application.AutofacModules;
using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace Api.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<AutoMapperModule>();
            builder.AddMediatR(ThisAssembly);

            base.Load(builder);
        }
    }
}
