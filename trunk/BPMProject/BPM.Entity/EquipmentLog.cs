// File:    EquipmentLog.cs
// Author:  Administrator
// Created: 2015年5月19日 22:15:45
// Purpose: Definition of Class EquipmentLog

using System;

using ServiceStack.DataAnnotations;
/// 设备变动信息表
public class EquipmentLog
{
   ///<summary>
   ///日志Id
   ///</summary>
    [AutoIncrement]
   public long id {get;set;}
   ///<summary>
   ///设备编码
   ///</summary>
   public long equipmentId {get;set;}
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
   ///申请人Id
   ///</summary>
   public long applyId { get; set; }
   ///<summary>
   ///批准人Id
   ///</summary>
   public long approveId { get; set; }
   ///<summary>
   ///关联任务号
   ///</summary>
   public long relativeTask { get; set; }
   ///<summary>
   ///出库管理员
   ///</summary>
   public long managerId { get; set; }

}