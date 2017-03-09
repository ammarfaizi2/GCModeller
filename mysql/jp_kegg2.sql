CREATE DATABASE  IF NOT EXISTS `jp_kegg2` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `jp_kegg2`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: jp_kegg2
-- ------------------------------------------------------
-- Server version	5.7.12-log

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
-- Table structure for table `disease`
--

DROP TABLE IF EXISTS `disease`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `disease` (
  `entry_id` varchar(45) NOT NULL,
  `definition` longtext,
  `guid` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`entry_id`),
  UNIQUE KEY `guid_UNIQUE` (`guid`),
  UNIQUE KEY `entry_id_UNIQUE` (`entry_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='KEGG上面的疾病的定义的数据表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `drug`
--

DROP TABLE IF EXISTS `drug`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `drug` (
  `entry` char(8) NOT NULL,
  `names` mediumtext,
  `formula` varchar(128) DEFAULT NULL,
  `exact_mass` double DEFAULT NULL,
  `mol_weight` double DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  `activity` varchar(45) DEFAULT NULL,
  `atoms` varchar(45) DEFAULT NULL,
  `bounds` varchar(45) DEFAULT NULL,
  `comments` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`entry`),
  UNIQUE KEY `entry_UNIQUE` (`entry`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='KEGG drug data';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `drug_xref`
--

DROP TABLE IF EXISTS `drug_xref`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `drug_xref` (
  `drug` int(11) NOT NULL,
  `db` varchar(45) DEFAULT NULL,
  `xref` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`drug`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `genes`
--

DROP TABLE IF EXISTS `genes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `genes` (
  `locus_tag` char(45) NOT NULL COMMENT '基因号',
  `gene_name` mediumtext COMMENT '基因名',
  `definition` mediumtext,
  `aa_seq` longtext,
  `nt_seq` longtext,
  `ec` tinytext,
  `modules` mediumtext,
  `diseases` mediumtext,
  `organism` varchar(45) DEFAULT NULL,
  `pathways` varchar(45) DEFAULT NULL,
  `uniprot` varchar(45) DEFAULT NULL COMMENT 'uniprot entry for this protein',
  `ncbi_entry` varchar(45) DEFAULT NULL,
  `kegg_sp` varchar(45) DEFAULT NULL COMMENT 'kegg species organism brief code',
  PRIMARY KEY (`locus_tag`),
  UNIQUE KEY `entry_UNIQUE` (`locus_tag`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='基因的概览表，主要的数据包括蛋白功能以及序列数据和一些dbxref的简单的数量统计';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `module`
--

DROP TABLE IF EXISTS `module`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `module` (
  `entry` varchar(45) NOT NULL,
  `name` longtext,
  `definition` longtext,
  `class` text,
  `category` text,
  `type` text,
  PRIMARY KEY (`entry`),
  UNIQUE KEY `entry_UNIQUE` (`entry`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='KEGG反应模块概览表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `orthology`
--

DROP TABLE IF EXISTS `orthology`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orthology` (
  `entry` char(45) NOT NULL,
  `name` mediumtext,
  `definition` longtext,
  `pathways` int(11) DEFAULT NULL COMMENT 'Number of pathways that associated with this kegg orthology data',
  `modules` int(11) DEFAULT NULL,
  `genes` int(11) DEFAULT NULL,
  `disease` int(11) DEFAULT NULL,
  `brief_A` text,
  `brief_B` text,
  `brief_C` text,
  `brief_D` text,
  `brief_E` text,
  `EC` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`entry`),
  UNIQUE KEY `entry_UNIQUE` (`entry`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `orthology_diseases`
--

DROP TABLE IF EXISTS `orthology_diseases`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orthology_diseases` (
  `entry_id` varchar(45) NOT NULL,
  `disease` varchar(45) NOT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` text,
  `url` text,
  PRIMARY KEY (`disease`,`entry_id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='直系同源基因与疾病之间的关联表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `orthology_genes`
--

DROP TABLE IF EXISTS `orthology_genes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orthology_genes` (
  `ko` varchar(100) NOT NULL,
  `gene` varchar(100) NOT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `url` text,
  `sp_code` varchar(45) DEFAULT NULL COMMENT 'The bacterial genome name brief code in KEGG database',
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`gene`,`ko`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `orthology_modules`
--

DROP TABLE IF EXISTS `orthology_modules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orthology_modules` (
  `entry_id` varchar(45) NOT NULL,
  `module` varchar(45) NOT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`module`,`entry_id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `orthology_pathways`
--

DROP TABLE IF EXISTS `orthology_pathways`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orthology_pathways` (
  `entry_id` varchar(45) NOT NULL,
  `pathway` varchar(45) NOT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `describ` text,
  `url` text,
  PRIMARY KEY (`entry_id`,`pathway`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `orthology_references`
--

DROP TABLE IF EXISTS `orthology_references`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orthology_references` (
  `entry_id` varchar(45) NOT NULL,
  `pmid` varchar(45) NOT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`pmid`,`entry_id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `pathway`
--

DROP TABLE IF EXISTS `pathway`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pathway` (
  `entry_id` varchar(45) NOT NULL,
  `name` longtext,
  `definition` longtext,
  `class` text,
  `category` text,
  PRIMARY KEY (`entry_id`),
  UNIQUE KEY `entry_id_UNIQUE` (`entry_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='代谢途径概览表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `reference`
--

DROP TABLE IF EXISTS `reference`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reference` (
  `authors` longtext,
  `title` longtext,
  `journal` longtext,
  `pmid` bigint(20) NOT NULL,
  PRIMARY KEY (`pmid`),
  UNIQUE KEY `pmid_UNIQUE` (`pmid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='参考文献数据表';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `xref_ko2cog`
--

DROP TABLE IF EXISTS `xref_ko2cog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `xref_ko2cog` (
  `uid` int(11) NOT NULL AUTO_INCREMENT,
  `ko` varchar(45) NOT NULL,
  `COG` varchar(45) NOT NULL,
  `url` text,
  PRIMARY KEY (`ko`,`COG`),
  UNIQUE KEY `uid_UNIQUE` (`uid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='KEGG orthology database cross reference to COG database.';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `xref_ko2go`
--

DROP TABLE IF EXISTS `xref_ko2go`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `xref_ko2go` (
  `uid` int(11) NOT NULL AUTO_INCREMENT,
  `ko` varchar(45) NOT NULL,
  `go` varchar(45) NOT NULL,
  `url` text,
  PRIMARY KEY (`ko`,`go`),
  UNIQUE KEY `uid_UNIQUE` (`uid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='kegg orthology cross reference to go database';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `xref_ko2rn`
--

DROP TABLE IF EXISTS `xref_ko2rn`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `xref_ko2rn` (
  `uid` int(11) NOT NULL AUTO_INCREMENT,
  `ko` varchar(45) NOT NULL,
  `rn` varchar(45) NOT NULL,
  `url` text,
  PRIMARY KEY (`ko`,`rn`),
  UNIQUE KEY `uid_UNIQUE` (`uid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='kegg orthology corss reference to kegg reactions database.';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping events for database 'jp_kegg2'
--

--
-- Dumping routines for database 'jp_kegg2'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-03-07 22:10:00