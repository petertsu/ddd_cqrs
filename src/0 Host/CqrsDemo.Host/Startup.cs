using System;
using System.Linq;
using CqrsDemo.Api.Users;
using CqrsDemo.Application.CQRS;
using CqrsDemo.Host.CQRS;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace CqrsDemo.Host
{
    public class Startup
    {
        private readonly Container _ioc = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddApplicationPart(typeof(UsersController).Assembly);

            IntegrateSimpleInjector(services);
        }

        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            _ioc.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(_ioc));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(_ioc));

            services.EnableSimpleInjectorCrossWiring(_ioc);
            services.UseSimpleInjectorAspNetRequestScoping(_ioc);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeContainer(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            _ioc.Verify();

            app.UseMvc();

        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            // Add application presentation components:
            _ioc.RegisterMvcControllers(app);
            _ioc.RegisterMvcViewComponents(app);

            // Add CQRS services. 
            
            _ioc.Register(typeof(ICommandHandler<>), typeof(ICommandHandler<>).Assembly);
            _ioc.Register<ICommandDispatcher, CommandDispatcher>();
            _ioc.Register<ICommandHandlerResolver, CommandHandlerResolver>();

            // Allow Simple Injector to resolve services from ASP.NET Core.
            _ioc.AutoCrossWireAspNetComponents(app);
        }
    }
}

