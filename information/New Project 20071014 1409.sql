-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.0.21-community-nt


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema libruary
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ libruary;
USE libruary;

--
-- Table structure for table `libruary`.`admininformation`
--

DROP TABLE IF EXISTS `admininformation`;
CREATE TABLE `admininformation` (
  `idAdmin` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`idAdmin`),
  KEY `FK_adminInformation_1` (`idAdmin`),
  CONSTRAINT `FK_adminInformation_1` FOREIGN KEY (`idAdmin`) REFERENCES `userinformation` (`idUser`)
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;

--
-- Dumping data for table `libruary`.`admininformation`
--

/*!40000 ALTER TABLE `admininformation` DISABLE KEYS */;
/*!40000 ALTER TABLE `admininformation` ENABLE KEYS */;


--
-- Table structure for table `libruary`.`board`
--

DROP TABLE IF EXISTS `board`;
CREATE TABLE `board` (
  `Context` varchar(100) NOT NULL default '',
  PRIMARY KEY  (`Context`)
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;

--
-- Dumping data for table `libruary`.`board`
--

/*!40000 ALTER TABLE `board` DISABLE KEYS */;
/*!40000 ALTER TABLE `board` ENABLE KEYS */;


--
-- Table structure for table `libruary`.`bookcomment`
--

DROP TABLE IF EXISTS `bookcomment`;
CREATE TABLE `bookcomment` (
  `idBook` int(10) unsigned NOT NULL,
  `idUser` int(10) unsigned NOT NULL default '0',
  `comment` varchar(200) NOT NULL default '',
  `commentDate` datetime NOT NULL default '0000-00-00 00:00:00',
  PRIMARY KEY  (`idBook`,`idUser`,`commentDate`),
  KEY `FK_bookComment_2` (`idUser`),
  CONSTRAINT `FK_bookComment_1` FOREIGN KEY (`idBook`) REFERENCES `bookstable` (`idBook`),
  CONSTRAINT `FK_bookComment_2` FOREIGN KEY (`idUser`) REFERENCES `userinformation` (`idUser`)
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;

--
-- Dumping data for table `libruary`.`bookcomment`
--

/*!40000 ALTER TABLE `bookcomment` DISABLE KEYS */;
/*!40000 ALTER TABLE `bookcomment` ENABLE KEYS */;


--
-- Table structure for table `libruary`.`bookstable`
--

DROP TABLE IF EXISTS `bookstable`;
CREATE TABLE `bookstable` (
  `idBook` int(10) unsigned NOT NULL auto_increment,
  `type` varchar(10) NOT NULL default '',
  `numCopies` smallint(5) unsigned NOT NULL default '0',
  `abstract` varchar(150) default NULL,
  `author` varchar(20) NOT NULL default '',
  `publishCompany` varchar(40) NOT NULL default '',
  `comment` varchar(100) default NULL,
  `donatePerson` varchar(10) NOT NULL default '',
  `state` enum('BORROWED','FREE','MISSING') NOT NULL default 'FREE',
  `bookName` varchar(50) NOT NULL default '',
  PRIMARY KEY  (`idBook`)
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;

--
-- Dumping data for table `libruary`.`bookstable`
--

/*!40000 ALTER TABLE `bookstable` DISABLE KEYS */;
/*!40000 ALTER TABLE `bookstable` ENABLE KEYS */;


--
-- Table structure for table `libruary`.`borrowtable`
--

DROP TABLE IF EXISTS `borrowtable`;
CREATE TABLE `borrowtable` (
  `idBook` int(10) unsigned NOT NULL,
  `idUser` int(10) unsigned NOT NULL default '0',
  `deadLine` datetime NOT NULL default '0000-00-00 00:00:00',
  PRIMARY KEY  (`idBook`),
  KEY `FK_borrowTable_2` (`idUser`),
  CONSTRAINT `FK_borrowTable_1` FOREIGN KEY (`idBook`) REFERENCES `bookstable` (`idBook`),
  CONSTRAINT `FK_borrowTable_2` FOREIGN KEY (`idUser`) REFERENCES `userinformation` (`idUser`)
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;

--
-- Dumping data for table `libruary`.`borrowtable`
--

/*!40000 ALTER TABLE `borrowtable` DISABLE KEYS */;
/*!40000 ALTER TABLE `borrowtable` ENABLE KEYS */;


--
-- Table structure for table `libruary`.`toadmincomment`
--

DROP TABLE IF EXISTS `toadmincomment`;
CREATE TABLE `toadmincomment` (
  `idUser` int(10) unsigned NOT NULL auto_increment,
  `idAdmin` int(10) unsigned NOT NULL default '0',
  `comment` varchar(200) NOT NULL default '',
  `commentDate` datetime NOT NULL default '0000-00-00 00:00:00',
  PRIMARY KEY  (`idUser`,`idAdmin`,`commentDate`),
  KEY `FK_toadmincomment_1` (`idAdmin`),
  CONSTRAINT `FK_toadmincomment_2` FOREIGN KEY (`idUser`) REFERENCES `userinformation` (`idUser`),
  CONSTRAINT `FK_toadmincomment_1` FOREIGN KEY (`idAdmin`) REFERENCES `admininformation` (`idAdmin`)
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;

--
-- Dumping data for table `libruary`.`toadmincomment`
--

/*!40000 ALTER TABLE `toadmincomment` DISABLE KEYS */;
/*!40000 ALTER TABLE `toadmincomment` ENABLE KEYS */;


--
-- Table structure for table `libruary`.`userinformation`
--

DROP TABLE IF EXISTS `userinformation`;
CREATE TABLE `userinformation` (
  `idUser` int(10) unsigned NOT NULL auto_increment,
  `username` varchar(30) NOT NULL default '',
  `password` varchar(30) NOT NULL default '',
  `trueName` varchar(10) NOT NULL default '',
  `college` varchar(20) NOT NULL default '',
  `address` varchar(60) NOT NULL default '',
  `birthday` datetime NOT NULL default '0000-00-00 00:00:00',
  `sex` enum('MALE','FEMALE') NOT NULL default 'MALE',
  `email` varchar(40) NOT NULL default '',
  `telnumber` varchar(15) default NULL,
  `discription` varchar(300) default NULL,
  `mark` int(10) unsigned NOT NULL default '0',
  PRIMARY KEY  (`idUser`,`username`)
) ENGINE=InnoDB DEFAULT CHARSET=gb2312;

--
-- Dumping data for table `libruary`.`userinformation`
--

/*!40000 ALTER TABLE `userinformation` DISABLE KEYS */;
/*!40000 ALTER TABLE `userinformation` ENABLE KEYS */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
