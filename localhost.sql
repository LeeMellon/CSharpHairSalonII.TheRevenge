-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Mar 04, 2018 at 05:34 PM
-- Server version: 5.6.34-log
-- PHP Version: 7.1.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ian_goodrich`
--
CREATE DATABASE IF NOT EXISTS `ian_goodrich` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `ian_goodrich`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `first_name` varchar(125) NOT NULL,
  `last_name` varchar(125) NOT NULL,
  `number` bigint(11) NOT NULL,
  `email` varchar(125) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `first_name`, `last_name`, `number`, `email`) VALUES
(1, 'Testy', 'McTesterson', 5414995779, 'teste@test.com'),
(2, 'dad', 'dad', 21321, 'dasda'),
(3, 'dsasda', 'dsadwasd', 21321321321, 'dsadda'),
(4, 'dwadwaaw', 'dwadwadwa', 2132134, 'dsaafagfeaf'),
(5, 'r3ew2', 'dada', 123214, 'sa'),
(6, 'test', 'test', 1234567890, 'fgh');

-- --------------------------------------------------------

--
-- Table structure for table `clients_stylists`
--

CREATE TABLE `clients_stylists` (
  `id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients_stylists`
--

INSERT INTO `clients_stylists` (`id`, `client_id`, `stylist_id`) VALUES
(1, 6, 6);

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
  `id` int(11) NOT NULL,
  `name` varchar(125) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`id`, `name`) VALUES
(1, 'Coloring'),
(2, 'shaving');

-- --------------------------------------------------------

--
-- Table structure for table `specialties_stylists`
--

CREATE TABLE `specialties_stylists` (
  `id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties_stylists`
--

INSERT INTO `specialties_stylists` (`id`, `specialty_id`, `stylist_id`) VALUES
(6, 1, 6),
(7, 2, 7),
(8, 1, 7);

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `chair` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`id`, `name`, `chair`) VALUES
(1, '', 0),
(2, '', 0),
(3, '', 0),
(5, '', 0),
(6, 'dsadas', 1),
(7, 'dsadasdadw', 1),
(8, 'dadwads', 7);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `clients_stylists`
--
ALTER TABLE `clients_stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties_stylists`
--
ALTER TABLE `specialties_stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `clients_stylists`
--
ALTER TABLE `clients_stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `specialties_stylists`
--
ALTER TABLE `specialties_stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;--
-- Database: `ian_goodrich_test`
--
CREATE DATABASE IF NOT EXISTS `ian_goodrich_test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `ian_goodrich_test`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `first_name` varchar(125) NOT NULL,
  `last_name` varchar(125) NOT NULL,
  `number` bigint(11) NOT NULL,
  `email` varchar(125) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `clients_stylists`
--

CREATE TABLE `clients_stylists` (
  `id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
  `id` int(11) NOT NULL,
  `name` varchar(125) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`id`, `name`) VALUES
(26, 'shaving'),
(27, 'shavingXXX'),
(28, 'shaving'),
(29, 'shavingXXX'),
(30, 'shaving'),
(31, 'shavingXXX'),
(32, 'shaving'),
(33, 'shavingXXX'),
(34, 'shaving'),
(35, 'shavingXXX'),
(36, 'shaving'),
(37, 'shavingXXX'),
(38, 'shaving'),
(39, 'shavingXXX'),
(40, 'shaving'),
(41, 'shavingXXX'),
(42, 'shaving'),
(43, 'shavingXXX'),
(44, 'shaving'),
(45, 'shavingXXX'),
(46, 'shaving'),
(47, 'shavingXXX'),
(48, 'shaving'),
(49, 'shavingXXX'),
(50, 'shaving'),
(51, 'shavingXXX'),
(52, 'shaving'),
(53, 'shavingXXX'),
(54, 'shaving'),
(55, 'shavingXXX'),
(56, 'shaving'),
(57, 'shavingXXX'),
(58, 'shaving'),
(59, 'shavingXXX'),
(60, 'shaving'),
(61, 'shavingXXX'),
(62, 'shaving'),
(63, 'shavingXXX'),
(64, 'shaving'),
(65, 'shavingXXX'),
(66, 'shaving'),
(67, 'shavingXXX'),
(68, 'shaving'),
(69, 'shavingXXX'),
(70, 'shaving'),
(71, 'shavingXXX'),
(72, 'shaving'),
(73, 'shavingXXX'),
(74, 'shaving'),
(75, 'shavingXXX'),
(76, 'shaving'),
(77, 'shavingXXX'),
(78, 'shaving');

-- --------------------------------------------------------

--
-- Table structure for table `specialties_stylists`
--

CREATE TABLE `specialties_stylists` (
  `id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties_stylists`
--

INSERT INTO `specialties_stylists` (`id`, `specialty_id`, `stylist_id`) VALUES
(1, 1, 2),
(2, 2, 1),
(3, 3, 363),
(4, 4, 364),
(5, 5, 377),
(6, 6, 378),
(7, 7, 391),
(8, 8, 392),
(9, 8, 9),
(10, 1, 1),
(11, 9, 405),
(12, 10, 406),
(13, 11, 419),
(14, 12, 420),
(15, 13, 433),
(16, 14, 434),
(17, 15, 447),
(18, 16, 448),
(19, 17, 461),
(20, 18, 462),
(21, 19, 475),
(22, 20, 476),
(23, 21, 489),
(24, 22, 490),
(25, 23, 503),
(26, 24, 504),
(27, 25, 517),
(28, 26, 518),
(29, 27, 531),
(30, 28, 532),
(31, 29, 545),
(32, 30, 546),
(33, 31, 559),
(34, 32, 560),
(35, 33, 573),
(36, 34, 574),
(37, 35, 587),
(38, 36, 588),
(39, 37, 601),
(40, 38, 602),
(41, 39, 615),
(42, 40, 616),
(43, 41, 629),
(44, 42, 630),
(45, 43, 643),
(46, 44, 644),
(47, 45, 657),
(48, 46, 658),
(49, 47, 671),
(50, 48, 672),
(51, 49, 685),
(52, 50, 686),
(53, 51, 699),
(54, 52, 700),
(55, 53, 713),
(56, 54, 714),
(57, 55, 727),
(58, 56, 728),
(59, 57, 741),
(60, 58, 742),
(61, 59, 755),
(62, 60, 756),
(63, 61, 769),
(64, 62, 770),
(65, 63, 783),
(66, 64, 784),
(67, 65, 797),
(68, 66, 798),
(69, 67, 811),
(70, 68, 812),
(71, 69, 825),
(72, 70, 826),
(73, 71, 13),
(74, 72, 14),
(75, 73, 27),
(76, 74, 28),
(77, 75, 41),
(78, 76, 42),
(79, 77, 55),
(80, 78, 56);

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `chair` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `clients_stylists`
--
ALTER TABLE `clients_stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties_stylists`
--
ALTER TABLE `specialties_stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `clients_stylists`
--
ALTER TABLE `clients_stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=79;
--
-- AUTO_INCREMENT for table `specialties_stylists`
--
ALTER TABLE `specialties_stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=81;
--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
