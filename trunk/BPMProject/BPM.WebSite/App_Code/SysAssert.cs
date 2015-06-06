using System;
using Newtonsoft.Json;
using BPM.Common;
using BPM.BLL;
using BPM.Entity.DTO;
using BPM.Entity.Paged;
using BPM.Entity;
/// <summary>
/// MakeAssert 的摘要说明
/// </summary>
public class SysAssert
{
    public static string ProcRequest(string method, string strParams)
    {
        switch (method.ToLower())
        {

            case "getalldepttree":
                {
                    try
                    {
                        var productinput = JsonConvert.DeserializeObject<ProductInput>(strParams);
                        var vProjectList = BPM.BLL.ObjMng.SubmitLibrary(productinput);
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            case "updatedeptinfo":
                {
                    try
                    {
                        var productinput = JsonConvert.DeserializeObject<ProductInput>(strParams);
                        var vProjectList = BPM.BLL.ObjMng.SubmitLibrary(productinput);
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            case "deletedeptinfo":
                {
                    try
                    {
                        var vProjectList = BPM.BLL.SysMng.DeleteEptInfo();
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            case "getallemployee":
                {
                    try
                    {
                        var productinput = JsonConvert.DeserializeObject<Employee>(strParams);
                        var vProjectList = BPM.BLL.SysMng.GetAllEmployee();
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
        }
        return ResponseHelper.GetErrorReturn(ResponseCode.ErrorParameter, "输入参数错误，请重新输入");
    }
}