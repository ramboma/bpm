// File:    StepTemplate.cs
// Author:  Administrator
// Created: 2015��6��5�� 9:47:29
// Purpose: Definition of Class StepTemplate

using System;

namespace BPM.Entity.Process
{
    public class StepTemplate
    {
        ///<summary>
        ///����ģ��Id
        ///</summary>
        public int ����ģ��Id { get; set; }

        ///<summary>
        ///����ģ������
        ///</summary>
        public string ����ģ������ { get; set; }

        ///<summary>
        ///������ɫ
        ///</summary>
        public int ������ɫ { get; set; }

        ///<summary>
        ///��������
        ///</summary>
        public int �������� { get; set; }

        ///<summary>
        ///��һ����
        ///</summary>
        public StepTemplate ��һ���� { get; set; }

        ///<summary>
        ///��һ����
        ///</summary>
        public StepTemplate ��һ���� { get; set; }

        ///<summary>
        ///�ύ�����¼�
        ///</summary>
        public string �ύ�����¼� { get; set; }

        ///<summary>
        ///���ض����¼�
        ///</summary>
        public int ���ض����¼� { get; set; }

        ///<summary>
        ///�¼�ʵ��
        ///</summary>
        public int �¼�ʵ�� { get; set; }

    }
}