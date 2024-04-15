-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 15, 2024 at 11:08 AM
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
(2, 'Mangotangay', 'Edison', 'Pagatpat', 'Ambot', 6010, '2000-01-19', 24, 'Pagatpat Father', 'Pagatpat Mother', 'Single Dad', 'Child of Hitler', 'ambot');

-- --------------------------------------------------------

--
-- Table structure for table `loan_db`
--

CREATE TABLE `loan_db` (
  `Id` int(50) NOT NULL,
  `Client` varchar(200) NOT NULL,
  `Type` varchar(200) NOT NULL,
  `Amount` int(50) NOT NULL,
  `Interest` varchar(200) NOT NULL,
  `No_Of_Payment` varchar(200) NOT NULL,
  `Deduction` int(50) NOT NULL,
  `Status` varchar(200) NOT NULL,
  `Date_Created` date NOT NULL,
  `Recievable_Amount` int(50) NOT NULL,
  `Due_Date` date NOT NULL
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
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients_info_tb`
--
ALTER TABLE `clients_info_tb`
  MODIFY `ID` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `loan_db`
--
ALTER TABLE `loan_db`
  MODIFY `Id` int(50) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
