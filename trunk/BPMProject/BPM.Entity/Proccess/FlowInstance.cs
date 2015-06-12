// File:    ����ʵ��.cs
// Author:  Administrator
// Created: 2015��6��5�� 9:47:30
// Purpose: Definition of Class ����ʵ��

using System;
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
namespace BPM.Entity.Process
{
    public class FlowInstance
    {
        ///<summary>
        ///����ʵ��ID
        ///</summary>
        [AutoIncrement]
        public long FlowInstanceId { get; set; }

        ///<summary>
        ///����ʵ������
        ///</summary>
        public String FlowInstanceName { get; set; }

        ///<summary>
        ///ģ��Id
        ///</summary>
        public int TemplateId { get; set; }

        ///<summary>
        ///ģ������
        ///</summary>
        public String TemplateName { get; set; }

        ///<summary>
        ///�����û�
        ///</summary>
        public long ApproveUserId { get; set; }

        ///<summary>
        ///����ʱ��
        ///</summary>
        public System.DateTime ApproveTime { get; set; }

        ///<summary>
        ///����״̬
        ///</summary>
        public int Status { get; set; }

        ///<summary>
        ///��ǰ����
        ///</summary>
        public long CurrentStepInstanceId { get; set; }
        [Ignore]
        public StepInstance CurrentStepInstance { get; set; }

        [Ignore]
        public List<StepInstance> StepInstanceList { get; set; }

    }
}