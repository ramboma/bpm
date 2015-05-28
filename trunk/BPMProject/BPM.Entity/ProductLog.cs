// File:    ProductLog.cs
// Author:  Administrator
// Created: 2015年5月19日 22:15:45
// Purpose: Definition of Class ProductLog

using System;
using ServiceStack.DataAnnotations;
/// 资产出入
public class ProductLog
{
   ///<summary>
   ///Id
   ///</summary>
    [AutoIncrement]
   public long id {get;set;}
   ///<summary>
   ///入库Id
   ///</summary>
   public long productInputId {get;set;}
   ///<summary>
   ///时间
   ///</summary>
   public DateTime time {get;set;}
   ///<summary>
   ///数量
   ///</summary>
   public int quantity {get;set;}
   ///<summary>
   ///经办人Id
   ///</summary>
   public long userId {get;set;}
   ///<summary>
   ///来源
   ///</summary>
   public string source {get;set;}
   ///<summary>
   ///批准人Id
   ///</summary>
   public long approveId {get;set;}
   ///<summary>
   ///关联任务号
   ///</summary>
   public long relativeTask {get;set;}

}