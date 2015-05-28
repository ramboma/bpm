using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPM.Entity.Paged
{
    public class PagedList<T>:IPageList
    {
        public PagedList(IEnumerable<T> source,long pageIndex,long pageSize,long totalItemCount)
        {
            Data = source;
            TotalItemCount = totalItemCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public IEnumerable<T> Data { get; set; }
        #region IPageList
        public long TotalItemCount
        {
            get;
            private set;
        }
        
        public long PageIndex
        {
            get;
            private set;
        }
        public long PageSize
        {
            get;
            private set;
        }

        #endregion
    }
}
