-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- 主機： 127.0.0.1
-- 產生時間： 2025-05-29 01:51:50
-- 伺服器版本： 10.4.32-MariaDB
-- PHP 版本： 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- 資料庫： `snstoycotest`
--
CREATE DATABASE IF NOT EXISTS `snstoycotest` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `snstoycotest`;

-- --------------------------------------------------------

--
-- 資料表結構 `customer`
--

CREATE TABLE `customer` (
  `CustomerID` varchar(10) NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `PhoneNum` int(11) DEFAULT NULL,
  `Address` varchar(200) DEFAULT NULL,
  `Email` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `customer`
--

INSERT INTO `customer` (`CustomerID`, `Name`, `PhoneNum`, `Address`, `Email`) VALUES
('CUST001', 'John Doe', 1234567890, '456 Oak St', 'john@example.com'),
('CUST002', NULL, NULL, '789 Elm St', NULL),
('CUST003', 'Jane Smith', 2147483647, NULL, 'jane@example.com'),
('CUST004', 'Alice Brown', NULL, '123 Pine St', NULL),
('CUST005', NULL, 2147483647, NULL, NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `delivery`
--

CREATE TABLE `delivery` (
  `DeliveryID` varchar(10) NOT NULL,
  `Method` varchar(30) DEFAULT NULL,
  `Date` date DEFAULT NULL,
  `OrderID` varchar(10) DEFAULT NULL,
  `EmployeeID` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `delivery`
--

INSERT INTO `delivery` (`DeliveryID`, `Method`, `Date`, `OrderID`, `EmployeeID`) VALUES
('DEL001', 'Courier', '2025-03-22', 'ORD001', 'EMP001'),
('DEL002', NULL, NULL, 'ORD002', NULL),
('DEL003', 'Truck', '2025-04-03', NULL, 'EMP003'),
('DEL004', 'Courier', NULL, 'ORD004', NULL),
('DEL005', NULL, '2025-03-30', NULL, NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `employee`
--

CREATE TABLE `employee` (
  `EmployeeID` varchar(10) NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `PhoneNum` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `employee`
--

INSERT INTO `employee` (`EmployeeID`, `Name`, `PhoneNum`) VALUES
('EMP001', 'Jane Smith', 2147483647),
('EMP002', NULL, 2147483647),
('EMP003', 'Bob Jones', NULL),
('EMP004', 'Alice Green', 1234567890),
('EMP005', NULL, NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `file`
--

CREATE TABLE `file` (
  `FileID` varchar(10) NOT NULL,
  `ProductID` varchar(10) DEFAULT NULL,
  `FileName` varchar(100) DEFAULT NULL,
  `FileLoc` varchar(100) DEFAULT NULL,
  `AddDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `file`
--

INSERT INTO `file` (`FileID`, `ProductID`, `FileName`, `FileLoc`, `AddDate`) VALUES
('FILE001', 'TOY001', 'teddy_bear.jpg', '/files/toys/', '2025-03-20'),
('FILE002', NULL, 'car_manual.pdf', '/files/docs/', NULL),
('FILE003', 'TOY003', NULL, '/files/images/', '2025-04-01'),
('FILE004', 'TOY002', 'toy_car.png', NULL, '2025-03-25'),
('FILE005', NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `ingredient`
--

CREATE TABLE `ingredient` (
  `MaterialID` varchar(10) NOT NULL,
  `MaterialQty` varchar(10) DEFAULT NULL,
  `Desc` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `ingredient`
--

INSERT INTO `ingredient` (`MaterialID`, `MaterialQty`, `Desc`) VALUES
('MAT001', '500g', 'Soft fabric for toys'),
('MAT002', NULL, 'Plastic for car bodies'),
('MAT003', '2kg', NULL),
('MAT004', '100g', 'Rubber for wheels'),
('MAT005', NULL, NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `material`
--

CREATE TABLE `material` (
  `MaterialID` varchar(10) NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Category` varchar(50) DEFAULT NULL,
  `Desc` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `material`
--

INSERT INTO `material` (`MaterialID`, `Name`, `Category`, `Desc`) VALUES
('MAT001', 'Plush Fabric', 'Toy Material', 'Soft fabric for teddy bears'),
('MAT002', 'Plastic', 'Raw Material', NULL),
('MAT003', NULL, 'Processed', 'Wood for doll houses'),
('MAT004', 'Rubber', NULL, 'For toy wheels'),
('MAT005', 'Paint', 'Toy Material', NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `meeting`
--

CREATE TABLE `meeting` (
  `MeetingID` varchar(10) NOT NULL,
  `Date` date DEFAULT NULL,
  `Time` time DEFAULT NULL,
  `Loc` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `meeting`
--

INSERT INTO `meeting` (`MeetingID`, `Date`, `Time`, `Loc`) VALUES
('MEET001', '2025-03-25', '14:30:00', 'Conference Room A'),
('MEET002', NULL, NULL, 'Room B'),
('MEET003', '2025-04-01', '09:00:00', NULL),
('MEET004', '2025-03-28', NULL, 'Office C'),
('MEET005', NULL, '15:00:00', NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `meetingparticipant`
--

CREATE TABLE `meetingparticipant` (
  `MeetingID` varchar(10) NOT NULL,
  `EmpID` varchar(10) NOT NULL,
  `CustomerID` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `meetingparticipant`
--

INSERT INTO `meetingparticipant` (`MeetingID`, `EmpID`, `CustomerID`) VALUES
('MEET001', 'EMP001', 'CUST001'),
('MEET002', 'EMP002', NULL),
('MEET003', 'EMP003', 'CUST003'),
('MEET004', 'EMP004', NULL),
('MEET005', 'EMP005', 'CUST005');

-- --------------------------------------------------------

--
-- 資料表結構 `order`
--

CREATE TABLE `order` (
  `OrderID` varchar(10) NOT NULL,
  `OrderDate` varchar(15) DEFAULT NULL,
  `Status` varchar(15) DEFAULT NULL,
  `SaleID` varchar(10) DEFAULT NULL,
  `CustomerID` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `order`
--

INSERT INTO `order` (`OrderID`, `OrderDate`, `Status`, `SaleID`, `CustomerID`) VALUES
('ORD001', '2025-03-20', 'Pending', 'SALE001', 'CUST001'),
('ORD002', NULL, 'Shipped', 'SALE002', NULL),
('ORD003', '2025-04-01', NULL, 'SALE003', 'CUST003'),
('ORD004', '2025-03-25', 'Pending', NULL, 'CUST002'),
('ORD005', NULL, NULL, 'SALE004', NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `orderline`
--

CREATE TABLE `orderline` (
  `OrderID` varchar(10) NOT NULL,
  `ProductID` varchar(10) NOT NULL,
  `Qty` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `orderline`
--

INSERT INTO `orderline` (`OrderID`, `ProductID`, `Qty`) VALUES
('ORD001', 'TOY001', 10),
('ORD002', 'TOY002', NULL),
('ORD003', 'TOY003', 5),
('ORD004', 'TOY004', 20),
('ORD005', 'TOY005', NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `payment`
--

CREATE TABLE `payment` (
  `PaymentID` varchar(10) NOT NULL,
  `OrderID` varchar(10) DEFAULT NULL,
  `PaymentDate` date DEFAULT NULL,
  `Due` date DEFAULT NULL,
  `Amount` int(11) DEFAULT NULL,
  `Type` varchar(15) DEFAULT NULL,
  `Status` varchar(15) DEFAULT NULL,
  `Method` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `payment`
--

INSERT INTO `payment` (`PaymentID`, `OrderID`, `PaymentDate`, `Due`, `Amount`, `Type`, `Status`, `Method`) VALUES
('PAY001', 'ORD001', '2025-03-21', '2025-04-01', 500, 'Credit', 'Completed', 'Online'),
('PAY002', NULL, NULL, '2025-04-10', 200, NULL, 'Pending', NULL),
('PAY003', 'ORD003', '2025-04-02', NULL, NULL, 'Cash', NULL, 'In-person'),
('PAY004', 'ORD002', NULL, '2025-04-05', 300, NULL, 'Completed', NULL),
('PAY005', NULL, '2025-03-30', NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `product`
--

CREATE TABLE `product` (
  `ProductID` varchar(10) NOT NULL,
  `Name` varchar(30) DEFAULT NULL,
  `Desc` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `product`
--

INSERT INTO `product` (`ProductID`, `Name`, `Desc`) VALUES
('TOY001', 'Teddy Bear', 'A soft teddy bear for kids'),
('TOY002', 'Toy Car', 'Red race car with remote control'),
('TOY003', 'Doll House', NULL),
('TOY004', NULL, 'Building blocks set'),
('TOY005', 'Puzzle', NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `productinventory`
--

CREATE TABLE `productinventory` (
  `ProductID` varchar(10) NOT NULL,
  `WarehouseID` varchar(10) NOT NULL,
  `Qty` int(11) DEFAULT NULL,
  `Loc` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `productinventory`
--

INSERT INTO `productinventory` (`ProductID`, `WarehouseID`, `Qty`, `Loc`) VALUES
('TOY001', 'WH001', 50, 'Shelf A1'),
('TOY002', 'WH002', NULL, 'Shelf B2'),
('TOY003', 'WH001', 20, NULL),
('TOY004', 'WH003', 100, 'Shelf C3'),
('TOY005', 'WH004', NULL, NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `productorder`
--

CREATE TABLE `productorder` (
  `POrderID` varchar(10) NOT NULL,
  `ProductID` varchar(10) DEFAULT NULL,
  `LineProductID` varchar(10) DEFAULT NULL,
  `StartDate` date DEFAULT NULL,
  `Due` date DEFAULT NULL,
  `Qty` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `productorder`
--

INSERT INTO `productorder` (`POrderID`, `ProductID`, `LineProductID`, `StartDate`, `Due`, `Qty`) VALUES
('PORD001', 'TOY001', 'LINE001', '2025-03-01', '2025-03-15', 100),
('PORD002', NULL, 'LINE002', NULL, '2025-04-01', 50),
('PORD003', 'TOY003', 'LINE003', '2025-03-10', NULL, 75),
('PORD004', 'TOY002', 'LINE004', NULL, NULL, NULL),
('PORD005', NULL, 'LINE005', '2025-03-20', '2025-04-10', 25);

-- --------------------------------------------------------

--
-- 資料表結構 `purchase`
--

CREATE TABLE `purchase` (
  `PurchaseID` varchar(10) NOT NULL,
  `Date` date DEFAULT NULL,
  `Amount` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `purchase`
--

INSERT INTO `purchase` (`PurchaseID`, `Date`, `Amount`) VALUES
('PUR001', '2025-03-15', 1000),
('PUR002', NULL, 500),
('PUR003', '2025-04-01', NULL),
('PUR004', '2025-03-20', 750),
('PUR005', NULL, NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `purchaseline`
--

CREATE TABLE `purchaseline` (
  `PurchaseID` varchar(10) NOT NULL,
  `SupplierID` varchar(10) NOT NULL,
  `MaterialID` varchar(10) NOT NULL,
  `Qty` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `purchaseline`
--

INSERT INTO `purchaseline` (`PurchaseID`, `SupplierID`, `MaterialID`, `Qty`) VALUES
('PUR001', 'SUP001', 'MAT001', 200),
('PUR002', 'SUP002', 'MAT002', NULL),
('PUR003', 'SUP003', 'MAT003', 150),
('PUR004', 'SUP004', 'MAT004', 100),
('PUR005', 'SUP005', 'MAT005', NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `supplier`
--

CREATE TABLE `supplier` (
  `SupplierID` varchar(10) NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `PhoneNum` int(11) DEFAULT NULL,
  `Address` varchar(200) DEFAULT NULL,
  `Email` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `supplier`
--

INSERT INTO `supplier` (`SupplierID`, `Name`, `PhoneNum`, `Address`, `Email`) VALUES
('SUP001', 'Toy Materials Inc.', 2147483647, '789 Pine St', 'toys@materials.com'),
('SUP002', NULL, NULL, '456 Maple Ave', NULL),
('SUP003', 'Fabric Co.', 2147483647, NULL, 'fabric@example.com'),
('SUP004', 'Plastic Ltd.', NULL, '123 Birch Rd', NULL),
('SUP005', NULL, 1231231234, NULL, NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `warehouse`
--

CREATE TABLE `warehouse` (
  `WarehouseID` varchar(10) NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Address` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `warehouse`
--

INSERT INTO `warehouse` (`WarehouseID`, `Name`, `Address`) VALUES
('WH001', 'Toy Storage', '123 Toy Lane'),
('WH002', NULL, '456 Pine St'),
('WH003', 'Main Warehouse', NULL),
('WH004', 'North Depot', '789 Oak Rd'),
('WH005', NULL, NULL);

--
-- 已傾印資料表的索引
--

--
-- 資料表索引 `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`CustomerID`);

--
-- 資料表索引 `delivery`
--
ALTER TABLE `delivery`
  ADD PRIMARY KEY (`DeliveryID`);

--
-- 資料表索引 `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`EmployeeID`);

--
-- 資料表索引 `file`
--
ALTER TABLE `file`
  ADD PRIMARY KEY (`FileID`);

--
-- 資料表索引 `ingredient`
--
ALTER TABLE `ingredient`
  ADD PRIMARY KEY (`MaterialID`);

--
-- 資料表索引 `material`
--
ALTER TABLE `material`
  ADD PRIMARY KEY (`MaterialID`);

--
-- 資料表索引 `meeting`
--
ALTER TABLE `meeting`
  ADD PRIMARY KEY (`MeetingID`);

--
-- 資料表索引 `meetingparticipant`
--
ALTER TABLE `meetingparticipant`
  ADD PRIMARY KEY (`MeetingID`,`EmpID`);

--
-- 資料表索引 `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`OrderID`);

--
-- 資料表索引 `orderline`
--
ALTER TABLE `orderline`
  ADD PRIMARY KEY (`OrderID`,`ProductID`);

--
-- 資料表索引 `payment`
--
ALTER TABLE `payment`
  ADD PRIMARY KEY (`PaymentID`);

--
-- 資料表索引 `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`ProductID`);

--
-- 資料表索引 `productinventory`
--
ALTER TABLE `productinventory`
  ADD PRIMARY KEY (`ProductID`,`WarehouseID`);

--
-- 資料表索引 `productorder`
--
ALTER TABLE `productorder`
  ADD PRIMARY KEY (`POrderID`);

--
-- 資料表索引 `purchase`
--
ALTER TABLE `purchase`
  ADD PRIMARY KEY (`PurchaseID`);

--
-- 資料表索引 `purchaseline`
--
ALTER TABLE `purchaseline`
  ADD PRIMARY KEY (`PurchaseID`,`SupplierID`,`MaterialID`);

--
-- 資料表索引 `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`SupplierID`);

--
-- 資料表索引 `warehouse`
--
ALTER TABLE `warehouse`
  ADD PRIMARY KEY (`WarehouseID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
