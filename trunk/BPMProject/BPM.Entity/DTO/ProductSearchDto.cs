using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPM.Entity.DTO
{
    /// <summary>
    /// 资产查询Dto
    /// </summary>
    public class ProductSearchDto
    {
        public long productId{get;set;}
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
        public int Source { get; set; }
    }
}
