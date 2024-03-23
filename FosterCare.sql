USE [FosterCareDB]
GO
/****** Object:  Table [dbo].[AdminLoginTbl]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminLoginTbl](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Role] [bigint] NULL,
	[IsActive] [bigint] NULL,
 CONSTRAINT [PK_AdminLoginTbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CCIMasterTbl]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CCIMasterTbl](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[InstitudeName] [nvarchar](100) NULL,
	[CreateDate] [smalldatetime] NULL,
	[ModifiedDate] [smalldatetime] NULL,
	[IsActive] [bigint] NULL,
 CONSTRAINT [PK_CCIMasterTbl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChildCategoryTbl]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChildCategoryTbl](
	[Id] [bigint] NOT NULL,
	[ChildCategory] [nvarchar](max) NULL,
	[IsActive] [bigint] NULL,
 CONSTRAINT [PK_ChildCategoryTbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChildIndividualTbl]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChildIndividualTbl](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Age] [float] NULL,
	[Gender] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[State] [bigint] NULL,
	[District] [bigint] NULL,
	[Tehsil] [bigint] NULL,
	[ChildName] [nvarchar](50) NULL,
	[ChildAge] [float] NULL,
	[ChildGender] [nvarchar](50) NULL,
	[FatherName] [nvarchar](50) NULL,
	[MotherName] [nvarchar](50) NULL,
	[ChildState] [bigint] NULL,
	[ChildDistrict] [bigint] NULL,
	[ChildTehsil] [bigint] NULL,
	[SocialCategory] [nvarchar](500) NULL,
	[ChildCategory] [bigint] NULL,
	[ChildImage] [nvarchar](max) NULL,
	[Otherillness] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[ModifieddDate] [datetime] NULL,
	[IsActive] [bigint] NULL,
 CONSTRAINT [PK_ChildIndividualTbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChildInstitutionTbl]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChildInstitutionTbl](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StateID] [bigint] NULL,
	[DistrictID] [bigint] NULL,
	[NameOfTheOrganization] [nvarchar](500) NULL,
	[TypeOfOrganization] [nvarchar](500) NULL,
	[NameOfEmployee] [nvarchar](50) NULL,
	[DesignationOfTheEmployee] [nvarchar](max) NULL,
	[TehsilID] [bigint] NULL,
	[ChildName] [nvarchar](50) NULL,
	[ChildAge] [float] NULL,
	[ChildGender] [nvarchar](50) NULL,
	[ChildStateId] [bigint] NULL,
	[ChildDistrictId] [bigint] NULL,
	[ChildTehsil] [bigint] NULL,
	[FatherName] [nvarchar](50) NULL,
	[MotherName] [nvarchar](50) NULL,
	[SocialCategory] [nvarchar](50) NULL,
	[CategoryOfChild] [bigint] NULL,
	[Otherillness] [nvarchar](max) NULL,
	[ChildImage] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bigint] NULL,
 CONSTRAINT [PK_ChildInstitutionTbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChildMasterTbl]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChildMasterTbl](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NULL,
	[SerialNumber] [bigint] NOT NULL,
	[CCIMasterID] [bigint] NULL,
	[DistrictID] [bigint] NULL,
	[ChildCode] [nvarchar](50) NULL,
	[ChildName] [nvarchar](50) NULL,
	[Sex] [nvarchar](10) NULL,
	[DOB] [date] NOT NULL,
	[Age] [float] NULL,
	[Education] [nvarchar](50) NULL,
	[SocialGroup] [nvarchar](50) NULL,
	[SpecialChild] [nvarchar](5) NULL,
	[MothersName] [nvarchar](50) NULL,
	[MothersCurrentStatus] [nvarchar](100) NULL,
	[FathersName] [nvarchar](50) NULL,
	[FathersCurrentStatus] [nvarchar](100) NULL,
	[SistersCount] [bigint] NULL,
	[BrothersCount] [bigint] NULL,
	[SiblingCount] [bigint] NULL,
	[CaretakerAddress] [nvarchar](max) NULL,
	[AddressDistrict] [bigint] NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[ClosestAliveRelative] [nvarchar](50) NULL,
	[RelativeAddress] [nvarchar](500) NULL,
	[RelativeContactNumber] [nvarchar](50) NULL,
	[DataCollectionDate] [date] NOT NULL,
	[ChildCareInstitutionEnrollDate] [date] NOT NULL,
	[ChildConsentToFostering] [nvarchar](5) NULL,
	[BiologicalParentsConsentToFostering] [nvarchar](5) NULL,
	[InCCIFor] [nvarchar](500) NULL,
	[PotentialForFoster] [nvarchar](50) NULL,
	[IsFostering] [nvarchar](5) NULL,
	[PlacementDistrict] [bigint] NULL,
	[MonitoringDistrict] [bigint] NULL,
	[LastFollowUpDate] [date] NOT NULL,
	[CreateDate] [smalldatetime] NULL,
	[ModifiedDate] [smalldatetime] NULL,
	[IsActive] [bigint] NULL,
 CONSTRAINT [PK_ChildMasterTbl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChildParentConnectionTbl]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChildParentConnectionTbl](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ChildID] [bigint] NULL,
	[ParentID] [bigint] NULL,
	[CreateDate] [smalldatetime] NULL,
	[ModifiedDate] [smalldatetime] NULL,
	[IsActive] [bigint] NULL,
 CONSTRAINT [PK_ChildParentConnectionTbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DistrictMasterTbl]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DistrictMasterTbl](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StateID] [bigint] NULL,
	[DistrictName] [nvarchar](50) NULL,
	[CreateDate] [smalldatetime] NULL,
	[ModifiedDate] [smalldatetime] NULL,
	[IsActive] [bigint] NULL,
 CONSTRAINT [PK_DistrictMasterTbl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnquiryTbl]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnquiryTbl](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[CreateDate] [smalldatetime] NULL,
	[ModifiedDate] [smalldatetime] NULL,
	[IsActive] [bigint] NULL,
 CONSTRAINT [PK_EnquiryTbl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FosterParentTbl]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FosterParentTbl](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FosterCareFor] [nvarchar](50) NULL,
	[FosterParentName] [nvarchar](50) NULL,
	[State] [bigint] NULL,
	[District] [bigint] NULL,
	[Gender] [nvarchar](50) NULL,
	[Age] [float] NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[ReasonForFosterCare] [nvarchar](500) NULL,
	[OtherReasone] [nvarchar](max) NULL,
	[Education] [nvarchar](50) NULL,
	[OtherEducation] [nvarchar](max) NULL,
	[Occupation] [nvarchar](100) NULL,
	[MaritalStatus] [nvarchar](100) NULL,
	[NameOfSpouse] [nvarchar](100) NULL,
	[AgeOfSpouse] [float] NULL,
	[OccupationOfSpouse] [nvarchar](200) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bigint] NULL,
 CONSTRAINT [PK_FosterParentTbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModuleMasterTbl]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModuleMasterTbl](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ModuleName] [nvarchar](50) NULL,
	[URL] [nvarchar](max) NULL,
	[IsActive] [bigint] NULL,
 CONSTRAINT [PK_ModuleMasterTbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParentMasterTbl]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParentMasterTbl](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NULL,
	[FosterParentSerialNumber] [bigint] NOT NULL,
	[FosterParentDistrict] [bigint] NULL,
	[ParentCode] [nvarchar](50) NULL,
	[FosterMothersName] [nvarchar](50) NULL,
	[FosterMothersDOB] [date] NOT NULL,
	[FosterMotherCurrentStatus] [nvarchar](100) NULL,
	[FosterMotherHighestEducation] [nvarchar](100) NULL,
	[FosterMotherEmploymentStatus] [nvarchar](50) NULL,
	[FosterMotherIncome] [nvarchar](50) NULL,
	[FosterFathersName] [nvarchar](50) NULL,
	[FosterFathersDOB] [date] NOT NULL,
	[FosterFathersCurrentStatus] [nvarchar](100) NULL,
	[FosterFathersHighestEducation] [nvarchar](100) NULL,
	[FosterFathersEmploymentStatus] [nvarchar](50) NULL,
	[FosterFathersIncome] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[FosterGirlsCount] [bigint] NULL,
	[FosterBoysCount] [bigint] NULL,
	[RationCardFosterChildrenCount] [bigint] NULL,
	[AnyOtherFosters] [nvarchar](5) NULL,
	[ChildSheetFosteredChildrenCount] [bigint] NULL,
	[AdoptedChildrenCount] [bigint] NULL,
	[BiologicalChildrenCount] [bigint] NULL,
	[PlacementDate] [date] NOT NULL,
	[ReasonForFostering] [nvarchar](500) NULL,
	[LastExtensionDate] [date] NOT NULL,
	[ExtensionPeriod] [nvarchar](50) NULL,
	[TerminationDate] [date] NOT NULL,
	[ReasonForTermination] [nvarchar](max) NULL,
	[LastFollowUpDate] [date] NOT NULL,
	[CreateDate] [smalldatetime] NULL,
	[ModifiedDate] [smalldatetime] NULL,
	[IsActive] [bigint] NULL,
 CONSTRAINT [PK_ParentMasterTbl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionMasterTbl]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionMasterTbl](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleID] [bigint] NULL,
	[ModuleID] [bigint] NULL,
	[IsActive] [bigint] NULL,
 CONSTRAINT [PK_PermissionMasterTbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PotentialParentMaster]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PotentialParentMaster](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NULL,
	[SerialNumber] [bigint] NOT NULL,
	[ApplicantsName] [nvarchar](50) NULL,
	[ApplicantsAddress] [nvarchar](max) NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[ApplicantsDOB] [date] NOT NULL,
	[Age] [float] NULL,
	[ApplicantsHighestEducation] [nvarchar](50) NULL,
	[MartialStatus] [nvarchar](20) NULL,
	[DoYouHaveChildren] [nvarchar](10) NULL,
	[ChildrenCount] [bigint] NULL,
	[IsLegalCase] [nvarchar](10) NULL,
	[IsKnowFosterCare] [nvarchar](10) NULL,
	[YouWillingToFosterAChild] [nvarchar](10) NULL,
	[AnyQuestion] [nvarchar](max) NULL,
	[CreateDate] [smalldatetime] NULL,
	[ModifiedDate] [smalldatetime] NULL,
	[IsActive] [bigint] NULL,
 CONSTRAINT [PK_PotentialParentMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMasterTbl]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMasterTbl](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[CreateDate] [smalldatetime] NULL,
	[Isactive] [bigint] NULL,
 CONSTRAINT [PK_RoleMasterTbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StateMasterTbl]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StateMasterTbl](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bigint] NULL,
 CONSTRAINT [PK_StateMasterTbl] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TehsilMasterTbl]    Script Date: 23-03-2024 04:11:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TehsilMasterTbl](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StateID] [bigint] NULL,
	[DistrictID] [bigint] NULL,
	[TehsilName] [nvarchar](500) NULL,
	[CreateDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bigint] NULL,
 CONSTRAINT [PK_TehsilMasterTbl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AdminLoginTbl] ON 
GO
INSERT [dbo].[AdminLoginTbl] ([Id], [UserName], [ContactNumber], [Password], [Role], [IsActive]) VALUES (1, N'admin', N'9829200320', N'5uBhg4hWv0fh3nMHGfsmCQ==', 1, 1)
GO
INSERT [dbo].[AdminLoginTbl] ([Id], [UserName], [ContactNumber], [Password], [Role], [IsActive]) VALUES (2, N'Anshul', N'9784553586', N'Qpf0SxOVUjUkWySXOZ16kw==', 2, 0)
GO
INSERT [dbo].[AdminLoginTbl] ([Id], [UserName], [ContactNumber], [Password], [Role], [IsActive]) VALUES (3, N'demo', N'8879797739', N'9wLBUCvo5V9CCNaUGfUNCg==', 3, 0)
GO
SET IDENTITY_INSERT [dbo].[AdminLoginTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[CCIMasterTbl] ON 
GO
INSERT [dbo].[CCIMasterTbl] ([ID], [InstitudeName], [CreateDate], [ModifiedDate], [IsActive]) VALUES (1, N'Balika grah', CAST(N'2023-01-12T13:28:00' AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[CCIMasterTbl] ([ID], [InstitudeName], [CreateDate], [ModifiedDate], [IsActive]) VALUES (2, N'Baal grah ', CAST(N'2023-01-12T13:28:00' AS SmallDateTime), CAST(N'2023-01-19T16:31:00' AS SmallDateTime), 1)
GO
INSERT [dbo].[CCIMasterTbl] ([ID], [InstitudeName], [CreateDate], [ModifiedDate], [IsActive]) VALUES (3, N'Vatasalya grah', CAST(N'2023-01-19T16:33:00' AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[CCIMasterTbl] ([ID], [InstitudeName], [CreateDate], [ModifiedDate], [IsActive]) VALUES (4, N'Mother Tersa', CAST(N'2023-08-02T12:39:00' AS SmallDateTime), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[CCIMasterTbl] OFF
GO
INSERT [dbo].[ChildCategoryTbl] ([Id], [ChildCategory], [IsActive]) VALUES (1, N'Orphan(Rejected from Adoption)', 1)
GO
INSERT [dbo].[ChildCategoryTbl] ([Id], [ChildCategory], [IsActive]) VALUES (2, N'Missing Child', 1)
GO
INSERT [dbo].[ChildCategoryTbl] ([Id], [ChildCategory], [IsActive]) VALUES (3, N'Mentally Challenged (Father/Mother/Both)', 1)
GO
INSERT [dbo].[ChildCategoryTbl] ([Id], [ChildCategory], [IsActive]) VALUES (4, N'Physically Disabled(Mother/Father/Both)', 1)
GO
INSERT [dbo].[ChildCategoryTbl] ([Id], [ChildCategory], [IsActive]) VALUES (5, N'Parents in Prison(Mother/Father/Both)', 1)
GO
INSERT [dbo].[ChildCategoryTbl] ([Id], [ChildCategory], [IsActive]) VALUES (6, N'Physical/Sexual/Eotionally Abused Child', 1)
GO
INSERT [dbo].[ChildCategoryTbl] ([Id], [ChildCategory], [IsActive]) VALUES (7, N'Physically illness', 1)
GO
SET IDENTITY_INSERT [dbo].[ChildIndividualTbl] ON 
GO
INSERT [dbo].[ChildIndividualTbl] ([Id], [Name], [Age], [Gender], [PhoneNumber], [Email], [State], [District], [Tehsil], [ChildName], [ChildAge], [ChildGender], [FatherName], [MotherName], [ChildState], [ChildDistrict], [ChildTehsil], [SocialCategory], [ChildCategory], [ChildImage], [Otherillness], [CreateDate], [ModifieddDate], [IsActive]) VALUES (1, N'Jainam Nalwaya', 12, N'Boy', N'9784553586', N'Elixation@gmail.com', 1, 7, 1, N'Jainam', 21, N'Boy', N'Ramesh Kumar Nalwaya', N'Seema Nalwaya', 1, 7, 2, N'Gen', 7, N'/Files/ChildIndividual/20238642115.jpg', NULL, CAST(N'2023-08-06T04:21:18.000' AS DateTime), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[ChildIndividualTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[ChildInstitutionTbl] ON 
GO
INSERT [dbo].[ChildInstitutionTbl] ([Id], [StateID], [DistrictID], [NameOfTheOrganization], [TypeOfOrganization], [NameOfEmployee], [DesignationOfTheEmployee], [TehsilID], [ChildName], [ChildAge], [ChildGender], [ChildStateId], [ChildDistrictId], [ChildTehsil], [FatherName], [MotherName], [SocialCategory], [CategoryOfChild], [Otherillness], [ChildImage], [CreateDate], [ModifiedDate], [IsActive]) VALUES (1, 1, 7, N'Elixation INformatique', N'NGO', N'Jainam', N'Developer', 1, N'Jainam', 21, N'Boy', 1, 7, 2, N'Ramesh Kumar Nalwaya', N'Seema Nalwaya', N'Gen', 7, NULL, N'/Files/ChildImage/20238602312.jpg', CAST(N'2023-08-06T00:23:22.000' AS DateTime), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[ChildInstitutionTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[ChildMasterTbl] ON 
GO
INSERT [dbo].[ChildMasterTbl] ([ID], [UserID], [SerialNumber], [CCIMasterID], [DistrictID], [ChildCode], [ChildName], [Sex], [DOB], [Age], [Education], [SocialGroup], [SpecialChild], [MothersName], [MothersCurrentStatus], [FathersName], [FathersCurrentStatus], [SistersCount], [BrothersCount], [SiblingCount], [CaretakerAddress], [AddressDistrict], [ContactNumber], [ClosestAliveRelative], [RelativeAddress], [RelativeContactNumber], [DataCollectionDate], [ChildCareInstitutionEnrollDate], [ChildConsentToFostering], [BiologicalParentsConsentToFostering], [InCCIFor], [PotentialForFoster], [IsFostering], [PlacementDistrict], [MonitoringDistrict], [LastFollowUpDate], [CreateDate], [ModifiedDate], [IsActive]) VALUES (1, 1, 1, 1, 1, N'101', N'Ayush', N'Boy', CAST(N'2006-02-19' AS Date), 16.1, N'12th', N'General', N'Yes', N'Sita', N'Living', N'Naresh', N'Living', 1, 1, 0, N'....................', 1, N'9784553586', N'Yes', N'.........................', N'1231231231', CAST(N'2023-01-27' AS Date), CAST(N'2023-01-26' AS Date), N'Yes', N'Yes', N'...........................', N'Yes', N'No', 5, 5, CAST(N'2023-01-14' AS Date), CAST(N'2023-01-24T18:08:00' AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[ChildMasterTbl] ([ID], [UserID], [SerialNumber], [CCIMasterID], [DistrictID], [ChildCode], [ChildName], [Sex], [DOB], [Age], [Education], [SocialGroup], [SpecialChild], [MothersName], [MothersCurrentStatus], [FathersName], [FathersCurrentStatus], [SistersCount], [BrothersCount], [SiblingCount], [CaretakerAddress], [AddressDistrict], [ContactNumber], [ClosestAliveRelative], [RelativeAddress], [RelativeContactNumber], [DataCollectionDate], [ChildCareInstitutionEnrollDate], [ChildConsentToFostering], [BiologicalParentsConsentToFostering], [InCCIFor], [PotentialForFoster], [IsFostering], [PlacementDistrict], [MonitoringDistrict], [LastFollowUpDate], [CreateDate], [ModifiedDate], [IsActive]) VALUES (2, 1, 2, 2, 1, N'102', N'Siddhi', N'Girl', CAST(N'2016-01-20' AS Date), 7, N'8th', N'General', N'Yes', N'Snehlata', N'Separate', N'Suresh', N'Separate', 1, 1, 1, N'..........................', 5, N'1231231231', N'Yes', N'.......................', N'1231231231', CAST(N'2023-01-05' AS Date), CAST(N'2023-01-14' AS Date), N'No', N'No', N'............................', N'No', N'Yes', 5, 5, CAST(N'2023-01-20' AS Date), CAST(N'2023-01-24T18:10:00' AS SmallDateTime), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[ChildMasterTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[ChildParentConnectionTbl] ON 
GO
INSERT [dbo].[ChildParentConnectionTbl] ([Id], [ChildID], [ParentID], [CreateDate], [ModifiedDate], [IsActive]) VALUES (1, 2, 1, CAST(N'2023-01-24T18:13:00' AS SmallDateTime), CAST(N'2023-01-25T12:26:00' AS SmallDateTime), 1)
GO
INSERT [dbo].[ChildParentConnectionTbl] ([Id], [ChildID], [ParentID], [CreateDate], [ModifiedDate], [IsActive]) VALUES (2, 1, 1, CAST(N'2023-01-24T18:13:00' AS SmallDateTime), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[ChildParentConnectionTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[DistrictMasterTbl] ON 
GO
INSERT [dbo].[DistrictMasterTbl] ([ID], [StateID], [DistrictName], [CreateDate], [ModifiedDate], [IsActive]) VALUES (1, NULL, N'Udaipur', CAST(N'2023-01-12T13:25:00' AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[DistrictMasterTbl] ([ID], [StateID], [DistrictName], [CreateDate], [ModifiedDate], [IsActive]) VALUES (2, NULL, N'Dungarpur', CAST(N'2023-01-12T13:25:00' AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[DistrictMasterTbl] ([ID], [StateID], [DistrictName], [CreateDate], [ModifiedDate], [IsActive]) VALUES (3, NULL, N'Chittorgarh', CAST(N'2023-01-12T13:25:00' AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[DistrictMasterTbl] ([ID], [StateID], [DistrictName], [CreateDate], [ModifiedDate], [IsActive]) VALUES (4, NULL, N'Banswara', CAST(N'2023-01-13T13:42:00' AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[DistrictMasterTbl] ([ID], [StateID], [DistrictName], [CreateDate], [ModifiedDate], [IsActive]) VALUES (5, NULL, N'Pratapgarh', CAST(N'2023-01-13T13:42:00' AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[DistrictMasterTbl] ([ID], [StateID], [DistrictName], [CreateDate], [ModifiedDate], [IsActive]) VALUES (6, NULL, N'Rajsamand', CAST(N'2023-01-13T13:42:00' AS SmallDateTime), CAST(N'2023-01-13T13:42:00' AS SmallDateTime), 1)
GO
INSERT [dbo].[DistrictMasterTbl] ([ID], [StateID], [DistrictName], [CreateDate], [ModifiedDate], [IsActive]) VALUES (7, 1, N'Bharatpur*', CAST(N'2023-08-05T07:52:00' AS SmallDateTime), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[DistrictMasterTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[EnquiryTbl] ON 
GO
INSERT [dbo].[EnquiryTbl] ([ID], [UserID], [Name], [ContactNumber], [Address], [Message], [CreateDate], [ModifiedDate], [IsActive]) VALUES (1, 1, N'ayush', N'1234567890', N'.......', N'.......', CAST(N'2023-01-24T18:16:00' AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[EnquiryTbl] ([ID], [UserID], [Name], [ContactNumber], [Address], [Message], [CreateDate], [ModifiedDate], [IsActive]) VALUES (2, 1, N'maahesh', N'9772665554', N'udaipur ', N'test ', CAST(N'2023-07-31T14:37:00' AS SmallDateTime), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[EnquiryTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[FosterParentTbl] ON 
GO
INSERT [dbo].[FosterParentTbl] ([Id], [FosterCareFor], [FosterParentName], [State], [District], [Gender], [Age], [PhoneNumber], [Email], [ReasonForFosterCare], [OtherReasone], [Education], [OtherEducation], [Occupation], [MaritalStatus], [NameOfSpouse], [AgeOfSpouse], [OccupationOfSpouse], [CreateDate], [ModifiedDate], [IsActive]) VALUES (1, N'MySelf', N'jainam', 1, 7, N'Male', 12, N'cz', N'czx', N'Others', N'czx', N'Others', N'yes', N'Retired', N'Married', N'zcz', 10, N'zczc', CAST(N'2023-08-05T13:18:40.000' AS DateTime), CAST(N'2023-08-06T07:03:41.133' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[FosterParentTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[ModuleMasterTbl] ON 
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (1, N'Child Master View', N'/Admin/ChildMaster', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (2, N'Child Master Create', N'/Admin/ChildMaster/Create/', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (3, N'Child Master Edit', N'/Admin/ChildMaster/Edit', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (4, N'Parent Master View', N'/Admin/ParentMaster', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (5, N'Parent Master Create', N'/Admin/ParentMaster/Create/', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (6, N'Parent Master Edit', N'/Admin/ParentMaster/Edit', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (7, N'Potential Parent Master View', N'/Admin/PotentialParentMasters', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (8, N'Potential Parent Master Create', N'/Admin/PotentialParentMasters/Create/', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (9, N'Potential Parent Master Edit', N'/Admin/PotentialParentMasters/Edit', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (10, N'Child Report View', N'/Admin/ChildReports', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (11, N'Parent Report', N'/Admin/ParentReports', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (12, N'Potential Parent Master View', N'/Admin/PotentialParentReports', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (13, N'Enquiry View', N'/Admin/Enquiry', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (14, N'Super Admin < Role Master View', N'/Admin/RoleMaster', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (15, N'Super Admin < Role Master Create', N'/Admin/RoleMaster/Create/', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (16, N'Super Admin < Role Master Edit', N'/Admin/RoleMaster/Edit', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (17, N'Super Admin < Module Master View', N'/Admin/ModuleMaster', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (18, N'Super Admin < Module Master  Create', N'/Admin/ModuleMaster/Create/', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (19, N'Super Admin < Module Master Edit', N'/Admin/ModuleMaster/Edit', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (20, N'Super Admin < Manage User View', N'/Admin/ManageUser', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (21, N'Super Admin < Manage  User Create ', N'/Admin/ManageUser/Create/', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (22, N'Super Admin < CCI Master View', N'/Admin/CCIMaster', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (23, N'Super Admin < CCI Master create', N'/Admin/CCIMaster/Create/', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (24, N'Super Admin < CCI Master Edit', N'/admin/CCIMaster/Edit', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (25, N'Super Admin < District Master VIew ', N'/Admin/DistrictMaster', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (26, N'Super Admin < District Master Create', N'/Admin/DistrictMaster/Create/', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (27, N'Super Admin < District  Master Edit', N'/Admin/DistrictMaster/Edit', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (28, N'Change Password', N'/Admin/ManageUser/ChangePassword', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (29, N'Super Admin < Permission Master', N'/Admin/PermissionMaster', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (30, N'Super Admin', N'##', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (31, N'All Reports', N'#', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (32, N'Super Admin < Role Master Delete', N'/Admin/RoleMaster/Delete', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (33, N'Super Admin < Module Master Delete', N'/Admin/ModuleMaster/Delete', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (34, N'Super Admin < Manage Users Delete', N'/Admin/ManageUser/Delete', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (35, N'Super Admin < CCI Master Delete', N'/Admin/CCIMaster/Delete', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (36, N'Super Admin < District Master Delete', N'/Admin/DistrictMaster/Delete', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (37, N'Child Master Delete', N'/Admin/ChildMaster/Delete', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (38, N'Parent Master Delete', N'/Admin/ParentMaster/Delete', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (39, N'Potential Parent Master Delete', N'/Admin/PotentialParentMasters/Delete', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (40, N'Enquiry Delete', N'/Admin/Enquiry/Delete', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (41, N'Assign Parent', N'/Admin/ChildMaster/AssignParent', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (42, N'Assign Child', N'/Admin/ParentMaster/AssignChild', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (43, N'Assign Child Delete', N'/Admin/ParentMaster/DeleteAssignChild', 1)
GO
INSERT [dbo].[ModuleMasterTbl] ([Id], [ModuleName], [URL], [IsActive]) VALUES (44, N'Assigned Child Parent Reports', N'/Admin/AssignChildParent', 1)
GO
SET IDENTITY_INSERT [dbo].[ModuleMasterTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[ParentMasterTbl] ON 
GO
INSERT [dbo].[ParentMasterTbl] ([ID], [UserID], [FosterParentSerialNumber], [FosterParentDistrict], [ParentCode], [FosterMothersName], [FosterMothersDOB], [FosterMotherCurrentStatus], [FosterMotherHighestEducation], [FosterMotherEmploymentStatus], [FosterMotherIncome], [FosterFathersName], [FosterFathersDOB], [FosterFathersCurrentStatus], [FosterFathersHighestEducation], [FosterFathersEmploymentStatus], [FosterFathersIncome], [Address], [ContactNumber], [FosterGirlsCount], [FosterBoysCount], [RationCardFosterChildrenCount], [AnyOtherFosters], [ChildSheetFosteredChildrenCount], [AdoptedChildrenCount], [BiologicalChildrenCount], [PlacementDate], [ReasonForFostering], [LastExtensionDate], [ExtensionPeriod], [TerminationDate], [ReasonForTermination], [LastFollowUpDate], [CreateDate], [ModifiedDate], [IsActive]) VALUES (1, 1, 1, 1, N'101', N'Sunita', CAST(N'2014-06-06' AS Date), N'Living', N'Postgraduate ', N'Private', N'20000', N'Suresh', CAST(N'2023-01-06' AS Date), N'Living', N'Secondary', N'Self', N'30000', N'..........................', N'1231231231', 1, 2, 1, N'Yes', 1, 1, 0, CAST(N'2023-01-04' AS Date), N'........................', CAST(N'2023-01-05' AS Date), N'5', CAST(N'2023-01-20' AS Date), N'..............................', CAST(N'2023-01-20' AS Date), CAST(N'2023-01-24T18:12:00' AS SmallDateTime), NULL, 1)
GO
INSERT [dbo].[ParentMasterTbl] ([ID], [UserID], [FosterParentSerialNumber], [FosterParentDistrict], [ParentCode], [FosterMothersName], [FosterMothersDOB], [FosterMotherCurrentStatus], [FosterMotherHighestEducation], [FosterMotherEmploymentStatus], [FosterMotherIncome], [FosterFathersName], [FosterFathersDOB], [FosterFathersCurrentStatus], [FosterFathersHighestEducation], [FosterFathersEmploymentStatus], [FosterFathersIncome], [Address], [ContactNumber], [FosterGirlsCount], [FosterBoysCount], [RationCardFosterChildrenCount], [AnyOtherFosters], [ChildSheetFosteredChildrenCount], [AdoptedChildrenCount], [BiologicalChildrenCount], [PlacementDate], [ReasonForFostering], [LastExtensionDate], [ExtensionPeriod], [TerminationDate], [ReasonForTermination], [LastFollowUpDate], [CreateDate], [ModifiedDate], [IsActive]) VALUES (2, 1, 2, 2, N'102', N'Seema', CAST(N'2023-01-28' AS Date), N'Living', N'Graduate', N'Self', N'20000', N'Mahesh', CAST(N'2023-01-27' AS Date), N'Living', N'Secondary', N'Self', N'30000', N'..................', N'1231231231', 2, 1, 0, N'Yes', 1, 1, 0, CAST(N'2023-01-12' AS Date), N'...............................', CAST(N'2023-01-19' AS Date), N'2', CAST(N'2023-01-13' AS Date), N'.....................', CAST(N'2023-01-20' AS Date), CAST(N'2023-01-24T18:13:00' AS SmallDateTime), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[ParentMasterTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[PermissionMasterTbl] ON 
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (180, 3, 1, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (181, 3, 2, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (182, 3, 3, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (183, 3, 4, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (184, 3, 5, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (185, 3, 6, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (186, 3, 7, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (187, 3, 8, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (188, 3, 9, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (189, 3, 10, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (190, 3, 11, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (191, 3, 12, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (192, 3, 13, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (193, 3, 14, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (194, 3, 15, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (195, 3, 16, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (196, 3, 17, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (197, 3, 18, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (198, 3, 19, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (199, 3, 20, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (200, 3, 21, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (201, 3, 22, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (202, 3, 23, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (203, 3, 24, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (204, 3, 25, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (205, 3, 26, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (206, 3, 27, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (207, 3, 28, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (917, 2, 1, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (918, 2, 2, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (919, 2, 3, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (920, 2, 4, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (921, 2, 5, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (922, 2, 6, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (923, 2, 7, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (924, 2, 8, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (925, 2, 9, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (926, 2, 10, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (927, 2, 11, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (928, 2, 12, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (929, 2, 31, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1512, 1, 1, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1513, 1, 2, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1514, 1, 3, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1515, 1, 4, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1516, 1, 5, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1517, 1, 6, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1518, 1, 7, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1519, 1, 8, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1520, 1, 9, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1521, 1, 10, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1522, 1, 11, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1523, 1, 12, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1524, 1, 13, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1525, 1, 14, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1526, 1, 15, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1527, 1, 16, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1528, 1, 17, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1529, 1, 18, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1530, 1, 19, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1531, 1, 20, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1532, 1, 21, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1533, 1, 22, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1534, 1, 23, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1535, 1, 24, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1536, 1, 25, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1537, 1, 26, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1538, 1, 27, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1539, 1, 28, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1540, 1, 29, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1541, 1, 30, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1542, 1, 31, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1543, 1, 32, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1544, 1, 33, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1545, 1, 34, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1546, 1, 35, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1547, 1, 36, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1548, 1, 37, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1549, 1, 38, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1550, 1, 39, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1551, 1, 40, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1552, 1, 41, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1553, 1, 42, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1554, 1, 43, 1)
GO
INSERT [dbo].[PermissionMasterTbl] ([Id], [RoleID], [ModuleID], [IsActive]) VALUES (1555, 1, 44, 1)
GO
SET IDENTITY_INSERT [dbo].[PermissionMasterTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[PotentialParentMaster] ON 
GO
INSERT [dbo].[PotentialParentMaster] ([ID], [UserID], [SerialNumber], [ApplicantsName], [ApplicantsAddress], [ContactNumber], [ApplicantsDOB], [Age], [ApplicantsHighestEducation], [MartialStatus], [DoYouHaveChildren], [ChildrenCount], [IsLegalCase], [IsKnowFosterCare], [YouWillingToFosterAChild], [AnyQuestion], [CreateDate], [ModifiedDate], [IsActive]) VALUES (1, 1, 1, N'Ayush Jain', N'....................', N'1231231231', CAST(N'1983-08-30' AS Date), 40, N'Secondary', N'Yes', N'Yes', 1, N'Yes', N'Yes', N'No', N'....................', CAST(N'2023-01-24T18:14:00' AS SmallDateTime), CAST(N'2023-08-02T13:24:00' AS SmallDateTime), 1)
GO
INSERT [dbo].[PotentialParentMaster] ([ID], [UserID], [SerialNumber], [ApplicantsName], [ApplicantsAddress], [ContactNumber], [ApplicantsDOB], [Age], [ApplicantsHighestEducation], [MartialStatus], [DoYouHaveChildren], [ChildrenCount], [IsLegalCase], [IsKnowFosterCare], [YouWillingToFosterAChild], [AnyQuestion], [CreateDate], [ModifiedDate], [IsActive]) VALUES (2, 1, 1, N'Sohail', N'abc', N'8879797739', CAST(N'1991-03-28' AS Date), 32.5, N'Postgraduate ', N'No', N'No', 0, N'No', N'Yes', N'Yes', N'no', CAST(N'2023-08-02T13:23:00' AS SmallDateTime), CAST(N'2023-08-02T13:26:00' AS SmallDateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[PotentialParentMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleMasterTbl] ON 
GO
INSERT [dbo].[RoleMasterTbl] ([Id], [RoleName], [CreateDate], [Isactive]) VALUES (1, NULL, CAST(N'2023-08-06T00:23:00' AS SmallDateTime), 1)
GO
INSERT [dbo].[RoleMasterTbl] ([Id], [RoleName], [CreateDate], [Isactive]) VALUES (2, N'Admin', CAST(N'2023-01-12T12:25:00' AS SmallDateTime), 1)
GO
INSERT [dbo].[RoleMasterTbl] ([Id], [RoleName], [CreateDate], [Isactive]) VALUES (3, N'User', CAST(N'2023-01-12T13:21:00' AS SmallDateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[RoleMasterTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[StateMasterTbl] ON 
GO
INSERT [dbo].[StateMasterTbl] ([Id], [StateName], [CreateDate], [ModifiedDate], [IsActive]) VALUES (1, N'Rajasthan', CAST(N'2023-08-05T04:48:13.000' AS DateTime), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[StateMasterTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[TehsilMasterTbl] ON 
GO
INSERT [dbo].[TehsilMasterTbl] ([ID], [StateID], [DistrictID], [TehsilName], [CreateDate], [ModifiedDate], [IsActive]) VALUES (1, 1, 7, N'Dungla', NULL, NULL, 1)
GO
INSERT [dbo].[TehsilMasterTbl] ([ID], [StateID], [DistrictID], [TehsilName], [CreateDate], [ModifiedDate], [IsActive]) VALUES (2, 1, 7, N'Barisadri', CAST(N'2023-08-05T10:10:07.180' AS DateTime), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[TehsilMasterTbl] OFF
GO
ALTER TABLE [dbo].[AdminLoginTbl]  WITH CHECK ADD  CONSTRAINT [FK_AdminLoginTbl_RoleMasterTbl] FOREIGN KEY([Role])
REFERENCES [dbo].[RoleMasterTbl] ([Id])
GO
ALTER TABLE [dbo].[AdminLoginTbl] CHECK CONSTRAINT [FK_AdminLoginTbl_RoleMasterTbl]
GO
ALTER TABLE [dbo].[ChildIndividualTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildIndividualTbl_ChildCategoryTbl] FOREIGN KEY([ChildCategory])
REFERENCES [dbo].[ChildCategoryTbl] ([Id])
GO
ALTER TABLE [dbo].[ChildIndividualTbl] CHECK CONSTRAINT [FK_ChildIndividualTbl_ChildCategoryTbl]
GO
ALTER TABLE [dbo].[ChildIndividualTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildIndividualTbl_DistrictMasterTbl] FOREIGN KEY([District])
REFERENCES [dbo].[DistrictMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[ChildIndividualTbl] CHECK CONSTRAINT [FK_ChildIndividualTbl_DistrictMasterTbl]
GO
ALTER TABLE [dbo].[ChildIndividualTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildIndividualTbl_DistrictMasterTbl1] FOREIGN KEY([ChildDistrict])
REFERENCES [dbo].[DistrictMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[ChildIndividualTbl] CHECK CONSTRAINT [FK_ChildIndividualTbl_DistrictMasterTbl1]
GO
ALTER TABLE [dbo].[ChildIndividualTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildIndividualTbl_StateMasterTbl] FOREIGN KEY([State])
REFERENCES [dbo].[StateMasterTbl] ([Id])
GO
ALTER TABLE [dbo].[ChildIndividualTbl] CHECK CONSTRAINT [FK_ChildIndividualTbl_StateMasterTbl]
GO
ALTER TABLE [dbo].[ChildIndividualTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildIndividualTbl_StateMasterTbl1] FOREIGN KEY([ChildState])
REFERENCES [dbo].[StateMasterTbl] ([Id])
GO
ALTER TABLE [dbo].[ChildIndividualTbl] CHECK CONSTRAINT [FK_ChildIndividualTbl_StateMasterTbl1]
GO
ALTER TABLE [dbo].[ChildIndividualTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildIndividualTbl_TehsilMasterTbl] FOREIGN KEY([Tehsil])
REFERENCES [dbo].[TehsilMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[ChildIndividualTbl] CHECK CONSTRAINT [FK_ChildIndividualTbl_TehsilMasterTbl]
GO
ALTER TABLE [dbo].[ChildIndividualTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildIndividualTbl_TehsilMasterTbl1] FOREIGN KEY([ChildTehsil])
REFERENCES [dbo].[TehsilMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[ChildIndividualTbl] CHECK CONSTRAINT [FK_ChildIndividualTbl_TehsilMasterTbl1]
GO
ALTER TABLE [dbo].[ChildInstitutionTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildInstitutionTbl_ChildCategoryTbl] FOREIGN KEY([CategoryOfChild])
REFERENCES [dbo].[ChildCategoryTbl] ([Id])
GO
ALTER TABLE [dbo].[ChildInstitutionTbl] CHECK CONSTRAINT [FK_ChildInstitutionTbl_ChildCategoryTbl]
GO
ALTER TABLE [dbo].[ChildInstitutionTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildInstitutionTbl_DistrictMasterTbl] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[DistrictMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[ChildInstitutionTbl] CHECK CONSTRAINT [FK_ChildInstitutionTbl_DistrictMasterTbl]
GO
ALTER TABLE [dbo].[ChildInstitutionTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildInstitutionTbl_DistrictMasterTbl1] FOREIGN KEY([ChildDistrictId])
REFERENCES [dbo].[DistrictMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[ChildInstitutionTbl] CHECK CONSTRAINT [FK_ChildInstitutionTbl_DistrictMasterTbl1]
GO
ALTER TABLE [dbo].[ChildInstitutionTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildInstitutionTbl_StateMasterTbl] FOREIGN KEY([StateID])
REFERENCES [dbo].[StateMasterTbl] ([Id])
GO
ALTER TABLE [dbo].[ChildInstitutionTbl] CHECK CONSTRAINT [FK_ChildInstitutionTbl_StateMasterTbl]
GO
ALTER TABLE [dbo].[ChildInstitutionTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildInstitutionTbl_StateMasterTbl1] FOREIGN KEY([ChildStateId])
REFERENCES [dbo].[StateMasterTbl] ([Id])
GO
ALTER TABLE [dbo].[ChildInstitutionTbl] CHECK CONSTRAINT [FK_ChildInstitutionTbl_StateMasterTbl1]
GO
ALTER TABLE [dbo].[ChildInstitutionTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildInstitutionTbl_TehsilMasterTbl] FOREIGN KEY([TehsilID])
REFERENCES [dbo].[TehsilMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[ChildInstitutionTbl] CHECK CONSTRAINT [FK_ChildInstitutionTbl_TehsilMasterTbl]
GO
ALTER TABLE [dbo].[ChildInstitutionTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildInstitutionTbl_TehsilMasterTbl1] FOREIGN KEY([ChildTehsil])
REFERENCES [dbo].[TehsilMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[ChildInstitutionTbl] CHECK CONSTRAINT [FK_ChildInstitutionTbl_TehsilMasterTbl1]
GO
ALTER TABLE [dbo].[ChildMasterTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildMasterTbl_AdminLoginTbl] FOREIGN KEY([UserID])
REFERENCES [dbo].[AdminLoginTbl] ([Id])
GO
ALTER TABLE [dbo].[ChildMasterTbl] CHECK CONSTRAINT [FK_ChildMasterTbl_AdminLoginTbl]
GO
ALTER TABLE [dbo].[ChildMasterTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildMasterTbl_CCIMasterTbl] FOREIGN KEY([CCIMasterID])
REFERENCES [dbo].[CCIMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[ChildMasterTbl] CHECK CONSTRAINT [FK_ChildMasterTbl_CCIMasterTbl]
GO
ALTER TABLE [dbo].[ChildMasterTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildMasterTbl_DistrictMasterTbl] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[DistrictMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[ChildMasterTbl] CHECK CONSTRAINT [FK_ChildMasterTbl_DistrictMasterTbl]
GO
ALTER TABLE [dbo].[ChildMasterTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildMasterTbl_DistrictMasterTbl1] FOREIGN KEY([PlacementDistrict])
REFERENCES [dbo].[DistrictMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[ChildMasterTbl] CHECK CONSTRAINT [FK_ChildMasterTbl_DistrictMasterTbl1]
GO
ALTER TABLE [dbo].[ChildMasterTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildMasterTbl_DistrictMasterTbl2] FOREIGN KEY([MonitoringDistrict])
REFERENCES [dbo].[DistrictMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[ChildMasterTbl] CHECK CONSTRAINT [FK_ChildMasterTbl_DistrictMasterTbl2]
GO
ALTER TABLE [dbo].[ChildMasterTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildMasterTbl_DistrictMasterTbl3] FOREIGN KEY([AddressDistrict])
REFERENCES [dbo].[DistrictMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[ChildMasterTbl] CHECK CONSTRAINT [FK_ChildMasterTbl_DistrictMasterTbl3]
GO
ALTER TABLE [dbo].[ChildParentConnectionTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildParentConnectionTbl_ChildMasterTbl] FOREIGN KEY([ChildID])
REFERENCES [dbo].[ChildMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[ChildParentConnectionTbl] CHECK CONSTRAINT [FK_ChildParentConnectionTbl_ChildMasterTbl]
GO
ALTER TABLE [dbo].[ChildParentConnectionTbl]  WITH CHECK ADD  CONSTRAINT [FK_ChildParentConnectionTbl_ParentMasterTbl] FOREIGN KEY([ParentID])
REFERENCES [dbo].[ParentMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[ChildParentConnectionTbl] CHECK CONSTRAINT [FK_ChildParentConnectionTbl_ParentMasterTbl]
GO
ALTER TABLE [dbo].[DistrictMasterTbl]  WITH CHECK ADD  CONSTRAINT [FK_DistrictMasterTbl_StateMasterTbl] FOREIGN KEY([StateID])
REFERENCES [dbo].[StateMasterTbl] ([Id])
GO
ALTER TABLE [dbo].[DistrictMasterTbl] CHECK CONSTRAINT [FK_DistrictMasterTbl_StateMasterTbl]
GO
ALTER TABLE [dbo].[EnquiryTbl]  WITH CHECK ADD  CONSTRAINT [FK_EnquiryTbl_AdminLoginTbl] FOREIGN KEY([UserID])
REFERENCES [dbo].[AdminLoginTbl] ([Id])
GO
ALTER TABLE [dbo].[EnquiryTbl] CHECK CONSTRAINT [FK_EnquiryTbl_AdminLoginTbl]
GO
ALTER TABLE [dbo].[FosterParentTbl]  WITH CHECK ADD  CONSTRAINT [FK_FosterParentTbl_DistrictMasterTbl] FOREIGN KEY([District])
REFERENCES [dbo].[DistrictMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[FosterParentTbl] CHECK CONSTRAINT [FK_FosterParentTbl_DistrictMasterTbl]
GO
ALTER TABLE [dbo].[FosterParentTbl]  WITH CHECK ADD  CONSTRAINT [FK_FosterParentTbl_StateMasterTbl] FOREIGN KEY([State])
REFERENCES [dbo].[StateMasterTbl] ([Id])
GO
ALTER TABLE [dbo].[FosterParentTbl] CHECK CONSTRAINT [FK_FosterParentTbl_StateMasterTbl]
GO
ALTER TABLE [dbo].[ParentMasterTbl]  WITH CHECK ADD  CONSTRAINT [FK_ParentMasterTbl_AdminLoginTbl] FOREIGN KEY([UserID])
REFERENCES [dbo].[AdminLoginTbl] ([Id])
GO
ALTER TABLE [dbo].[ParentMasterTbl] CHECK CONSTRAINT [FK_ParentMasterTbl_AdminLoginTbl]
GO
ALTER TABLE [dbo].[ParentMasterTbl]  WITH CHECK ADD  CONSTRAINT [FK_ParentMasterTbl_DistrictMasterTbl] FOREIGN KEY([FosterParentDistrict])
REFERENCES [dbo].[DistrictMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[ParentMasterTbl] CHECK CONSTRAINT [FK_ParentMasterTbl_DistrictMasterTbl]
GO
ALTER TABLE [dbo].[PermissionMasterTbl]  WITH CHECK ADD  CONSTRAINT [FK_PermissionMasterTbl_ModuleMasterTbl] FOREIGN KEY([ModuleID])
REFERENCES [dbo].[ModuleMasterTbl] ([Id])
GO
ALTER TABLE [dbo].[PermissionMasterTbl] CHECK CONSTRAINT [FK_PermissionMasterTbl_ModuleMasterTbl]
GO
ALTER TABLE [dbo].[PermissionMasterTbl]  WITH CHECK ADD  CONSTRAINT [FK_PermissionMasterTbl_RoleMasterTbl] FOREIGN KEY([RoleID])
REFERENCES [dbo].[RoleMasterTbl] ([Id])
GO
ALTER TABLE [dbo].[PermissionMasterTbl] CHECK CONSTRAINT [FK_PermissionMasterTbl_RoleMasterTbl]
GO
ALTER TABLE [dbo].[PotentialParentMaster]  WITH CHECK ADD  CONSTRAINT [FK_PotentialParentMaster_AdminLoginTbl] FOREIGN KEY([UserID])
REFERENCES [dbo].[AdminLoginTbl] ([Id])
GO
ALTER TABLE [dbo].[PotentialParentMaster] CHECK CONSTRAINT [FK_PotentialParentMaster_AdminLoginTbl]
GO
ALTER TABLE [dbo].[TehsilMasterTbl]  WITH CHECK ADD  CONSTRAINT [FK_TehsilMasterTbl_DistrictMasterTbl] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[DistrictMasterTbl] ([ID])
GO
ALTER TABLE [dbo].[TehsilMasterTbl] CHECK CONSTRAINT [FK_TehsilMasterTbl_DistrictMasterTbl]
GO
ALTER TABLE [dbo].[TehsilMasterTbl]  WITH CHECK ADD  CONSTRAINT [FK_TehsilMasterTbl_StateMasterTbl] FOREIGN KEY([StateID])
REFERENCES [dbo].[StateMasterTbl] ([Id])
GO
ALTER TABLE [dbo].[TehsilMasterTbl] CHECK CONSTRAINT [FK_TehsilMasterTbl_StateMasterTbl]
GO
