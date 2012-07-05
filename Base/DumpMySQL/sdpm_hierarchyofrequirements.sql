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
-- Table structure for table `hierarchyofrequirements`
--

DROP TABLE IF EXISTS `hierarchyofrequirements`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `hierarchyofrequirements` (
  `idHierarchyOfRequirements` int(11) NOT NULL AUTO_INCREMENT,
  `isRequirementsBegin` int(11) DEFAULT NULL,
  `isRequirementsEnd` int(11) DEFAULT NULL,
  `Projects_idProjects` int(11) NOT NULL,
  PRIMARY KEY (`idHierarchyOfRequirements`),
  KEY `fk_HierarchyOfSpecifications_Projects1` (`Projects_idProjects`),
  CONSTRAINT `fk_HierarchyOfSpecifications_Projects1` FOREIGN KEY (`Projects_idProjects`) REFERENCES `projects` (`idProjects`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hierarchyofrequirements`
--

LOCK TABLES `hierarchyofrequirements` WRITE;
/*!40000 ALTER TABLE `hierarchyofrequirements` DISABLE KEYS */;
/*!40000 ALTER TABLE `hierarchyofrequirements` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2012-07-05 10:00:32
