// File:    ����ʵ��.cs
// Author:  Administrator
// Created: 2015��6��5�� 9:47:31
// Purpose: Definition of Class ����ʵ��

using System;

namespace BPM.Entity.Process
{
    public class ����ʵ��
    {
        ///<summary>
        ///����ʵ��ID
        ///</summary>
        public int ����ʵ��id { get; set; }

        ///<summary>
        ///����ģ��Id
        ///</summary>
        public StepTemplate ����ģ�� { get; set; }


        ///<summary>
        ///������
        ///</summary>
        public int ������ { get; set; }

        ///<summary>
        ///����ʵ��ID
        ///</summary>
        public ����ʵ�� ����ʵ�� { get; set; }

        ///<summary>
        ///������
        ///</summary>
        public int ������ { get; set; }

        ///<summary>
        ///��������
        ///</summary>
        public string �������� { get; set; }

        ///<summary>
        ///����
        ///</summary>
        public string ���� { get; set; }

    }
}