// File:    流程实例.cs
// Author:  Administrator
// Created: 2015年6月5日 9:47:30
// Purpose: Definition of Class 流程实例

using System;
using System.Collections.Generic;

namespace BPM.Entity.Process
{
    public class 流程实例
    {
        ///<summary>
        ///流程实例ID
        ///</summary>
        public int 流程实例id { get; set; }

        ///<summary>
        ///流程实例名称
        ///</summary>
        public String 流程实例名称 { get; set; }

        ///<summary>
        ///模板Id
        ///</summary>
        public int 模板Id { get; set; }

        ///<summary>
        ///模板名称
        ///</summary>
        public String 模板名称 { get; set; }

        ///<summary>
        ///申请用户
        ///</summary>
        public int 申请用户 { get; set; }

        ///<summary>
        ///申请时间
        ///</summary>
        public System.DateTime 申请时间 { get; set; }

        ///<summary>
        ///流程状态
        ///</summary>
        public int 流程状态 { get; set; }

        ///<summary>
        ///当前步骤
        ///</summary>
        public StepInstance 当前步骤 { get; set; }

        public List<StepInstance> StepInstanceList { get; set; }

    }
}