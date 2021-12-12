using Blog.Core.Model.ViewModel;
using Blog.Core.Repository.Base;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        public IBaseRepository<TEntity> _baseRepositroy { get; set; }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(TEntity entity)
        {
            return _baseRepositroy.AddEntity(entity);
        }
        /// <summary>
        /// 添加实体 异步
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> AddEntityAsync(TEntity entity)
        {
            return await _baseRepositroy.AddEntityAsync(entity);
        }
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool BulkCopy(List<TEntity> entities)
        {
            return _baseRepositroy.BulkCopy(entities);
        }
        /// <summary>
        /// 批量新增异步
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<bool> BulkCopyAsync(List<TEntity> entities)
        {
            return await _baseRepositroy.BulkCopyAsync(entities);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteEntity(TEntity entity)
        {
            return _baseRepositroy.DeleteEntity(entity);
        }
        /// <summary>
        /// 根据表达式删除
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool DeleteEntityByWhere(Expression<Func<TEntity, bool>> expression)
        {
            return _baseRepositroy.DeleteEntityByWhere(expression);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteEntityList(List<TEntity> entities)
        {
            return _baseRepositroy.DeleteEntityList(entities);
        }
        /// <summary>
        /// 根据ID逻辑删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteIsLogicEntityById(int Id)
        {
            return _baseRepositroy.DeleteIsLogicEntityById(Id);
        }
        /// <summary>
        /// 根据表达式逻辑删除
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool DeleteIsLogicEntityByWhere(Expression<Func<TEntity, bool>> expression)
        {
            return _baseRepositroy.DeleteIsLogicEntityByWhere(expression);
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllListAsync()
        {
            return await _baseRepositroy.GetAllListAsync();
        }
        /// <summary>
        /// 执行sql获取Queryable
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>

        public ISugarQueryable<TEntity> GetGetQueryableSql(string strSql)
        {
            return _baseRepositroy.GetGetQueryableSql(strSql);
        }
        /// <summary>
        /// 根据表达式获取数据
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>

        public async Task<List<TEntity>> GetListByWhreAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _baseRepositroy.GetListByWhreAsync(expression);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="expression"></param>
        /// <param name="strshortByFileds"></param>
        /// <returns></returns>

        public async Task<PageModel<TEntity>> GetPageAsync(int PageIndex, int PageSize, Expression<Func<TEntity, bool>> expression, string strshortByFileds)
        {
            return await _baseRepositroy.GetPageAsync(PageIndex, PageSize, expression, strshortByFileds);
        }
        /// <summary>
        /// 获取Queryable
        /// </summary>
        /// <returns></returns>
        public ISugarQueryable<TEntity> GetQueryable()
        {
            return _baseRepositroy.GetQueryable();
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public  bool UpdateAsync(TEntity model)
        {
            return  _baseRepositroy.UpdateAsync(model);
        }
        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public  bool UpdateListAsync(List<TEntity> entities)
        {
            return  _baseRepositroy.UpdateListAsync(entities);
        }
    }
}
