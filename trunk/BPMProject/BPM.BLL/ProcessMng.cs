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

        public static FlowInstance CreateProcessInstance(processTemplate temp)
        {
            //根据模板创建一个流程实例
            var instance = new FlowInstance();
            instance.FlowInstanceId = 1;
            instance.FlowInstanceName = "第一个实例";
            instance.TemplateId = temp.模板Id;
            instance.ApproveTime = DateTime.Now;
            instance.ApproveUserId = 1;//当前用户
            instance.StepInstanceList = new List<StepInstance>();
            var currentStep = temp.HeaderStep;
            while (currentStep != null)
            {
                StepInstance current = new StepInstance();
                current.stepid = new Random().Next();
                current.StepTemplate = currentStep;
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
        public static int SubmitStep(StepInstance stepInstance)
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
                    stepInstance.FlowInstance.Status = 1; //流程结束
                    iReturnCode = 3;
                }
                else
                {
                    stepInstance.FlowInstance.CurrentStepInstance = nextStep;
                    iReturnCode = 2;
                }

            }
            iReturnCode = 3;
            return iReturnCode;
        }

        private static StepInstance GetNextStep(StepInstance stepInstance)
        {
            foreach (var si in stepInstance.FlowInstance.StepInstanceList)
            {
                if (si.StepTemplate.步骤模板Id == stepInstance.StepTemplate.下一步骤.步骤模板Id)
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
