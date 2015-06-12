using System;
using Newtonsoft.Json;
using BPM.Common;
using BPM.BLL;
using BPM.Entity.DTO;
using BPM.Entity.Paged;
using BPM.Entity;
using System.Web;
using System.Web.SessionState;
/// <summary>
/// MakeAssert 的摘要说明
/// </summary>
public class SysAssert
{
    public static string ProcRequest(string method, string strParams)
    {
        switch (method.ToLower())
        {
            #region 员工信息增删改查
            case "getallemplyeeinfo":
                {
                    try
                    {
                        var vProjectList = BPM.BLL.SysMng.GetAllEmployeeInfo();
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            case "getemplinfobyid":
                {
                    try
                    {
                        var vProjectList = BPM.BLL.SysMng.GetEmployeeInfoById(long.Parse(strParams));
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            case "addemplyeeinfo":
                {
                    try
                    {
                        var productinput = JsonConvert.DeserializeObject<Employee>(strParams);
                        long vProjectList = BPM.BLL.SysMng.AddEmployeeInfo(productinput);
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            case "updateemployee":
                {
                    try
                    {
                        var productinput = JsonConvert.DeserializeObject<Employee>(strParams);
                        long vProjectList = BPM.BLL.SysMng.UpdateEmployeeInfo(productinput);
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            case "deleteemployee":
                {
                    try
                    {
                        long vProjectList = BPM.BLL.SysMng.DeleteEmployeeInfo(int.Parse(strParams));
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            #endregion

            #region 角色增删改查
            case "addroleinfo":
                {
                    try
                    {
                        var roleInput = JsonConvert.DeserializeObject<Role>(strParams);
                        long vProjectList = BPM.BLL.SysMng.AddRoleInfo(roleInput);
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            case "getallroleinfo":
                {
                    try
                    {
                        var vProjectList = BPM.BLL.SysMng.GetAllRoleInfo();
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            case "updateroleinfo":
                {
                    try
                    {
                        var roleInput = JsonConvert.DeserializeObject<Role>(strParams);
                        long vProjectList = BPM.BLL.SysMng.UpdateRoleInfo(roleInput);
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            case "deleteroleinfo":
                {
                    try
                    {
                        long vProjectList = BPM.BLL.SysMng.DeleteRoleInfo(int.Parse(strParams));
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            #endregion
            #region 部门增删改查
            case "adddeptinfo":
                {
                    try
                    {
                        var departInput = JsonConvert.DeserializeObject<Department>(strParams);
                        long vProjectList = BPM.BLL.SysMng.AddDeptInfo(departInput);
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            case "getalldepttree":
                {
                    try
                    {
                        var vProjectList = BPM.BLL.SysMng.GetAllDeptInfo();
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            case "getdeptinfobyid":
                {
                    try
                    {
                        var vProjectList = BPM.BLL.SysMng.GetDepartmentInfoById(long.Parse(strParams));
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            case "getalldeptlist":
                {
                    try
                    {
                        var vDeptInfoList = BPM.BLL.SysMng.GetAllDeptInfoList();
                        return ResponseHelper.GetSuccessReturn(vDeptInfoList);
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
                        var departInput = JsonConvert.DeserializeObject<Department>(strParams);
                        long vProjectList = BPM.BLL.SysMng.UpdateDeptInfo(departInput);
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
                        long vProjectList = BPM.BLL.SysMng.DeleteDeptInfo(int.Parse(strParams));
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            case "userlogin":
                {
                    try
                    {
                        var vUserLoginInfo = JsonConvert.DeserializeObject<UserAuth>(strParams);
                        var vUserAuth= BPM.BLL.SysMng.AuthUserLogin(vUserLoginInfo);
                        if (vUserAuth.LoginState==0)
                        {
                            HttpContext.Current.Session["UserAuth"] = vUserAuth;
                            return ResponseHelper.GetSuccessReturn(vUserAuth.LoginState);
                        }
                        else
                        {
                            return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, vUserAuth.LoginState.ToString());
                        }
                    }
                    catch (Exception e1)
                    { 
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            case "getallfunctioninfo":
                {
                    try
                    {
                        var vFunctionTree = SysMng.GetAllFunctionInfoList();
                        return ResponseHelper.GetSuccessReturn(vFunctionTree);
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
    public static bool CheckAuthInfo()
    {
        UserAuthDto obj_Temp = (UserAuthDto)HttpContext.Current.Session["UserAuth"];
        if (obj_Temp != null)
        {
            if (obj_Temp.LoginState == 0)
            {
                return true;
            }
        }
        return false;
    }
    public static long GetAccessMask()
    {
        UserAuthDto obj_Temp = (UserAuthDto)HttpContext.Current.Session["UserAuth"];
        if (obj_Temp != null)
        {
            if (obj_Temp.LoginState == 0)
            {
                return obj_Temp.AccessMask;
            }
        }
        return -1;
    } 
}