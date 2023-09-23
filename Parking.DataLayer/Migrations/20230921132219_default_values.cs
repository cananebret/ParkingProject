using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingProject.DataLayer.Migrations
{
    public partial class default_values : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    INSERT [dbo].[CarParks] ([Id], [TypeId], [NumberPlate], [ModelYear], [ModelName], [Color], [Description], [StartDate], [EndDate], [Amount], [CreatedDate], [UpdatedDate], [Deleted], [IsActive], [StayDate], [IsOut]) VALUES (N'b3f56032-3785-41ce-08e3-08dbba8a00bb', 1, N'34Test0034', N'2023', N'BMW', NULL, NULL, CAST(N'2023-09-21T13:03:28.3019565' AS DateTime2), CAST(N'2023-09-21T15:18:58.8642508' AS DateTime2), NULL, CAST(N'2023-09-21T13:03:28.3016780' AS DateTime2), CAST(N'2023-09-21T13:03:28.3018246' AS DateTime2), 0, 1, NULL, 0)
                                    INSERT [dbo].[CarParks] ([Id], [TypeId], [NumberPlate], [ModelYear], [ModelName], [Color], [Description], [StartDate], [EndDate], [Amount], [CreatedDate], [UpdatedDate], [Deleted], [IsActive], [StayDate], [IsOut]) VALUES (N'b6114676-b166-492a-cda2-08dbba994c2f', 2, N'34CE34', N'2022', N'Audi', NULL, NULL, CAST(N'2023-09-21T14:52:57.3584156' AS DateTime2), CAST(N'2023-09-21T15:25:15.6622785' AS DateTime2), NULL, CAST(N'2023-09-21T14:52:57.3582647' AS DateTime2), CAST(N'2023-09-21T14:52:57.3582650' AS DateTime2), 0, 1, NULL, 0)
                                    INSERT [dbo].[CarParks] ([Id], [TypeId], [NumberPlate], [ModelYear], [ModelName], [Color], [Description], [StartDate], [EndDate], [Amount], [CreatedDate], [UpdatedDate], [Deleted], [IsActive], [StayDate], [IsOut]) VALUES (N'eaf58956-52ab-44b8-29c4-08dbba999bc8', 3, N'34AB34', N'2021', N'Mercedes', NULL, NULL, CAST(N'2023-09-21T14:55:10.9052754' AS DateTime2), NULL, NULL, CAST(N'2023-09-21T14:55:10.9049718' AS DateTime2), CAST(N'2023-09-21T14:55:10.9049742' AS DateTime2), 0, 1, NULL, 0)
                                    INSERT [dbo].[ParkingInfos] ([Id], [OpeningDate], [ClosingDate], [HourlyWage], [CreatedDate], [UpdatedDate], [Deleted], [IsActive]) VALUES (N'b33154c0-d577-421a-74f8-08dbba92a848', CAST(N'2023-01-01T06:00:00.0000000' AS DateTime2), CAST(N'2023-01-01T23:59:00.0000000' AS DateTime2), CAST(25.00 AS Decimal(18, 2)), CAST(N'2023-09-21T14:05:25.3105579' AS DateTime2), CAST(N'2023-09-21T14:05:25.3107222' AS DateTime2), 0, 1)
                                    INSERT [dbo].[Vehicles] ([Id], [Type], [Description], [IsCarWashing], [IsTireChanging], [CreatedDate], [UpdatedDate], [Deleted], [IsActive], [HasAmount], [HasAutoPilot], [HasSpareTyre], [HasTrunkVolume], [WageCoefficient]) VALUES (N'088dbce7-639a-40b7-8472-08dbba6557e8', 1, N'1.Sınıf Araç', 1, 0, CAST(N'2023-09-21T08:41:03.1793700' AS DateTime2), CAST(N'2023-09-21T08:41:03.1794817' AS DateTime2), 0, 1, 1, 1, 0, 0, CAST(1.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[Vehicles] ([Id], [Type], [Description], [IsCarWashing], [IsTireChanging], [CreatedDate], [UpdatedDate], [Deleted], [IsActive], [HasAmount], [HasAutoPilot], [HasSpareTyre], [HasTrunkVolume], [WageCoefficient]) VALUES (N'6349a494-0e02-4a12-8473-08dbba6557e8', 2, N'2.Sınıf Araç', 0, 1, CAST(N'2023-09-21T08:41:11.9810353' AS DateTime2), CAST(N'2023-09-21T08:41:11.9810362' AS DateTime2), 0, 1, 0, 0, 1, 1, CAST(2.00 AS Decimal(18, 2)))
                                    INSERT [dbo].[Vehicles] ([Id], [Type], [Description], [IsCarWashing], [IsTireChanging], [CreatedDate], [UpdatedDate], [Deleted], [IsActive], [HasAmount], [HasAutoPilot], [HasSpareTyre], [HasTrunkVolume], [WageCoefficient]) VALUES (N'be2a31e4-11a4-4c61-8474-08dbba6557e8', 3, N'3.Sınıf Araç', 0, 0, CAST(N'2023-09-21T08:41:18.2765952' AS DateTime2), CAST(N'2023-09-21T08:41:18.2765971' AS DateTime2), 0, 1, 0, 0, 0, 0, CAST(3.00 AS Decimal(18, 2)))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
