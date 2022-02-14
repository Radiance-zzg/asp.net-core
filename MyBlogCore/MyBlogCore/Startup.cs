using Autofac;
using Blog.Core.Extensions.ServiceExtensions;
using Blog.Core.Model;
using Hangfire;
using Hangfire.Dashboard.Dark;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyBlogCore.AutofacConfig;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogCore
{
    public class Startup
    {
        protected IHostEnvironment _basehostEnvironment { get; }
        private JWTTokenOptions _jWTTokenOptions { set; get; }
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            _basehostEnvironment = hostEnvironment;
            _jWTTokenOptions = Configuration.GetSection("JWTTokenOptions").Get<JWTTokenOptions>(); ;
        }


        private readonly string apiName = "MyBlog.Core";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSqlsugarSetup(Configuration);
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = $"{apiName} 接口文档——dotnetcore 5.0",
                    Description = $"{apiName} HTTP API V1",
                    License = new OpenApiLicense { Name = apiName }

                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                options.OrderActionsBy(o => o.RelativePath);
                options.IncludeXmlComments(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "MyBlogCore.xml"), true);
                options.IncludeXmlComments(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Blog.Core.Model.xml"), true);
                options.IncludeXmlComments(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Blog.Core.Entities.xml"), true);
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidAudience = _jWTTokenOptions.Audience,
                            ValidIssuer = _jWTTokenOptions.IisUer,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWTTokenOptions.SecretKey)),
                            LifetimeValidator = (b, e, s, v) =>
                            {
                                DateTime expires;
                                if (DateTime.TryParse(e.ToString(), out expires) && expires >= DateTime.Now)
                                {
                                    return true;
                                }
                                return false;
                            }
                        };

                    });
            services.AddControllers().AddControllersAsServices();
            services.AddHangfire(configuration => configuration
                                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                                .UseSimpleAssemblyNameTypeSerializer()
                                .UseRecommendedSerializerSettings()
                                .UseSqlServerStorage(Configuration.GetConnectionString("SqlServer"), new SqlServerStorageOptions
                                {
                                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                                    QueuePollInterval = TimeSpan.Zero,
                                    UseRecommendedIsolationLevel = false,
                                    DisableGlobalLocks = true
                                })
                                .UseDarkDashboard()
                                ); ;
            services.AddHangfireServer();
            services.AddRazorPages();
        }
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<ConfigureAutofac>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
                //app.UseHangfireDashboard();
                //app.UseDarkDashboard();
                GlobalConfiguration.Configuration.UseDarkDashboard();
                //app.UseSwaggerUI(optins => { optins.  });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();
            });
        }
    }
}
