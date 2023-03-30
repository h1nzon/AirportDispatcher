USE [AirportDispatcher]
GO
/****** Object:  Table [dbo].[Aircrafts]    Script Date: 30.03.2023 13:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aircrafts](
	[AircraftCode] [char](3) NOT NULL,
	[Model] [nvarchar](50) NULL,
	[Range] [nvarchar](50) NULL,
 CONSTRAINT [PK_Aircrafts] PRIMARY KEY CLUSTERED 
(
	[AircraftCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Airports]    Script Date: 30.03.2023 13:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airports](
	[AirportCode] [char](3) NOT NULL,
	[AirportName] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[TimeZone] [int] NULL,
 CONSTRAINT [PK_Airports] PRIMARY KEY CLUSTERED 
(
	[AirportCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoardingPasses]    Script Date: 30.03.2023 13:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoardingPasses](
	[TicketNo] [char](13) NULL,
	[FlightID] [int] NULL,
	[BoardingNo] [int] NULL,
	[SeatNo] [varchar](4) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 30.03.2023 13:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[BookRef] [char](6) NULL,
	[BookDate] [bigint] NULL,
	[TotalAmount] [numeric](10, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flights]    Script Date: 30.03.2023 13:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flights](
	[FlightID] [int] NOT NULL,
	[FlightNo] [char](6) NULL,
	[ScheduledDeparture] [bigint] NULL,
	[ScheduledArrival] [bigint] NULL,
	[DepartureAirport] [char](3) NULL,
	[ArrivalAirport] [char](3) NULL,
	[Status] [varchar](20) NULL,
	[AircraftCode] [char](3) NULL,
	[ActualDeparture] [bigint] NULL,
	[ActualArrival] [bigint] NULL,
 CONSTRAINT [PK_Flights] PRIMARY KEY CLUSTERED 
(
	[FlightID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 30.03.2023 13:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[NameRole] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seats]    Script Date: 30.03.2023 13:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seats](
	[AircraftCode] [char](3) NOT NULL,
	[SeatNo] [varchar](4) NOT NULL,
	[FareConditions] [varbinary](10) NULL,
 CONSTRAINT [PK_Seats] PRIMARY KEY CLUSTERED 
(
	[AircraftCode] ASC,
	[SeatNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketFlights]    Script Date: 30.03.2023 13:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketFlights](
	[TicketNo] [char](13) NULL,
	[FlightID] [int] NULL,
	[FareConditions] [varchar](10) NULL,
	[Amount] [numeric](10, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 30.03.2023 13:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[TicketNo] [char](13) NULL,
	[BookRef] [char](6) NULL,
	[PassengerID] [varchar](20) NULL,
	[PassengerName] [varchar](50) NULL,
	[ContactData] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 30.03.2023 13:30:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[PassportID] [int] NULL,
	[PassportSeries] [int] NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [NameRole]) VALUES (1, N'Пользователь')
SET IDENTITY_INSERT [dbo].[Roles] OFF
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IDRole]  DEFAULT ((1)) FOR [RoleID]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_Flights_Aircrafts] FOREIGN KEY([AircraftCode])
REFERENCES [dbo].[Aircrafts] ([AircraftCode])
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_Flights_Aircrafts]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_Flights_Airports] FOREIGN KEY([ArrivalAirport])
REFERENCES [dbo].[Airports] ([AirportCode])
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_Flights_Airports]
GO
ALTER TABLE [dbo].[Flights]  WITH CHECK ADD  CONSTRAINT [FK_Flights_Airports1] FOREIGN KEY([DepartureAirport])
REFERENCES [dbo].[Airports] ([AirportCode])
GO
ALTER TABLE [dbo].[Flights] CHECK CONSTRAINT [FK_Flights_Airports1]
GO
ALTER TABLE [dbo].[Seats]  WITH CHECK ADD  CONSTRAINT [FK_Seats_Aircrafts] FOREIGN KEY([AircraftCode])
REFERENCES [dbo].[Aircrafts] ([AircraftCode])
GO
ALTER TABLE [dbo].[Seats] CHECK CONSTRAINT [FK_Seats_Aircrafts]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
