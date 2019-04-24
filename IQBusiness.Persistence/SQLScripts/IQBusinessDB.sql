USE [master]
GO

/****** Object:  Database [IQBusiness]    Script Date: 2019/04/23 03:27:44 ******/
CREATE DATABASE [IQBusiness]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IQBusiness', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\IQBusiness.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IQBusiness_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\IQBusiness_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO


ALTER DATABASE [IQBusiness] SET  READ_WRITE 
GO


