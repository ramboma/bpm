// File:    流程实例.cs
// Author:  Administrator
// Created: 2015年6月5日 9:47:30
// Purpose: Definition of Class 流程实例

using System;
using System.Collections.Generic;

namespace BPM.Entity.Process
{
    public class FlowInstance
    {
        ///<summary>
        ///流程实例ID
        ///</summary>
        public int FlowInstanceId { get; set; }

        ///<summary>
        ///流程实例名称
        ///</summary>
        public String FlowInstanceName { get; set; }

        ///<summary>
        ///模板Id
        ///</summary>
        public int TemplateId { get; set; }

        ///<summary>
        ///模板名称
        ///</summary>
        public String TemplateName { get; set; }

        ///<summary>
        ///申请用户
        ///</summary>
        public int ApproveUserId { get; set; }

        ///<summary>
        ///申请时间
        ///</summary>
        public System.DateTime ApproveTime { get; set; }

        ///<summary>
        ///流程状态
        ///</summary>
        public int Status { get; set; }

        ///<summary>
        ///当前步骤
        ///</summary>
        public StepInstance CurrentStepInstance { get; set; }

        public List<StepInstance> StepInstanceList { get; set; }

    }
}