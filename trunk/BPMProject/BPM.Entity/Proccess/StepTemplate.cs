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
    [Serializable]
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


        ///<summary>
        ///��һ����
        ///</summary>
        [XmlAttribute]
        public int PreStepId { get; set; }
        ///<summary>
        ///��һ����
        ///</summary>
        [XmlAttribute]
        public int NextStepId { get; set; }

        ///<summary>
        ///�ύ�����¼�
        ///</summary>
        [XmlAttribute]
        public string SubmitAction { get; set; }

        ///<summary>
        ///���ض����¼�
        ///</summary>
        [XmlAttribute]
        public string RebackAction { get; set; }

        ///<summary>
        ///�¼�ʵ��
        ///</summary>
        public string  DataDto { get; set; }

    }
}