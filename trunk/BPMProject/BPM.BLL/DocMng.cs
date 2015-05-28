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
    public class DocMng
    {
        /// <summary>
        /// 文档入库 
        /// </summary>
        /// <param name="docInfo"></param>
        /// <returns></returns>

        public static long SaveDocInfo(DocInfo docInfo)
        {
            docInfo.time = DateTime.Now;
            return Utity.Connection.Insert<DocInfo>(docInfo,selectIdentity:true);
            
        }
        /// <summary>
        /// 获取文档信息
        /// </summary>
        /// <param name="docId"></param>
        /// <returns></returns>
        public static DocInfo GetDocInfo(int docId)
        {
            var docinfo=Utity.Connection.Single<DocInfo>(s => s.id== docId);
            return docinfo;
        }

        /// <summary>
        /// 文档借阅
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public static long BorrowDoc(DocLog log)
        {
            //获取文档信息
            log.time = DateTime.Now;
            log.recordType = "借阅";
            log.borrowDays = (log.returnTime - log.time).Days;
            return Utity.Connection.Insert<DocLog>(log,selectIdentity:true);
        }
        /// <summary>
        /// 获取借阅的文档列表
        /// </summary>
        /// <returns></returns>
        public static List<TreeDto> GetReturnDocs()
        {
            var treeList = new List<TreeDto>();
            SqlExpression<DocLog> sqlexpress = Utity.Connection.From<DocLog>();
            sqlexpress.Where(s=>s.recordType=="借阅");
            sqlexpress.Join<DocInfo>((log, info) => log.docId == info.id);
            var list = Utity.Connection.Select<DocBorrowDto>(sqlexpress);
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
        /// 文档归还
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public static long ReturnDoc(long logId)
        {
            //上一次的借阅记录
            DocLog preLog = Utity.Connection.Single<DocLog>(s => s.id == logId&&s.recordType=="借阅");
            //获取文档信息
            preLog.recordType = "未借";
            //实际归还时间
            preLog.returnTime = DateTime.Now;
            return Utity.Connection.Update<DocLog>(preLog);
        }
    }
}
