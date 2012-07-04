CREATE DATABASE  IF NOT EXISTS `sdpm` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `sdpm`;
-- MySQL dump 10.13  Distrib 5.5.16, for Win32 (x86)
--
-- Host: localhost    Database: sdpm
-- ------------------------------------------------------
-- Server version	5.5.25

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `parametervalue`
--

DROP TABLE IF EXISTS `parametervalue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `parametervalue` (
  `idParameterValue` int(11) NOT NULL AUTO_INCREMENT,
  `Number` int(11) NOT NULL,
  `Value` varchar(45) DEFAULT NULL,
  `ValueMax` varchar(45) DEFAULT NULL,
  `ValueMin` varchar(45) DEFAULT NULL,
  `Units_idUnits` int(11) NOT NULL,
  `UnitPrefix_idUnitPrefix` int(11) NOT NULL,
  `Projects_has_Requirements_idProjectsHasRequirements` int(11) NOT NULL,
  `Parameters_idParameters` int(11) NOT NULL,
  PRIMARY KEY (`idParameterValue`),
  KEY `fk_ParameterValue_Units1` (`Units_idUnits`),
  KEY `fk_ParameterValue_UnitPrefix1` (`UnitPrefix_idUnitPrefix`),
  KEY `fk_ParameterValue_Projects_has_Requirements1` (`Projects_has_Requirements_idProjectsHasRequirements`),
  KEY `fk_ParameterValue_Parameters1` (`Parameters_idParameters`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parametervalue`
--

LOCK TABLES `parametervalue` WRITE;
/*!40000 ALTER TABLE `parametervalue` DISABLE KEYS */;
/*!40000 ALTER TABLE `parametervalue` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2012-07-04 15:57:30
