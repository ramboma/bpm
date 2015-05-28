using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPM.Entity.Paged
{
    public interface IPageList
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        long TotalItemCount { get; }
        /// <summary>
        /// 当前页码
        /// </summary>
        long PageIndex { get; }
        /// <summary>
        /// 页内记录数
        /// </summary>
        long PageSize { get; }
    }
}
