using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using BPM.Common;
using BPM.Entity.Proccess;
/// <summary>
/// EquipmentRepair 的摘要说明
/// </summary>
public class EquipmentRepairServer
{
    public static string ProcRequest(string method, string strParams)
    {
        switch (method.ToLower())
        {
                //新增流程数据
            case "initequipmentrepair":
                try
                {
                    var vProjectList = BPM.BLL.EquipmentRepairMng.InitEquipmentRepair(long.Parse(strParams));
                    return ResponseHelper.GetSuccessReturn(vProjectList);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
                //打开流程数据
            case "openequipmentrepair":
                try
                {
                    var vProjectList = BPM.BLL.EquipmentRepairMng.OpenEquipmentRepair(long.Parse(strParams));
                    return ResponseHelper.GetSuccessReturn(vProjectList);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            case "createequipmentrepair":
                try
                {
                    var vProjectList = BPM.BLL.EquipmentRepairMng.createEquipmentRepair();
                    return ResponseHelper.GetSuccessReturn(vProjectList);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
                //步骤1,装备入库
            case "equipmentinputfactory":
                try
                {
                    var obj = JsonConvert.DeserializeObject<EquipmentRepair>(strParams);
                    var vProjectList = BPM.BLL.EquipmentRepairMng.EquipmentInputFactory(obj);
                    return ResponseHelper.GetSuccessReturn(vProjectList);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }

        }
        return ResponseHelper.GetErrorReturn(ResponseCode.ErrorParameter, "输入参数错误，请重新输入");
    }
}