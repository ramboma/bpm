// File:    Equipment.cs
// Author:  Administrator
// Created: 2015年5月27日 9:01:08
// Purpose: Definition of Class Equipment

using System;

/// 设备信息
public class Equipment
{
    ///<summary>
   ///设备编码
   ///</summary>
   public long id {get;set;}
    ///<summary>
   ///设备名称
   ///</summary>
   public string equipmentName {get;set;}
    ///<summary>
   ///型号
   ///</summary>
   public string model {get;set;}
    ///<summary>
   ///规格
   ///</summary>
   public string standard {get;set;}
    ///<summary>
   ///来源
   ///</summary>
   public long source {get;set;}
    ///<summary>
   ///单价
   ///</summary>
   public double price {get;set;}
    ///<summary>
   ///入库时间
   ///</summary>
   public DateTime updateTime {get;set;}
    ///<summary>
   ///设备状态初始
   ///</summary>
   public string equipmentStatus {get;set;}
    ///<summary>
   ///保管单位
   ///</summary>
   public long departMent {get;set;}
    ///<summary>
   ///技术文档
   ///</summary>
   public string docPath {get;set;}
    ///<summary>
   ///删除标示
   ///</summary>
   public byte hasDelete {get;set;}
    ///<summary>
   ///保管人
   ///</summary>
   public long keeper {get;set;}

}