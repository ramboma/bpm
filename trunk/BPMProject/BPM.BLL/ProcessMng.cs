using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPM.Entity.Process;
namespace BPM.BLL
{
    public class ProcessMng
    {
        public static List<processTemplate> 获取流程模板()
        {
            //获取配置文件中的模板
            return new List<processTemplate>();
        }

        public static 流程实例 CreateProcessInstance(processTemplate temp)
        {
            //根据模板创建一个流程实例
            var instance = new 流程实例();
            instance.流程实例id = 1;
            instance.流程实例名称 = "第一个实例";
            instance.模板Id = temp.模板Id;
            instance.申请时间 = DateTime.Now;
            instance.申请用户 = 1;//当前用户
            instance.StepInstanceList = new List<步骤实例>();
            var currentStep = temp.HeaderStep;
            while (currentStep != null)
            {
                步骤实例 current = new 步骤实例();
                current.步骤实例id = new Random().Next();
                current.步骤模板 = currentStep;
                instance.StepInstanceList.Add(current);
                //下一步骤
                currentStep = currentStep.下一步骤;
            }
            //创建新流程实例
            return instance;
        }
        /// <summary>
        /// 步骤提交
        /// </summary>
        /// <param name="stepInstance"></param>
        /// <returns>1,提交成功，2，流程结束，3，提交失败</returns>
        public static int SubmitStep(步骤实例 stepInstance)
        {
            int iReturnCode = 0;
            //获取步骤模板
            StepTemplate temp = new StepTemplate();
            string actionName = temp.提交动作事件;//assetlibrary.SubmitPaiChe
            string data = stepInstance.数据;//

            string queryurl = "http://localhost:3665/Route/LibraryHandler.ashx";
            string c = actionName.Split(new char[] { '.' })[0];
            string m = actionName.Split(new char[] { '.' })[1];
            string p = data;

            ReturnBase rb = Post(queryurl, c, m, p);
            if (rb.Code == 1)
            {
                //提交成功,更新步骤状态
                stepInstance.操作人 = 1;
                stepInstance.操作动作 = actionName;

                //修改当前步骤
                var nextStep = GetNextStep(stepInstance);
                //下一步为空，说明流程走完了
                if (nextStep == null)
                {
                    stepInstance.流程实例.流程状态 = 1; //流程结束
                    iReturnCode = 3;
                }
                else
                {
                    stepInstance.流程实例.当前步骤 = nextStep;
                    iReturnCode = 2;
                }

            }
            iReturnCode = 3;
            return iReturnCode;
        }

        private static 步骤实例 GetNextStep(步骤实例 stepInstance)
        {
            foreach (var si in stepInstance.流程实例.StepInstanceList)
            {
                if (si.步骤模板.步骤模板Id == stepInstance.步骤模板.下一步骤.步骤模板Id)
                {
                    return si;
                }
            }
            return null;

        }


        private static ReturnBase Post(string queryurl, string c, string m, string p)
        {
            //post数据，获取实际数据
            return new ReturnBase() { Code = 1 };
        }

    }


}
