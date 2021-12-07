using Blog_Core.Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Configuration;

namespace Blog.Core.Extensions.ServiceExtensions
{
    public static class SqlsugarSetup
    {
        //private readonly IConfiguration _configuration;
        //public SqlsugarSetup(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
     
        public static void AddSqlsugarSetup(this IServiceCollection services)
        {
            SqlSugarScope sqlSugar = new SqlSugarScope(new ConnectionConfig()
            {
                DbType = SqlSugar.DbType.SqlServer,
                ConnectionString = CommConfiguration.GetConnetionStr("SqlServer"),
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
    }
}
