// File:    ProcessLog.cs
// Author:  Administrator
// Created: 2015年5月19日 22:15:45
// Purpose: Definition of Class ProcessLog

using System;

using ServiceStack.DataAnnotations;
/// 流程日志表
public class ProcessLog
{
   ///<summary>
   ///流程日志Id
   ///</summary>
[AutoIncrement]    
   public int processLogId {get;set;}
   ///<summary>
   ///环节Id
   ///</summary>
   public int segmentId {get;set;}
   ///<summary>
   ///操作表
   ///</summary>
   public string tableName {get;set;}
   ///<summary>
   ///创建人
   ///</summary>
   public string createUser {get;set;}
   ///<summary>
   ///创建时间
   ///</summary>
   public DateTime createTime {get;set;}
   ///<summary>
   ///更新时间
   ///</summary>
   public DateTime updateTime {get;set;}
   ///<summary>
   ///客户ip
   ///</summary>
   public string ipaddress {get;set;}

}