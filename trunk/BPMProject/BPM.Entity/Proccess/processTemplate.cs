// File:    processTemplate.cs
// Author:  Administrator
// Created: 2015年6月5日 9:47:27
// Purpose: Definition of Class processTemplate

using System;

namespace BPM.Entity.Process
{

    public class processTemplate
    {
        ///<summary>
        ///模板Id
        ///</summary>
        public int 模板Id { get; set; }
        ///<summary>
        ///模板名称
        ///</summary>
        public int 模板名称 { get; set; }
        ///<summary>
        ///流程申请权限
        ///</summary>
        public int 流程申请权限 { get; set; }

        /// <summary>
        /// 第一个步骤
        /// </summary>
        public StepTemplate HeaderStep { get; set; }

    }
}