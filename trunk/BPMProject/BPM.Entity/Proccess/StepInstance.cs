// File:    步骤实例.cs
// Author:  Administrator
// Created: 2015年6月5日 9:47:31
// Purpose: Definition of Class 步骤实例

using System;
using ServiceStack.DataAnnotations;
namespace BPM.Entity.Process
{
    public class StepInstance
    {
        ///<summary>
        ///步骤实例ID
        ///</summary>
        [AutoIncrement]
        public long stepid { get; set; }

        ///<summary>
        ///步骤模板Id
        ///</summary>
        public long StepTemplateId { get; set; }
        public string StepTemplateName { get; set; }  
        [Ignore]
        public StepTemplate StepTemplate { get; set; }


        ///<summary>
        ///审批人
        ///</summary>
        public int Approver { get; set; }

        ///<summary>
        ///流程实例ID
        ///</summary>
        public long FlowInstanceId { get; set; }
        [Ignore]
        public FlowInstance FlowInstance { get; set; }

        ///<summary>
        ///操作人
        ///</summary>
        public int Operator { get; set; }

        ///<summary>
        ///操作动作
        ///</summary>
        public string OperateAction { get; set; }

        ///<summary>
        ///数据
        ///</summary>
        public string Data { get; set; }

    }
}