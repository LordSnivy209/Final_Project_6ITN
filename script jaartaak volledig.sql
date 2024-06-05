CREATE DATABASE  IF NOT EXISTS `databasenotities` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `databasenotities`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: databasenotities
-- ------------------------------------------------------
-- Server version	8.0.34

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `gebruiker`
--

DROP TABLE IF EXISTS `gebruiker`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `gebruiker` (
  `userID` int NOT NULL AUTO_INCREMENT,
  `orgID` int NOT NULL,
  `username` varchar(50) NOT NULL,
  `passwordUser` varchar(40) NOT NULL,
  PRIMARY KEY (`userID`),
  UNIQUE KEY `username_UNIQUE` (`username`),
  KEY `orgID` (`orgID`),
  CONSTRAINT `gebruiker_ibfk_1` FOREIGN KEY (`orgID`) REFERENCES `organisation` (`orgID`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gebruiker`
--

LOCK TABLES `gebruiker` WRITE;
/*!40000 ALTER TABLE `gebruiker` DISABLE KEYS */;
INSERT INTO `gebruiker` VALUES (1,1,'Flor','1234'),(2,2,'Victor','1234'),(3,1,'Fedor','1234'),(4,2,'Luka','1234'),(8,0,'Bart','1234'),(9,0,'Willem','1234'),(10,0,'Bert','1234'),(11,0,'Mark','1234'),(12,0,'Nesquick','1239'),(22,0,'Henk','1234');
/*!40000 ALTER TABLE `gebruiker` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notitie`
--

DROP TABLE IF EXISTS `notitie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notitie` (
  `noteID` int NOT NULL AUTO_INCREMENT,
  `userID` int NOT NULL,
  `title` varchar(120) NOT NULL,
  `content` text,
  `creationDate` date NOT NULL,
  PRIMARY KEY (`noteID`),
  KEY `userID` (`userID`),
  CONSTRAINT `notitie_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `gebruiker` (`userID`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notitie`
--

LOCK TABLES `notitie` WRITE;
/*!40000 ALTER TABLE `notitie` DISABLE KEYS */;
INSERT INTO `notitie` VALUES (2,2,'Meeting 11-09-2024','Meeting met de baas op bureau','2023-11-30'),(4,4,'Luka','Luka Luka Luka Luka Luka Luka','2023-12-01'),(7,1,'hallo!!!','hallo wereld!','2024-05-22'),(9,2,'Js','scriptje schrijven','2024-05-23'),(11,1,'idk','ik weet niet wat te typen','2024-05-24'),(14,3,'hhhh','ahahah','2024-05-24'),(19,1,'help','help alles werkt nog','2024-05-27'),(20,1,'taken','\nSnel opruimen van rondslingerende spullen, \nEettafel en stoelen afvegen','2024-06-05'),(21,1,'school','de leerkrachten uitwuiven','2024-06-05');
/*!40000 ALTER TABLE `notitie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organisation`
--

DROP TABLE IF EXISTS `organisation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `organisation` (
  `orgID` int NOT NULL AUTO_INCREMENT,
  `orgName` varchar(50) NOT NULL,
  `orgPassword` varchar(40) NOT NULL,
  PRIMARY KEY (`orgID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organisation`
--

LOCK TABLES `organisation` WRITE;
/*!40000 ALTER TABLE `organisation` DISABLE KEYS */;
INSERT INTO `organisation` VALUES (0,'default','default'),(1,'Baap','1234'),(2,'Pidpa','1234'),(3,'Shell','1234'),(4,'Pepsico','1234'),(5,'McDonalds','1234');
/*!40000 ALTER TABLE `organisation` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-05 10:49:32
