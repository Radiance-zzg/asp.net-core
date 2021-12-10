using Autofac;
using Blog.Core.Extensions.ServiceExtensions;
using Blog.Core.Model;
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
        protected IHostEnvironment _hostEnvironment { get; }
        private JWTTokenOptions _jWTTokenOptions { set; get; }
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            _hostEnvironment = hostEnvironment;
           
            _jWTTokenOptions = Configuration.GetSection("JWTTokenOptions").Get<JWTTokenOptions>(); ;
        }


        private readonly string apiName = "MyBlog.Core";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSqlsugarSetup(Configuration);
            services.AddControllers().AddControllersAsServices();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = $"{apiName} �ӿ��ĵ�����dotnetcore 5.0",
                    Description = $"{apiName} HTTP API V1",
                    //Contact = new OpenApiContact { Name = apiName, Email = "2334344234@163.com" },//�༭��ϵ��ʽ
                    License = new OpenApiLicense { Name = apiName }//�༭���֤
                });
                options.OrderActionsBy(o => o.RelativePath);
                options.IncludeXmlComments(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "MyBlogCore.xml"), true); // �ѽӿ��ĵ���·�����ý�ȥ���ڶ���������ʾ�����Ƿ���������Controller��ע�����ɡ��ڶ����������Բ��ӡ�
                options.IncludeXmlComments(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Blog.Core.Model.xml"), true);
                options.IncludeXmlComments(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Blog.Core.Entities.xml"), true);
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                        {
                            ValidateIssuer = true,//��֤�䷢��
                            ValidateAudience = true,//��֤������
                            ValidateLifetime = true,//��֤��Ч��
                            ValidateIssuerSigningKey = true,//��֤��Կ
                            ValidAudience = _jWTTokenOptions.Audience,
                            ValidIssuer = _jWTTokenOptions.IisUer,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWTTokenOptions.SecretKey)),
                            //����չ��֤��Ϊ��ί��
                            AudienceValidator = (m, s, n) => {

                                return true;
                            },
                            //����չ��֤��Ϊ��ί��
                            LifetimeValidator = (b, e, s, v) => {

                                return true;
                            }
                        };
                       
                    });
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
                //app.UseSwaggerUI(optins => { optins.  });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                   name: "default-api",
                   pattern: "api/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
