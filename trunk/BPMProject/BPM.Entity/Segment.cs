// File:    Segment.cs
// Author:  Administrator
// Created: 2015年5月19日 22:15:45
// Purpose: Definition of Class Segment

using System;
using ServiceStack.DataAnnotations;
/// 环节
public class Segment
{
   ///<summary>
   ///环节ID
   ///</summary>
    [AutoIncrement]
   public int segmentId {get;set;}
   ///<summary>
   ///环节名
   ///</summary>
   public string segmentName {get;set;}
   ///<summary>
   ///环节描述
   ///</summary>
   public string segmentTitle {get;set;}
   ///<summary>
   ///包含表
   ///</summary>
   public string includeTable {get;set;}
   ///<summary>
   ///包含字段
   ///</summary>
   public string includeParam {get;set;}
   ///<summary>
   ///责任人
   ///</summary>
   public string blameName {get;set;}
   ///<summary>
   ///前一环节
   ///</summary>
   public int preSegment {get;set;}
   ///<summary>
   ///跳转表达式
   ///</summary>
   public string actionExpression {get;set;}
   ///<summary>
   ///创建时间
   ///</summary>
   public DateTime createTime {get;set;}
   ///<summary>
   ///更新时间
   ///</summary>
   public DateTime updateTime {get;set;}

}