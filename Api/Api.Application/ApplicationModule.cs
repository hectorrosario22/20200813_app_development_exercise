using Api.Application.AutofacModules;
using Autofac;

namespace Api.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<AutoMapperModule>();
            base.Load(builder);
        }
    }
}
