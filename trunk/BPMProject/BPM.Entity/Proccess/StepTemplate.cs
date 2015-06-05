// File:    StepTemplate.cs
// Author:  Administrator
// Created: 2015年6月5日 9:47:29
// Purpose: Definition of Class StepTemplate

using System;

namespace BPM.Entity.Process
{
    public class StepTemplate
    {
        ///<summary>
        ///步骤模板Id
        ///</summary>
        public int 步骤模板Id { get; set; }

        ///<summary>
        ///步骤模板名称
        ///</summary>
        public string 步骤模板名称 { get; set; }

        ///<summary>
        ///审批角色
        ///</summary>
        public int 审批角色 { get; set; }

        ///<summary>
        ///所属流程
        ///</summary>
        public int 所属流程 { get; set; }

        ///<summary>
        ///上一步骤
        ///</summary>
        public StepTemplate 上一步骤 { get; set; }

        ///<summary>
        ///下一步骤
        ///</summary>
        public StepTemplate 下一步骤 { get; set; }

        ///<summary>
        ///提交动作事件
        ///</summary>
        public string 提交动作事件 { get; set; }

        ///<summary>
        ///驳回动作事件
        ///</summary>
        public int 驳回动作事件 { get; set; }

        ///<summary>
        ///事件实体
        ///</summary>
        public int 事件实体 { get; set; }

    }
}