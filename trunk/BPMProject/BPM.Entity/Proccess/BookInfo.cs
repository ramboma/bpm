// File:    BookInfo.cs
// Author:  rambo
// Created: 2015��5��23�� 15:29:19
// Purpose: Definition of Class BookInfo

using System;
using ServiceStack.DataAnnotations;
/// �鼮��Ϣ��
public class BookInfo
{
   ///<summary>
   ///���ϱ���
   ///</summary>
    [AutoIncrement]
    public long id {get;set;}
   ///<summary>
   ///��������
   ///</summary>
    public string bookName {get;set;}
   ///<summary>
   ///����
   ///</summary>
    public string author {get;set;}
   ///<summary>
   ///������
   ///</summary>
    public string publisher {get;set;}
   ///<summary>
   ///��Դ
   ///</summary>
    public string source {get;set;}
   ///<summary>
   ///����
   ///</summary>
    public double price {get;set;}
   ///<summary>
   ///�ϼ�ʱ��
   ///</summary>
    public DateTime time {get;set;}
   ///<summary>
   ///����Ȩ��
   ///</summary>
    public int readLevel {get;set;}
   ///<summary>
   ///�ؼ���
   ///</summary>
    public string keyWord {get;set;}
   ///<summary>
   ///���λ��
   ///</summary>var
    public string location {get;set;}
   ///<summary>
   ///���ݼ��
   ///</summary>
    public string content {get;set;}
   ///<summary>
   ///ɾ����ʾ
   ///</summary>
    public byte deleteFlag {get;set;}

}