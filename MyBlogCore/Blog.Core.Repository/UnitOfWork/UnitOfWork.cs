using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ISqlSugarClient _sqlSugarClient;
        public UnitOfWork(ISqlSugarClient sqlSugarClient)
        {
            _sqlSugarClient = sqlSugarClient;
        }
        public SqlSugarScope GetDB()
        {
            return _sqlSugarClient as SqlSugarScope;
        }
        public void BeginTran()
        {
            _sqlSugarClient.Ado.BeginTran();
        }

        public void CommitTran()
        {
            _sqlSugarClient.Ado.CommitTran();
        }



        public void RollbackTran()
        {
            _sqlSugarClient.Ado.RollbackTran();
        }
    }
}
