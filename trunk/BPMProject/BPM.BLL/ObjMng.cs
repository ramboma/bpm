﻿using System.Collections.Generic;
using BPM.Entity;
using ServiceStack.OrmLite;
using BPM.ORMLite;
using BPM.Entity.DTO;
using BPM.Entity.Paged;
using System;
namespace BPM.BLL
{
    public class ObjMng
    {
        /// <summary>
        /// 获取所有品名
        /// </summary>
        /// <returns></returns>
        public static PagedList<Product> GetAllPingMing(PageDto dto)
        {
            var express = ORMLite.Utity.Connection.From<Product>();
            express.Where(s => s.hasDelete == 1);
            int skips = (dto.PageIndex - 1) * dto.PageSize;
            express.Limit(skip: skips, rows: dto.PageSize);
            long allCount = Utity.Connection.Count<Product>(express);
            var list = Utity.Connection.Select<Product>(express);
            var pagedList = new PagedList<Product>(list, dto.PageIndex, dto.PageSize, allCount);

            return pagedList;
        }
        /// <summary>
        /// 获取命名目录
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static List<Product> GetPingMingInfo(string code)
        {
            List<KeyValuePair<int, int>> kpValues = new List<KeyValuePair<int, int>>();
            kpValues.Add(new KeyValuePair<int, int>(0, 2));
            kpValues.Add(new KeyValuePair<int, int>(2, 5));
            kpValues.Add(new KeyValuePair<int, int>(5, 12));
            var sqlexpression = Utity.Connection.From<Product>();
            sqlexpression.Where(s => s.hasDelete == 1);
            //判断code的长度
            //0,那么返回第一级目录
            //2位，那么是第一级目录
            //5位，那么是二级目录
            //12位，那么是品名
            //var currentkey = kpValues.Find(s => s.Key == code.Length);
            //sqlexpression.Where("len(productid)={0} and productid/", currentkey.Value);
            switch (code.Length)
            {
                case 0:
                    sqlexpression.Where("len(productid)=2 ");
                    break;
                case 2:
                    sqlexpression.Where("len(productid)=5 and productid/1000={0}", int.Parse(code));
                    break;
                case 5:
                    sqlexpression.Where("len(productid)=12 and productid/10000000={0}", int.Parse(code));
                    break;
            }

            string strSql = sqlexpression.SelectInto<Product>();
            return Utity.Connection.Select<Product>(sqlexpression);
        }
        #region 出库
        /// <summary>
        /// 输入资产内码，返回资产信息和剩余数量
        /// </summary>
        /// <param name="productCode">资产内码</param>
        /// <returns>资产数量实体</returns>
        public static ProductStatiscDto GetProductStatisc(string productCode)
        {
            string strsql = @"SELECT a.ProductId,a.ProductNum,a.ProductName,a.ProductFlag,a.FactoryId,a.DealerId,a.Model,a.Standard,a.Price,a.QuantityUnit,a.HasDelete,a.incount-a.outcount AS stacks from
(SELECT p.ProductId,p.ProductNum,p.ProductName,p.ProductFlag,p.FactoryId,p.DealerId,p.Model,p.Standard,p.Price,p.QuantityUnit,p.HasDelete,SUM(input.Quantity) incount,SUM(outp.Quantity) AS outcount FROM dbo.Product p JOIN dbo.ProductInput input ON p.ProductId=input.ProductId
JOIN dbo.ProductLog  outp ON input.Id=outp.ProductInputId
WHERE p.productid={0}
GROUP BY p.ProductId,p.ProductNum,p.ProductName,p.ProductFlag,p.FactoryId,p.DealerId,p.Model,p.Standard,p.Price,p.QuantityUnit,p.HasDelete) a";
            string strFinalSql = string.Format(strsql, productCode);
            var dto = Utity.Connection.Single<ProductStatiscDto>(strFinalSql);
            return dto;
        }
        /// <summary>
        /// 保存出库信息
        /// </summary>
        /// <param name="productLog"></param>
        /// <returns>返回出库的id号</returns>
        public static long SaveProductLog(ProductLog productLog)
        {
            productLog.time = System.DateTime.Now;
            long lResult = Utity.Connection.Insert<ProductLog>(productLog, selectIdentity: true);
            return lResult;
        }
        /// <summary>
        /// 批量保存出库信息
        /// </summary>
        /// <remarks>
        /// 2015-5-30 rambo
        ///     ApplyId:'',ApproveId:'',RelativeTask:'',ManagerId:'',
        ///     data[{ProductId:11,SaleCount:22}]
        /// </remarks>
        public static OutPutDetailListDto SaveFetchDetail(FetchDetailDto dto)
        {
            OutPutDetailListDto listDto = new OutPutDetailListDto();
            listDto.Lists = new List<OutPutDetailDto>();
            //批量详情中的经办人等数据入productlog表
            ProductLog log = new ProductLog();
            log.approveId = dto.ApproveId;
            log.relativeTask = dto.RelativeTask;
            log.time = System.DateTime.Now;
            log.managerId = dto.ManagerId;
            var trans = Utity.Connection.BeginTransaction();
            try
            {
                //入主表
                var logId = Utity.Connection.Insert<ProductLog>(log, selectIdentity: true);
                //入从表
                foreach (var d in dto.data)
                {
                    //ProductOutDetail detail = new ProductOutDetail();
                    //detail.ProductLogId = logId;
                    //通过productid获取符合条件的待出库资产对象OutBoundList,
                    var list = GetOutputDetailList(d.ProductId, d.SaleCount);
                    //依次取出数据，从所有可用批次中找出要出库的批次

                    //在出库详情表中增加出库记录
                    foreach(var detail in list)
                    {
                        Utity.Connection.Insert<ProductOutDetail>(new ProductOutDetail() { productInputId = (long)detail.ProductInputId, productLogId = logId, quantity = detail.Quantity });
                    }
                    //返回出库记录
                    listDto.Lists.AddRange(list);
                }

                trans.Commit();
            }
            catch (Exception ep)
            {
                trans.Rollback();
            }

            return listDto;
        }

        private static List<OutPutDetailDto> GetOutputDetailList(double ProductId, double salecount)
        {
            //先取出该资产有效的入库批次取出来；
            string sql = @"SELECT  *
FROM    ( SELECT    id as ProductInputId ,
                    incount ,
                    CASE WHEN outcount IS NULL THEN 0
                         ELSE outcount
                    END AS ncount ,
                    CASE WHEN outcount IS NULL THEN incount
                         ELSE incount - outcount
                    END AS quantity ,
                    time + shelflife * 30 AS timelife ,
                    ProductName ,
                    productid ,
                    Price ,
                    shelfname as shelf ,
                    storageName
          FROM      ( SELECT    pin.Id ,
                                pin.time ,
                                pin.shelflife ,
                                p.ProductName ,
                                p.productid ,
                                p.Price ,
                                pr1.CatalogName AS shelfname ,
                                pr2.CatalogName AS storageName ,
                                SUM(pin.Quantity) AS incount ,
                                SUM(detail.quantity) outcount
                      FROM      dbo.ProductInput pin
                                LEFT JOIN dbo.ProductOutDetail detail ON pin.Id = detail.productinputid
                                JOIN dbo.Product p ON p.productid = pin.ProductId
                                LEFT JOIN dbo.Provider pr1 ON pin.Shelf = pr1.CatalogId
                                LEFT JOIN dbo.Provider pr2 ON pin.StorageNum = pr2.CatalogId
                      WHERE     pin.productid = @id
                      GROUP BY  pin.id ,
                                pin.time ,
                                pin.shelflife ,
                                p.ProductName ,
                                p.productid ,
                                p.Price ,
                                pr1.CatalogName ,
                                pr2.CatalogName
                    ) a
        ) b
WHERE   b.quantity > 0
ORDER BY timelife,quantity";
            var list = Utity.Connection.Select<OutPutDetailDto>(sql, new Dictionary<string, object> { { "id", ProductId } });

            Dictionary<double, int> outputCount = new Dictionary<double, int>();
                int temp = (int)salecount;
            for (int i = 0; i < list.Count; i++)
            {
                temp -= list[i].Quantity;
                if (temp <= 0)
                {
                    outputCount[list[i].ProductInputId] = list[i].Quantity+temp;
                    break;
                }
                else
                {
                    outputCount[list[i].ProductInputId]= list[i].Quantity;
                }
            }
            var returnList = new List<OutPutDetailDto>();
            foreach (var key in outputCount.Keys)
            {
                var currentDto=list.Find(s => s.ProductInputId == key);
                currentDto.Quantity = outputCount[key];
                returnList.Add(currentDto);
            }

            return returnList;
        }
        #endregion
        #region 入库

        /// <summary>
        /// 入库信息
        /// </summary>
        /// <param name="newProductInput">新的资产入库</param>
        /// <returns>大于0为成功，0为失败</returns>
        public static long SubmitLibrary(ProductInput newProductInput)
        {
            int iResult = 0;
            long lResult = Utity.Connection.Insert<ProductInput>(newProductInput, selectIdentity: true);
            iResult = (int)lResult;
            return iResult;
        }
        #endregion
        /// <summary>
        /// 资产查询
        /// </summary>
        /// <param name="productSearch"></param>
        /// <returns></returns>
        public static List<ProductStatiscDto> SearchProduct(ProductSearchDto productSearch)
        {
            if (productSearch == null) return null;
            string strSql = @"SELECT  pro.productid ,
        pro.productnum ,
        pro.productname ,
        pro.productflag ,
        pro.factoryid,
        pro.dealerid,
        pv.CatalogName AS factoryname ,
        pv1.CatalogName AS dealername ,
        pro.model ,
        pro.standard ,
        pro.price ,
        pro.quantityunit ,
        CASE WHEN e.myintotal - e.myouttotal IS NULL THEN 0
             ELSE e.myintotal - e.myouttotal
        END AS Stacks
FROM    product pro
        LEFT  JOIN ( SELECT d.productid ,
                            SUM(total) AS myintotal ,
                            SUM(pouttotal) AS myouttotal
                     FROM   ( SELECT    c.id ,
                                        c.productid ,
                                        c.total ,
                                        CASE WHEN c.outtotal IS NULL THEN 0
                                             ELSE c.outtotal
                                        END AS pouttotal
                              FROM      ( SELECT    a.id ,
                                                    a.productid ,
                                                    a.total ,
                                                    SUM(pout.Quantity) AS outtotal
                                          FROM      ( SELECT  id ,
                                                              productid ,
                                                              SUM(quantity) total
                                                      FROM    dbo.Productinput {0} 
                                                      GROUP BY id ,
                                                              ProductId
                                                    ) a
                                                    LEFT JOIN productoutdetail pout ON a.id = pout.ProductInputId
                                          GROUP BY  a.id ,
                                                    a.productid ,
                                                    a.total
                                        ) c
                            ) d
                     GROUP BY d.productid
                   ) e ON pro.productid = e.ProductId
        LEFT JOIN Provider pv ON pro.FactoryId = pv.CatalogId
        LEFT JOIN Provider pv1 ON pro.DealerId = pv1.CatalogId
        where pro.ProductId>100000000000 and pro.hasdelete=0 {1}                                        ";


            string strFormat = "";
            string strInput = "";
            string strAnd = "";
            if (!string.IsNullOrEmpty(productSearch.Source)) strInput += "dbo.Productinput.source="+productSearch.Source.ToString() + " and ";
            if (!string.IsNullOrEmpty(productSearch.StorageNum)) strInput += "dbo.Productinput.storageNum="+productSearch.StorageNum.ToString() + " and ";
            if (!string.IsNullOrEmpty(productSearch.StartTime)&&!string.IsNullOrEmpty(productSearch.EndTime))
            {
                    strInput += "dbo.productinput.Time>='" + productSearch.StartTime + "' and " + "dbo.productinput.time<='" + productSearch.EndTime + "' and ";
            }
            if (!string.IsNullOrEmpty(strInput))
            {
                strInput = strInput.Remove(strInput.Length - 5, 5);
                if (!string.IsNullOrEmpty(strInput))
                {
                    strInput = " where " + strInput;
                }
            }
            strAnd = "";
            string strLikeFormat = " {0} like '{1}%' ";
            if (!string.IsNullOrEmpty(productSearch.productName)) strAnd += string.Format(strLikeFormat, "pro.productName", productSearch.productName) + " and ";
            if (!string.IsNullOrEmpty(productSearch.factoryName)) strAnd += string.Format(strLikeFormat, "pv.CatalogName", productSearch.factoryName) + " and ";
            if (!string.IsNullOrEmpty(productSearch.model)) strAnd += string.Format(strLikeFormat, "pro.model", productSearch.model) + " and ";
            if (!string.IsNullOrEmpty(productSearch.standard)) strAnd += string.Format(strLikeFormat, "pro.standard", productSearch.standard) + " and ";
            if (strAnd.Length>5)
            { 
                strAnd = strAnd.Remove(strAnd.Length - 5, 5);
            }
            if (!string.IsNullOrEmpty(strAnd))
            {
                strFormat = " and " + strAnd;
            }
            string strSqlFormat = string.Format(strSql, strInput,strFormat);
            return Utity.Connection.Select<ProductStatiscDto>(strSqlFormat);

        }
        /// <summary>
        ///  获取品名详情
        /// </summary>
        /// <param name="dto"></param>
        /// <remarks>
        ///  {productName:'机',factoryId:11,model:'',standard:'',source:33,storageNum :33,starttime:'2015/5/4 0:2:15',endtime:'2015/5/20 11:30:50'}
        /// </remarks>
        public static List<ProductInOutDetailDto> SearchProductDetail(ProductDetailSearchDto dto)
        {
            string str_sql = @"select a.ProductInputId,
                            a.InoutFlag,
                            a.Time,
                            a.Quantity,
                            b.emplname as ApplyName,
                            d.CatalogName as Source,
                            c.EmplName  as ApproveName,
                            a.RelativeTask,
                            e.CatalogName as Storage,
                            f.CatalogName as Shelf
                            from (
                            (select productinput.ProductId,
                            '进库' as InoutFlag,
                            ProductInput.Id as productInputId,
                            ProductInput.Time,
                            ProductInput.Quantity,
                            ProductInput.UserId as ApplyId,
                            ProductInput.Source,
                            ProductInput.ApproveId,
                            ProductInput.RelativeTask,
                            ProductInput.StorageNum,
                            ProductInput.Shelf 
                            from ProductInput)
                             union(
                            select ProductInput.ProductId,
                            '出库' as InoutFlag,
                            ProductInput.Id as productInputId,
                            ProductLog.Time,
                            ProductOutDetail.Quantity,
                            ProductLog.ApplyId,
                            ProductInput.Source,
                            ProductLog.ApproveId,
                            ProductLog.RelativeTask,
                            ProductInput.StorageNum,
                            ProductInput.Shelf 
                            from ProductOutDetail  
                            left join ProductLog on 
                            ProductLog.Id=ProductOutDetail.ProductLogId
                            left join ProductInput on ProductInput.Id=ProductOutDetail.ProductInputId)) as a 
                            left join Employee as b on b.EmplID=a.ApplyId
                            left join Employee as c on c.EmplID =a.ApproveId
                            left join Provider as d on d.CatalogId =a.Source 
                            left join Provider as e on e.CatalogId=a.StorageNum 
                            left join Provider as f on f.CatalogId =a.Shelf 
                            where a.ProductId="+dto.ProductId.ToString();
            if (!string.IsNullOrEmpty(dto.StartTime) && !string.IsNullOrEmpty(dto.EndTime))
            {
                str_sql += "and a.Time>='" + dto.StartTime + "' and " + "a.Time<='" + dto.EndTime + "'";
            }
            str_sql += " order by productInputId,Time asc";
            var list = Utity.Connection.Select<ProductInOutDetailDto>(str_sql);
         
            return list;
        }
        /// <summary>
        /// 资产统计
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static string StaticsProduct(ProductStatiscDto productStatiscDto)
        {
            return @"{code:1,message:’’,result:{
RecordsCounts:1000,currentRows:10,data:
[{productId:111104000001,productNum:’as001dssdf’,AllInput:300,AllOutput:200,Stocks:1000}]}}";
        }
        #region 品名表的增删改查
        /// <summary>
        /// 新增品名
        /// </summary>
        /// <param name="addProductDto"></param>
        /// <returns></returns>
        public static long AddProduct(AddProductDto addProductDto)
        {
            //如果父id长度是2，那么增加的是目录
            //如果父id长度是5，那么增加的是资产
            //如果父id长度是12，那么无法添加
            //生成子id
            switch (addProductDto.ParentId.ToString().Length)
            {
                case 2:
                    long lMaxId=Utity.Connection.ScalarFmt<long>(@"SELECT MAX(productid) FROM dbo.Product p
WHERE p.ProductId LIKE'{0}%' AND Len(p.productid)=5",addProductDto.ParentId);
                    addProductDto.productId = lMaxId + 1; 
                    break;
                case 5:
                    long lProductId=Utity.Connection.ScalarFmt<long>(@"SELECT MAX(productid) FROM dbo.Product p
WHERE p.ProductId LIKE'{0}%' AND Len(p.productid)>5",addProductDto.ParentId);
                    addProductDto.productId = lProductId + 1; 
                    break;
                default:
                    break;
            }

            long lresult = Utity.Connection.Insert<Product>(addProductDto);
            return lresult;
        }
        /// <summary>
        /// 删除品名
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static int DeleteProduct(Product product)
        {
            int pLength = product.productId.ToString().Length;
            product.hasDelete = 2;
            if (pLength == 12)
            {
                return UpdateProduct(product);
            }
            else
            {
                //否则就删除该目录下所有节点
                var exp = Utity.Connection.From<Product>();
                exp.Where("productid like '{0}%'", product.productId);
                exp.AddUpdateField(s => s.hasDelete);
                //Utity.Connection.Update(<Product>(new Product() { hasDelete = 2 });
                return 0;
            }

        }
        /// <summary>
        /// 更新品名表
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static int UpdateProduct(Product product)
        {
            var lresult = Utity.Connection.Update<Product>(product);
            return lresult;
        }
        #endregion
        /// <summary>
        /// 获取类似xx%的品名列表De
        /// </summary>
        /// <param name="key">资产关键字</param>
        /// <returns>资产列表</returns>
        public static List<Product> GetProductList(string key)
        {
            List<Product> list = new List<Product>();
            var expression = Utity.Connection.From<Product>();
            expression.Where<Product>(s => s.productName.StartsWith(key));
            //执行查询，返回实体列表
            list = Utity.Connection.Select<Product>(expression);
            return list;
        }
        /// <summary>
        /// 获取类似xx%的厂家列表
        /// </summary>
        /// <param name="providerName">厂家关键字</param>
        /// <returns>厂家列表</returns>
        public static List<Provider> GetProviderList(string catalogName)
        {
            List<Provider> list = new List<Provider>();
            var expression = Utity.Connection.From<Provider>();
            expression.Where<Provider>(s => s.catalogName.StartsWith(catalogName));
            expression.Where<Provider>(s => s.catalogKey == "厂家");
            //执行查询，返回实体列表
            list = Utity.Connection.Select<Provider>(expression);
            return list;
        }
        //获取型号

        //生成二维码

        /// <summary>
        /// 获取资产树
        /// </summary>
        /// <returns></returns>
        public static List<TreeDto> GetPinMingTree()
        {
            var express = ORMLite.Utity.Connection.From<Product>();
            long allCount = Utity.Connection.Count<Product>(express);
            var list = Utity.Connection.Select<Product>(express);
            var treeDtoList = new List<TreeDto>();
            //取第一层
            foreach (var product in list)
            {
                if (product.productId <= 99 && product.productId >= 10)
                {
                    treeDtoList.Add(new TreeDto() { id = product.productId.ToString(), text = product.productName, children = new List<TreeDto>(), Node = product });
                }
            }
            //取第二层，依次加入第一层
            foreach (var product in list)
            {
                if (product.productId >= 10000 && product.productId <= 99999)
                {
                    int parant = (int)product.productId / 1000;
                    var current = new TreeDto()
                        {
                            id = product.productId.ToString(),
                            text = product.productName,
                            children = new List<TreeDto>(),
                            Node = product
                        };

                    var parentNode = treeDtoList.Find(s => s.id == parant.ToString());
                    if (parentNode != null)
                    {
                        parentNode.children.Add(current);
                    }
                }
            }
            //取第三层，加入第二层
            foreach (var product in list)
            {
                if (product.productId >= 100000000000 && product.productId <= 999999999999)
                {
                    int parant = (int)(product.productId / 10000000);
                    int grandpa = (int)(parant / 1000);
                    var current = new TreeDto()
                        {
                            id = product.productId.ToString(),
                            text = product.productName,
                            children = new List<TreeDto>(),
                            Node = product
                        };
                    var grandpaNode = treeDtoList.Find(s => s.id == grandpa.ToString());
                    if (grandpaNode != null)
                    {
                        var parentNode = grandpaNode.children.Find((s => s.id == parant.ToString()));
                        if (parentNode != null)
                        {
                            parentNode.children.Add(current);
                        }
                    }
                }
            }
            return treeDtoList;
        }
    }
}
