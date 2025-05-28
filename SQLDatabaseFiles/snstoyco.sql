-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- 主機： 127.0.0.1
-- 產生時間： 2025-05-29 01:52:08
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
-- 資料庫： `snstoyco`
--
CREATE DATABASE IF NOT EXISTS `snstoyco` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `snstoyco`;

-- --------------------------------------------------------

--
-- 資料表結構 `customer`
--

CREATE TABLE `customer` (
  `CustomerID` varchar(10) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `PhoneNum` int(11) NOT NULL,
  `Address` varchar(200) NOT NULL,
  `Email` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `customer`
--

INSERT INTO `customer` (`CustomerID`, `Name`, `PhoneNum`, `Address`, `Email`) VALUES
('CUST001', 'John Doe', 1234567890, '456 Oak St', 'john@example.com'),
('CUST002', 'Jane Lee', 2147483647, '789 Pine St', 'jane@example.com'),
('CUST003', 'Sam Chen', 2147483647, '101 Maple Rd', 'sam@example.com'),
('CUST004', 'Lily Wong', 2147483647, '202 Birch Ave', 'lily@example.com'),
('CUST005', 'Tom Lin', 2147483647, '303 Cedar Dr', 'tom@example.com');

-- --------------------------------------------------------

--
-- 資料表結構 `delivery`
--

CREATE TABLE `delivery` (
  `DeliveryID` varchar(10) NOT NULL,
  `Method` varchar(30) NOT NULL,
  `Date` date NOT NULL,
  `OrderID` varchar(10) DEFAULT NULL,
  `EmployeeID` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `delivery`
--

INSERT INTO `delivery` (`DeliveryID`, `Method`, `Date`, `OrderID`, `EmployeeID`) VALUES
('DEL001', 'Courier', '2025-03-22', 'ORD001', 'EMP001'),
('DEL002', 'Truck', '2025-03-23', 'ORD002', 'EMP002'),
('DEL003', 'Courier', '2025-03-24', 'ORD003', 'EMP003'),
('DEL004', 'Truck', '2025-03-25', 'ORD004', 'EMP004'),
('DEL005', 'Courier', '2025-03-26', 'ORD005', 'EMP005');

-- --------------------------------------------------------

--
-- 資料表結構 `employee`
--

CREATE TABLE `employee` (
  `EmployeeID` varchar(10) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `PhoneNum` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `employee`
--

INSERT INTO `employee` (`EmployeeID`, `Name`, `PhoneNum`) VALUES
('EMP001', 'Jane Smith', 2147483647),
('EMP002', 'Mike Brown', 2147483647),
('EMP003', 'Sarah Davis', 2147483647),
('EMP004', 'Tom Wilson', 2147483647),
('EMP005', 'Emma Clark', 2147483647);

-- --------------------------------------------------------

--
-- 資料表結構 `file`
--

CREATE TABLE `file` (
  `FileID` varchar(10) NOT NULL,
  `ProductID` varchar(10) DEFAULT NULL,
  `FileName` varchar(100) NOT NULL,
  `FileLoc` varchar(100) NOT NULL,
  `AddDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `file`
--

INSERT INTO `file` (`FileID`, `ProductID`, `FileName`, `FileLoc`, `AddDate`) VALUES
('FILE001', 'TOY001', 'teddy_bear.jpg', '/files/toys/', '2025-03-20'),
('FILE002', 'TOY002', 'blocks.png', '/files/toys/', '2025-03-21'),
('FILE003', 'TOY003', 'action_figure.jpg', '/files/toys/', '2025-03-22'),
('FILE004', 'TOY004', 'puzzle_set.pdf', '/files/toys/', '2025-03-23'),
('FILE005', 'TOY005', 'unicorn.jpg', '/files/toys/', '2025-03-24');

-- --------------------------------------------------------

--
-- 資料表結構 `ingredient`
--

CREATE TABLE `ingredient` (
  `MaterialID` varchar(10) NOT NULL,
  `MaterialQty` varchar(10) NOT NULL,
  `Desc` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `ingredient`
--

INSERT INTO `ingredient` (`MaterialID`, `MaterialQty`, `Desc`) VALUES
('MAT001', '500g', 'Soft fabric for teddy bears'),
('MAT002', '1kg', 'Plastic for building blocks'),
('MAT003', '200g', 'Vinyl for action figures'),
('MAT004', '300g', 'Cardboard for puzzle pieces'),
('MAT005', '400g', 'Cotton for stuffed unicorn');

-- --------------------------------------------------------

--
-- 資料表結構 `material`
--

CREATE TABLE `material` (
  `MaterialID` varchar(10) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `Desc` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `material`
--

INSERT INTO `material` (`MaterialID`, `Name`, `Category`, `Desc`) VALUES
('MAT001', 'Plush Fabric', 'Toy Material', 'Soft fabric for teddy bears'),
('MAT002', 'Plastic Pellets', 'Toy Material', 'Durable plastic for blocks'),
('MAT003', 'Vinyl', 'Toy Material', 'Flexible material for action figures'),
('MAT004', 'Cardboard', 'Toy Material', 'Sturdy material for puzzles'),
('MAT005', 'Cotton Stuffing', 'Toy Material', 'Soft filling for stuffed toys');

-- --------------------------------------------------------

--
-- 資料表結構 `meeting`
--

CREATE TABLE `meeting` (
  `MeetingID` varchar(10) NOT NULL,
  `Date` date NOT NULL,
  `Time` time NOT NULL,
  `Loc` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `meeting`
--

INSERT INTO `meeting` (`MeetingID`, `Date`, `Time`, `Loc`) VALUES
('MEET001', '2025-03-25', '14:30:00', 'Conference Room A'),
('MEET002', '2025-03-26', '10:00:00', 'Conference Room B'),
('MEET003', '2025-03-27', '15:00:00', 'Meeting Room C'),
('MEET004', '2025-03-28', '11:30:00', 'Board Room'),
('MEET005', '2025-03-29', '09:00:00', 'Conference Room A');

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
('MEET002', 'EMP002', NULL),
('MEET004', 'EMP004', NULL),
('MEET001', 'EMP001', 'CUST001'),
('MEET003', 'EMP003', 'CUST002'),
('MEET005', 'EMP005', 'CUST003');

-- --------------------------------------------------------

--
-- 資料表結構 `order`
--

CREATE TABLE `order` (
  `OrderID` varchar(10) NOT NULL,
  `OrderDate` varchar(15) NOT NULL,
  `Status` varchar(15) NOT NULL,
  `SaleID` varchar(10) NOT NULL,
  `CustomerID` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `order`
--

INSERT INTO `order` (`OrderID`, `OrderDate`, `Status`, `SaleID`, `CustomerID`) VALUES
('ORD001', '2025-03-20', 'Pending', 'SALE001', 'CUST001'),
('ORD002', '2025-03-21', 'Shipped', 'SALE002', 'CUST002'),
('ORD003', '2025-03-22', 'Pending', 'SALE003', 'CUST003'),
('ORD004', '2025-03-23', 'Delivered', 'SALE004', 'CUST004'),
('ORD005', '2025-03-24', 'Pending', 'SALE005', 'CUST005');

-- --------------------------------------------------------

--
-- 資料表結構 `orderline`
--

CREATE TABLE `orderline` (
  `OrderID` varchar(10) NOT NULL,
  `ProductID` varchar(10) NOT NULL,
  `Qty` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `orderline`
--

INSERT INTO `orderline` (`OrderID`, `ProductID`, `Qty`) VALUES
('ORD001', 'TOY001', 10),
('ORD002', 'TOY002', 20),
('ORD003', 'TOY003', 15),
('ORD004', 'TOY004', 5),
('ORD005', 'TOY005', 8);

-- --------------------------------------------------------

--
-- 資料表結構 `payment`
--

CREATE TABLE `payment` (
  `PaymentID` varchar(10) NOT NULL,
  `OrderID` varchar(10) DEFAULT NULL,
  `PaymentDate` date NOT NULL,
  `Due` date NOT NULL,
  `Amount` int(11) NOT NULL,
  `Type` varchar(15) NOT NULL,
  `Status` varchar(15) NOT NULL,
  `Method` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `payment`
--

INSERT INTO `payment` (`PaymentID`, `OrderID`, `PaymentDate`, `Due`, `Amount`, `Type`, `Status`, `Method`) VALUES
('PAY001', 'ORD001', '2025-03-21', '2025-04-01', 500, 'Credit', 'Completed', 'Online'),
('PAY002', 'ORD002', '2025-03-22', '2025-04-02', 1000, 'Cash', 'Pending', 'In-person'),
('PAY003', 'ORD003', '2025-03-23', '2025-04-03', 750, 'Credit', 'Completed', 'Online'),
('PAY004', 'ORD004', '2025-03-24', '2025-04-04', 250, 'Debit', 'Completed', 'Online'),
('PAY005', 'ORD005', '2025-03-25', '2025-04-05', 400, 'Credit', 'Pending', 'Online');

-- --------------------------------------------------------

--
-- 資料表結構 `product`
--

CREATE TABLE `product` (
  `ProductID` varchar(10) NOT NULL,
  `Name` varchar(30) NOT NULL,
  `Desc` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `product`
--

INSERT INTO `product` (`ProductID`, `Name`, `Desc`) VALUES
('TOY001', 'Teddy Bear', 'A soft teddy bear for kids'),
('TOY002', 'Building Blocks', 'Colorful plastic blocks for creative play'),
('TOY003', 'Action Figure', 'Superhero figure with movable joints'),
('TOY004', 'Puzzle Set', '100-piece animal-themed puzzle'),
('TOY005', 'Stuffed Unicorn', 'Plush unicorn with sparkly horn');

-- --------------------------------------------------------

--
-- 資料表結構 `productinventory`
--

CREATE TABLE `productinventory` (
  `ProductID` varchar(10) NOT NULL,
  `WarehouseID` varchar(10) NOT NULL,
  `Qty` int(11) NOT NULL,
  `Loc` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `productinventory`
--

INSERT INTO `productinventory` (`ProductID`, `WarehouseID`, `Qty`, `Loc`) VALUES
('TOY001', 'WH001', 50, 'Shelf A1'),
('TOY002', 'WH002', 100, 'Shelf B2'),
('TOY003', 'WH003', 75, 'Shelf C3'),
('TOY004', 'WH004', 30, 'Shelf D4'),
('TOY005', 'WH005', 60, 'Shelf E5');

-- --------------------------------------------------------

--
-- 資料表結構 `productorder`
--

CREATE TABLE `productorder` (
  `POrderID` varchar(10) NOT NULL,
  `ProductID` varchar(10) DEFAULT NULL,
  `LineProductID` varchar(10) NOT NULL,
  `StartDate` date NOT NULL,
  `Due` date NOT NULL,
  `Qty` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `productorder`
--

INSERT INTO `productorder` (`POrderID`, `ProductID`, `LineProductID`, `StartDate`, `Due`, `Qty`) VALUES
('PORD001', 'TOY001', 'LINE001', '2025-03-01', '2025-03-15', 100),
('PORD002', 'TOY002', 'LINE002', '2025-03-02', '2025-03-16', 200),
('PORD003', 'TOY003', 'LINE003', '2025-03-03', '2025-03-17', 150),
('PORD004', 'TOY004', 'LINE004', '2025-03-04', '2025-03-18', 80),
('PORD005', 'TOY005', 'LINE005', '2025-03-05', '2025-03-19', 120);

-- --------------------------------------------------------

--
-- 資料表結構 `purchase`
--

CREATE TABLE `purchase` (
  `PurchaseID` varchar(10) NOT NULL,
  `Date` date NOT NULL,
  `Amount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `purchase`
--

INSERT INTO `purchase` (`PurchaseID`, `Date`, `Amount`) VALUES
('PUR001', '2025-03-15', 1000),
('PUR002', '2025-03-16', 2000),
('PUR003', '2025-03-17', 1500),
('PUR004', '2025-03-18', 800),
('PUR005', '2025-03-19', 1200);

-- --------------------------------------------------------

--
-- 資料表結構 `purchaseline`
--

CREATE TABLE `purchaseline` (
  `PurchaseID` varchar(10) NOT NULL,
  `SupplierID` varchar(10) NOT NULL,
  `MaterialID` varchar(10) NOT NULL,
  `Qty` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `purchaseline`
--

INSERT INTO `purchaseline` (`PurchaseID`, `SupplierID`, `MaterialID`, `Qty`) VALUES
('PUR001', 'SUP001', 'MAT001', 200),
('PUR002', 'SUP002', 'MAT002', 500),
('PUR003', 'SUP003', 'MAT003', 300),
('PUR004', 'SUP004', 'MAT004', 400),
('PUR005', 'SUP005', 'MAT005', 250);

-- --------------------------------------------------------

--
-- 資料表結構 `supplier`
--

CREATE TABLE `supplier` (
  `SupplierID` varchar(10) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `PhoneNum` int(11) NOT NULL,
  `Address` varchar(200) NOT NULL,
  `Email` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `supplier`
--

INSERT INTO `supplier` (`SupplierID`, `Name`, `PhoneNum`, `Address`, `Email`) VALUES
('SUP001', 'Toy Materials Inc.', 2147483647, '789 Pine St', 'toys@materials.com'),
('SUP002', 'Plush Suppliers', 2147483647, '101 Oak Rd', 'plush@suppliers.com'),
('SUP003', 'Plastic Co.', 2147483647, '202 Elm St', 'plastic@co.com'),
('SUP004', 'Cardboard Ltd.', 2147483647, '303 Birch Ave', 'cardboard@ltd.com'),
('SUP005', 'Stuffing Corp.', 2147483647, '404 Cedar Dr', 'stuffing@corp.com');

-- --------------------------------------------------------

--
-- 資料表結構 `warehouse`
--

CREATE TABLE `warehouse` (
  `WarehouseID` varchar(10) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Address` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `warehouse`
--

INSERT INTO `warehouse` (`WarehouseID`, `Name`, `Address`) VALUES
('WH001', 'Toy Storage A', '123 Toy Lane, Toy City'),
('WH002', 'Toy Storage B', '456 Play St, Toy City'),
('WH003', 'Main Warehouse', '789 Fun Rd, Toy City'),
('WH004', 'Distribution Center', '101 Joy Ave, Toy City'),
('WH005', 'Overflow Storage', '202 Happy Dr, Toy City');

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
  ADD PRIMARY KEY (`DeliveryID`),
  ADD KEY `OrderID` (`OrderID`),
  ADD KEY `EmployeeID` (`EmployeeID`);

--
-- 資料表索引 `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`EmployeeID`);

--
-- 資料表索引 `file`
--
ALTER TABLE `file`
  ADD PRIMARY KEY (`FileID`),
  ADD KEY `ProductID` (`ProductID`);

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
  ADD PRIMARY KEY (`MeetingID`,`EmpID`),
  ADD KEY `EmpID` (`EmpID`),
  ADD KEY `CustomerID` (`CustomerID`);

--
-- 資料表索引 `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`OrderID`),
  ADD KEY `CustomerID` (`CustomerID`);

--
-- 資料表索引 `orderline`
--
ALTER TABLE `orderline`
  ADD PRIMARY KEY (`OrderID`,`ProductID`),
  ADD KEY `ProductID` (`ProductID`);

--
-- 資料表索引 `payment`
--
ALTER TABLE `payment`
  ADD PRIMARY KEY (`PaymentID`),
  ADD KEY `OrderID` (`OrderID`);

--
-- 資料表索引 `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`ProductID`);

--
-- 資料表索引 `productinventory`
--
ALTER TABLE `productinventory`
  ADD PRIMARY KEY (`ProductID`,`WarehouseID`),
  ADD KEY `WarehouseID` (`WarehouseID`);

--
-- 資料表索引 `productorder`
--
ALTER TABLE `productorder`
  ADD PRIMARY KEY (`POrderID`),
  ADD KEY `ProductID` (`ProductID`);

--
-- 資料表索引 `purchase`
--
ALTER TABLE `purchase`
  ADD PRIMARY KEY (`PurchaseID`);

--
-- 資料表索引 `purchaseline`
--
ALTER TABLE `purchaseline`
  ADD PRIMARY KEY (`PurchaseID`,`SupplierID`,`MaterialID`),
  ADD KEY `SupplierID` (`SupplierID`),
  ADD KEY `MaterialID` (`MaterialID`);

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

--
-- 已傾印資料表的限制式
--

--
-- 資料表的限制式 `delivery`
--
ALTER TABLE `delivery`
  ADD CONSTRAINT `delivery_ibfk_1` FOREIGN KEY (`OrderID`) REFERENCES `order` (`OrderID`),
  ADD CONSTRAINT `delivery_ibfk_2` FOREIGN KEY (`EmployeeID`) REFERENCES `employee` (`EmployeeID`);

--
-- 資料表的限制式 `file`
--
ALTER TABLE `file`
  ADD CONSTRAINT `file_ibfk_1` FOREIGN KEY (`ProductID`) REFERENCES `product` (`ProductID`);

--
-- 資料表的限制式 `ingredient`
--
ALTER TABLE `ingredient`
  ADD CONSTRAINT `ingredient_ibfk_1` FOREIGN KEY (`MaterialID`) REFERENCES `material` (`MaterialID`);

--
-- 資料表的限制式 `meetingparticipant`
--
ALTER TABLE `meetingparticipant`
  ADD CONSTRAINT `meetingparticipant_ibfk_1` FOREIGN KEY (`MeetingID`) REFERENCES `meeting` (`MeetingID`),
  ADD CONSTRAINT `meetingparticipant_ibfk_2` FOREIGN KEY (`EmpID`) REFERENCES `employee` (`EmployeeID`),
  ADD CONSTRAINT `meetingparticipant_ibfk_3` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`);

--
-- 資料表的限制式 `order`
--
ALTER TABLE `order`
  ADD CONSTRAINT `order_ibfk_1` FOREIGN KEY (`CustomerID`) REFERENCES `customer` (`CustomerID`);

--
-- 資料表的限制式 `orderline`
--
ALTER TABLE `orderline`
  ADD CONSTRAINT `orderline_ibfk_1` FOREIGN KEY (`OrderID`) REFERENCES `order` (`OrderID`),
  ADD CONSTRAINT `orderline_ibfk_2` FOREIGN KEY (`ProductID`) REFERENCES `product` (`ProductID`);

--
-- 資料表的限制式 `payment`
--
ALTER TABLE `payment`
  ADD CONSTRAINT `payment_ibfk_1` FOREIGN KEY (`OrderID`) REFERENCES `order` (`OrderID`);

--
-- 資料表的限制式 `productinventory`
--
ALTER TABLE `productinventory`
  ADD CONSTRAINT `productinventory_ibfk_1` FOREIGN KEY (`ProductID`) REFERENCES `product` (`ProductID`),
  ADD CONSTRAINT `productinventory_ibfk_2` FOREIGN KEY (`WarehouseID`) REFERENCES `warehouse` (`WarehouseID`);

--
-- 資料表的限制式 `productorder`
--
ALTER TABLE `productorder`
  ADD CONSTRAINT `productorder_ibfk_1` FOREIGN KEY (`ProductID`) REFERENCES `product` (`ProductID`);

--
-- 資料表的限制式 `purchaseline`
--
ALTER TABLE `purchaseline`
  ADD CONSTRAINT `purchaseline_ibfk_1` FOREIGN KEY (`PurchaseID`) REFERENCES `purchase` (`PurchaseID`),
  ADD CONSTRAINT `purchaseline_ibfk_2` FOREIGN KEY (`SupplierID`) REFERENCES `supplier` (`SupplierID`),
  ADD CONSTRAINT `purchaseline_ibfk_3` FOREIGN KEY (`MaterialID`) REFERENCES `material` (`MaterialID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
