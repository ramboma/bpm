// File:    CarApply.cs
// Author:  Administrator
// Created: 2015年5月19日 22:15:45
// Purpose: Definition of Class CarApply

using System;
using ServiceStack.DataAnnotations;
/// 车辆申请
public class CarApply
{
   ///<summary>
   ///车辆申请Id
   ///</summary>
    [AutoIncrement]
   public int applyId {get;set;}
   ///<summary>
   ///用车单位
   ///</summary>
   public string userDep {get;set;}
   ///<summary>
   ///车辆类型
   ///</summary>
   public string carType {get;set;}
   ///<summary>
   ///出发地点
   ///</summary>
   public string startPos {get;set;}
   ///<summary>
   ///目的地
   ///</summary>
   public string targetPos {get;set;}
   ///<summary>
   ///申请人
   ///</summary>
   public string carUser {get;set;}
   ///<summary>
   ///车辆用途
   ///</summary>
   public string puspose {get;set;}
   ///<summary>
   ///司机姓名
   ///</summary>
   public string driverName {get;set;}
   ///<summary>
   ///出车时间
   ///</summary>
   public DateTime startTime {get;set;}
   ///<summary>
   ///车牌号
   ///</summary>
   public string carNum {get;set;}
   ///<summary>
   ///审批人
   ///</summary>
   public string approveName {get;set;}
   ///<summary>
   ///审批时间
   ///</summary>
   public DateTime approveTime {get;set;}
   ///<summary>
   ///审批意见
   ///</summary>
   public string approveIdea {get;set;}

}