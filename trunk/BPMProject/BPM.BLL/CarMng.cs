using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using BPM.ORMLite;
using BPM.Entity.DTO;
using BPM.Entity.Paged;
namespace BPM.BLL
{
    public class CarMng
    {
        /// <summary>
        /// 派车申请
        /// </summary>
        /// <returns></returns>
        public static long SubmitPaiChe(CarApply carApply)
        {
            //在派车表里插入一条记录，返回派车单号
            return Utity.Connection.Insert<CarApply>(carApply, selectIdentity: true);
        }
    }
}
