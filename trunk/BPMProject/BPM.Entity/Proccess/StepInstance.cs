// File:    ����ʵ��.cs
// Author:  Administrator
// Created: 2015��6��5�� 9:47:31
// Purpose: Definition of Class ����ʵ��

using System;
using ServiceStack.DataAnnotations;
namespace BPM.Entity.Process
{
    public class StepInstance
    {
        ///<summary>
        ///����ʵ��ID
        ///</summary>
        [AutoIncrement]
        public long stepid { get; set; }

        ///<summary>
        ///����ģ��Id
        ///</summary>
        public long StepTemplateId { get; set; }
        public string StepTemplateName { get; set; }  
        [Ignore]
        public StepTemplate StepTemplate { get; set; }


        ///<summary>
        ///������
        ///</summary>
        public int Approver { get; set; }

        ///<summary>
        ///����ʵ��ID
        ///</summary>
        public long FlowInstanceId { get; set; }
        [Ignore]
        public FlowInstance FlowInstance { get; set; }

        ///<summary>
        ///������
        ///</summary>
        public int Operator { get; set; }

        ///<summary>
        ///��������
        ///</summary>
        public string OperateAction { get; set; }

        ///<summary>
        ///����
        ///</summary>
        public string Data { get; set; }

    }
}