// File:    Equipment.cs
// Author:  Administrator
// Created: 2015��5��27�� 9:01:08
// Purpose: Definition of Class Equipment

using System;
using ServiceStack.DataAnnotations;
/// �豸��Ϣ
public class Equipment
{
    ///<summary>
   ///�豸����
   ///</summary>
   [AutoIncrement] 
   public long id {get;set;}
    ///<summary>
   ///�豸����
   ///</summary>
   public string equipmentName {get;set;}
    ///<summary>
   ///�ͺ�
   ///</summary>
   public string model {get;set;}
    ///<summary>
   ///���
   ///</summary>
   public string standard {get;set;}
    ///<summary>
   ///��Դ
   ///</summary>
   public long source {get;set;}
    ///<summary>
   ///����
   ///</summary>
   public double price {get;set;}
    ///<summary>
   ///���ʱ��
   ///</summary>
   public DateTime updateTime {get;set;}
    ///<summary>
   ///�豸״̬��ʼ
   ///</summary>
   public string equipmentStatus {get;set;}
    ///<summary>
   ///���ܵ�λ
   ///</summary>
   public long departMent {get;set;}
    ///<summary>
   ///�����ĵ�
   ///</summary>
   public string docPath {get;set;}
    ///<summary>
   ///ɾ����ʾ
   ///</summary>
   public byte hasDelete {get;set;}
    ///<summary>
   ///������
   ///</summary>
   public long keeper {get;set;}

    /// <summary>
    /// ������
    /// </summary>
   public string FactoryName { get; set; }
    /// <summary>
    /// ��Ӧ����
    /// </summary>
   public string SalerName { get; set; }
    /// <summary>
    /// ����ʱ��
    /// </summary>
   public DateTime ProductTime { get; set; }

}