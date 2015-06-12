using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPM.Entity.Process;
using System.IO;
using System.Xml.Serialization;
using ServiceStack.OrmLite;
using BPM.ORMLite;
namespace BPM.BLL
{
    public class ProcessMng
    {
        /// <summary>
        /// 获取配置文件中的模板
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static ProcessTemplateList GetAllTemplateList(string path)
        {
            FileStream fs = null;
            XmlSerializer xs = new XmlSerializer(typeof(ProcessTemplateList));
            fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            var listResult = (ProcessTemplateList)xs.Deserialize(fs);
            fs.Close();
            foreach (ProcessTemplate template in listResult.Lists)
            {
                template.HeaderStep = template.StepTemplateList.SingleOrDefault(s => s.StepTemplateId == template.StartStep);
                template.RearStep = template.StepTemplateList.SingleOrDefault(s => s.StepTemplateId == template.EndStep);
            }
            return listResult;
        }
        /// <summary>
        /// 获取步骤所属的流程模板
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentStepId"></param>
        /// <returns></returns>
        public static ProcessTemplate GetParentProcessTemplate(string path,int currentStepId)
        {
            ProcessTemplate template=null;
            ProcessTemplateList list = GetAllTemplateList(path);
            foreach (var v in list.Lists)
            {
                if (v.StepTemplateList.Find(s => s.ProcessTemplateId == v.TemplateId) != null)
                {
                    template = v;
                    break;
                }
            }
            return template;
        }
        /// <summary>
        /// 返回当前步骤的后一步骤
        /// </summary>
        /// <param name="list"></param>
        /// <param name="currentStepId"></param>
        /// <returns></returns>
        public static StepTemplate GetNextStepTemplate(ProcessTemplate processTemplate, int currentStepId)
        {

            if (currentStepId == processTemplate.EndStep)
                return null;
            StepTemplate stReturn = null;
            foreach (var step in processTemplate.StepTemplateList)
            {
                if (currentStepId == step.PreStepId)
                {
                    stReturn = step;
                    break;
                }

            }
            return stReturn;
        }
        /// <summary>
        /// 返回当前步骤的前一步骤
        /// </summary>
        /// <param name="list"></param>
        /// <param name="currentStepId"></param>
        /// <returns></returns>
        public static StepTemplate GetPreStepTemplate(ProcessTemplate processTemplate, int currentStepId)
        {

            if (currentStepId == processTemplate.StartStep)
                return null;
            StepTemplate stReturn = null;
            foreach (var step in processTemplate.StepTemplateList)
            {
                if (currentStepId == step.NextStepId)
                {
                    stReturn = step;
                    break;
                }

            }
            return stReturn;
        }
        /// <summary>
        /// 通过模板创建新流程实例
        /// </summary>
        /// <param name="path"></param>
        /// <param name="templateId"></param>
        /// <returns></returns>
        public static FlowInstance CreateProcessInstance(string path,int templateId)
        {
            var list = GetAllTemplateList(path);
            //获取流程模板
            var temp=list.Lists.SingleOrDefault(s => s.TemplateId == templateId);
            //根据模板创建一个流程实例
            var instance = new FlowInstance();
            //instance.FlowInstanceName = "第一个实例";
            instance.TemplateId = templateId;
            instance.TemplateName = temp.TemplateName;
            instance.ApproveTime = DateTime.Now;
            instance.ApproveUserId = 1;//当前用户
            //插入流程实体
            long flowId=Utity.Connection.Insert<FlowInstance>(instance,selectIdentity:true);
            instance.FlowInstanceId = flowId;
            instance.StepInstanceList = new List<StepInstance>();

            foreach (var stepTemplate in temp.StepTemplateList)
            {
                instance.StepInstanceList.Add(CreateStepInstance(flowId,instance,stepTemplate));
            }
            //返回新流程实例
            return instance;
        }

        /// <summary>
        /// 插入步骤实体
        /// </summary>
        /// <param name="stepTemplate"></param>
        /// <returns></returns>
        private static StepInstance CreateStepInstance(long flowInstanceId,FlowInstance fInstance,StepTemplate stepTemplate)
        {
                StepInstance current = new StepInstance();
                current.FlowInstance = fInstance;
                current.FlowInstanceId = flowInstanceId;
                current.StepTemplate = stepTemplate;
                current.StepTemplateName = stepTemplate.StepTemplateName;
                long id=Utity.Connection.Insert<StepInstance>(current, selectIdentity: true);
                if (stepTemplate.PreStepId == 0)
                {
                    fInstance.CurrentStepInstanceId = id;
                    Utity.Connection.Update<FlowInstance>(fInstance);
                }
                return Utity.Connection.Single<StepInstance>(s => s.stepid == id);
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
            string actionName = temp.SubmitAction;//assetlibrary.SubmitPaiChe
            string data = stepInstance.Data;//

            string queryurl = "http://localhost:3665/Route/LibraryHandler.ashx";
            string c = actionName.Split(new char[] { '.' })[0];
            string m = actionName.Split(new char[] { '.' })[1];
            string p = data;

            ReturnBase rb = Post(queryurl, c, m, p);
            if (rb.Code == 1)
            {
                //提交成功,更新步骤状态
                stepInstance.Operator = 1;
                stepInstance.OperateAction = actionName;

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

        public static int CreateInstanceTable()
        {
            try
            {

                //创建processTemplate表
                Utity.Connection.CreateTable<FlowInstance>(overwrite:true);
                //创建StepInstance表
                Utity.Connection.CreateTable<StepInstance>(overwrite:true);
                return 1;
            }
            catch (Exception ep)
            {

                return 0;
            }

        }

    }


}
