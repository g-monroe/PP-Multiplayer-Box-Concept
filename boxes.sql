-- phpMyAdmin SQL Dump
-- version 4.3.8
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Sep 17, 2016 at 04:20 PM
-- Server version: 5.6.29-76.2
-- PHP Version: 5.4.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `d8m7n0s6_boxbase`
--

-- --------------------------------------------------------

--
-- Table structure for table `boxes`
--

CREATE TABLE IF NOT EXISTS `boxes` (
  `Name` text NOT NULL,
  `x` text NOT NULL,
  `y` text NOT NULL,
  `Status` text NOT NULL,
  `UID` text NOT NULL,
  `boxType` text NOT NULL,
  `Comment` text NOT NULL,
  `CommentTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `boxes`
--

INSERT INTO `boxes` (`Name`, `x`, `y`, `Status`, `UID`, `boxType`, `Comment`, `CommentTime`) VALUES
('159.203.62.96', '144', '206', 'Online', 'Hackerrrr', 'box4', 'Test', '2016-09-17 20:39:31'),
('159.203.43.215', '301.5', '180.5', 'Offline', 'tester33', 'box2', 'wwwwwwwwwwwwawdssssasawH', '2016-09-17 20:35:10'),
('71.30.208.115', '293', '248', 'Offline', 'Kevin123', 'box1', 'Hello Bot', '2016-09-17 20:50:08'),
('159.203.61.22', '242', '178', 'Offline', 'Bot', 'box1', 'Hey Kevin', '2016-09-17 20:49:58');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
