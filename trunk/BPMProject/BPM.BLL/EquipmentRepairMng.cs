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

    }
}
