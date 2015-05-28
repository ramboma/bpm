using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPM.Entity.DTO
{
    public class BookBorrowDto
    {
        #region docinfo

        ///<summary>
        ///资料编码
        ///</summary>
        public long id { get; set; }
        ///<summary>
        ///资料名称
        ///</summary>
        public string docName { get; set; }
        ///<summary>
        ///作者
        ///</summary>
        public string author { get; set; }
        ///<summary>
        ///出版社
        ///</summary>
        public string publisher { get; set; }
        ///<summary>
        ///来源
        ///</summary>
        public string source { get; set; }
        ///<summary>
        ///单价
        ///</summary>
        public double price { get; set; }
        
        ///<summary>
        ///借阅权限
        ///</summary>
        public int readLevel { get; set; }
        ///<summary>
        ///关键字
        ///</summary>
        public string keyWord { get; set; }
        ///<summary>
        ///存放位置
        ///</summary>
        public string location { get; set; }
        ///<summary>
        ///内容简介
        ///</summary>
        public string content { get; set; }
        ///<summary>
        ///删除标示
        ///</summary>
        public byte deleteFlag { get; set; } 
        #endregion
        #region 借阅部分
        ///<summary>
   ///借阅人
   ///</summary>
   public string borrower {get;set;}
   ///<summary>
   ///时间
   ///</summary>
   public DateTime time {get;set;}
   ///<summary>
   ///记录类型
   ///</summary>
   public string recordType {get;set;}
   ///<summary>
   ///备注
   ///</summary>
   public string remarks {get;set;}
   ///<summary>
   ///借阅天数
   ///</summary>
   public int borrowDays {get;set;}
   ///<summary>
   ///实际归还时间
   ///</summary>
   public DateTime returnTime {get;set;}
        
        #endregion
    }
}
