// File:    StepTemplate.cs
// Author:  Administrator
// Created: 2015��6��5�� 9:47:29
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
        ///����ģ��Id
        ///</summary>
        [XmlAttribute]
        public int StepTemplateId { get; set; }

        ///<summary>
        ///����ģ������
        ///</summary>
        [XmlAttribute]
        public string StepTemplateName { get; set; }

        ///<summary>
        ///������ɫ
        ///</summary>
        [XmlAttribute]
        public int RoleId { get; set; }

        ///<summary>
        ///��������
        ///</summary>
        [XmlAttribute]
        public int ProcessTemplateId { get; set; }

        [XmlAttribute]
        public int PreStepId { get; set; }
        [XmlAttribute]
        public int NextStepId { get; set; }
        ///<summary>
        ///��һ����
        ///</summary>
        public StepTemplate PreStep { get; set; }

        ///<summary>
        ///��һ����
        ///</summary>
        public StepTemplate NextStep { get; set; }

        ///<summary>
        ///�ύ�����¼�
        ///</summary>
        public string SubmitAction { get; set; }

        ///<summary>
        ///���ض����¼�
        ///</summary>
        public string RebackAction { get; set; }

        ///<summary>
        ///�¼�ʵ��
        ///</summary>
        public string  DataDto { get; set; }

    }
}