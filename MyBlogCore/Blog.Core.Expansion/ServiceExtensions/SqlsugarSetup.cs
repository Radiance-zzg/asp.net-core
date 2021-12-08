
using Blog.Core.Repository;
using Blog.Core.Repository.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Configuration;

namespace Blog.Core.Extensions.ServiceExtensions
{
    public static class SqlsugarSetup
    {


        public static void AddSqlsugarSetup(this IServiceCollection services, IConfiguration configuration)
        {
            SqlSugarScope sqlSugar = new SqlSugarScope(new ConnectionConfig()
            {
                DbType = SqlSugar.DbType.SqlServer,
                ConnectionString = configuration.GetConnectionString("SqlServer"),
                IsAutoCloseConnection = true,
            },
                db =>
                {
                    //单例参数配置，所有上下文生效
                    db.Aop.OnLogExecuting = (sql, pars) =>
                        {
                            //Console.WriteLine(sql);//输出sql
                        };
                });
            services.AddSingleton<ISqlSugarClient>(sqlSugar);//这边是SqlSugarScope用AddSingleton
        }
        public static void AddUnitOfWorkSetup(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
