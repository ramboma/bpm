// File:    processTemplate.cs
// Author:  Administrator
// Created: 2015��6��5�� 9:47:27
// Purpose: Definition of Class processTemplate

using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
namespace BPM.Entity.Process
{
    [Serializable]
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
        public string TemplateName { get; set; }
        ///<summary>
        ///��������Ȩ��
        ///</summary>
        [XmlAttribute]
        public int RoleId { get; set; }

        [XmlAttribute]
        public int StartStep { get; set; }
        [XmlAttribute]
        public int EndStep { get; set; }
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        [XmlAttribute]
        public string CreateAction { get; set; }
        /// <summary>
        /// ���������ݶ���
        /// </summary>
        [XmlAttribute]
        public string OpenAction{ get; set; }
        [XmlArray]
        [XmlArrayItem("StepTemplate")]
        public List<StepTemplate> StepTemplateList { get; set; }
        /// <summary>
        /// ��һ������
        /// </summary>
        public StepTemplate HeaderStep { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public StepTemplate RearStep { get; set; }
        
    }
    [Serializable]
    public class ProcessTemplateList
    {
        [XmlArray]
        [XmlArrayItem("ProcessTemplate")]
        public List<ProcessTemplate> Lists { get; set; }
       

    }
}