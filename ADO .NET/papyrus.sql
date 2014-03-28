-- phpMyAdmin SQL Dump
-- version 4.1.7
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Ven 28 Mars 2014 à 08:46
-- Version du serveur :  5.6.12-log
-- Version de PHP :  5.4.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `papyrus`
--
CREATE DATABASE IF NOT EXISTS `papyrus` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `papyrus`;

DELIMITER $$
--
-- Procédures
--
DROP PROCEDURE IF EXISTS `GetEntCom`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetEntCom`(IN `n` INT)
    NO SQL
if n = -1 then
	select NUMCOM, DATCOM, OBSCOM from ENTCOM;
else
	select NUMCOM, DATCOM, OBSCOM from ENTCOM where NUMFOU=n;
end if$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Structure de la table `entcom`
--

DROP TABLE IF EXISTS `entcom`;
CREATE TABLE IF NOT EXISTS `entcom` (
  `NUMCOM` int(11) NOT NULL,
  `OBSCOM` varchar(25) CHARACTER SET latin1 DEFAULT NULL,
  `DATCOM` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `NUMFOU` int(11) DEFAULT NULL,
  PRIMARY KEY (`NUMCOM`),
  KEY `FK_ENTCOM_FOURNIS` (`NUMFOU`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Vider la table avant d'insérer `entcom`
--

TRUNCATE TABLE `entcom`;
--
-- Contenu de la table `entcom`
--

INSERT INTO `entcom` (`NUMCOM`, `OBSCOM`, `DATCOM`, `NUMFOU`) VALUES
(70010, '', '2007-02-10 00:00:00', 120),
(70011, 'Commande urgente', '2007-01-03 00:00:00', 540),
(70025, 'Commande urgente', '2007-04-30 00:00:00', 9150),
(70210, 'Commande cadencée', '2007-05-05 00:00:00', 120),
(70250, 'Commande cadencée', '2007-10-02 00:00:00', 8700),
(70300, '', '2007-06-06 00:00:00', 9120),
(70620, '', '2007-10-02 00:00:00', 540),
(70625, '', '2007-10-09 00:00:00', 120);

-- --------------------------------------------------------

--
-- Structure de la table `fournis`
--

DROP TABLE IF EXISTS `fournis`;
CREATE TABLE IF NOT EXISTS `fournis` (
  `NUMFOU` int(11) NOT NULL,
  `NOMFOU` varchar(30) CHARACTER SET latin1 NOT NULL,
  `RUEFOU` varchar(40) CHARACTER SET latin1 NOT NULL,
  `POSFOU` varchar(5) CHARACTER SET latin1 NOT NULL,
  `VILFOU` varchar(30) CHARACTER SET latin1 NOT NULL,
  `CONFOU` varchar(15) CHARACTER SET latin1 NOT NULL,
  `SATISF` tinyint(4) DEFAULT NULL,
  PRIMARY KEY (`NUMFOU`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Vider la table avant d'insérer `fournis`
--

TRUNCATE TABLE `fournis`;
--
-- Contenu de la table `fournis`
--

INSERT INTO `fournis` (`NUMFOU`, `NOMFOU`, `RUEFOU`, `POSFOU`, `VILFOU`, `CONFOU`, `SATISF`) VALUES
(10, 'DICK', '18, rue du REDELACH', '57580', 'LESSE', 'dicklaurent', 5),
(120, 'GROBRIGAN', '20 rue du papier', '92200', 'papercity', 'Georges', 8),
(540, 'ECLIPSE', '53 rue laisse flotter les rubans', '78250', 'Bugbugville', 'Nestor', 7),
(8700, 'MEDICIS', '120 rue des plantes', '75014', 'Paris', 'Lison', NULL),
(9120, 'DISCOBOL', '11 rue des sports', '85100', 'La Roche sur Yon', 'Hercule', 8),
(9150, 'DEPANPAP', '26 avenue des locomotives', '59987', 'Coroncountry', 'Pollux', 5),
(9180, 'HURRYTAPE', '68 boulevard des octets', '04044', 'Dumpville', 'Track', NULL);

-- --------------------------------------------------------

--
-- Structure de la table `ligcom`
--

DROP TABLE IF EXISTS `ligcom`;
CREATE TABLE IF NOT EXISTS `ligcom` (
  `NUMCOM` int(11) NOT NULL,
  `NUMLIG` tinyint(4) NOT NULL,
  `CODART` char(4) CHARACTER SET latin1 NOT NULL,
  `QTECDE` smallint(6) NOT NULL,
  `PRIUNI` smallint(6) NOT NULL,
  `QTELIV` smallint(6) DEFAULT NULL,
  `DERLIV` datetime NOT NULL,
  PRIMARY KEY (`NUMCOM`,`NUMLIG`),
  KEY `FK_LIGCOM_PRODUIT` (`CODART`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Vider la table avant d'insérer `ligcom`
--

TRUNCATE TABLE `ligcom`;
--
-- Contenu de la table `ligcom`
--

INSERT INTO `ligcom` (`NUMCOM`, `NUMLIG`, `CODART`, `QTECDE`, `PRIUNI`, `QTELIV`, `DERLIV`) VALUES
(70010, 1, 'I100', 3000, 470, 3000, '2007-03-15 00:00:00'),
(70010, 2, 'I105', 2000, 485, 2000, '2007-07-05 00:00:00'),
(70010, 3, 'I108', 1000, 680, 1000, '2007-08-20 00:00:00'),
(70010, 4, 'D035', 200, 40, 250, '2007-02-20 00:00:00'),
(70010, 5, 'P220', 6000, 3500, 6000, '2007-03-31 00:00:00'),
(70010, 6, 'P240', 6000, 2000, 2000, '2007-03-31 00:00:00'),
(70011, 1, 'I105', 1000, 600, 1000, '2007-05-16 00:00:00'),
(70025, 1, 'I100', 1000, 590, 1000, '2007-05-15 00:00:00'),
(70025, 2, 'I105', 500, 590, 500, '2007-05-15 00:00:00'),
(70210, 1, 'I100', 1000, 470, 1000, '2007-07-15 00:00:00'),
(70210, 2, 'P220', 10000, 3500, 10000, '2007-08-31 00:00:00'),
(70250, 1, 'P230', 15000, 4900, 12000, '2007-12-15 00:00:00'),
(70250, 2, 'P220', 10000, 3350, 10000, '2007-11-10 00:00:00'),
(70300, 1, 'I110', 50, 790, 50, '2007-10-31 00:00:00'),
(70620, 1, 'I105', 200, 600, 200, '2007-11-01 00:00:00'),
(70625, 1, 'I100', 1000, 470, 1000, '2007-10-15 00:00:00'),
(70625, 2, 'P220', 10000, 3500, 10000, '2007-10-31 00:00:00');

-- --------------------------------------------------------

--
-- Structure de la table `produit`
--

DROP TABLE IF EXISTS `produit`;
CREATE TABLE IF NOT EXISTS `produit` (
  `CODART` char(4) CHARACTER SET latin1 NOT NULL,
  `LIBART` varchar(30) CHARACTER SET latin1 NOT NULL,
  `STKALE` smallint(6) NOT NULL,
  `STKPHY` smallint(6) NOT NULL,
  `QTEANN` smallint(6) NOT NULL,
  `UNIMES` char(5) CHARACTER SET latin1 NOT NULL,
  PRIMARY KEY (`CODART`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Vider la table avant d'insérer `produit`
--

TRUNCATE TABLE `produit`;
--
-- Contenu de la table `produit`
--

INSERT INTO `produit` (`CODART`, `LIBART`, `STKALE`, `STKPHY`, `QTEANN`, `UNIMES`) VALUES
('B001', 'Bande magnétique 1200', 20, 87, 240, 'unité'),
('B002', 'Bande magnétique 6250', 20, 12, 410, 'unité'),
('D035', 'CD R slim 80 mm', 40, 42, 150, 'B010'),
('D050', 'CD R-W 80mm', 50, 4, 0, 'B010'),
('I100', 'Papier 1 ex continu', 100, 557, 3500, 'B1000'),
('I105', 'Papier 2 ex continu', 75, 5, 2300, 'B1000'),
('I108', 'Papier 3 ex continu', 200, 557, 3500, 'B500'),
('I110', 'Papier 4 ex continu', 10, 12, 63, 'B400'),
('P220', 'Pré imprimé commande', 500, 2500, 24500, 'B500'),
('P230', 'Pré imprimé facture', 500, 250, 12500, 'B500'),
('P240', 'Pré imprimé bulletin paie', 500, 3000, 6250, 'B500'),
('P250', 'Pré imprimé bon livraison', 500, 2500, 24500, 'B500'),
('P270', 'Pré imprimé bon fabrication', 500, 2500, 24500, 'B500'),
('R080', 'Ruban Epson 850', 10, 2, 120, 'unité'),
('R132', 'Ruban imp1200 lignes', 25, 200, 182, 'unité');

-- --------------------------------------------------------

--
-- Structure de la table `vente`
--

DROP TABLE IF EXISTS `vente`;
CREATE TABLE IF NOT EXISTS `vente` (
  `CODART` char(4) CHARACTER SET latin1 NOT NULL,
  `NUMFOU` int(11) NOT NULL,
  `DELLIV` datetime NOT NULL,
  `QTE1` smallint(6) NOT NULL,
  `PRIX1` decimal(12,4) NOT NULL,
  `QTE2` smallint(6) DEFAULT NULL,
  `PRIX2` decimal(12,4) DEFAULT NULL,
  `QTE3` decimal(12,4) DEFAULT NULL,
  `PRIX3` decimal(12,4) DEFAULT NULL,
  PRIMARY KEY (`CODART`,`NUMFOU`),
  KEY `FK_VENTE_FOURNIS` (`NUMFOU`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Vider la table avant d'insérer `vente`
--

TRUNCATE TABLE `vente`;
--
-- Contenu de la table `vente`
--

INSERT INTO `vente` (`CODART`, `NUMFOU`, `DELLIV`, `QTE1`, `PRIX1`, `QTE2`, `PRIX2`, `QTE3`, `PRIX3`) VALUES
('B001', 8700, '1900-01-16 00:00:00', 0, '150.0000', 50, '145.0000', '100.0000', '140.0000'),
('B002', 8700, '1900-01-16 00:00:00', 0, '210.0000', 50, '200.0000', '100.0000', '185.0000'),
('D035', 120, '1900-01-01 00:00:00', 0, '40.0000', 0, '0.0000', '0.0000', '0.0000'),
('D035', 540, '1900-01-01 00:00:00', 0, '40.0000', 0, '0.0000', '0.0000', '0.0000'),
('D035', 8700, '1900-01-06 00:00:00', 0, '40.0000', 100, '30.0000', '0.0000', '0.0000'),
('D035', 9120, '1900-01-06 00:00:00', 0, '40.0000', 100, '30.0000', '5.0000', '0.0000'),
('I100', 120, '1900-04-01 00:00:00', 0, '700.0000', 50, '600.0000', '120.0000', '500.0000'),
('I100', 540, '1900-03-12 00:00:00', 0, '710.0000', 60, '630.0000', '100.0000', '600.0000'),
('I100', 9120, '1900-03-02 00:00:00', 0, '800.0000', 70, '600.0000', '90.0000', '500.0000'),
('I100', 9150, '1900-04-01 00:00:00', 0, '650.0000', 90, '600.0000', '200.0000', '590.0000'),
('I105', 120, '1900-04-01 00:00:00', 10, '705.0000', 50, '630.0000', '120.0000', '500.0000'),
('I105', 540, '1900-03-12 00:00:00', 0, '810.0000', 60, '645.0000', '100.0000', '600.0000'),
('I105', 8700, '1900-01-31 00:00:00', 0, '720.0000', 50, '670.0000', '100.0000', '510.0000'),
('I105', 9120, '1900-03-02 00:00:00', 0, '920.0000', 70, '800.0000', '90.0000', '700.0000'),
('I105', 9150, '1900-04-01 00:00:00', 0, '685.0000', 90, '600.0000', '200.0000', '590.0000'),
('I108', 120, '1900-04-01 00:00:00', 5, '795.0000', 30, '720.0000', '100.0000', '680.0000'),
('I108', 8700, '1900-01-09 00:00:00', 0, '37.0000', 0, '0.0000', '0.0000', '0.0000'),
('I108', 9120, '1900-03-02 00:00:00', 0, '920.0000', 70, '820.0000', '100.0000', '780.0000'),
('I110', 9120, '1900-03-02 00:00:00', 0, '950.0000', 70, '850.0000', '90.0000', '790.0000'),
('P220', 120, '1900-01-16 00:00:00', 0, '3700.0000', 100, '3500.0000', '0.0000', '0.0000'),
('P220', 8700, '1900-01-21 00:00:00', 50, '3500.0000', 100, '3350.0000', '0.0000', '0.0000'),
('P230', 120, '1900-01-31 00:00:00', 0, '5200.0000', 100, '5000.0000', '0.0000', '0.0000'),
('P230', 8700, '1900-03-02 00:00:00', 0, '5000.0000', 50, '4900.0000', '0.0000', '0.0000'),
('P240', 120, '1900-01-16 00:00:00', 0, '2200.0000', 100, '2000.0000', '0.0000', '0.0000'),
('P250', 120, '1900-01-31 00:00:00', 0, '1500.0000', 100, '1400.0000', '500.0000', '1200.0000'),
('P250', 9120, '1900-01-31 00:00:00', 0, '1500.0000', 100, '1400.0000', '500.0000', '1200.0000'),
('R080', 9120, '1900-01-11 00:00:00', 0, '120.0000', 100, '100.0000', '0.0000', '0.0000'),
('R132', 9120, '1900-01-06 00:00:00', 0, '275.0000', 0, '0.0000', '0.0000', '0.0000');

--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `entcom`
--
ALTER TABLE `entcom`
  ADD CONSTRAINT `FK_ENTCOM_FOURNIS` FOREIGN KEY (`NUMFOU`) REFERENCES `fournis` (`NUMFOU`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `ligcom`
--
ALTER TABLE `ligcom`
  ADD CONSTRAINT `FK_LIGCOM_ENTCOM` FOREIGN KEY (`NUMCOM`) REFERENCES `entcom` (`NUMCOM`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_LIGCOM_PRODUIT` FOREIGN KEY (`CODART`) REFERENCES `produit` (`CODART`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `vente`
--
ALTER TABLE `vente`
  ADD CONSTRAINT `FK_VENTE_FOURNIS` FOREIGN KEY (`NUMFOU`) REFERENCES `fournis` (`NUMFOU`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_VENTE_PRODUIT` FOREIGN KEY (`CODART`) REFERENCES `produit` (`CODART`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
