using CqrsDemo.Api.Users;
using CqrsDemo.Application.CQRS;
using CqrsDemo.Host.CQRS;
using CqrsDemo.Infrastructure.CQRS;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace CqrsDemo.Host.Di
{
    public class DiBootstraper
    {
        private readonly Container _ioc;

        public DiBootstraper()
        {
            _ioc = new Container();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddApplicationPart(typeof(UsersController).Assembly);


            _ioc.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(_ioc));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(_ioc));

            services.EnableSimpleInjectorCrossWiring(_ioc);
            services.UseSimpleInjectorAspNetRequestScoping(_ioc);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            RegisterTypes(app);

            _ioc.Verify();

            app.UseMvc();
        }

        private void RegisterTypes(IApplicationBuilder app)
        {
            // Add application presentation components:
            _ioc.RegisterMvcControllers(app);
            _ioc.RegisterMvcViewComponents(app);

            // Add CQRS services. 

            _ioc.Register(typeof(ICommandHandler<>), typeof(ICommandHandler<>).Assembly);
            _ioc.Register(typeof(ICommandHandler<,>), typeof(ICommandHandler<,>).Assembly);

            _ioc.Register<ICommandDispatcher, SinmpleInjectorCommandDispatcher>();
            _ioc.Register<ICommandHandlerResolver, SimpleInjectorCommandHandlerResolver>();

            // Allow Simple Injector to resolve services from ASP.NET Core.
            _ioc.AutoCrossWireAspNetComponents(app);
        }
    }
}