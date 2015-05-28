// File:    Product.cs
// Author:  Administrator
// Created: 2015年5月19日 22:15:45
// Purpose: Definition of Class Product

using System;

/// 资产品名
public class Product
{
   ///<summary>
   ///资产内码
   ///</summary>
   public long productId {get;set;}
   ///<summary>
   ///资产编码
   ///</summary>
   public string productNum {get;set;}
   ///<summary>
   ///资产名称
   ///</summary>
   public string productName {get;set;}
   ///<summary>
   ///资产类型(1为目录,2为资产)
   ///</summary>
   public byte productFlag {get;set;}
   ///<summary>
   ///生产厂家Id
   ///</summary>
   public long factoryId {get;set;}
   ///<summary>
   ///经销商Id
   ///</summary>
   public long dealerId {get;set;}
   ///<summary>
   ///型号
   ///</summary>
   public string model {get;set;}
   ///<summary>
   ///规格
   ///</summary>
   public string standard {get;set;}
   ///<summary>
   ///单价
   ///</summary>
   public double price {get;set;}
   ///<summary>
   ///数量单位
   ///</summary>
   public string quantityUnit {get;set;}
   ///<summary>
   ///删除标示
   ///</summary>
   public byte hasDelete {get;set;}

}