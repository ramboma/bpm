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
            case "equipmentinputfactory":
                try
                {
                    var obj=JsonConvert.DeserializeObject<EquipmentRepair>(strParams);
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