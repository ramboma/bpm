/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2015/6/5 22:52:26                            */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('BookInfo')
            and   type = 'U')
   drop table BookInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BookLog')
            and   type = 'U')
   drop table BookLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CarApply')
            and   type = 'U')
   drop table CarApply
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Department')
            and   type = 'U')
   drop table Department
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DocInfo')
            and   type = 'U')
   drop table DocInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DocLog')
            and   type = 'U')
   drop table DocLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Employee')
            and   type = 'U')
   drop table Employee
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Equipment')
            and   type = 'U')
   drop table Equipment
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EquipmentLog')
            and   type = 'U')
   drop table EquipmentLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ProcessLog')
            and   type = 'U')
   drop table ProcessLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ProcessType')
            and   type = 'U')
   drop table ProcessType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Product')
            and   type = 'U')
   drop table Product
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ProductInput')
            and   type = 'U')
   drop table ProductInput
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ProductLog')
            and   type = 'U')
   drop table ProductLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ProductOutDetail')
            and   type = 'U')
   drop table ProductOutDetail
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Provider')
            and   type = 'U')
   drop table Provider
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Role')
            and   type = 'U')
   drop table Role
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Segment')
            and   type = 'U')
   drop table Segment
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Task')
            and   type = 'U')
   drop table Task
go

/*==============================================================*/
/* Table: BookInfo                                              */
/*==============================================================*/
create table BookInfo (
   Id                   bigint               identity,
   BookName             varchar(100)         null,
   Author               varchar(500)         null,
   Publisher            varchar(100)         null,
   Source               varchar(10)          null,
   Price                double precision     null,
   Time                 datetime             null,
   ReadLevel            int                  null,
   KeyWord              varchar(200)         null,
   Location             varchar(1000)        null,
   Content              varchar(1000)        null,
   DeleteFlag           tinyint              null,
   constraint PK_BOOKINFO primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '书籍信息表',
   'user', @CurrentUser, 'table', 'BookInfo'
go

/*==============================================================*/
/* Table: BookLog                                               */
/*==============================================================*/
create table BookLog (
   Id                   bigint               identity,
   BookId               bigint               null,
   Borrower             varchar(100)         null,
   Time                 datetime             null,
   RecordType           varchar(10)          null,
   Remarks              varchar(1000)        null,
   BorrowDays           int                  null,
   ReturnTime           datetime             null,
   constraint PK_BOOKLOG primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '书籍借阅表',
   'user', @CurrentUser, 'table', 'BookLog'
go

/*==============================================================*/
/* Table: CarApply                                              */
/*==============================================================*/
create table CarApply (
   ApplyId              integer              null,
   UserDep              varchar(100)         null,
   CarType              varchar(100)         null,
   StartPos             varchar(500)         null,
   TargetPos            varchar(500)         null,
   CarUser              varchar(50)          null,
   Puspose              varchar(500)         null,
   DriverName           varchar(20)          null,
   StartTime            datetime             null,
   CarNum               varchar(50)          null,
   ApproveName          varchar(20)          null,
   ApproveTime          datetime             null,
   ApproveIdea          varchar(500)         null
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '车辆申请',
   'user', @CurrentUser, 'table', 'CarApply'
go

/*==============================================================*/
/* Table: Department                                            */
/*==============================================================*/
create table Department (
   Id                   bigint               null,
   部门名                  varchar(100)         null,
   备注                   varchar(500)         null
)
go

/*==============================================================*/
/* Table: DocInfo                                               */
/*==============================================================*/
create table DocInfo (
   Id                   bigint               identity,
   DocName              varchar(100)         null,
   DocType              varchar(50)          null,
   Author               varchar(500)         null,
   Publisher            varchar(100)         null,
   MiLevel              varchar(50)          null,
   ReadLevel            int                  null,
   Source               varchar(10)          null,
   KeyWord              varchar(200)         null,
   Time                 datetime             null,
   Content              varchar(1000)        null,
   FilePath             varchar(1000)        null,
   DeleteFlag           tinyint              null,
   constraint PK_DOCINFO primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资料信息表',
   'user', @CurrentUser, 'table', 'DocInfo'
go

/*==============================================================*/
/* Table: DocLog                                                */
/*==============================================================*/
create table DocLog (
   Id                   bigint               identity,
   DocId                bigint               null,
   Borrower             varchar(100)         null,
   Time                 datetime             null,
   RecordType           varchar(10)          null,
   Remarks              varchar(1000)        null,
   BorrowDays           int                  null,
   ReturnTime           datetime             null,
   constraint PK_DOCLOG primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资料变动信息表',
   'user', @CurrentUser, 'table', 'DocLog'
go

/*==============================================================*/
/* Table: Employee                                              */
/*==============================================================*/
create table Employee (
   Id                   bigint               null,
   Name                 varchar(50)          null,
   DeptID               bigint               null,
   Attribute            bigint               null,
   Age                  int                  null,
   AliasName            varchar(50)          null,
   Password             varchar(50)          null,
   KeyString            varchar(255)         null,
   Sex                  int                  null,
   TelNo                varchar(10)          null,
   Rank                 bigint               null,
   Remark               varchar(500)         null,
   RoleId               bigint               null
)
go

/*==============================================================*/
/* Table: Equipment                                             */
/*==============================================================*/
create table Equipment (
   Id                   bigint               identity,
   EquipmentName        varchar(100)         null,
   Model                varchar(500)         null,
   Standard             varchar(100)         null,
   Source               bigint               null,
   Price                double precision     null,
   UpdateTime           datetime             null,
   EquipmentStatus      varchar(50)          null,
   DepartMent           bigint               null,
   DocPath              varchar(1000)        null,
   HasDelete            tinyint              null,
   Keeper               bigint               null,
   FactoryName          varchar(00)          null,
   SalerName            varchar(100)         null,
   ProductTime          datetime             null,
   constraint PK_EQUIPMENT primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备信息表',
   'user', @CurrentUser, 'table', 'Equipment'
go

/*==============================================================*/
/* Table: EquipmentLog                                          */
/*==============================================================*/
create table EquipmentLog (
   Id                   bigint               identity,
   EquipmentId          bigint               null,
   Time                 datetime             null,
   RecordType           varchar(10)          null,
   Remarks              varchar(1000)        null,
   applyId              bigint               null,
   approveId            bigint               null,
   relativeTask         bigint               null,
   managerId            bigint               null,
   constraint PK_EQUIPMENTLOG primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设备变动信息表',
   'user', @CurrentUser, 'table', 'EquipmentLog'
go

/*==============================================================*/
/* Table: ProcessLog                                            */
/*==============================================================*/
create table ProcessLog (
   ProcessLogId         integer              null,
   SegmentId            integer              null,
   TableName            varchar(50)          null,
   CreateUser           varchar(10)          null,
   CreateTime           datetime             null,
   UpdateTime           datetime             null,
   ipaddress            varchar(50)          null
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '流程日志表',
   'user', @CurrentUser, 'table', 'ProcessLog'
go

/*==============================================================*/
/* Table: ProcessType                                           */
/*==============================================================*/
create table ProcessType (
   ProcessTypeId        integer              null,
   ProcessTypeName      nvarchar(50)         null,
   ProcessTypeTitle     varchar(5000)        null,
   FirstSegment         integer              null,
   EndSegment           integer              null,
   CreateUser           varchar(10)          null,
   CreateTime           datetime             null,
   UpdateTime           datetime             null,
   ParentId             integer              null
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '流程类型表',
   'user', @CurrentUser, 'table', 'ProcessType'
go

/*==============================================================*/
/* Table: Product                                               */
/*==============================================================*/
create table Product (
   ProductId            bigint               null,
   ProductNum           varchar(100)         null,
   ProductName          varchar(100)         null,
   ProductFlag          tinyint              null,
   FactoryId            bigint               null,
   DealerId             bigint               null,
   Model                varchar(50)          null,
   Standard             varchar(50)          null,
   Price                double precision     null,
   QuantityUnit         varchar(50)          null,
   HasDelete            tinyint              null
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资产品名表',
   'user', @CurrentUser, 'table', 'Product'
go

/*==============================================================*/
/* Table: ProductInput                                          */
/*==============================================================*/
create table ProductInput (
   Id                   bigint               identity,
   ProductId            bigint               null,
   Time                 datetime             null,
   Quantity             int                  null,
   UserId               bigint               null,
   Source               bigint               null,
   ApproveId            bigint               null,
   RelativeTask         bigint               null,
   StorageNum           varchar(20)          null,
   Shelf                varchar(20)          null,
   ShelfLife            decimal              null,
   constraint PK_PRODUCTINPUT primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资产入库表',
   'user', @CurrentUser, 'table', 'ProductInput'
go

/*==============================================================*/
/* Table: ProductLog                                            */
/*==============================================================*/
create table ProductLog (
   Id                   bigint               identity,
   Time                 datetime             null,
   ApplyId              bigint               null,
   ApproveId            bigint               null,
   RelativeTask         bigint               null,
   ManagerId            bigint               null,
   constraint PK_PRODUCTLOG primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '资产出库表',
   'user', @CurrentUser, 'table', 'ProductLog'
go

/*==============================================================*/
/* Table: ProductOutDetail                                      */
/*==============================================================*/
create table ProductOutDetail (
   id                   bigint               null,
   ProductLogId         bigint               null,
   ProductInputId       bigint               null,
   Quantity             int                  null
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '出库详情表',
   'user', @CurrentUser, 'table', 'ProductOutDetail'
go

/*==============================================================*/
/* Table: Provider                                              */
/*==============================================================*/
create table Provider (
   CatalogId            bigint               identity,
   CatalogName          varchar(500)         null,
   CatalogKey           varchar(50)          null,
   Remark1              varchar(500)         null,
   Remark2              varchar(500)         null,
   constraint PK_PROVIDER primary key (CatalogId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '类别表',
   'user', @CurrentUser, 'table', 'Provider'
go

/*==============================================================*/
/* Table: Role                                                  */
/*==============================================================*/
create table Role (
   Id                   bigint               null,
   Name                 varchar(50)          null,
   Remark               varchar(500)         null
)
go

/*==============================================================*/
/* Table: Segment                                               */
/*==============================================================*/
create table Segment (
   SegmentId            integer              null,
   SegmentName          varchar(50)          null,
   SegmentTitle         varchar(500)         null,
   IncludeTable         varchar(50)          null,
   IncludeParam         varchar(1000)        null,
   BlameName            varchar(50)          null,
   PreSegment           integer              null,
   ActionExpression     varchar(1000)        null,
   CreateTime           datetime             null,
   UpdateTime           datetime             null
)
go

/*==============================================================*/
/* Table: Task                                                  */
/*==============================================================*/
create table Task (
   TaskId               integer              null,
   TaskName             nvarchar(50)         null,
   ProcessTypeId        integer              null,
   ProcessLogId         integer              null,
   CreateUser           varchar(10)          null,
   CreateTime           datetime             null,
   UpdateTime           datetime             null,
   CurrentSegment       integer              null
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '任务表',
   'user', @CurrentUser, 'table', 'Task'
go

