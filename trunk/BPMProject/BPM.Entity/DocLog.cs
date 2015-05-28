// File:    DocLog.cs
// Author:  rambo
// Created: 2015年5月23日 15:29:19
// Purpose: Definition of Class DocLog

using System;

using ServiceStack.DataAnnotations;
/// 资料变动信息表
public class DocLog
{
   ///<summary>
   ///日志Id
   ///</summary>
    [AutoIncrement]
    public long id {get;set;}
   ///<summary>
   ///资料编码
   ///</summary>
    public long docId {get;set;}
   ///<summary>
   ///借阅人
   ///</summary>
    public string borrower {get;set;}
   ///<summary>
   ///时间
   ///</summary>
    public DateTime time {get;set;}
   ///<summary>
   ///记录类型
   ///</summary>
    public string recordType {get;set;}
   ///<summary>
   ///备注
   ///</summary>
    public string remarks {get;set;}
   ///<summary>
   ///借阅天数
   ///</summary>
    public int borrowDays {get;set;}
   ///<summary>
   ///实际归还时间
   ///</summary>
    public DateTime returnTime {get;set;}

}