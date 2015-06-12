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
    public class EquipmentDto:Equipment
    {
        public string Keeper { get; set; }
        public string DeptName { get; set; }
        public string SourceName { get; set; }
    }
}
