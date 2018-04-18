using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RedZoneRush.Common.Config;
using RedZoneRush.Logic;
using RedZoneRush.Logic.Interfaces;

namespace RedZoneRush.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public TwilioSettings TwilioSettings { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            this.TwilioSettings = configuration.GetSection(nameof(this.TwilioSettings)).Get<TwilioSettings>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // MVC
            services
                .AddMvc()
                .AddJsonOptions(o =>
                {
                    // JSON DateTime formatting as IS0 8601 UTC values...
                    o.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
                    o.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
                    o.SerializerSettings.DateFormatString = @"yyyy-MM-dd'T'HH:mm:ss.fff'Z'";
                    o.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });

            // routing options...
            services.AddRouting(o =>
            {
                o.LowercaseUrls = true;
            });

            // register Twilio configuration section...
           // services.Configure<TwilioSettings>(Configuration.GetSection("TwilioSettings"));
            services.Configure<TwilioSettings>(Configuration.GetSection(nameof(Common.Config.TwilioSettings)));

            services.AddSingleton(this.Configuration);

            // add services in the logic layer
            services.AddSingleton<IAuthService, AuthService>();

            // add services for options...
            services.AddOptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
