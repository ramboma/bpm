// File:    processTemplate.cs
// Author:  Administrator
// Created: 2015��6��5�� 9:47:27
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
        ///ģ��Id
        ///</summary>
        [XmlAttribute]
        public int TemplateId { get; set; }
        ///<summary>
        ///ģ������
        ///</summary>
        [XmlAttribute]
        public int TemplateName { get; set; }
        ///<summary>
        ///��������Ȩ��
        ///</summary>
        [XmlAttribute]
        public int RoleId { get; set; }

        /// <summary>
        /// ��һ������
        /// </summary>
        public StepTemplate HeaderStep { get; set; }

        public static void SerialXml(string path)
        {
            
        }

    }
}