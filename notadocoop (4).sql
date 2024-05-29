-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 29, 2024 at 08:48 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `notadocoop`
--

-- --------------------------------------------------------

--
-- Table structure for table `clients_info_tb`
--

CREATE TABLE `clients_info_tb` (
  `ID` int(50) NOT NULL,
  `User_Type` varchar(100) NOT NULL,
  `Full_Name` varchar(100) NOT NULL,
  `Last_Name` varchar(100) NOT NULL,
  `Address` varchar(100) NOT NULL,
  `ZIP_Code` int(100) NOT NULL,
  `Birthday` varchar(100) NOT NULL,
  `Age` int(50) NOT NULL,
  `NameOfFather` varchar(255) NOT NULL,
  `NameOfMother` varchar(255) NOT NULL,
  `Civil_Status` varchar(100) NOT NULL,
  `Religion` varchar(100) NOT NULL,
  `Occupation` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `clients_info_tb`
--

INSERT INTO `clients_info_tb` (`ID`, `User_Type`, `Full_Name`, `Last_Name`, `Address`, `ZIP_Code`, `Birthday`, `Age`, `NameOfFather`, `NameOfMother`, `Civil_Status`, `Religion`, `Occupation`) VALUES
(6, '21212', '12', 'Zane', '121', 6019, '1111-11-11', 912, '121', '312', '12', '121', '121'),
(7, '1', 'a', 'a', 'a', 9, '1111-11-11', 912, '121', '1', '1', '1231', '121'),
(8, 'Member', 'Lloyd', 'Dignos', 'Tabunan,Nailon,Bogo City Cebu', 6010, '2002-07-20', 21, 'Rokrok', 'shesh', 'shesh', 'shesh', 'shesh');

-- --------------------------------------------------------

--
-- Table structure for table `loan_db`
--

CREATE TABLE `loan_db` (
  `Id` int(50) NOT NULL,
  `ClientId` int(10) NOT NULL,
  `Type` varchar(200) NOT NULL,
  `Amount` int(50) NOT NULL,
  `Interest` decimal(10,0) NOT NULL,
  `No_Of_Payment` int(10) NOT NULL,
  `Deduction` decimal(10,0) NOT NULL,
  `Status` varchar(200) NOT NULL,
  `Date_Created` date NOT NULL,
  `Recievable_Amount` decimal(10,0) NOT NULL,
  `Payable_amount` decimal(10,0) NOT NULL,
  `Due_Date` date NOT NULL,
  `Term` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `login_tb`
--

CREATE TABLE `login_tb` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `RememberMe` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `login_tb`
--

INSERT INTO `login_tb` (`id`, `username`, `password`, `RememberMe`) VALUES
(1, 'admin', 'password', 0);

-- --------------------------------------------------------

--
-- Table structure for table `payments_tb`
--

CREATE TABLE `payments_tb` (
  `id` int(50) NOT NULL,
  `loan_id` int(50) NOT NULL,
  `client_id` int(50) NOT NULL,
  `collectable` decimal(10,0) NOT NULL,
  `deduction` decimal(10,0) NOT NULL,
  `date` date NOT NULL,
  `status` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `payments_tb`
--

INSERT INTO `payments_tb` (`id`, `loan_id`, `client_id`, `collectable`, `deduction`, `date`, `status`) VALUES
(95, 26, 6, 0, 0, '2024-05-29', 'Paid'),
(96, 26, 6, 0, 0, '2024-05-30', 'Paid'),
(97, 26, 6, 0, 0, '2024-05-31', 'Paid'),
(98, 26, 6, 0, 0, '2024-06-01', 'Paid'),
(99, 26, 6, 0, 0, '2024-06-02', 'Paid'),
(100, 27, 6, 0, 0, '2024-05-29', 'Paid'),
(101, 27, 6, 0, 0, '2024-06-05', 'Paid'),
(102, 27, 6, 0, 0, '2024-06-12', 'Paid'),
(103, 27, 6, 0, 0, '2024-06-19', 'Paid'),
(104, 27, 6, 0, 0, '2024-06-26', 'Paid'),
(105, 28, 6, 0, 31, '2024-05-29', 'Paid'),
(106, 28, 6, 0, 31, '2024-06-05', 'Paid'),
(107, 28, 6, 0, 31, '2024-06-12', 'Paid'),
(108, 28, 6, 0, 31, '2024-06-19', 'Paid'),
(109, 29, 8, 0, 32, '2024-05-29', 'Paid'),
(110, 29, 8, 0, 32, '2024-06-05', 'Paid'),
(111, 29, 8, 0, 32, '2024-06-12', 'Paid'),
(112, 29, 8, 0, 32, '2024-06-19', 'Paid'),
(113, 29, 8, 0, 32, '2024-06-26', 'Paid'),
(114, 30, 8, 0, 10, '2024-05-29', 'Paid'),
(115, 30, 8, 0, 10, '2024-05-30', 'Paid'),
(116, 30, 8, 0, 10, '2024-05-31', 'Paid'),
(117, 30, 8, 0, 10, '2024-06-01', 'Paid'),
(118, 30, 8, 0, 10, '2024-06-02', 'Paid'),
(119, 31, 6, 0, 32, '2024-05-29', 'Paid'),
(120, 31, 6, 0, 32, '2024-06-05', 'Paid'),
(121, 31, 6, 0, 32, '2024-06-12', 'Paid'),
(122, 31, 6, 0, 32, '2024-06-19', 'Paid'),
(123, 31, 6, 0, 32, '2024-06-26', 'Paid'),
(124, 32, 6, 0, 31, '2024-05-29', 'Paid'),
(125, 32, 6, 0, 31, '2024-06-05', 'Paid'),
(126, 32, 6, 0, 31, '2024-06-12', 'Paid'),
(127, 33, 6, 0, 10, '2024-05-29', 'Paid'),
(128, 33, 6, 0, 10, '2024-05-30', 'Paid'),
(129, 33, 6, 54, 10, '2024-05-31', 'Half Paid'),
(130, 33, 6, 0, 10, '2024-06-01', 'Paid'),
(131, 33, 6, 55, 10, '2024-06-02', 'Half Paid'),
(132, 33, 6, 177, 10, '2024-06-03', 'Pending'),
(133, 34, 6, 4, 1, '2024-05-29', 'Pending'),
(134, 34, 6, 4, 1, '2024-06-28', 'Pending'),
(135, 34, 6, 4, 1, '2024-07-28', 'Pending'),
(136, 35, 8, 0, 0, '2024-05-29', 'Paid'),
(137, 35, 8, 5, 0, '2024-05-30', 'Pending'),
(138, 35, 8, 5, 0, '2024-05-31', 'Pending'),
(139, 35, 8, 5, 0, '2024-06-01', 'Pending');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients_info_tb`
--
ALTER TABLE `clients_info_tb`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `loan_db`
--
ALTER TABLE `loan_db`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `login_tb`
--
ALTER TABLE `login_tb`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `payments_tb`
--
ALTER TABLE `payments_tb`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients_info_tb`
--
ALTER TABLE `clients_info_tb`
  MODIFY `ID` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `loan_db`
--
ALTER TABLE `loan_db`
  MODIFY `Id` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT for table `login_tb`
--
ALTER TABLE `login_tb`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `payments_tb`
--
ALTER TABLE `payments_tb`
  MODIFY `id` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=140;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
