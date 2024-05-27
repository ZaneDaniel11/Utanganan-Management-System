-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 27, 2024 at 08:13 PM
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

--
-- Dumping data for table `loan_db`
--

INSERT INTO `loan_db` (`Id`, `ClientId`, `Type`, `Amount`, `Interest`, `No_Of_Payment`, `Deduction`, `Status`, `Date_Created`, `Recievable_Amount`, `Payable_amount`, `Due_Date`, `Term`) VALUES
(22, 6, 'Daily', 1000, 0, 5, 10, 'alive', '2024-05-27', 1000, 0, '2024-06-01', 0),
(23, 6, 'Monthly', 1000, 0, 5, 50, 'alive', '2024-05-27', 1000, -25, '2024-10-27', 0);

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
(70, 21, 8, 0, 32, '2024-05-27', 'Paid'),
(71, 21, 8, 0, 32, '2024-06-03', 'Paid'),
(72, 21, 8, 0, 32, '2024-06-10', 'Paid'),
(73, 21, 8, 0, 32, '2024-06-17', 'Paid'),
(74, 21, 8, 0, 32, '2024-06-24', 'Paid'),
(75, 22, 6, 0, 10, '2024-05-27', 'Paid'),
(76, 22, 6, 0, 10, '2024-05-28', 'Paid'),
(77, 22, 6, 0, 10, '2024-05-29', 'Paid'),
(78, 22, 6, 0, 10, '2024-05-30', 'Paid'),
(79, 22, 6, 0, 10, '2024-05-31', 'Paid'),
(80, 23, 6, 0, 55, '2024-05-27', 'Paid'),
(81, 23, 6, 0, 55, '2024-06-26', 'Paid'),
(82, 23, 6, 0, 55, '2024-07-26', 'Paid'),
(83, 23, 6, 0, 55, '2024-08-25', 'Paid'),
(84, 23, 6, 0, 55, '2024-09-24', 'Paid');

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
  MODIFY `Id` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `payments_tb`
--
ALTER TABLE `payments_tb`
  MODIFY `id` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=85;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
