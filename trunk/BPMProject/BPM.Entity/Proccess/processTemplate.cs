// File:    processTemplate.cs
// Author:  Administrator
// Created: 2015年6月5日 9:47:27
// Purpose: Definition of Class processTemplate

using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace BPM.Entity.Process
{
    [XmlElement]
    public class ProcessTemplate
    {
        ///<summary>
        ///模板Id
        ///</summary>
        [XmlAttribute]
        public int TemplateId { get; set; }
        ///<summary>
        ///模板名称
        ///</summary>
        [XmlAttribute]
        public int TemplateName { get; set; }
        ///<summary>
        ///流程申请权限
        ///</summary>
        [XmlAttribute]
        public int RoleId { get; set; }

        /// <summary>
        /// 第一个步骤
        /// </summary>
        public StepTemplate HeaderStep { get; set; }

        public static void SerialXml(string path)
        {
            
        }

    }
}