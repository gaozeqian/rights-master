using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 文档评论
    /// </summary>
    public partial class SysDocumentTalkRepository : BaseRepository<SysDocumentTalk>, IDisposable
    {
        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="SysEntities">数据访问的上下文</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <param name="listQuery">额外的参数</param>
        /// <returns></returns>      
        public IQueryable<SysDocumentTalk> DaoChuData(SysEntities db, string order, string sort, string search, params object[] listQuery)
        {
            string where = string.Empty;
            int flagWhere = 0;

            Dictionary<string, string> queryDic = ValueConvert.StringToDictionary(search.GetString());
            if (queryDic != null && queryDic.Count > 0)
            {
                foreach (var item in queryDic)
                {
                    if (flagWhere != 0)
                    {
                        where += " and ";
                    }
                    flagWhere++;
                    
                    
                    if (queryDic.ContainsKey("SysDocumentId") && !string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Value == "noway" && item.Key == "SysDocumentId")
                    {//查询一对多关系的列名
                        where += "it.SysDocumentId is null";
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(Start_Time)) //开始时间
                    {
                        where += "it.[" + item.Key.Remove(item.Key.IndexOf(Start_Time)) + "] >=  CAST('" + item.Value + "' as   System.DateTime)";
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(End_Time)) //结束时间+1
                    {
                        where += "it.[" + item.Key.Remove(item.Key.IndexOf(End_Time)) + "] <  CAST('" + Convert.ToDateTime(item.Value).AddDays(1) + "' as   System.DateTime)";
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(Start_Int)) //开始数值
                    {
                        where += "it.[" + item.Key.Remove(item.Key.IndexOf(Start_Int)) + "] >= " + item.Value.GetInt();
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(End_Int)) //结束数值
                    {
                        where += "it.[" + item.Key.Remove(item.Key.IndexOf(End_Int)) + "] <= " + item.Value.GetInt();
                        continue;
                    }
     
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(DDL_Int)) //精确查询数值
                    {
                        where += "it.[" + item.Key.Remove(item.Key.IndexOf(DDL_Int)) + "] =" + item.Value;
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(DDL_String)) //精确查询字符串
                    {
                        where += "it.[" + item.Key.Remove(item.Key.IndexOf(DDL_String)) + "] = '" + item.Value + "'";
                        continue;
                    }
                    where += "it.[" + item.Key + "] like '%" + item.Value + "%'";//模糊查询
                }
            }
            return ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext 
                     .CreateObjectSet<SysDocumentTalk>().Where(string.IsNullOrEmpty(where) ? "true" : where)
                     .OrderBy("it.[" + sort.GetString() + "] " + order.GetString())
                     .AsQueryable(); 

        }
        /// <summary>
        /// 通过主键id，获取文档评论---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>文档评论</returns>
        public SysDocumentTalk GetById(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                return GetById(db, id);
            }                   
        }
        /// <summary>
        /// 通过主键id，获取文档评论---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>文档评论</returns>
        public SysDocumentTalk GetById(SysEntities db, string id)
        { 
            return db.SysDocumentTalk.SingleOrDefault(s => s.Id == id);
        
        }
        /// <summary>
        /// 确定删除一个对象，调用Save方法
        /// </summary>
        /// <param name="id">一条数据的主键</param>
        /// <returns></returns>    
        public int Delete(string id)
        {
            using (SysEntities db = new SysEntities())
            {
                this.Delete(db, id);
                return Save(db);
            }
        }
 
        /// <summary>
        /// 删除一个文档评论
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="id">一条文档评论的主键</param>
        public void Delete(SysEntities db, string id)
        {
            SysDocumentTalk deleteItem = GetById(db, id);
            if (deleteItem != null)
            { 
                db.SysDocumentTalk.Remove(deleteItem);
            }
        }
        /// <summary>
        /// 删除对象集合
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="deleteCollection">主键的集合</param>
        public void Delete(SysEntities db, string[] deleteCollection)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<SysDocumentTalk> collection = from f in db.SysDocumentTalk
                    where deleteCollection.Contains(f.Id)
                    select f;
            foreach (var deleteItem in collection)
            {
                db.SysDocumentTalk.Remove(deleteItem);
            }
        }

        /// <summary>
        /// 根据SysDocumentId，获取所有文档评论数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public IQueryable<SysDocumentTalk> GetByRefSysDocumentId(SysEntities db, string id)
        {
            return from c in db.SysDocumentTalk
                        where c.SysDocumentId == id
                        select c;
                      
        }

        public void Dispose()
        {          
        }
    }
}

