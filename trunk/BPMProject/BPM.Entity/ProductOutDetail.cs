// File:    ProductOutDetail.cs
// Author:  rambo
// Created: 2015��5��31�� 12:34:27
// Purpose: Definition of Class ProductOutDetail

using System;

/// ���������
public class ProductOutDetail
{
   ///<summary>
   ///id
   ///</summary>
    public long id {get;set;}
   ///<summary>
   ///�����
   ///</summary>
    public long productLogId {get;set;}
   ///<summary>
   ///����
   ///</summary>
    public long productInputId {get;set;}
   ///<summary>
   ///����
   ///</summary>
    public int quantity {get;set;}

}