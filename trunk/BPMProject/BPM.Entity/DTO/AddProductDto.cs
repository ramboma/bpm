using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPM.Entity.DTO
{
    /// <summary>
    /// 新增资产Dto
    /// </summary>
    public class AddProductDto:Product
    {
        /// <summary>
        /// 父Id
        /// </summary>
        public long ParentId { get; set; }
    }
}
