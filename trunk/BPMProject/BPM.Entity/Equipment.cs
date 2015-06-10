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
   public long EquipmentID {get;set;}
    ///<summary>
   ///�豸����
   ///</summary>
   public string EquipmentName { get; set; }
    ///<summary>
   ///�ͺ�
   ///</summary>
   public string Model { get; set; }
    ///<summary>
   ///���
   ///</summary>
   public string Standard { get; set; }
    ///<summary>
   ///��Դ
   ///</summary>
   public long Source { get; set; }
    ///<summary>
   ///����
   ///</summary>
   public double Price { get; set; }
    ///<summary>
   ///���ʱ��
   ///</summary>
   public DateTime UpdateTime { get; set; }
    ///<summary>
   ///�豸״̬��ʼ
   ///</summary>
   public string EquipmentStatus { get; set; }
    ///<summary>
   ///���ܵ�λ
   ///</summary>
   public long KeepDept { get; set; }
    ///<summary>
   ///�����ĵ�
   ///</summary>
   public string DocPath { get; set; }
    ///<summary>
   ///ɾ����ʾ
   ///</summary>
   public byte HasDelete { get; set; }
    ///<summary>
   ///������
   ///</summary>
   public long KeepEmpl { get; set; }

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