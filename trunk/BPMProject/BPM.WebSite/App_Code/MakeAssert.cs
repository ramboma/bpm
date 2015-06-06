using System;
using Newtonsoft.Json;
using BPM.Common;
using BPM.BLL;
using BPM.Entity.DTO;
using BPM.Entity.Paged;
/// <summary>
/// MakeAssert 的摘要说明
/// </summary>
public class MakeAssert
{
    public static string ProcRequest(string method, string strParams)
    {
        switch (method.ToLower())
        {
            #region 类型
            case "submitlibrary":
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
            //获取类型
            case "providermng":
                {
                    try
                    {
                        var lstProviderList = ProviderMng.GetCatalogInfo(strParams);
                        return ResponseHelper.GetSuccessReturn(lstProviderList);
                    }
                    catch (Exception eall)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, eall.Message);
                    }
                }
            //获取类型树
            case "providertree":
                {
                    try
                    {
                        var lstProviderList = ProviderMng.GetCatalogInfoTree(strParams);
                        return ResponseHelper.GetSuccessReturn(lstProviderList);
                    }
                    catch (Exception eall)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, eall.Message);
                    }
                }
            case "getproviderbyid":
                {
                    try
                    {
                        var lstProviderList = ProviderMng.GetCatalogInfoById(int.Parse(strParams));
                        return ResponseHelper.GetSuccessReturn(lstProviderList);
                    }
                    catch (Exception eall)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, eall.Message);
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
                        return ResponseHelper.GetSuccessReturn(lstAllPingMing);
                    }
                    catch (Exception eall)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, eall.Message);
                    }

                }
            //获取品名树
            case "getallpingmingtree":
                {
                    try
                    {
                        var lstAllPingMingTree = ObjMng.GetPinMingTree();
                        return ResponseHelper.GetSuccessReturn(lstAllPingMingTree);
                    }
                    catch (Exception eall)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, eall.Message);
                    }
                }
            //获取品名信息
            case "getpingminginfo":
                {
                    try
                    {
                        var vProjectList = BPM.BLL.ObjMng.GetPingMingInfo(strParams);
                        return ResponseHelper.GetSuccessReturn(vProjectList);
                    }
                    catch (Exception e1)
                    {
                        return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                    }
                }
            #region 资产出库
            //保存资产出库信息
            case "saveproductlog":
                try
                {
                    var productLog = JsonConvert.DeserializeObject<ProductLog>(strParams);
                    var vResult = ObjMng.SaveProductLog(productLog);
                    return ResponseHelper.GetSuccessReturn(vResult);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            //出库时获取品名信息和剩余数量
            case "getproductstatisc":
                try
                {
                    var vResult = ObjMng.GetProductStatisc(strParams);
                    return ResponseHelper.GetSuccessReturn(vResult);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            //保存出库详情,返回具体的出库数和库房号，架号
            case "savefetchdetail":
                try
                {
                    var fetchDetail = JsonConvert.DeserializeObject<FetchDetailDto>(strParams);
                    var vResult = ObjMng.SaveFetchDetail(fetchDetail);
                    return ResponseHelper.GetSuccessReturn(vResult);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }

            #endregion
            #region 资产查询
            case "searchproduct":
                try
                {
                    var productSearchDto = JsonConvert.DeserializeObject<ProductSearchDto>(strParams);
                    var vProjectList = ObjMng.SearchProduct(productSearchDto);
                    return ResponseHelper.GetSuccessReturn(vProjectList);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            //查询出入库详情
            case "searchproductdetail":
                try
                {
                    var productDetailSearchDto = JsonConvert.DeserializeObject<ProductDetailSearchDto>(strParams);
                    var vProjectList = ObjMng.SearchProductDetail(productDetailSearchDto);
                    return ResponseHelper.GetSuccessReturn(vProjectList);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            #endregion
            #region 资产统计
            case "StaticsProduct":
                return "";
            #endregion
            #endregion
            #region 装备
            case "getequiementlist":
                try
                {
                    var vProjectList = EquipmentMng.GetEquipmentTree();
                    return ResponseHelper.GetSuccessReturn(vProjectList);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }

            //保存装备出入库
            case "saveequipmentlog":
                try
                {
                    var equipmentLog = JsonConvert.DeserializeObject<EquipmentLog>(strParams);
                    var vResult = EquipmentMng.SaveEquipmentLog(equipmentLog);
                    return ResponseHelper.GetSuccessReturn(vResult);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            //装备报废
            case "kickequiement":
                try
                {
                    var vProjectList = EquipmentMng.KickEquiement(int.Parse(strParams));
                    return ResponseHelper.GetSuccessReturn(vProjectList);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            #region 装备品名增删改查
            case "saveequipment":
                try
                {
                    var equipment = JsonConvert.DeserializeObject<Equipment>(strParams);
                    var vProjectList = EquipmentMng.SaveEquipment(equipment);
                    return ResponseHelper.GetSuccessReturn(vProjectList);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }

            #endregion
            #endregion
            //文档上传
            case "uploadequiementdoc":
                return "";
            #region 图书文档
            #region 图书上架
            case "savebook":
                try
                {
                    var book = JsonConvert.DeserializeObject<BookInfo>(strParams);
                    var vResult = BookMng.SaveBookInfo(book);
                    return ResponseHelper.GetSuccessReturn(vResult);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            case "getbook":
                try
                {
                    var vResult = BookMng.GetBookInfo(int.Parse(strParams));
                    return ResponseHelper.GetSuccessReturn(vResult);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            #endregion
            //图书借阅
            //获取所有借阅的图书
            case "getreturnbooks":
                try
                {
                    var vResult = BookMng.GetReturnBooks();
                    return ResponseHelper.GetSuccessReturn(vResult);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            //出借图书
            case "borrowbook":
                try
                {

                    var borrow = JsonConvert.DeserializeObject<BookLog>(strParams);
                    var vResult = BookMng.BorrowBook(borrow);
                    return ResponseHelper.GetSuccessReturn(vResult);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            //归还图书
            case "returnbook":
                try
                {
                    var vResult = BookMng.ReturnBook(long.Parse(strParams));
                    return ResponseHelper.GetSuccessReturn(vResult);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
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
                    return ResponseHelper.GetSuccessReturn(vResult);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            case "getdoc":
                try
                {
                    var vResult = DocMng.GetDocInfo(int.Parse(strParams));
                    return ResponseHelper.GetSuccessReturn(vResult);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            #endregion
            //图书借阅
            //获取所有借阅的图书
            case "getreturndocs":
                try
                {
                    var vResult = DocMng.GetReturnDocs();
                    return ResponseHelper.GetSuccessReturn(vResult);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            //出借图书
            case "borrowdoc":
                try
                {

                    var borrow = JsonConvert.DeserializeObject<DocLog>(strParams);
                    var vResult = DocMng.BorrowDoc(borrow);
                    return ResponseHelper.GetSuccessReturn(vResult);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            //归还图书
            case "returndoc":
                try
                {
                    var vResult = DocMng.ReturnDoc(long.Parse(strParams));
                    return ResponseHelper.GetSuccessReturn(vResult);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }

            #endregion
            #region 品名表增删改查
            case "addproduct":
                try
                {
                    var addProduct = JsonConvert.DeserializeObject<AddProductDto>(strParams);
                    var vProjectList = ObjMng.AddProduct(addProduct);
                    return ResponseHelper.GetSuccessReturn(vProjectList);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }

            case "deleteproduct":
                try
                {
                    var product = JsonConvert.DeserializeObject<Product>(strParams);
                    var vProjectList = ObjMng.DeleteProduct(product);
                    return ResponseHelper.GetSuccessReturn(vProjectList);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            case "updateproduct":
                try
                {
                    var productSearchDto = JsonConvert.DeserializeObject<Product>(strParams);
                    var vProjectList = ObjMng.UpdateProduct(productSearchDto);
                    return ResponseHelper.GetSuccessReturn(vProjectList);
                }
                catch (Exception e1)
                {
                    return ResponseHelper.GetErrorReturn(ResponseCode.FAIL, e1.Message);
                }
            #endregion
        }
        return ResponseHelper.GetErrorReturn(ResponseCode.ErrorParameter, "输入参数错误，请重新输入");
    }
}