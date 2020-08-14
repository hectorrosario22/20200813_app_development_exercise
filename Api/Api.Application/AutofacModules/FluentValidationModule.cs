using Api.Application.Common.Behaviours;
using Autofac;
using FluentValidation;
using MediatR;
using System.Linq;
using System.Reflection;

namespace Api.Application.AutofacModules
{
    public class FluentValidationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterGeneric(typeof(RequestValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>)).InstancePerLifetimeScope();

            var validatorType = typeof(IValidator<>);
            var validatorTypes = Assembly.GetExecutingAssembly()
                .GetExportedTypes()
                .Where(d =>
                    d.GetInterfaces().Any(i =>
                        i.IsGenericType
                        && i.GetGenericTypeDefinition() == validatorType
                    )
                )
                .ToArray();

            foreach (var validator in validatorTypes)
            {
                var requestType = validator
                    .GetInterfaces()
                    .Where(d =>
                        d.IsGenericType
                        && d.GetGenericTypeDefinition() == typeof(IValidator<>)
                    )
                    .Select(d => d.GetGenericArguments()[0])
                    .First();

                var validatorInterface = validatorType.MakeGenericType(requestType);
                builder.RegisterType(validator).As(validatorInterface).InstancePerLifetimeScope();
            }
        }
    }
}
