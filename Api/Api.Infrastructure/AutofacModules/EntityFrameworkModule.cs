using Api.Infrastructure.Persistence;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Api.Infrastructure.AutofacModules
{
    public class EntityFrameworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            RegisterContext<ApiDbContext>(builder);
        }

        private void RegisterContext<TContext>(ContainerBuilder builder) where TContext : DbContext
        {
            builder.Register(context =>
            {
                var serviceProvider = context.Resolve<IServiceProvider>();
                var configuration = context.Resolve<IConfiguration>();

                var dbContextOptions = new DbContextOptions<TContext>(new Dictionary<Type, IDbContextOptionsExtension>());
                var optionsBuilder = new DbContextOptionsBuilder<TContext>(dbContextOptions)
                    .UseApplicationServiceProvider(serviceProvider)
                    .UseSqlServer(configuration.GetConnectionString("ApiConnection"));

                return optionsBuilder.Options;
            }).As<DbContextOptions<TContext>>()
            .InstancePerLifetimeScope();

            builder.Register(context => context.Resolve<DbContextOptions<TContext>>())
                .As<DbContextOptions>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TContext>()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
