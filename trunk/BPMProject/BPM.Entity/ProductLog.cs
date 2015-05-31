// File:    ProductLog.cs
// Author:  rambo
// Created: 2015��5��31�� 12:34:27
// Purpose: Definition of Class ProductLog

using System;
using ServiceStack.DataAnnotations;
/// �ʲ�����
public class ProductLog
{
   ///<summary>
   ///Id
   ///</summary>
    [AutoIncrement]
    public long id {get;set;}
   ///<summary>
   ///ʱ��
   ///</summary>
    public DateTime time {get;set;}
   ///<summary>
   ///������Id
   ///</summary>
    public long applyId {get;set;}
   ///<summary>
   ///��׼��Id
   ///</summary>
    public long approveId {get;set;}
   ///<summary>
   ///���������
   ///</summary>
    public long relativeTask {get;set;}
   ///<summary>
   ///�������Ա
   ///</summary>
    public long managerId {get;set;}

}