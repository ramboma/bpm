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
            return Utity.Connection.Insert<EquipmentRepair>(er, selectIdentity: true);
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

    }
}
