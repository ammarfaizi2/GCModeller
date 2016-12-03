﻿# event_2_edited
_namespace: [SMRUCC.genomics.Data.Reactome.LocalMySQL.Tables.gk_current](./index.md)_

--
 
 DROP TABLE IF EXISTS `event_2_edited`;
 /*!40101 SET @saved_cs_client = @@character_set_client */;
 /*!40101 SET character_set_client = utf8 */;
 CREATE TABLE `event_2_edited` (
 `DB_ID` int(10) unsigned DEFAULT NULL,
 `edited_rank` int(10) unsigned DEFAULT NULL,
 `edited` int(10) unsigned DEFAULT NULL,
 `edited_class` varchar(64) DEFAULT NULL,
 KEY `DB_ID` (`DB_ID`),
 KEY `edited` (`edited`)
 ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
 /*!40101 SET character_set_client = @saved_cs_client */;
 
 --



