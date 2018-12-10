using CqrsDemo.Api.Users;
using CqrsDemo.Host.Di;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsDemo.Host
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly DiBootstraper _diBootstraper;
        public Startup(IConfiguration configuration, DiBootstraper diBootstraper)
        {
            Configuration = configuration;
            _diBootstraper = diBootstraper;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _diBootstraper.ConfigureServices(services);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            _diBootstraper.Configure(app,env);
        }
    }
}

