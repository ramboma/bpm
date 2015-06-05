// File:    CarApply.cs
// Author:  Administrator
// Created: 2015��5��19�� 22:15:45
// Purpose: Definition of Class CarApply

using System;
using ServiceStack.DataAnnotations;
/// ��������
public class CarApply
{
   ///<summary>
   ///��������Id
   ///</summary>
    [AutoIncrement]
   public int applyId {get;set;}
   ///<summary>
   ///�ó���λ
   ///</summary>
   public string userDep {get;set;}
   ///<summary>
   ///��������
   ///</summary>
   public string carType {get;set;}
   ///<summary>
   ///�����ص�
   ///</summary>
   public string startPos {get;set;}
   ///<summary>
   ///Ŀ�ĵ�
   ///</summary>
   public string targetPos {get;set;}
   ///<summary>
   ///������
   ///</summary>
   public string carUser {get;set;}
   ///<summary>
   ///������;
   ///</summary>
   public string puspose {get;set;}
   ///<summary>
   ///˾������
   ///</summary>
   public string driverName {get;set;}
   ///<summary>
   ///����ʱ��
   ///</summary>
   public DateTime startTime {get;set;}
   ///<summary>
   ///���ƺ�
   ///</summary>
   public string carNum {get;set;}
   ///<summary>
   ///������
   ///</summary>
   public string approveName {get;set;}
   ///<summary>
   ///����ʱ��
   ///</summary>
   public DateTime approveTime {get;set;}
   ///<summary>
   ///�������
   ///</summary>
   public string approveIdea {get;set;}

}