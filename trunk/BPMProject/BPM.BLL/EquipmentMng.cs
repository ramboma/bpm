using System.Collections.Generic;
using BPM.Entity;
using ServiceStack.OrmLite;
using BPM.ORMLite;
using BPM.Entity.DTO;
using BPM.Entity.Paged;
namespace BPM.BLL
{
    public class EquipmentMng
    {
        /// <summary>
        /// 获取所有装备树
        /// </summary>
        /// <returns></returns>
        public static List<TreeDto> GetEquipmentTree()
        {
            var express = ORMLite.Utity.Connection.From<Equipment>();
            express.Where(s => s.HasDelete == 0);
            var list = Utity.Connection.Select<Equipment>(express);
            var treeDtoList = new List<TreeDto>();
            //取第一层
            foreach (var product in list)
            {
                treeDtoList.Add(new TreeDto() { id = product.EquipmentID.ToString(), text = product.EquipmentName, children = new List<TreeDto>(), Node = product });
            }
            return treeDtoList;
        }
        /// <summary>
        /// 获取可以报废的装备树
        /// </summary>
        /// <returns></returns>
        public static List<TreeDto> GetBfEquipmentTree()
        {
            var express = ORMLite.Utity.Connection.From<Equipment>();
            express.Where(s => s.HasDelete == 1);
            express.Join<EquipmentLog>((equ, log) => equ.EquipmentID == log.equipmentId && log.recordType != "报废");
            var list = Utity.Connection.Select<Equipment>(express);
            var treeDtoList = new List<TreeDto>();
            //取第一层
            foreach (var product in list)
            {
                    treeDtoList.Add(new TreeDto() { id = product.EquipmentID.ToString(), text = product.EquipmentName, children = new List<TreeDto>(), Node = product });
            }
            return treeDtoList;
        }
   
        /// <summary>
        /// 保存入库装备日志
        /// </summary>
        /// <param name="equipmentLog"></param>
        /// <returns></returns>
        public static long SaveEquipmentLog(EquipmentLog equipmentLog)
        {
            equipmentLog.time = System.DateTime.Now;
            long lResult = Utity.Connection.Insert<EquipmentLog>(equipmentLog,selectIdentity:true);
            return lResult;
        }
        /// <summary>
        /// 装备报废
        /// </summary>
        /// <param name="strEquipmentId">装备id</param>
        /// <returns></returns>
        public static long KickEquiement(int equipmentid)
        {
            //查找当前装备在哪里？
            SqlExpression<EquipmentLog> sqlexpression = Utity.Connection.From<EquipmentLog>();
            sqlexpression.Where(s => s.equipmentId == equipmentid);
            sqlexpression.OrderByDescending(s => s.time);
            //查看sql日志
            System.Diagnostics.Debug.WriteLine(sqlexpression.SelectInto<EquipmentLog>());
            var currentEquLog=Utity.Connection.Single(sqlexpression);
            //设置装备报废
            EquipmentLog newLog = new EquipmentLog();
            newLog.equipmentId = currentEquLog.equipmentId;
            newLog.remarks = currentEquLog.remarks;
            newLog.recordType = "报废";
            newLog.time = System.DateTime.Now;
            newLog.applyId = currentEquLog.applyId;
            newLog.approveId = currentEquLog.approveId;
            newLog.managerId = currentEquLog.managerId;
            long lResult = Utity.Connection.Insert<EquipmentLog>(newLog);
            return lResult;
        }
        #region 设备增删改查
        /// <summary>
        /// 保存装备
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns></returns>
        public static long SaveEquipment(Equipment equipment)
        {
            equipment.UpdateTime = System.DateTime.Now;
            return Utity.Connection.Insert<Equipment>(equipment, selectIdentity: true);
        }
        
        #endregion
    }
}
