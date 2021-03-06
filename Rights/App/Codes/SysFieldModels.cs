using System.Collections.Generic;
using System.Web.Mvc;
using Langben.BLL;
using Langben.IBLL;
namespace  Models
{
    public class SysFieldModels
    {

        /// <summary>
        /// 获取字段，首选默认
        /// </summary>
        /// <returns></returns>
        public static SelectList GetSysField(string table, string colum, string parentMyTexts)
        {
            if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(colum) || string.IsNullOrWhiteSpace(parentMyTexts))
            {
                List<SelectList> sl = new List<SelectList>();
                return new SelectList(sl);
            }
            ISysFieldHander baseDDL = new SysFieldHander();
            return new SelectList(baseDDL.GetSysField(table, colum, parentMyTexts), "MyTexts", "MyTexts");

        }
        /// <summary>
        /// 获取字段，首选默认，MyTexts做为value值
        /// </summary>
        /// <returns></returns>
        public static SelectList GetSysField(string table, string colum)
        {
            if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(colum))
            {
                List<SelectList> sl = new List<SelectList>();
                return new SelectList(sl);
            }
            ISysFieldHander baseDDL = new SysFieldHander();
            return new SelectList(baseDDL.GetSysField(table, colum), "MyTexts", "MyTexts");

        }
        /// <summary>
        /// 获取字段，首选默认，Id做为value值
        /// </summary>
        /// <returns></returns>
        public static SelectList GetSysFieldById(string table, string colum)
        {
            if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(colum))
            {
                List<SelectList> sl = new List<SelectList>();
                return new SelectList(sl);
            }
            ISysFieldHander baseDDL = new SysFieldHander();
            return new SelectList(baseDDL.GetSysField(table, colum), "Id", "MyTexts");

        }
        /// <summary>
        /// 根据主键id，获取数据字典的展示字段
        /// </summary>
        /// <param name="id">父亲节点的主键</param>
        /// <returns></returns>
        public static string GetMyTextsById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return string.Empty;
            }
            ISysFieldHander baseDDL = new SysFieldHander();
            return baseDDL.GetMyTextsById(id);

        }
    }
}

