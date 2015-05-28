using System.Collections.Generic;
using BPM.Entity;
using ServiceStack.OrmLite;
using BPM.ORMLite;
using BPM.Entity.DTO;
using BPM.Entity.Paged;
namespace BPM.BLL
{
    public class PageMng<T>
    {
        /// <summary>
        /// 对实体分页
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public  PagedList<T> GetAllEntitysByPage(PageDto dto)
        {
            var express = ORMLite.Utity.Connection.From<T>();
            int skips = (dto.PageIndex - 1) * dto.PageSize;
            express.Limit(skip: skips, rows: dto.PageSize);
            long allCount = Utity.Connection.Count<T>(express);
            var list = Utity.Connection.Select<T>(express);
            var pagedList = new PagedList<T>(list, dto.PageIndex, dto.PageSize, allCount);

            return pagedList;
        }
       
    }
}
