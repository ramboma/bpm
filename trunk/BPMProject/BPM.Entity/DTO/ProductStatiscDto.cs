using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPM.Entity.DTO
{
    /// <summary>
    /// 资产统计Dto
    /// </summary>
    public class ProductStatiscDto:Product
    {
        public long Stacks { get; set; }
    }
}
