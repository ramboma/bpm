using System;
using System.Web;
using BPM.BLL;
using BPM.Entity.DTO;
using BPM.Entity.Paged;
using Newtonsoft.Json;
using BPM.Common;
using System.Web.SessionState;
public class LibraryHandler : IHttpHandler,IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";

        //执行查询，返回实体列表
   
        if (context.Request.RequestType == "POST")
        {
            HttpPostedFile uploadFile = HttpContext.Current.Request.Files["fileupload"];
            if (uploadFile != null)
            {
                //获取文件
                try
                {
                    //保存文件
                    int iFileNameIndex = uploadFile.FileName.LastIndexOf("\\");
                    string FileName = uploadFile.FileName.Substring(iFileNameIndex + 1);
                    string savePath = context.Server.MapPath("~/upload/" + FileName);
                    uploadFile.SaveAs(savePath);
                    string returnPath = @"/upload/" + FileName;
                    //返回文件路径 
                    context.Response.Write(ResponseHelper.GetSuccessReturn(returnPath));
                }
                catch (Exception ep)
                {
                    context.Response.Write(ResponseHelper.GetErrorReturn(ResponseCode.FAIL, ep.Message));
                }
                return;
            }
            string classname = context.Request.Form["c"];
            string method = context.Request.Form["m"];
            string strParams = context.Request.Form["p"];
            if (!valideParam(classname, method, strParams))
            {
                //返回错误实体
                context.Response.Write(ResponseHelper.GetErrorReturn(ResponseCode.ErrorParameter, "参数错误"));
            }
            else
            {
                //获取数据并返回
                string strResult = GetData(classname, method, strParams);
                context.Response.Write(strResult);
            }
        }
        else
        {

            context.Response.Write(ResponseHelper.GetErrorReturn(ResponseCode.FAIL, "此接口只支持POST调用"));
        }
    }
    private bool valideParam(string className, string methodName, string param)
    {
        if (string.IsNullOrEmpty(className)) return false;
        if (string.IsNullOrEmpty(methodName)) return false;
        return true;
    }
    /// <summary>
    /// 实际的执行方法
    /// </summary>
    /// <param name="classname"></param>
    /// <param name="method"></param>
    /// <param name="strParams"></param>
    /// <returns></returns>
    private string GetData(string classname, string method, string strParams)
    {
        switch (classname.ToLower())
        {
            case "assetlibrary":
                return MakeAssert.ProcRequest(method, strParams);

            case "sysconfig":
               return SysAssert.ProcRequest(method, strParams);
            #region 出库流程测试
            case "flowlibrary":
               return EquipmentRepairServer.ProcRequest(method, strParams);
#endregion
            #region 流程相关
            case "flow":
               return Flow.ProcRequest(method, strParams);
            #endregion


            //case "equiplibrary":
            //    switch (method.ToLower())
            //    {
            //        case "getallequip":
            //            try
            //            {
            //                var pageDto = Newtonsoft.Json.JsonConvert.DeserializeObject<PageDto>(strParams);

            //                var pagemng = new PageMng<Equipment>();
            //                var lstAllPingMing =pagemng.GetAllEntitysByPage(pageDto);
            //                return GetSuccessReturn(lstAllPingMing);
            //            }
            //            catch (Exception eall)
            //            {
            //                return GetErrorReturn(ResponseCode.FAIL, eall.Message);
            //            }
            //        case "saveequip":
            //            break;
            //        default:
            //            break;
            //    }
        }
        //返回错误实体
        return ResponseHelper.GetErrorReturn(ResponseCode.ErrorParameter, "输入参数错误，请重新输入");
    }

   

   


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    
}