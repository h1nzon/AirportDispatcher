USE [AirportDispatcher]
GO
/****** Object:  Table [dbo].[Aircrafts]    Script Date: 4/20/2023 11:57:47 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Airports]    Script Date: 4/20/2023 11:57:47 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoardingPasses]    Script Date: 4/20/2023 11:57:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoardingPasses](
	[TicketNo] [char](13) NOT NULL,
	[FlightID] [int] NOT NULL,
	[BoardingNo] [int] NULL,
	[SeatNo] [varchar](4) NULL,
 CONSTRAINT [PK_BoardingPasses] PRIMARY KEY CLUSTERED 
(
	[TicketNo] ASC,
	[FlightID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 4/20/2023 11:57:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[BookRef] [char](6) NOT NULL,
	[BookDate] [bigint] NULL,
	[TotalAmount] [numeric](10, 2) NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[BookRef] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EncryptionKeys]    Script Date: 4/20/2023 11:57:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EncryptionKeys](
	[UserID] [int] NOT NULL,
	[EncryptionKey] [nvarchar](max) NULL,
	[EncryptionIV] [nvarchar](max) NULL,
 CONSTRAINT [PK_EncryptionKeys] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flights]    Script Date: 4/20/2023 11:57:47 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 4/20/2023 11:57:47 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seats]    Script Date: 4/20/2023 11:57:47 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketFlights]    Script Date: 4/20/2023 11:57:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketFlights](
	[TicketNo] [char](13) NOT NULL,
	[FlightID] [int] NOT NULL,
	[FareConditions] [varchar](10) NULL,
	[Amount] [numeric](10, 2) NULL,
 CONSTRAINT [PK_TicketFlights] PRIMARY KEY CLUSTERED 
(
	[TicketNo] ASC,
	[FlightID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 4/20/2023 11:57:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[TicketNo] [char](13) NOT NULL,
	[BookRef] [char](6) NULL,
	[PassengerID] [varchar](20) NULL,
	[PassengerName] [varchar](50) NULL,
	[ContactData] [varchar](50) NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[TicketNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/20/2023 11:57:47 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IDRole]  DEFAULT ((1)) FOR [RoleID]
GO
ALTER TABLE [dbo].[BoardingPasses]  WITH CHECK ADD  CONSTRAINT [FK_BoardingPasses_TicketFlights] FOREIGN KEY([TicketNo], [FlightID])
REFERENCES [dbo].[TicketFlights] ([TicketNo], [FlightID])
GO
ALTER TABLE [dbo].[BoardingPasses] CHECK CONSTRAINT [FK_BoardingPasses_TicketFlights]
GO
ALTER TABLE [dbo].[EncryptionKeys]  WITH CHECK ADD  CONSTRAINT [FK_EncryptionKeys_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EncryptionKeys] CHECK CONSTRAINT [FK_EncryptionKeys_Users]
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
ALTER TABLE [dbo].[TicketFlights]  WITH CHECK ADD  CONSTRAINT [FK_TicketFlights_Flights] FOREIGN KEY([FlightID])
REFERENCES [dbo].[Flights] ([FlightID])
GO
ALTER TABLE [dbo].[TicketFlights] CHECK CONSTRAINT [FK_TicketFlights_Flights]
GO
ALTER TABLE [dbo].[TicketFlights]  WITH CHECK ADD  CONSTRAINT [FK_TicketFlights_Tickets] FOREIGN KEY([TicketNo])
REFERENCES [dbo].[Tickets] ([TicketNo])
GO
ALTER TABLE [dbo].[TicketFlights] CHECK CONSTRAINT [FK_TicketFlights_Tickets]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Bookings] FOREIGN KEY([BookRef])
REFERENCES [dbo].[Bookings] ([BookRef])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Bookings]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
