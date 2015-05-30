<%@ WebHandler Language="C#" Class="LibraryHandler" %>

using System;
using System.Web;
using BPM.BLL;
using BPM.Entity.DTO;
using BPM.Entity.Paged;
using Newtonsoft.Json;
public class LibraryHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        
        //执行查询，返回实体列表

        if (context.Request.RequestType == "POST")
        {
            string classname = context.Request.Form["c"];
            string method = context.Request.Form["m"];
            string strParams = context.Request.Form["p"];
            if (!valideParam(classname, method, strParams))
            {
                //返回错误实体
                context.Response.Write(GetErrorReturn(ResponseCode.ErrorParameter, "参数错误"));
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

            context.Response.Write(GetErrorReturn(ResponseCode.FAIL, "此接口只支持POST调用"));
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
                switch (method.ToLower())
                {
                    #region 类型
                    case "submitlibrary":
                        {
                            try
                            {
                                var productinput = JsonConvert.DeserializeObject<ProductInput>(strParams);
                                var vProjectList = BPM.BLL.ObjMng.SubmitLibrary(productinput);
                                return GetSuccessReturn(vProjectList);
                            }
                            catch (Exception e1)
                            {
                                return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                            }
                        }
                        //获取类型
                    case "providermng":
                        {
                            try
                            {
                                var lstProviderList = ProviderMng.GetCatalogInfo(int.Parse(strParams));
                                return GetSuccessReturn(lstProviderList);
                            }
                            catch (Exception eall)
                            {
                                return GetErrorReturn(ResponseCode.FAIL, eall.Message);
                            }
                        }
                        //获取类型树
                    case "providertree":
                        {
                            try
                            {
                                var lstProviderList = ProviderMng.GetCatalogInfoTree(int.Parse(strParams));
                                return GetSuccessReturn(lstProviderList);
                            }
                            catch (Exception eall)
                            {
                                return GetErrorReturn(ResponseCode.FAIL, eall.Message);
                            }
                        }
	#endregion
#region 资产

                        //分页获取品名
                    case "getallpingming":
                        {
                            try
                            {
                                var pageDto = JsonConvert.DeserializeObject<PageDto>(strParams);
                                var lstAllPingMing = ObjMng.GetAllPingMing(pageDto);
                                return GetSuccessReturn(lstAllPingMing);
                            }
                            catch (Exception eall)
                            {
                                return GetErrorReturn(ResponseCode.FAIL, eall.Message);
                            }

                        }
                        //获取品名树
                    case "getallpingmingtree":
                        {
                            try
                            {
                                var lstAllPingMingTree = ObjMng.GetPinMingTree();
                                return GetSuccessReturn(lstAllPingMingTree);
                            }
                            catch (Exception eall)
                            {
                                return GetErrorReturn(ResponseCode.FAIL, eall.Message);
                            }
                        }
                    //获取品名信息
                    case "getpingminginfo":
                        {
                            try
                            {
                                var vProjectList = BPM.BLL.ObjMng.GetPingMingInfo(strParams);
                                return GetSuccessReturn(vProjectList);
                            }
                            catch (Exception e1)
                            {
                                return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                            }
                        }
                    #region 资产出库
                    //保存资产出库信息
                    case "saveproductlog":
                        try
                        {
                            var productLog = JsonConvert.DeserializeObject<ProductLog>(strParams);
                            var vResult = ObjMng.SaveProductLog(productLog);
                            return GetSuccessReturn(vResult);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }
                        //出库时获取品名信息和剩余数量
                    case "getproductstatisc":
                        try
                        {
                            var vResult = ObjMng.GetProductStatisc(strParams);
                            return GetSuccessReturn(vResult);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }

	#endregion
#region 资产查询
                    case "searchproduct":
                        try
                        {
                            var productSearchDto = JsonConvert.DeserializeObject<ProductSearchDto>(strParams);
                            var vProjectList = ObjMng.SearchProduct(productSearchDto);
                            return GetSuccessReturn(vProjectList);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }
#endregion
#region 资产统计
                    case "StaticsProduct":

                        break;
#endregion
	#endregion
                    #region 装备
                    case "getequiementlist":
                        try
                        {
                            var vProjectList = EquipmentMng.GetEquipmentTree();
                            return GetSuccessReturn(vProjectList);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }

                    //保存装备出入库
                    case "saveequiement":
                         try
                        {
                            var equipmentLog = JsonConvert.DeserializeObject<EquipmentLog>(strParams);
                            var vResult = EquipmentMng.SaveEquipmentLog(equipmentLog);
                            return GetSuccessReturn(vResult);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }
                    //装备报废
                    case "kickequiement":
                        try
                        {
                            var vProjectList = EquipmentMng.KickEquiement(int.Parse(strParams));
                            return GetSuccessReturn(vProjectList);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }
#region 装备品名增删改查
                    case "saveequipment":
                         try
                        {
                            var equipment= JsonConvert.DeserializeObject<Equipment>(strParams);
                            var vProjectList = EquipmentMng.SaveEquipment(equipment);
                            return GetSuccessReturn(vProjectList);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }

	#endregion
                    #endregion
                    //文档上传
                    case "uploadequiementdoc":
                        break;
                    #region 图书文档
#region 图书上架
                    case "savebook":
                        try
                        {
                            var book = JsonConvert.DeserializeObject<BookInfo>(strParams);
                            var vResult = BookMng.SaveBookInfo(book);
                            return GetSuccessReturn(vResult);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }
                    case "getbook":
                        try
                        {
                            var vResult = BookMng.GetBookInfo(int.Parse(strParams));
                            return GetSuccessReturn(vResult);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }
#endregion
                        //图书借阅
                        //获取所有借阅的图书
                    case "getreturnbooks":
                         try
                        {
                            var vResult = BookMng.GetReturnBooks();
                            return GetSuccessReturn(vResult);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }
                        //出借图书
                    case "borrowbook":
                        try
                        {

                            var borrow = JsonConvert.DeserializeObject<BookLog>(strParams);
                            var vResult = BookMng.BorrowBook(borrow);
                            return GetSuccessReturn(vResult);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }
                        //归还图书
                    case "returnbook":
                        try
                        {
                            var vResult = BookMng.ReturnBook(long.Parse(strParams));
                            return GetSuccessReturn(vResult);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }
                        //文档借阅
                        //文档入库
                    
                    #endregion

                    #region 文档
#region 文档入库
                    case "savedoc":
                        try
                        {
                            var book = JsonConvert.DeserializeObject<DocInfo>(strParams);
                            var vResult = DocMng.SaveDocInfo(book);
                            return GetSuccessReturn(vResult);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }
                    case "getdoc":
                        try
                        {
                            var vResult = DocMng.GetDocInfo(int.Parse(strParams));
                            return GetSuccessReturn(vResult);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }
#endregion
                        //图书借阅
                        //获取所有借阅的图书
                    case "getreturndocs":
                         try
                        {
                            var vResult = DocMng.GetReturnDocs();
                            return GetSuccessReturn(vResult);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }
                        //出借图书
                    case "borrowdoc":
                        try
                        {

                            var borrow = JsonConvert.DeserializeObject<DocLog>(strParams);
                            var vResult = DocMng.BorrowDoc(borrow);
                            return GetSuccessReturn(vResult);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }
                        //归还图书
                    case "returndoc":
                        try
                        {
                            var vResult = DocMng.ReturnDoc(long.Parse(strParams));
                            return GetSuccessReturn(vResult);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }
                    
                    #endregion
                    #region 品名表增删改查
                    case "addproduct":
                        try
                        {
                            var product = JsonConvert.DeserializeObject<Product>(strParams);
                            var vProjectList = ObjMng.AddProduct(product);
                            return GetSuccessReturn(vProjectList);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }

                    case "deleteproduct":
                        try
                        {
                            var product = JsonConvert.DeserializeObject<Product>(strParams);
                            var vProjectList = ObjMng.DeleteProduct(product);
                            return GetSuccessReturn(vProjectList);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }
                    case "updateproduct":
                        try
                        {
                            var productSearchDto = JsonConvert.DeserializeObject<Product>(strParams);
                            var vProjectList = ObjMng.UpdateProduct(productSearchDto);
                            return GetSuccessReturn(vProjectList);
                        }
                        catch (Exception e1)
                        {
                            return GetErrorReturn(ResponseCode.FAIL, e1.Message);
                        }
                    #endregion
                }
                break;
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
            default:
                break;
        }
        //返回错误实体

        return GetErrorReturn(ResponseCode.ErrorParameter, "输入参数错误，请重新输入");
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    /// <summary>
    /// 简单的成功代码生成方法
    /// </summary>
    /// <param name="vProjectList"></param>
    /// <returns></returns>
    private static string GetSuccessReturn(object vProjectList)
    {
        ReturnBase rb = new ReturnBase();
        rb.Code = ResponseCode.SUCCESS;
        rb.Message = "";
        rb.Result = vProjectList;
        string strJsonResult = JsonConvert.SerializeObject(rb);
        return strJsonResult;
    }
    /// <summary>
    /// 简单的错误代码生成方法
    /// </summary>
    /// <param name="code"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    private string GetErrorReturn(int code, string message)
    {
        ReturnBase rb = new ReturnBase();
        rb.Code = code;
        rb.Message = message;
        rb.Result = null;
        return JsonConvert.SerializeObject(rb);
    }
}