SELECT  a.productid ,
        a.productnum ,
        a.productname ,
        a.productflag ,
        a.factoryid ,
        a.dealerid ,
        a.model ,
        a.standard ,
        a.price ,
        a.quantityunit ,
        SUM(dd) AS stacks
FROM    ( SELECT    p.* ,
                    CASE WHEN l.inout = 1 THEN p.Price * l.Quantity
                         ELSE -1 * p.Price * l.Quantity
                    END AS dd
          FROM      Product p
                    JOIN ProductLog l ON p.ProductId = l.ProductId
                    JOIN Provider pv ON p.FactoryId = pv.CatalogId
                                        AND pv.CatalogKey = '工厂'
        ) a
GROUP BY a.productid ,
        a.productnum ,
        a.productname ,
        a.productflag ,
        a.factoryid ,
        a.dealerid ,
        a.model ,
        a.standard ,
        a.price ,
        a.quantityunit

INSERT  INTO Provider
VALUES  ( 123, '哈尔滨制造厂', '工厂', '', '' );
INSERT  INTO Provider
VALUES  ( 124, '北京制造厂', '工厂', '', '' );
INSERT  INTO Provider
VALUES  ( 125, '哈尔滨经销商', '经销商', '', '' );
INSERT  INTO Provider
VALUES  ( 126, '北京经销商', '经销商', '', '' );