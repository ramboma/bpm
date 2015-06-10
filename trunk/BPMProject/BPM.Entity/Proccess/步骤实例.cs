// File:    步骤实例.cs
// Author:  Administrator
// Created: 2015年6月5日 9:47:31
// Purpose: Definition of Class 步骤实例

using System;

namespace BPM.Entity.Process
{
    public class StepInstance
    {
        ///<summary>
        ///步骤实例ID
        ///</summary>
        public int stepid { get; set; }

        ///<summary>
        ///步骤模板Id
        ///</summary>
        public StepTemplate StepTemplate { get; set; }


        ///<summary>
        ///审批人
        ///</summary>
        public int 审批人 { get; set; }

        ///<summary>
        ///流程实例ID
        ///</summary>
        public 流程实例 流程实例 { get; set; }

        ///<summary>
        ///操作人
        ///</summary>
        public int 操作人 { get; set; }

        ///<summary>
        ///操作动作
        ///</summary>
        public string 操作动作 { get; set; }

        ///<summary>
        ///数据
        ///</summary>
        public string 数据 { get; set; }

    }
}