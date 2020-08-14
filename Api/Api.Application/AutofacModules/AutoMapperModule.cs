using Autofac;
using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Api.Application.AutofacModules
{
    public class AutoMapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var allTypes = assemblies
                .Where(d =>
                    !d.IsDynamic
                    && d.GetName().Name != nameof(AutoMapper)
                )
                .Distinct()
                .SelectMany(d => d.DefinedTypes)
                .ToArray();

            var openTypes = new[] {
                typeof(IValueResolver<,,>),
                typeof(IMemberValueResolver<,,,>),
                typeof(ITypeConverter<,>),
                typeof(IValueConverter<,>),
                typeof(IMappingAction<,>)
            };

            var types = openTypes.SelectMany(openType =>
                allTypes.Where(d =>
                    d.IsClass
                    && !d.IsAbstract
                    && ImplementsGenericInterface(d.AsType(), openType)
                )
            );

            foreach (var type in types)
            {
                builder.RegisterType(type.AsType()).InstancePerDependency();
            }

            builder.Register<IConfigurationProvider>(ctx => new MapperConfiguration(cfg => cfg.AddMaps(assemblies)));
            builder.Register<IMapper>(ctx => new Mapper(ctx.Resolve<IConfigurationProvider>(), ctx.Resolve)).InstancePerDependency();
        }

        private static bool ImplementsGenericInterface(Type type, Type interfaceType)
        {
            return IsGenericType(type, interfaceType)
                || type.GetTypeInfo().ImplementedInterfaces.Any(@interface => IsGenericType(@interface, interfaceType));
        }

        private static bool IsGenericType(Type type, Type genericType)
        {
            return type.GetTypeInfo().IsGenericType
                && type.GetGenericTypeDefinition() == genericType;
        }
    }
}
