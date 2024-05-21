-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 21, 2024 at 08:58 PM
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
  `ClientId` varchar(200) NOT NULL,
  `Type` varchar(200) NOT NULL,
  `Amount` int(50) NOT NULL,
  `Interest` decimal(10,0) NOT NULL,
  `No_Of_Payment` varchar(200) NOT NULL,
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
(6, '8', 'Daily', 100, 0, '10', 100, 'pending', '2024-05-16', 100, 200, '0001-01-01', 0),
(7, '6', 'Daily', 1000, 0, '10', 100, 'pending', '2024-05-16', 1000, 1200, '2024-05-25', 0);

-- --------------------------------------------------------

--
-- Table structure for table `payments_tb`
--

CREATE TABLE `payments_tb` (
  `id` int(50) NOT NULL,
  `loan_id` int(50) NOT NULL,
  `client_id` int(50) NOT NULL,
  `collectable` int(50) NOT NULL,
  `date` datetime NOT NULL,
  `status` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
  MODIFY `Id` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `payments_tb`
--
ALTER TABLE `payments_tb`
  MODIFY `id` int(50) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
