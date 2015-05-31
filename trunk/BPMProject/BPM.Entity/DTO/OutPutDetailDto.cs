using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPM.Entity.DTO
{
    /// <summary>
    /// 通过优化算法计算出的待出库资产Dto,
    /// </summary>
    /// <remarks>
    /// {
    ///result:
    ///[
    ///{
    ///    ProductInputId:,
    ///    Shelf:'1',
    ///    StorageNum:'2',
    ///    Quantity:11
    ///},
    ///{
    ///    ProductInputId:,
    ///    Shelf:'2',
    ///    StorageNum:'2',
    ///    Quantity:21
    ///}
    ///} 
    /// </remarks>
    public class OutPutDetailDto
    {
        /// <summary>
        /// 资产id
        /// </summary>
        public double ProductId { get; set; }
        /// <summary>
        /// 资产名
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 入库批次
        /// </summary>
        public double ProductInputId { get; set; }
        /// <summary>
        /// 架号
        /// </summary>
        public string Shelf { get; set; }
        /// <summary>
        /// 仓库号
        /// </summary>
        public string StorageName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }
    }
    public class OutPutDetailListDto
    {
        public List<OutPutDetailDto> Lists { get; set; }
    }
}
