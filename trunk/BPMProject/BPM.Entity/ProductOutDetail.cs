// File:    ProductOutDetail.cs
// Author:  rambo
// Created: 2015年5月31日 12:34:27
// Purpose: Definition of Class ProductOutDetail

using System;

/// 出库详情表
public class ProductOutDetail
{
   ///<summary>
   ///id
   ///</summary>
    public long id {get;set;}
   ///<summary>
   ///出库号
   ///</summary>
    public long productLogId {get;set;}
   ///<summary>
   ///入库号
   ///</summary>
    public long productInputId {get;set;}
   ///<summary>
   ///数量
   ///</summary>
    public int quantity {get;set;}

}