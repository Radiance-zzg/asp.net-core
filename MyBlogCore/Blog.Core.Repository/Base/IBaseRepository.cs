using Blog.Core.Model.ViewModel;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repository.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// SqlsugarClient实体
        /// </summary>
        public SqlSugarScope Db { get; }
        #region 新增
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool AddEntity(TEntity entity);
        Task<bool> AddEntityAsync(TEntity entity);
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        bool BulkCopy(List<TEntity> entities);
        Task<bool> BulkCopyAsync(List<TEntity> entities);
        #endregion
        #region 删除
        bool DeleteEntity(TEntity entity);
        bool DeleteEntityList(List<TEntity> entities);
        bool DeleteEntityByWhere(Expression<Func<TEntity, bool>> expression);
        bool DeleteIsLogicEntityById(int Id);
        /// <summary>
        /// 逻辑删除表达式
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool DeleteIsLogicEntityByWhere(Expression<Func<TEntity, bool>> expression);

        #endregion
        #region 更新Model
        bool UpdateAsync(TEntity model);
        bool UpdateListAsync(List<TEntity> entities);
        #endregion
        //查询
        #region
        /// <summary>
        /// 获取Queryable对象
        /// </summary>
        /// <returns></returns>
        ISugarQueryable<TEntity> GetQueryable();
        ISugarQueryable<TEntity> GetGetQueryableSql(string strSql);

        Task<List<TEntity>> GetAllListAsync();
        Task<List<TEntity>> GetListByWhreAsync(Expression<Func<TEntity, bool>> expression);

        Task<PageModel<TEntity>> GetPageAsync(int PageIndex, int PageSize, Expression<Func<TEntity, bool>> expression, string strshortByFileds);

        #endregion



    }
}
