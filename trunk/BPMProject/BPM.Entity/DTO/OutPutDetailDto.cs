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
        public double ProductInputId { get; set; }
        public string Shelf { get; set; }
        public string StorageNum { get; set; }
        public int Quantity { get; set; }
    }
    public class OutPutDetailListDto
    {
        public List<OutPutDetailDto> Lists { get; set; }
    }
}
