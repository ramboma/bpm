// File:    DocInfo.cs
// Author:  rambo
// Created: 2015年5月23日 15:29:19
// Purpose: Definition of Class DocInfo

using System;

using ServiceStack.DataAnnotations;
/// 资料信息表
public class DocInfo
{
   ///<summary>
   ///资料编码
   ///</summary>
    [AutoIncrement]
    public long id {get;set;}
   ///<summary>
   ///资料名称
   ///</summary>
    public string docName {get;set;}
   ///<summary>
   ///资料类型
   ///</summary>
    public string docType {get;set;}
   ///<summary>
   ///作者
   ///</summary>
    public string author {get;set;}
   ///<summary>
   ///出版社
   ///</summary>
    public string publisher {get;set;}
   ///<summary>
   ///密级
   ///</summary>
    public string miLevel {get;set;}
   ///<summary>
   ///借阅权限
   ///</summary>
    public int readLevel {get;set;}
   ///<summary>
   ///来源
   ///</summary>
    public string source {get;set;}
   ///<summary>
   ///关键字
   ///</summary>
    public string keyWord {get;set;}
   ///<summary>
   ///入库时间
   ///</summary>
    public DateTime time {get;set;}
   ///<summary>
   ///内容简介
   ///</summary>
    public string content {get;set;}
   ///<summary>
   ///文件位置
   ///</summary>
    public string filePath {get;set;}
   ///<summary>
   ///删除标示
   ///</summary>
    public byte deleteFlag {get;set;}

}