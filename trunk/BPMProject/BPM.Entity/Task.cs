// File:    Task.cs
// Author:  Administrator
// Created: 2015年5月19日 22:15:45
// Purpose: Definition of Class Task

using System;
using ServiceStack.DataAnnotations;

/// 任务表
public class Task
{
   ///<summary>
   ///任务Id
   ///</summary>
    [AutoIncrement]
   public int taskId {get;set;}
   ///<summary>
   ///任务名称
   ///</summary>
   public string taskName {get;set;}
   ///<summary>
   ///流程类型
   ///</summary>
   public int processTypeId {get;set;}
   ///<summary>
   ///流程日志Id
   ///</summary>
   public int processLogId {get;set;}
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
   ///当前环节
   ///</summary>
   public int currentSegment {get;set;}

}