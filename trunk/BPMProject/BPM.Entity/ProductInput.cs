// File:    ProductInput.cs
// Author:  Administrator
// Created: 2015年5月27日 9:01:08
// Purpose: Definition of Class ProductInput

using System;
using ServiceStack.DataAnnotations;
/// 资产入库表
public class ProductInput
{
    ///<summary>
   ///Id
   ///</summary>
    [AutoIncrement]
   public long id {get;set;}
    ///<summary>
   ///资产内码
   ///</summary>
   public long productId {get;set;}
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
   public long source {get;set;}
    ///<summary>
   ///批准人Id
   ///</summary>
   public long approveId {get;set;}
    ///<summary>
   ///关联任务号
   ///</summary>
   public long relativeTask {get;set;}
    ///<summary>
   ///库房编号
   ///</summary>
   public string storageNum {get;set;}
    ///<summary>
   ///货架号
   ///</summary>
   public string shelf {get;set;}
    ///<summary>
   ///保质期
   ///</summary>
   public decimal shelfLife {get;set;}

}