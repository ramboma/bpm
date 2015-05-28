select * from Product;
select * from ProductLog;

INSERT INTO dbo.Product
        ( ProductId ,
          ProductNum ,
          ProductName ,
          ProductFlag ,
          FactoryId ,
          DealerId ,
          Model ,
          Standard ,
          Price ,
          QuantityUnit
        )
VALUES  ( 11 , -- ProductId - bigint
          'abcd1234' , -- ProductNum - bigint
          '机车类' , -- ProductName - varchar(100)
          0 , -- Flag - tinyint
          123 , -- FactoryId - bigint
          456 , -- DealerId - bigint
          '无' , -- Model - varchar(50)
          '无' , -- Standard - varchar(50)
          0.0 , -- Price - float
          '无'  -- QuantityUnit - varchar(50)
        )


insert into ProductLog values(11,GETDATE(),1,30,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),1,20,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),1,30,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),2,30,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),2,20,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),1,30,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),1,30,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),1,30,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),2,30,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),1,30,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),1,30,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),1,30,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),1,20,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),2,30,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),1,30,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),1,30,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),2,50,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),1,30,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),1,30,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),1,30,1,'手动','123','456','5号库','3号架');
insert into ProductLog values(11,GETDATE(),1,30,1,'手动','123','456','5号库','3号架');

--provider test data
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂001',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂002',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商003', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商004', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂005',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂006',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商007', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商008', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂009',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂010',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商011', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商012', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂013',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂014',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商015', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商016', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂017',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂018',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商019', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商020', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂021',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂022',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商023', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商024', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂025',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂026',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商027', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商028', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂029',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂030',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商031', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商032', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂033',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂034',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商035', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商036', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂037',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂038',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商039', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商040', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂041',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂042',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商043', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商044', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂045',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂046',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商047', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商048', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂049',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商050', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商051', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂052',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂053',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商054', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商055', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂056',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂057',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商058', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商059', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂060',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂061',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商062', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商063', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂064',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂065',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商066', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商067', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂068',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂069',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商070', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商071', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂072',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商073', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商074', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂075',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂076',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商077', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商078', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂079',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂080',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商081', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商082', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂083',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂084',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商085', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商086', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂087',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂088',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商089', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商090', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂091',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂092',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商093', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商094', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂095',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商096', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商097', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂098',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂099',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商100', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商101', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂102',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂103',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商104', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商105', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂106',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂107',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商108', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商109', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂110',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂111',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商112', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商113', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂114',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂115',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商116', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商117', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂118',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商119', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商120', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂121',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂122',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商123', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商124', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂125',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂126',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商127', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商128', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂129',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂130',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商131', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商132', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂133',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂134',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商135', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商136', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨制造厂137',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '北京市制造厂138',   '工厂', '', '' );
INSERT  INTO Provider VALUES  ( '哈尔滨经销商139', '经销商', '', '' );
INSERT  INTO Provider VALUES  ( '北京市经销商140', '经销商', '', '' );
