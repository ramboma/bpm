using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPM.Entity.DTO
{
    /// <summary>
    /// 批量插入出库信息Dto
    /// </summary>
    ///     ApplyId:'',ApproveId:'',RelativeTask:'',ManagerId:'',
    ///     data[{ProductId:11,SaleCount:22}]
    public class FetchDetailDto
    {
        public int ApplyId { get; set; }
        public int ApproveId { get; set; }
        public int RelativeTask { get; set; }
        public int ManagerId { get; set; }
        public List<DetailDto> data { get; set; }
    }
    public class DetailDto
    {
        public long ProductId { get; set; }
        public double SaleCount { get; set; }
    }
}
