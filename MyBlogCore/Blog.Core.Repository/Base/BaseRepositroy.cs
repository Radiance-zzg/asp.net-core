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
    public class BaseRepositroy<TEntiy> : IBaseRepository<TEntiy> where TEntiy : class, new()
    {

        public IUnitOfWork _unitOfWork { get; set; }



        //public BaseRepositroy(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        public SqlSugarScope Db => _unitOfWork.GetDB();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddEntity(TEntiy entity)
        {
            return Db.Insertable(entity).ExecuteCommand() > 0;
        }
        /// <summary>
        /// 异步新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> AddEntityAsync(TEntiy entity)
        {
            var result = await Db.Insertable(entity).ExecuteCommandAsync();
            return result > 0;

        }
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool BulkCopy(List<TEntiy> entities)
        {
            var result = Db.Insertable(entities).ExecuteCommand();
            return result > 0;
        }
        /// <summary>
        ///批量新增
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<bool> BulkCopyAsync(List<TEntiy> entities)
        {
            var result = await Db.Insertable(entities).ExecuteCommandAsync();
            return result >= 0;
        }
        /// <summary>
        ///根据实体删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(TEntiy entity)
        {
            return Db.Deleteable(entity).ExecuteCommandHasChange();
        }
        /// <summary>
        /// 根据表达式删除
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool DeleteEntityByWhere(Expression<Func<TEntiy, bool>> expression)
        {
            return Db.Deleteable<TEntiy>().Where(expression).ExecuteCommandHasChange();
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool DeleteEntityList(List<TEntiy> entities)
        {
            return Db.Deleteable(entities).ExecuteCommand() > 0;
        }
        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntiy>> GetAllListAsync()
        {
            return await Db.Queryable<TEntiy>().ToListAsync();
        }
        /// <summary>
        /// 根据表达式查询
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Task<List<TEntiy>> GetListByWhreAsync(Expression<Func<TEntiy, bool>> expression)
        {
            return Db.Queryable<TEntiy>().Where(expression).ToListAsync();
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="expression"></param>
        /// <param name="strshortByFileds"></param>
        /// <returns></returns>
        public async Task<PageModel<TEntiy>> GetPageAsync(int PageIndex, int PageSize, Expression<Func<TEntiy, bool>> expression, string strshortByFileds = null)
        {
            RefAsync<int> total = 0;
            var result = await Db.Queryable<TEntiy>().Where(expression).OrderBy(strshortByFileds).ToPageListAsync(PageIndex, PageSize, total);
            return new PageModel<TEntiy> { Data = result, Total = total, PageIndex = PageIndex, PageSize = PageSize, PageCounet = (int)System.Math.Ceiling((decimal)total / PageSize) };
        }
        /// <summary>
        /// 获取queryable
        /// </summary>
        /// <returns></returns>
        public ISugarQueryable<TEntiy> GetQueryable()
        {
            return Db.Queryable<TEntiy>();
        }
        public ISugarQueryable<TEntiy> GetGetQueryableSql(string strSql)
        {
            return Db.SqlQueryable<TEntiy>(strSql);
        }
        /// <summary>
        /// 单条修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(TEntiy model)
        {
            return await Db.Updateable(model).ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<bool> UpdateListAsync(List<TEntiy> entities)
        {
            return await Db.Updateable(entities).ExecuteCommandHasChangeAsync();
        }
    }

}
