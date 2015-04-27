/*
Navicat MySQL Data Transfer

Source Server         : lenny
Source Server Version : 50542
Source Host           : localhost:3306
Source Database       : vocalconcert

Target Server Type    : MYSQL
Target Server Version : 50542
File Encoding         : 65001

Date: 2015-04-27 07:47:24
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for t_user
-- ----------------------------
DROP TABLE IF EXISTS `t_user`;
CREATE TABLE `t_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Username` longtext,
  `Password` longtext,
  `Avatar` longblob,
  `RoleAsInt` int(11) NOT NULL,
  `City` longtext,
  `Name` longtext,
  `Phone` longtext,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;


-- ----------------------------
-- Table structure for t_group
-- ----------------------------
DROP TABLE IF EXISTS `t_group`;
CREATE TABLE `t_group` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Title` longtext,
  `Description` longtext,
  `Icon` longblob,
  `UserID` int(11) NOT NULL,
  `Time` datetime NOT NULL,
  `City` longtext,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `Group_User` FOREIGN KEY (`UserID`) REFERENCES `t_user` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for t_action
-- ----------------------------
DROP TABLE IF EXISTS `t_action`;
CREATE TABLE `t_action` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `GroupID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `Title` longtext NOT NULL,
  `Description` longtext NOT NULL,
  `Begin` datetime NOT NULL,
  `End` datetime NOT NULL,
  `Time` datetime NOT NULL,
  `Address` longtext NOT NULL,
  `Hint` longtext,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`),
  KEY `GroupID` (`GroupID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `Action_Group` FOREIGN KEY (`GroupID`) REFERENCES `t_group` (`ID`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `Action_User` FOREIGN KEY (`UserID`) REFERENCES `t_user` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for t_actionattender
-- ----------------------------
DROP TABLE IF EXISTS `t_actionattender`;
CREATE TABLE `t_actionattender` (
  `UserID` int(11) NOT NULL,
  `ActionID` int(11) NOT NULL,
  `Time` datetime NOT NULL,
  PRIMARY KEY (`UserID`,`ActionID`),
  KEY `ActionAttender_Action` (`ActionID`),
  CONSTRAINT `ActionAttender_Action` FOREIGN KEY (`ActionID`) REFERENCES `t_action` (`ID`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `ActionAttender_User` FOREIGN KEY (`UserID`) REFERENCES `t_user` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for t_music
-- ----------------------------
DROP TABLE IF EXISTS `t_music`;
CREATE TABLE `t_music` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Title` longtext,
  `Description` longtext,
  `Lyric` longtext,
  `UserID` int(11) NOT NULL,
  `RecommendMark` tinyint(1) NOT NULL,
  `Path` longtext,
  `Time` datetime NOT NULL,
  `TypeAsInt` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `Music_User` FOREIGN KEY (`UserID`) REFERENCES `t_user` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;


-- ----------------------------
-- Table structure for t_comment
-- ----------------------------
DROP TABLE IF EXISTS `t_comment`;
CREATE TABLE `t_comment` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) NOT NULL,
  `MusicID` int(11) NOT NULL,
  `Content` longtext,
  `Score` int(11) NOT NULL,
  `Time` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`),
  KEY `MusicID` (`MusicID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `Comment_Music` FOREIGN KEY (`MusicID`) REFERENCES `t_music` (`ID`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `Comment_User` FOREIGN KEY (`UserID`) REFERENCES `t_user` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;


-- ----------------------------
-- Table structure for t_groupmember
-- ----------------------------
DROP TABLE IF EXISTS `t_groupmember`;
CREATE TABLE `t_groupmember` (
  `UserID` int(11) NOT NULL,
  `GroupID` int(11) NOT NULL,
  `Time` datetime NOT NULL,
  PRIMARY KEY (`UserID`,`GroupID`),
  KEY `GroupMember_Group` (`GroupID`),
  CONSTRAINT `GroupMember_Group` FOREIGN KEY (`GroupID`) REFERENCES `t_group` (`ID`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `GroupMember_User` FOREIGN KEY (`UserID`) REFERENCES `t_user` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- ----------------------------
-- Table structure for t_product
-- ----------------------------
DROP TABLE IF EXISTS `t_product`;
CREATE TABLE `t_product` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) NOT NULL,
  `Title` longtext NOT NULL,
  `Description` longtext NOT NULL,
  `Icon` longblob,
  `Begin` datetime NOT NULL,
  `End` datetime NOT NULL,
  `Time` datetime NOT NULL,
  `City` longtext,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `Product_User` FOREIGN KEY (`UserID`) REFERENCES `t_user` (`id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;


