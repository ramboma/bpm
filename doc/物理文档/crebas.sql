/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2015/5/31 12:30:39                           */
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
   '�鼮��Ϣ��',
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
   '�鼮���ı�',
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
   '��������',
   'user', @CurrentUser, 'table', 'CarApply'
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
   '������Ϣ��',
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
   '���ϱ䶯��Ϣ��',
   'user', @CurrentUser, 'table', 'DocLog'
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
   keeper               bigint               null,
   FactoryName          varchar(500)         null,
   SalerName            varchar(500)         null,
   ProductTime          datetime             null,
   constraint PK_EQUIPMENT primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�豸��Ϣ��',
   'user', @CurrentUser, 'table', 'Equipment'
go

/*==============================================================*/
/* Table: EquipmentLog                                          */
/*==============================================================*/
create table EquipmentLog (
   Id                   bigint               identity,
   EquipmentId          bigint               null,
   UserName             varchar(100)         null,
   Time                 datetime             null,
   RecordType           varchar(10)          null,
   Remarks              varchar(1000)        null,
   ApplyId              bigint               null,
   ApproveId            bigint               null,
   RelativeTask         bigint               null,
   ManagerId            bigint               null,
   constraint PK_EQUIPMENTLOG primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�豸�䶯��Ϣ��',
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
   '������־��',
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
   '�������ͱ�',
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
   '�ʲ�Ʒ����',
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
   Source               varchar(50)          null,
   ApproveId            bigint               null,
   RelativeTask         bigint               null,
   StorageNum           varchar(20)          null,
   Shelf                varchar(20)          null,
   StoreTime            decimal              null,
   constraint PK_PRODUCTINPUT primary key (Id)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ʲ�����',
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
   '�ʲ������',
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
   '���������',
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
   '����',
   'user', @CurrentUser, 'table', 'Provider'
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
CREATE TABLE [dbo].[Employee](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DeptID] [bigint] NOT NULL,
	[Attribute] [bigint] not null,
	[Age] [bigint] NOT NULL,
        [AliasName] varchar(50) NOT NULL,
        [Password]  varchar(24) NOT NULL,
        [KeyString] varchar(128) NULL,
	[Sex] [bigint] NOT NULL,
	[TelNo] [varchar](50) NULL,
	[Rank] [bigint] NULL,
	[Remark] [varchar](100) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
CREATE TABLE [dbo].[Department](
	[ID] [bigint] NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Remark] [varchar](100) NULL,
 CONSTRAINT [PK_Department1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
CREATE TABLE [dbo].[Role](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[EmployeeID] [bigint] NOT NULL,
	[AccessMask] [varchar](128) NULL,
	[Remark] [varchar](100) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����',
   'user', @CurrentUser, 'table', 'Task'
go

