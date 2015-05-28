using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPM.Entity;
using BPM.ORMLite;
using ServiceStack.OrmLite;
using BPM.Entity.DTO;
using BPM.Entity.Paged;
namespace BPM.BLL
{
    public class BookMng
    {
        /// <summary>
        /// 图书上架 
        /// </summary>
        /// <param name="docInfo"></param>
        /// <returns></returns>

        public static long SaveBookInfo(BookInfo docInfo)
        {
            docInfo.time = DateTime.Now;
            return Utity.Connection.Insert<BookInfo>(docInfo,selectIdentity:true);
            
        }
        /// <summary>
        /// 获取图书信息
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static BookInfo GetBookInfo(int bookId)
        {
            var docinfo=Utity.Connection.Single<BookInfo>(s => s.id== bookId);
            return docinfo;
        }

        /// <summary>
        /// 图书借阅
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public static long BorrowBook(BookLog log)
        {
            //获取图书信息
            log.time = DateTime.Now;
            log.recordType = "借阅";
            log.borrowDays = (log.returnTime - log.time).Days;
            return Utity.Connection.Insert<BookLog>(log,selectIdentity:true);
        }
        /// <summary>
        /// 获取借阅的图书列表
        /// </summary>
        /// <returns></returns>
        public static List<TreeDto> GetReturnBooks()
        {
            var treeList = new List<TreeDto>();
            SqlExpression<BookLog> sqlexpress = Utity.Connection.From<BookLog>();
            sqlexpress.Where(s=>s.recordType=="借阅");
            sqlexpress.Join<BookInfo>((log, info) => log.bookId == info.id);
            var list = Utity.Connection.Select<BookBorrowDto>(sqlexpress);
            foreach (var v in list)
            {
                TreeDto td = new TreeDto();
                td.id = v.id.ToString();
                td.text = v.docName;
                td.Node = v;
                treeList.Add(td);
            }
            return treeList;
        }
        /// <summary>
        /// 图书归还
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public static long ReturnBook(long logId)
        {
            //上一次的借阅记录
            BookLog preLog = Utity.Connection.Single<BookLog>(s => s.id == logId&&s.recordType=="借阅");
            //获取图书信息
            preLog.recordType = "未借";
            //实际归还时间
            preLog.returnTime = DateTime.Now;
            return Utity.Connection.Update<BookLog>(preLog);
        }
    }
}
