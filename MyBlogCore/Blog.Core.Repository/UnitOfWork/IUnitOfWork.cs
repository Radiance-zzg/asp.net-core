using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repository
{
    public interface IUnitOfWork
    {

        public SqlSugarScope GetDB();
        void BeginTran();
        void CommitTran();
        void RollbackTran();
    }
}
