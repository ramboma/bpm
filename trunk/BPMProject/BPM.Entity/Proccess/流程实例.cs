// File:    ����ʵ��.cs
// Author:  Administrator
// Created: 2015��6��5�� 9:47:30
// Purpose: Definition of Class ����ʵ��

using System;
using System.Collections.Generic;

namespace BPM.Entity.Process
{
    public class ����ʵ��
    {
        ///<summary>
        ///����ʵ��ID
        ///</summary>
        public int ����ʵ��id { get; set; }

        ///<summary>
        ///����ʵ������
        ///</summary>
        public String ����ʵ������ { get; set; }

        ///<summary>
        ///ģ��Id
        ///</summary>
        public int ģ��Id { get; set; }

        ///<summary>
        ///ģ������
        ///</summary>
        public String ģ������ { get; set; }

        ///<summary>
        ///�����û�
        ///</summary>
        public int �����û� { get; set; }

        ///<summary>
        ///����ʱ��
        ///</summary>
        public System.DateTime ����ʱ�� { get; set; }

        ///<summary>
        ///����״̬
        ///</summary>
        public int ����״̬ { get; set; }

        ///<summary>
        ///��ǰ����
        ///</summary>
        public StepInstance ��ǰ���� { get; set; }

        public List<StepInstance> StepInstanceList { get; set; }

    }
}