using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPM.Entity;
using ServiceStack;
using ServiceStack.OrmLite;
using BPM.ORMLite;
using BPM.Entity.Paged;
namespace BPM.BLL
{
    public class ProviderMng
    {
        /// <summary>
        /// 返回类型列表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<Provider> GetCatalogInfo(string key)
        {
            SqlExpression<Provider> sqlexpress=Utity.Connection.From<Provider>();
            sqlexpress.Where(s=>s.catalogKey.ToLower()==key.ToLower());
            return Utity.Connection.Select<Provider>(sqlexpress);
        }
        public static List<TreeDto> GetCatalogInfoTree(string key)
        {
            var treeList=new List<TreeDto>();
            List<Provider> list = GetCatalogInfo(key);
            foreach (var provider in list)
            {
                var current=new TreeDto
                    {
                        id = provider.catalogId.ToString(),
                        text = provider.catalogName,
                        Node = provider
                    };
                treeList.Add(current);
            }
            return treeList;
        }
        /// <summary>
        /// 通过id获取类型信息
        /// </summary>
        /// <param name="key">类型id</param>
        /// <returns></returns>
        public static Provider GetCatalogInfoById(int key)
        {
            SqlExpression<Provider> sqlexpress=Utity.Connection.From<Provider>();
            sqlexpress.Where(s=>s.catalogId==key);
            var list=Utity.Connection.Select<Provider>(sqlexpress);
            if (list.Count > 0)
                return list[0];
            return null;
        }
    }
}
