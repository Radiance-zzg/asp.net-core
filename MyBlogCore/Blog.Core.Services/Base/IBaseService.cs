using Blog.Core.Model.ViewModel;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services.Base
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        #region 新增
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(TEntity entity);
        public Task<bool> AddEntityAsync(TEntity entity);
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool BulkCopy(List<TEntity> entities);
        public Task<bool> BulkCopyAsync(List<TEntity> entities);
        #endregion
        #region 删除
        public bool DeleteEntity(TEntity entity);
        public bool DeleteEntityList(List<TEntity> entities);
        public bool DeleteEntityByWhere(Expression<Func<TEntity, bool>> expression);
        #endregion
        #region 更新Model
        Task<bool> UpdateAsync(TEntity model);
        Task<bool> UpdateListAsync(List<TEntity> entities);
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
