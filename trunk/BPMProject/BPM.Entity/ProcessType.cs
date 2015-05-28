// File:    ProcessType.cs
// Author:  Administrator
// Created: 2015年5月19日 22:15:45
// Purpose: Definition of Class ProcessType

using System;

/// 流程类型表
public class ProcessType
{
   ///<summary>
   ///流程类型Id
   ///</summary>
   public int processTypeId {get;set;}
   ///<summary>
   ///流程类型名称
   ///</summary>
   public string processTypeName {get;set;}
   ///<summary>
   ///流程类型描述
   ///</summary>
   public string processTypeTitle {get;set;}
   ///<summary>
   ///首环
   ///</summary>
   public int firstSegment {get;set;}
   ///<summary>
   ///末环
   ///</summary>
   public int endSegment {get;set;}
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
   ///父流程类型Id
   ///</summary>
   public int parentId {get;set;}

}