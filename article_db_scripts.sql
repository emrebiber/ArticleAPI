CREATE DATABASE Article;
USE Article;

CREATE TABLE `Article` (
  `ArticleId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(128) COLLATE utf8_turkish_ci NOT NULL,
  `Content` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `CreatedDate` datetime NOT NULL,
  PRIMARY KEY (`ArticleId`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

CREATE TABLE `User` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `FullName` varchar(64) COLLATE utf8_turkish_ci NOT NULL,
  `Email` varchar(128) COLLATE utf8_turkish_ci NOT NULL,
  `Password` varchar(128) COLLATE utf8_turkish_ci NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `IsActive` bit(1) NOT NULL,
  `IsDeleted` bit(1) NOT NULL,
  `ActivationGuid` varchar(128) COLLATE utf8_turkish_ci DEFAULT NULL,
  `Salt` varchar(128) COLLATE utf8_turkish_ci DEFAULT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;