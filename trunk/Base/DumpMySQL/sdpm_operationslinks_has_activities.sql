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
-- Table structure for table `operationslinks_has_activities`
--

DROP TABLE IF EXISTS `operationslinks_has_activities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `operationslinks_has_activities` (
  `LinksOperations_idLinksOperations` int(11) NOT NULL,
  `Activities_idActivities` int(11) NOT NULL,
  `OperationStart` int(11) DEFAULT NULL,
  `OperationFinish` int(11) DEFAULT NULL,
  KEY `fk_OperationsRelations_has_Activities_Activities1` (`Activities_idActivities`),
  KEY `fk_OperationsRelations_has_Activities_OperationsRelations1` (`LinksOperations_idLinksOperations`),
  CONSTRAINT `fk_OperationsRelations_has_Activities_OperationsRelations1` FOREIGN KEY (`LinksOperations_idLinksOperations`) REFERENCES `linksoperations` (`idLinksOperations`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_OperationsRelations_has_Activities_Activities1` FOREIGN KEY (`Activities_idActivities`) REFERENCES `activities` (`idActivities`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `operationslinks_has_activities`
--

LOCK TABLES `operationslinks_has_activities` WRITE;
/*!40000 ALTER TABLE `operationslinks_has_activities` DISABLE KEYS */;
/*!40000 ALTER TABLE `operationslinks_has_activities` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2012-07-05 10:00:43
