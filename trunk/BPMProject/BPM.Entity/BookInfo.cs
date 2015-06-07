// File:    BookInfo.cs
// Author:  rambo
// Created: 2015年5月23日 15:29:19
// Purpose: Definition of Class BookInfo

using System;
using ServiceStack.DataAnnotations;
/// 书籍信息表
public class BookInfo
{
   ///<summary>
   ///资料编码
   ///</summary>
    [AutoIncrement]
    public long id {get;set;}
   ///<summary>
   ///资料名称
   ///</summary>
    public string bookName {get;set;}
   ///<summary>
   ///作者
   ///</summary>
    public string author {get;set;}
   ///<summary>
   ///出版社
   ///</summary>
    public string publisher {get;set;}
   ///<summary>
   ///来源
   ///</summary>
    public string source {get;set;}
   ///<summary>
   ///单价
   ///</summary>
    public double price {get;set;}
   ///<summary>
   ///上架时间
   ///</summary>
    public DateTime time {get;set;}
   ///<summary>
   ///借阅权限
   ///</summary>
    public int readLevel {get;set;}
   ///<summary>
   ///关键字
   ///</summary>
    public string keyWord {get;set;}
   ///<summary>
   ///存放位置
   ///</summary>var
    public string location {get;set;}
   ///<summary>
   ///内容简介
   ///</summary>
    public string content {get;set;}
   ///<summary>
   ///删除标示
   ///</summary>
    public byte deleteFlag {get;set;}

}