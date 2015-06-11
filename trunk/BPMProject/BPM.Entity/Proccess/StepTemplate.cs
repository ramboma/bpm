// File:    StepTemplate.cs
// Author:  Administrator
// Created: 2015年6月5日 9:47:29
// Purpose: Definition of Class StepTemplate

using System;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace BPM.Entity.Process
{
    [XmlElement]
    public class StepTemplate
    {
        ///<summary>
        ///步骤模板Id
        ///</summary>
        [XmlAttribute]
        public int StepTemplateId { get; set; }

        ///<summary>
        ///步骤模板名称
        ///</summary>
        [XmlAttribute]
        public string StepTemplateName { get; set; }

        ///<summary>
        ///审批角色
        ///</summary>
        [XmlAttribute]
        public int RoleId { get; set; }

        ///<summary>
        ///所属流程
        ///</summary>
        [XmlAttribute]
        public int ProcessTemplateId { get; set; }

        [XmlAttribute]
        public int PreStepId { get; set; }
        [XmlAttribute]
        public int NextStepId { get; set; }
        ///<summary>
        ///上一步骤
        ///</summary>
        public StepTemplate PreStep { get; set; }

        ///<summary>
        ///下一步骤
        ///</summary>
        public StepTemplate NextStep { get; set; }

        ///<summary>
        ///提交动作事件
        ///</summary>
        public string SubmitAction { get; set; }

        ///<summary>
        ///驳回动作事件
        ///</summary>
        public string RebackAction { get; set; }

        ///<summary>
        ///事件实体
        ///</summary>
        public string  DataDto { get; set; }

    }
}