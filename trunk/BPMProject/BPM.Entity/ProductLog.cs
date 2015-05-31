// File:    ProductLog.cs
// Author:  rambo
// Created: 2015年5月31日 12:34:27
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
   ///时间
   ///</summary>
    public DateTime time {get;set;}
   ///<summary>
   ///申请人Id
   ///</summary>
    public long applyId {get;set;}
   ///<summary>
   ///批准人Id
   ///</summary>
    public long approveId {get;set;}
   ///<summary>
   ///关联任务号
   ///</summary>
    public long relativeTask {get;set;}
   ///<summary>
   ///出库管理员
   ///</summary>
    public long managerId {get;set;}

}