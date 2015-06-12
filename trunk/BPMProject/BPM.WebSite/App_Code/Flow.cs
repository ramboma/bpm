﻿using System;
using Newtonsoft.Json;
using BPM.Common;
using BPM.BLL;
using BPM.Entity.DTO;
using BPM.Entity.Paged;
using BPM.Entity;
using System.Web;
using System.Web.SessionState;
/// <summary>
/// Flow 的摘要说明
/// </summary>
public class Flow
{
    public static string processTemplatePath = "\\xml\\ProcessTemplate.xml";
    public static string ProcRequest(string method, string strParams)
    {
        string templatePath = System.Web.HttpContext.Current.Server.MapPath(processTemplatePath);
        switch (method)
        {
            //获取所有模板列表
            case "getalltemplatelist":
                {
                    try
                    {
                        string path = System.Web.HttpContext.Current.Server.MapPath(templatePath);
                        var vProjectList = BPM.BLL.ProcessMng.GetAllTemplateList(path);
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            #region 流程实例
            case "createprocessinstance":
                {
                    try
                    {
                        var flowinstance = BPM.BLL.ProcessMng.CreateProcessInstance(templatePath, int.Parse(strParams));
                        var list = BPM.BLL.ProcessMng.GetAllTemplateList(templatePath);
                        var template = list.Lists.Find(s => s.TemplateId == flowinstance.TemplateId);
                        var obj = postAction(template.CreateAction, flowinstance.FlowInstanceId.ToString());
                        FlowDto dto = new FlowDto();
                        dto.flowInstance = flowinstance;
                        dto.Date = obj.Result;
                        return ResponseHelper.GetSuccessReturn(dto);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            case "openprocessinstance":
                {
                    try
                    {
                        var flowinstance = BPM.BLL.ProcessMng.OpenProcessInstance(long.Parse(strParams));
                        var list = BPM.BLL.ProcessMng.GetAllTemplateList(templatePath);
                        var template = list.Lists.Find(s => s.TemplateId == flowinstance.TemplateId);
                        var obj = postAction(template.OpenAction, flowinstance.FlowInstanceId.ToString());
                        FlowDto dto = new FlowDto();
                        dto.flowInstance = flowinstance;
                        dto.Date = obj.Result;
                        return ResponseHelper.GetSuccessReturn(dto);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            #endregion
            #region 辅助方法
            //创建流程实例表
            case "createinstancetable":
                {
                    try
                    {
                        var vProjectList = BPM.BLL.ProcessMng.CreateInstanceTable();
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            #endregion

        }
        return ResponseHelper.GetErrorReturn(ResponseCode.ErrorParameter, "输入参数错误，请重新输入");
    }

    private static ReturnBase postAction(string action, string strparams)
    {
        string queryurl = "http://localhost:3665/Route/LibraryHandler.ashx";
        string c = action.Split(new char[] { '.' })[0];
        string m = action.Split(new char[] { '.' })[1];
        string p = strparams;
        return BPM.Common.ResponseHelper.Post(queryurl, c,m,p);
    }
}