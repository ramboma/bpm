using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using BPM.Entity;
using BPM.Entity.DTO;
using BPM.Entity.Paged;
using BPM.ORMLite;
using BPM.Entity.Proccess;
namespace BPM.BLL
{
    public class EquipmentRepairMng
    {
        /// <summary>
        /// 装备进场
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public static long EquipmentInputFactory(EquipmentRepair er)
        {
            //更新装备维修数据
           long lReturn= Utity.Connection.Update<EquipmentRepair>(er);
           return lReturn;
        }
        public static long createEquipmentRepair()
        {
            long lReturn = 0;
            try
            {
                Utity.Connection.CreateTable<EquipmentRepair>();
                lReturn = 1;
            }
            catch(Exception e)
            {
                lReturn = 0;
            }
            return lReturn;
        }


        public static EquipmentRepair InitEquipmentRepair(long flowid)
        {
            EquipmentRepair er=new EquipmentRepair();
            er.FlowInstanceId=flowid;
            long id=Utity.Connection.Insert<EquipmentRepair>(er, selectIdentity: true);
            er.EquipmentRepairId = id;
            return er;
        }

        public static EquipmentRepair OpenEquipmentRepair(long flowid)
        {
            return Utity.Connection.Single<EquipmentRepair>(s => s.FlowInstanceId == flowid);
        }
    }
}
