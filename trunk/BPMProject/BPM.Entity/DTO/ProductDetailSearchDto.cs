using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPM.Entity.DTO
{
    /// <summary>
    /// 产品详情查询Dto
    /// {productName:'机',factoryId:11,model:'',standard:'',source:33,storageNum :33,starttime:'',endtime:''}
    /// </summary>
    public class ProductDetailSearchDto
    {
        public string ProductId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
    /// <summary>
    /// {productName:'机',factoryId:11,model:'',standard:'',source:33,storageNum :33,starttime:'',endtime:''}
    /// [
   /// {
   ///     Id:333,
   ///     Inout:1,
   ///     Time:'2015/5/30',
   ///     Quantity:30,
   ///     AprrovalId:88,
   ///     ApprovalName:'rambo',
   ///     SourceId:888,
   ///     SourceName:'军区'
   /// }
    ///]
    /// </summary>
    public class ProductInOutDetailDto
    {
        public int Id { get; set; }
        public int InOut { get; set; }
        public DateTime Time { get; set; }
        public int Quantity { get; set; }
        public int AprrovalId { get; set; }
        public string ApprovalName { get; set; }
        public int SourceId { get; set; }
        public string SourceName { get; set; }
    }
    public class ProductInOutListDetailDto
    {
        public List<ProductInOutDetailDto> Lists { get; set; }
    }
}
