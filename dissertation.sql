-- phpMyAdmin SQL Dump
-- version 4.5.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 14, 2016 at 03:32 PM
-- Server version: 5.7.11
-- PHP Version: 5.6.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dissertation`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `Admin_id` varchar(25) NOT NULL,
  `Password` varchar(30) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`Admin_id`, `Password`) VALUES
('admin', '123');

-- --------------------------------------------------------

--
-- Table structure for table `evaluation`
--

CREATE TABLE `evaluation` (
  `ID` int(100) NOT NULL,
  `Faculty_Code` varchar(25) NOT NULL,
  `Student_id` varchar(25) NOT NULL,
  `internal` int(50) DEFAULT NULL,
  `Report_Writting` int(100) NOT NULL,
  `Technical_Content` int(100) NOT NULL,
  `Presentaion` int(100) NOT NULL,
  `Total` int(250) NOT NULL,
  `remark` text NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `evaluation`
--

INSERT INTO `evaluation` (`ID`, `Faculty_Code`, `Student_id`, `internal`, `Report_Writting`, `Technical_Content`, `Presentaion`, `Total`, `remark`) VALUES
(45, 'ASB', '12/ICS/004', 21, 10, 10, 10, 30, ''),
(44, 'ST', '12/ICS/004', 21, 7, 7, 7, 21, 'DJWO'),
(43, 'AS', '12/ICS/004', 21, 9, 9, 9, 27, 'welldone'),
(42, 'AS', '12/ICS/006', 0, 8, 8, 8, 24, 'RE'),
(46, 'op', '564', NULL, 52, 12, 63, 35, 'He is Boy'),
(47, 'PT', '12/ICS/018', NULL, 8, 8, 8, 24, ''),
(48, 'PT', '12/ICS/025', NULL, 5, 5, 5, 15, ''),
(49, 'PT', '12/ICS/064', NULL, 8, 3, 9, 20, '``'),
(50, 'PT', '15/PIT/066', NULL, 1, 1, 1, 3, '``'),
(51, 'PT', '15/PIT/006', NULL, 6, 7, 7, 20, ''),
(52, 'PT', '15/PIT/014', NULL, 6, 6, 7, 19, ''),
(53, 'PT', '15/PIT/009', NULL, 8, 8, 8, 24, ''),
(54, 'as', '15/PIT/006', NULL, 7, 7, 8, 22, ''),
(55, 'as', '15/PIT/016', NULL, 7, 7, 7, 21, ''),
(56, 'as', '15/PIT/003', NULL, 6, 6, 6, 18, ''),
(57, 'as', '15/PIT/012', NULL, 6, 6, 6, 18, ''),
(58, 'asb', '15/PIT/014', NULL, 6, 6, 6, 18, ''),
(59, 'asb', '15/PIT/009', NULL, 8, 8, 8, 24, ''),
(60, 'asb', '15/PIT/003', NULL, 6, 5, 6, 17, ''),
(61, 'asb', '15/PIT/012', NULL, 5, 5, 5, 15, '');

-- --------------------------------------------------------

--
-- Table structure for table `faculty_registraion`
--

CREATE TABLE `faculty_registraion` (
  `Faculty_Code` varchar(15) NOT NULL,
  `Faculty_Name` varchar(60) NOT NULL,
  `Password` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `faculty_registraion`
--

INSERT INTO `faculty_registraion` (`Faculty_Code`, `Faculty_Name`, `Password`) VALUES
('AGD', 'Miss Aarti Gautam Dinkar', ''),
('AS', 'Dr. Arun Solanki', ''),
('ASB', 'Dr. Anurag Singh Baghel', ''),
('GK', 'Dr. Gurjit Kaur', ''),
('NG', 'Miss Nidhi Gaulati', ''),
('NS', 'Miss Nita Singh', ''),
('NZR', 'Dr. Navaid Zafar Rizvi', ''),
('PG', 'Miss Priyanka Goyal', ''),
('PT', 'Dr. Pradeep Tomar', ''),
('RBS', 'Dr. Rajendra Bahadur Singh', ''),
('RM', 'Dr. Rajesh Mishra', ''),
('SS', 'Dr. Sandeep Sharma', ''),
('ST', 'Dr. Sandhaya Tarar', ''),
('VM', 'Mr. Vimlesh Kumar', ''),
('VS', 'Dr. Vidhushi Sharma', '');

-- --------------------------------------------------------

--
-- Table structure for table `student_registration`
--

CREATE TABLE `student_registration` (
  `Roll_no` varchar(75) NOT NULL,
  `Name` varchar(78) NOT NULL,
  `Branch` varchar(25) NOT NULL,
  `Guide` varchar(26) NOT NULL,
  `broad_area` varchar(100) NOT NULL,
  `topic` varchar(100) NOT NULL,
  `any_other_info` text NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `student_registration`
--

INSERT INTO `student_registration` (`Roll_no`, `Name`, `Branch`, `Guide`, `broad_area`, `topic`, `any_other_info`, `password`) VALUES
('11/ICS/073', 'Rahul Kumar', 'Software Engg.', 'AGD', '', '', '', ''),
('12/ICS/001', 'AKSHANSH KUMAR', 'Software Engg.', 'AS', '', 'Robatics', '', ''),
('12/ICS/002', 'Sonal Agarwal', 'Software Engg.', 'VS', '', '', '', ''),
('12/ICS/004', 'RISHABH', 'Software Engg.', 'PT', '', '', '', ''),
('12/ICS/005', 'Palak Kapila', 'Software Engg.', 'RM', '', '', '', ''),
('12/ICS/006', 'Nitin Bhati', 'ISR', 'PT', '', '', '', ''),
('12/ICS/007', 'Nitin kumar', 'ISR', 'ST', '', '', '', ''),
('12/ICS/008', 'Anupam Mishra', 'Software Engg.', 'AS', '', '', '', ''),
('12/ICS/009', 'Nischay Dagar', 'ISR', 'RBS', '', '', '', ''),
('12/ICS/010', 'Prachi Agarwal', 'Software Engg.', 'ST', '', '', '', ''),
('12/ICS/011', 'AKSHAY KUMAR', 'ISR', 'SS', '', '', '', ''),
('12/ICS/013', 'MANISH KUMAR', 'ISR', 'NZR', '', '', '', ''),
('12/ICS/014', 'Shrey Kapoor', 'ISR', 'AGD', '', '', '', ''),
('12/ICS/015', 'Amit', 'ISR', 'ST', '', '', '', ''),
('12/ICS/017', 'ABHISHEK DUBEY', 'ISR', 'RM', '', '', '', ''),
('12/ICS/018', 'Bhawna Singh', 'Software Engg.', 'NS', '', '', '', ''),
('12/ICS/019', 'NIHAR NAGAR', 'Software Engg.', 'AS', '', '', '', ''),
('12/ICS/020', 'VIKAS KUMAR KAIN', 'ISR', 'VM', '', '', '', ''),
('12/ICS/022', 'ABHISHEK PATHIK', 'Software Engg.', 'NG', '', '', '', ''),
('12/ICS/023', 'Aseem Chaudhary', 'ISR', 'RBS', '', '', '', ''),
('12/ICS/025', 'Sanjay Chaudhary', 'ISR', 'VM', '', '', '', ''),
('12/ICS/026', 'DARPIT CHAUDHARY', 'Software Engg.', 'NG', '', '', '', ''),
('12/ICS/027', 'Arjun Singh', 'Software Engg.', 'PT', '', '', '', ''),
('12/ICS/028', 'Ankita Banerji', 'Software Engg.', 'VS', '', '', '', ''),
('12/ICS/029', 'Vyomika Singh', 'Software Engg.', 'ST', '', '', '', ''),
('12/ICS/031', 'ANKIT KUMAR', 'ISR', 'NG', '', '', '', ''),
('12/ICS/032', 'ASHUTOSH KUMAR', 'Software Engg.', 'AS', '', 'Signal And Design', '', ''),
('12/ICS/033', 'PIYUSH YADAV', 'Software Engg.', 'ASB', '', '', '', ''),
('12/ICS/035', 'MOHIT SINGH YADAV', 'ISR', 'SS', '', '', '', ''),
('12/ICS/036', 'Prateek Mathur', 'ISR', 'ASB', '', '', '', ''),
('12/ICS/037', 'Prashant Sagar', 'Software Engg.', 'RM', '', '', '', ''),
('12/ICS/038', 'RIYA LAMBA', 'WCN', 'NS', '', '', '', ''),
('12/ICS/039', 'SHUBHAM SHUKLA', 'Software Engg.', 'ST', '', '', '', ''),
('12/ICS/040', 'ANUPAMA ANAND', 'Software Engg.', 'NS', '', '', '', ''),
('12/ICS/042', 'Satyendra Singh', 'Software Engg.', 'ST', '', '', '', ''),
('12/ICS/043', 'ANUJ KUMAR', 'Software Engg.', 'PT', '', '', '', ''),
('12/ICS/046', 'Shubham Garg', 'Software Engg.', 'PT', '', '', '', ''),
('12/ICS/047', 'SHUVALAXMI DASS', 'Software Engg.', 'VS', '', '', '', ''),
('12/ICS/048', 'Jagriti Maurya', 'Software Engg.', 'PT', '', '', '', ''),
('12/ICS/049', 'Pooja Dhingra', 'Software Engg.', 'NG', '', '', '', ''),
('12/ICS/051', 'SANJANA SAXENA', 'Software Engg.', 'ST', '', '', '', ''),
('12/ICS/052', 'Akshit Khanna', 'Software Engg.', 'NG', '', '', '', ''),
('12/ICS/053', 'Diksha', 'ISR', 'NS', '', '', '', ''),
('12/ICS/054', 'DISHA AGARWAL', 'Software Engg.', 'NG', '', '', '', ''),
('12/ICS/055', 'Shubham Goel', 'WCN', 'GK', '', '', '', ''),
('12/ICS/057', 'Saket Sharma', 'Software Engg.', 'PT', '', '', '', ''),
('12/ICS/059', 'Lakshay Bharadwaj', 'ISR', 'RBS', '', '', '', ''),
('12/ICS/060', 'Ayush Kumar Singh', 'ISR', 'AGD', '', '', '', ''),
('12/ICS/061', 'Mayank Gaur', 'ISR', 'NS', '', '', '', ''),
('12/ICS/062', 'Anshul Parashar', 'Software Engg.', 'VS', '', '', '', ''),
('12/ICS/063', 'Kartikey Pariya', 'ISR', 'ASB', '', '', '', ''),
('12/ICS/064', 'Ankur Chauhan', 'Software Engg.', 'ST', '', '', '', ''),
('12/ICS/065', 'Madhulika Sharma', 'ISR', 'AGD', '', '', '', ''),
('12/ICS/066', 'Prashant Rajput', 'Software Engg.', 'ASB', '', '', '', ''),
('12/ICS/067', 'MANMINDER', 'ISR', 'RBS', '', '', '', ''),
('12/ICS/069', 'Mohit Kumar', 'ISR', 'NZR', '', '', '', ''),
('12/IEC/001', 'PANKAJ PATHAK', 'ISR', 'AGD', '', '', '', ''),
('12/IEC/002', 'ABHILASH SINGH', 'WCN', 'SS', '', '', '', ''),
('12/IEC/004', 'NIKHIL AGARWAL', 'ISR', 'ASB', '', '', '', ''),
('12/IEC/008', 'TEJBIR SINGH', 'VLSI', 'RBS', '', '', '', ''),
('12/IEC/009', 'SOMENDRA PRAKASH SINGH', 'WCN', 'NS', '', '', '', ''),
('12/IEC/011', 'MOHIT SHARMA', 'WCN', 'PG', '', '', '', ''),
('12/IEC/012', 'MAYANK SINGH', 'WCN', 'RM', '', '', '', ''),
('12/IEC/014', 'NIVESH SINGH ', 'WCN', 'PG', '', '', '', ''),
('12/IEC/017', 'BIPUL KUMAR SINGH DEO', 'WCN', 'PG', '', '', '', ''),
('12/IEC/018', 'SABA BAKHSHISH ZAHRA', 'ISR', 'AGD', '', '', '', ''),
('12/IEC/023', 'ARCHIT MALIK', 'WCN', 'GK', '', '', '', ''),
('12/IEC/024', 'DEEKSHA', 'WCN', 'GK', '', '', '', ''),
('12/IEC/028', 'ANANYA JHA', 'WCN', 'AGD', '', '', '', ''),
('12/IEC/029', 'ANKITA SRIVASTAVA', 'ISR', 'AS', '', '', '', ''),
('12/IEC/030', 'MONIKA KUMARI', 'WCN', 'NS', '', '', '', ''),
('12/IEC/032', 'JYOTI RAJ MADHESHIYA', 'WCN', 'SS', '', '', '', ''),
('12/IEC/033', 'SHALU CHAUDHARY', 'WCN', 'AGD', '', '', '', ''),
('12/IEC/034', 'RAM AWADH RAM', 'WCN', 'GK', '', '', '', ''),
('12/IEC/035', 'MUDIT MAHENDU SHARMA', 'ISR', 'RBS', '', '', '', ''),
('12/IEC/036', 'RAHUL KUMAR UPADHYAY', 'WCN', 'SS', '', '', '', ''),
('12/IEC/037', 'UJJWAL SHARMA', 'WCN', 'SS', '', '', '', ''),
('12/IEC/043', 'JITENDRA SINGH', 'WCN', 'SS', '', '', '', ''),
('12/IEC/044', 'NIHARIKA DUBEY ', 'WCN', 'GK', '', '', '', ''),
('12/IEC/045', 'PRACHI BHATI', 'WCN', 'AGD', '', '', '', ''),
('12/IEC/046', 'VIKRAM MEHTA', 'ISR', 'AGD', '', '', '', ''),
('12/IEC/047', 'VARUN KUMAR', 'WCN', 'GK', '', '', '', ''),
('12/IEC/048', 'URVASHI CHAUDHARY', 'VLSI', 'RBS', '', '', '', ''),
('12/IEC/051', 'MOHIT SINGH', 'VLSI', 'NZR', '', '', '', ''),
('12/IEC/053', 'SHASHANK RAI', 'WCN', 'RM', '', '', '', ''),
('12/IEC/055', 'HIMANSHU SAINI', 'WCN', 'NZR', '', '', '', ''),
('12/IEC/060', 'KUMAR HARSH VARDHAN', 'WCN', 'PG', '', '', '', ''),
('12/IEC/065', 'BHARAT VERMA', 'VLSI', 'PG', '', '', '', ''),
('12/IEC/067', 'GAURAV CHAUDHARY', 'WCN', 'SS', '', '', '', ''),
('12/IEC/068', 'DILIP KUMAR', 'WCN', 'NZR', '', '', '', ''),
('12/IEC/069', 'ASHWANI KUMAR', 'WCN', 'GK', '', '', '', ''),
('15/PIT/001', 'AAKANKSHA BANSAL', 'Comp. Sci.', 'ASB', '', '', '', ''),
('15/PIT/002', 'ABHISHEK CHAUDHARY', 'Comp. Sci.', 'NG', '', '', '', ''),
('15/PIT/003', 'ANJALI MALIK', 'Comp. Sci.', 'PT', '', '', '', ''),
('15/PIT/004', 'DHARMENDRA KUMAR', 'Comp. Sci.', 'NS', '', '', '', ''),
('15/PIT/005', 'HARSHITA PANDEY', 'Comp. Sci.', 'AS', '', '', '', ''),
('15/PIT/006', 'HIMANSHU KUMAR', 'Comp. Sci.', 'ASB', '', '', '', ''),
('15/PIT/007', 'JUHI', 'Comp. Sci.', 'RM', '', '', '', ''),
('15/PIT/008', 'KM. ANJALI TYAGI', 'Comp. Sci.', 'RM', '', '', '', ''),
('15/PIT/009', 'NAVJOT KAUR', 'Comp. Sci.', 'AS', '', '', '', ''),
('15/PIT/010', 'PRASHANT CHAUDHARY', 'Comp. Sci.', 'NG', '', '', '', ''),
('15/PIT/011', 'RUCHI HOLKER', 'Comp. Sci.', 'RM', '', '', '', ''),
('15/PIT/012', 'SNEHLATA GAUTAM', 'Comp. Sci.', 'PT', '', '', '', ''),
('15/PIT/013', 'SUMAN', 'Comp. Sci.', 'NG', '', '', '', ''),
('15/PIT/014', 'SUPRIT KUMAR SUDHANSHU', 'Comp. Sci.', 'AS', '', '', '', ''),
('15/PIT/015', 'VAISHNAWI PRIYADARSHNI', 'Comp. Sci.', 'AS', '', '', '', ''),
('15/PIT/016', 'VIKASH KUMAR GUPTA', 'Comp. Sci.', 'ASB', '', '', '', ''),
('15/PIT/021', 'ANIRUDDHA SHARMA', 'Software Engg.', 'VS', '', '', '', ''),
('15/PIT/022', 'PRSHANT SHARMA', 'Software Engg.', 'ASB', '', '', '', ''),
('15/PIT/041', 'ANKITA MISHRA', 'VLSI', 'NZR', '', '', '', ''),
('15/PIT/042', 'ANKITA SINGH', 'VLSI', 'NZR', '', '', '', ''),
('15/PIT/043', 'ANSHIKA GUPTA', 'VLSI', 'NZR', '', '', '', ''),
('15/PIT/044', 'ROHIT KUMAR', 'VLSI', 'RBS', '', '', '', ''),
('15/PIT/045', 'SAHADEV KUMAR', 'VLSI', 'NZR', '', '', '', ''),
('15/PIT/046', 'SHASHI KANT', 'VLSI', 'RBS', '', '', '', ''),
('15/PIT/047', 'SHILPI KHARE', 'VLSI', 'PG', '', '', '', ''),
('15/PIT/048', 'UTKARSH KUMAR SINGH', 'VLSI', 'PG', '', '', '', ''),
('15/PIT/062', 'HIMANI VERMA', 'WCN', 'SS', '', '', '', ''),
('15/PIT/063', 'MADHU PRIYA', 'WCN', 'NS', '', '', '', ''),
('15/PIT/064', 'SAKSHI GUPTA', 'WCN', 'RM', '', '', '', ''),
('15/PIT/066', 'SURBHI SINGH', 'WCN', 'GK', '', '', '', ''),
('R11/IEC/003', 'ABISHEK KUMAR', 'ISR', 'ST', '', '', '', ''),
('R11/IEC/063', 'NAVEEN KUMAR', 'VLSI', 'PG', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `task`
--

CREATE TABLE `task` (
  `id` int(11) NOT NULL,
  `student_id` varchar(50) NOT NULL,
  `task` text NOT NULL,
  `deadline` varchar(30) NOT NULL,
  `assaign_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `task`
--

INSERT INTO `task` (`id`, `student_id`, `task`, `deadline`, `assaign_date`) VALUES
(1, '12/ICS/004', 'fjdkbrkf', '2016-06-12', '2016-11-02 11:22:54'),
(2, '12/ICS/008', 'ndslaoi', '02-Nov-16', '2016-11-02 12:11:22'),
(3, '12/ICS/008', 'Study Hadoop', '03-Nov-16', '2016-11-02 14:26:27'),
(4, '12/ICS/009', 'fjdkbrkf', '2016/06/12', '2016-11-02 14:27:01'),
(5, '12/IEC/029', 'bkj', '10-Nov-16', '2016-11-02 14:29:27'),
(6, '12/ICS/032', 'SOmee', '25-Nov-16', '2016-11-02 14:32:51');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`Admin_id`);

--
-- Indexes for table `evaluation`
--
ALTER TABLE `evaluation`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `faculty_registraion`
--
ALTER TABLE `faculty_registraion`
  ADD PRIMARY KEY (`Faculty_Code`);

--
-- Indexes for table `student_registration`
--
ALTER TABLE `student_registration`
  ADD PRIMARY KEY (`Roll_no`);

--
-- Indexes for table `task`
--
ALTER TABLE `task`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `evaluation`
--
ALTER TABLE `evaluation`
  MODIFY `ID` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=62;
--
-- AUTO_INCREMENT for table `task`
--
ALTER TABLE `task`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
