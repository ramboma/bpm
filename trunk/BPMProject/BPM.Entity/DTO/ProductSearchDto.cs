using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPM.Entity.DTO
{
    /// <summary>
    /// 资产查询Dto
    /// {productName:'机',factoryname:11,model:'',standard:'',source:33,storageNum :33,starttime:'2015/5/4 0:2:15',endtime:'2015/5/20 11:30:50'}
    /// </summary>
    public class ProductSearchDto
    {
        //public long productId{get;set;}
        /// <summary>
        /// 资产名称
        /// </summary>
        public string productName{get;set;}
        /// <summary>
        /// 生产厂家Id
        /// </summary>
        public string factoryName{get;set;}
        /// <summary>
        /// 型号
        /// </summary>
        public string model{get;set;}
        /// <summary>
        /// 规格
        /// </summary>
        public string standard{get;set;}
        public string Source { get; set; }
        public string StorageNum { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
