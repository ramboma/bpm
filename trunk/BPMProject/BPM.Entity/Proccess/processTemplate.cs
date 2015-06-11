// File:    processTemplate.cs
// Author:  Administrator
// Created: 2015年6月5日 9:47:27
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

        [XmlAttribute]
        public int StartStep { get; set; }
        [XmlArray]
        public List<StepTemplate> StepTemplateList { get; set; }
        /// <summary>
        /// 第一个步骤
        /// </summary>
        public StepTemplate HeaderStep { get; set; }

        
    }
    [XmlRoot]
    public class ProcessTemplateList
    {
        [XmlArray]
        [XmlArrayItem("ProcessTemplate")]
        public List<ProcessTemplate> Lists { get; set; }
        public static ProcessTemplate SerialXml(string path)
        {
            FileStream fs = null;

            XmlSerializer xs = new XmlSerializer(typeof(ProcessTemplate));
            fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            var template = (ProcessTemplate)xs.Deserialize(fs);
            fs.Close();
            return template;

        }

    }
}