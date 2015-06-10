// File:    Equipment.cs
// Author:  Administrator
// Created: 2015年5月27日 9:01:08
// Purpose: Definition of Class Equipment

using System;
using ServiceStack.DataAnnotations;
/// 设备信息
public class Equipment
{
    ///<summary>
   ///设备编码
   ///</summary>
   [AutoIncrement] 
   public long EquipmentID {get;set;}
    ///<summary>
   ///设备名称
   ///</summary>
   public string EquipmentName { get; set; }
    ///<summary>
   ///型号
   ///</summary>
   public string Model { get; set; }
    ///<summary>
   ///规格
   ///</summary>
   public string Standard { get; set; }
    ///<summary>
   ///来源
   ///</summary>
   public long Source { get; set; }
    ///<summary>
   ///单价
   ///</summary>
   public double Price { get; set; }
    ///<summary>
   ///入库时间
   ///</summary>
   public DateTime UpdateTime { get; set; }
    ///<summary>
   ///设备状态初始
   ///</summary>
   public string EquipmentStatus { get; set; }
    ///<summary>
   ///保管单位
   ///</summary>
   public long KeepDept { get; set; }
    ///<summary>
   ///技术文档
   ///</summary>
   public string DocPath { get; set; }
    ///<summary>
   ///删除标示
   ///</summary>
   public byte HasDelete { get; set; }
    ///<summary>
   ///保管人
   ///</summary>
   public long KeepEmpl { get; set; }

    /// <summary>
    /// 工厂名
    /// </summary>
   public string FactoryName { get; set; }
    /// <summary>
    /// 供应商名
    /// </summary>
   public string SalerName { get; set; }
    /// <summary>
    /// 出厂时间
    /// </summary>
   public DateTime ProductTime { get; set; }

}