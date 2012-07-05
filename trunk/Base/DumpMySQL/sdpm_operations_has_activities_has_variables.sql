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
-- Table structure for table `operations_has_activities_has_variables`
--

DROP TABLE IF EXISTS `operations_has_activities_has_variables`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `operations_has_activities_has_variables` (
  `Operations_has_Activities_idOperationsHasActivities` int(11) NOT NULL AUTO_INCREMENT,
  `Variables_idVariables` int(11) NOT NULL,
  `VarValue` varchar(45) DEFAULT NULL,
  `Number` int(11) DEFAULT NULL,
  KEY `fk_Operations_has_Activities_has_Variables_Variables1` (`Variables_idVariables`),
  KEY `fk_Operations_has_Activities_has_Variables_Operations_has_Act1` (`Operations_has_Activities_idOperationsHasActivities`),
  CONSTRAINT `fk_Operations_has_Activities_has_Variables_Operations_has_Act1` FOREIGN KEY (`Operations_has_Activities_idOperationsHasActivities`) REFERENCES `operations_has_activities` (`idOperationsHasActivities`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Operations_has_Activities_has_Variables_Variables1` FOREIGN KEY (`Variables_idVariables`) REFERENCES `variables` (`idVariables`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `operations_has_activities_has_variables`
--

LOCK TABLES `operations_has_activities_has_variables` WRITE;
/*!40000 ALTER TABLE `operations_has_activities_has_variables` DISABLE KEYS */;
/*!40000 ALTER TABLE `operations_has_activities_has_variables` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2012-07-05 10:00:45
