using CM.Services.Wallet.Views.Concrete;
using CM.Services.Wallet.Views.Concrete.Application.QueryHandlers;
using CM.Services.Wallet.Views.Concrete.Application.Validators;
using CM.Services.Wallet.Views.Infrastracture;
using CM.Services.Wallet.Views.Infrastracture.Contexts;
using CM.Shared.Web;
using CM.Shared.Web.Others.FluentValidation;
using CM.Shared.Web.Others.Kong;
using CM.Shared.Web.Others.Postgres;
using CM.Shared.Web.Others.Redis;
using CM.Shared.Web.Others.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CM.Services.Wallet.Views.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppSettings = Configuration.Get<AppSettings>();
        }

        public IConfiguration Configuration { get; }

        public AppSettings AppSettings { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .Initialize<AppSettings>(Configuration, AppSettings.Global.WalletViews)
                .IncludeCors(AppSettings.Global.Web.HttpsUrl)
                .IncludeAuthenticationForAPI(AppSettings.Global.WalletViews.Name, AppSettings.Global.Identity.LocalUrl)
                .IncludePostgres<ApplicationContext>(AppSettings.Global.Postgres, AppSettings.Local.Postgres, true)
                .IncludeKong(AppSettings.Global.Kong, AppSettings.Local.Kong, AppSettings.Global.WalletViews)
                .IncludeKafka(AppSettings.Global.Kafka, AppSettings.Local.Kafka)
                .IncludeRedis(AppSettings.Global.Redis)
                .IncludeBus(typeof(GetUserListHandler))
                .IncludeSwagger(AppSettings.Local.Swagger, AppSettings.Global.Identity.HttpsUrl)
                .AddMvc()
                .IncludeFluentValidation(typeof(GetUserQueryValidator))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            return services.RegisterModules(new InfrastractureAutofacModule(), new ConcreteAutofacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCorsForCM()
                .UseSwaggerForCM(AppSettings.Local.Swagger)
                .UseAuthenticationForCM()
                .UseResponseWrapperForCM()
                .UseHttpsRedirection()
                .UseMvc();
        }
    }
}
