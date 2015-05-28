// File:    Provider.cs
// Author:  Administrator
// Created: 2015年5月19日 22:15:45
// Purpose: Definition of Class Provider

using System;
using ServiceStack.DataAnnotations;

/// 类别
public class Provider
{
   ///<summary>
   ///类别id
   ///</summary>
    [AutoIncrement]
   public long catalogId {get;set;}
   ///<summary>
   ///类别名称
   ///</summary>
   public string catalogName {get;set;}
   ///<summary>
   ///关键词
   ///</summary>
   public string catalogKey {get;set;}
   ///<summary>
   ///备注1
   ///</summary>
   public string remark1 {get;set;}
   ///<summary>
   ///备注2
   ///</summary>
   public string remark2 {get;set;}

}