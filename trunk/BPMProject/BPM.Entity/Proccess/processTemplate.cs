// File:    processTemplate.cs
// Author:  Administrator
// Created: 2015��6��5�� 9:47:27
// Purpose: Definition of Class processTemplate

using System;

namespace BPM.Entity.Process
{

    public class processTemplate
    {
        ///<summary>
        ///ģ��Id
        ///</summary>
        public int ģ��Id { get; set; }
        ///<summary>
        ///ģ������
        ///</summary>
        public int ģ������ { get; set; }
        ///<summary>
        ///��������Ȩ��
        ///</summary>
        public int ��������Ȩ�� { get; set; }

        /// <summary>
        /// ��һ������
        /// </summary>
        public StepTemplate HeaderStep { get; set; }

    }
}