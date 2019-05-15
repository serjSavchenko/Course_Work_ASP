CREATE DATABASE  IF NOT EXISTS `cake` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `cake`;
-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: localhost    Database: cake
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cakes`
--

DROP TABLE IF EXISTS `cakes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `cakes` (
  `CakeId` int(11) NOT NULL,
  `Name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Category` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Price` decimal(16,2) NOT NULL,
  `CreateDate` datetime NOT NULL,
  `SpoiledDate` datetime NOT NULL,
  `Quantity` int(11) NOT NULL,
  PRIMARY KEY (`CakeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cakes`
--

LOCK TABLES `cakes` WRITE;
/*!40000 ALTER TABLE `cakes` DISABLE KEYS */;
INSERT INTO `cakes` VALUES (1,'Киевский торт','Киевский торт','Торт',600.00,'2019-09-05 15:06:00','2019-10-05 15:06:00',10),(2,'\"Наполеон\"','Торт \"Наполеон\"','Торт',650.00,'2019-09-05 15:06:00','2019-10-05 03:06:00',11),(3,'\"Эклер\"','Пироженое \"Эклер\"','Пироженое',350.00,'2019-09-05 15:06:00','2019-10-05 15:06:00',9),(4,'\"Кекс\"','Пироженое \"Кекс\"','Пироженое',500.00,'2019-09-05 15:06:00','2019-10-05 15:06:00',40),(5,'\"Крекеры\"','Печенье \"Крекер\"','Печенье',150.00,'2019-09-05 15:06:00','2019-10-05 15:06:00',12),(6,'\"Мария\"','Печенье \"Мария\"','Печенье',175.00,'2019-09-05 15:06:00','2019-10-05 15:06:00',65),(7,'\"Американо\"','Печенье \"Американо\"','Печенье',170.00,'2019-09-05 15:06:00','2019-10-05 15:06:00',4),(8,'\"Корзинка\"','Пироженое \"Корзинка\"','Пироженое',250.00,'2019-09-05 15:06:00','2019-10-05 15:06:00',74),(9,'\"Бизе\"','Пироженое \"Бизе\"','Пироженое',300.00,'2019-09-05 15:06:00','2019-10-05 15:06:00',20),(10,'\"Макарунс\"','Пироженное \"Макарунс\"','Пироженое',350.00,'2019-09-05 15:06:00','2019-10-05 15:06:00',10);
/*!40000 ALTER TABLE `cakes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-15 17:16:21
