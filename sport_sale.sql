-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 02, 2023 at 10:13 AM
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
-- Database: `sport_sale`
--

-- --------------------------------------------------------

--
-- Table structure for table `amokejimas`
--

CREATE TABLE `amokejimas` (
  `id` int(11) NOT NULL,
  `mokejimoData` date DEFAULT NULL,
  `kaina` float DEFAULT NULL,
  `fk_NARYSTEid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `amokejimas`
--

INSERT INTO `amokejimas` (`id`, `mokejimoData`, `kaina`, `fk_NARYSTEid`) VALUES
(1, '2023-05-27', 12, 3),
(2, '2023-07-06', 50, 4);

-- --------------------------------------------------------

--
-- Table structure for table `darbas`
--

CREATE TABLE `darbas` (
  `id` int(11) NOT NULL,
  `darboValandos` date DEFAULT NULL,
  `sumoketa` float DEFAULT NULL,
  `pozicija` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `darbas`
--

INSERT INTO `darbas` (`id`, `darboValandos`, `sumoketa`, `pozicija`) VALUES
(1, '2023-07-01', 785, 1),
(2, '2023-05-21', 900, 2),
(3, '2023-01-10', 1500, 3);

-- --------------------------------------------------------

--
-- Table structure for table `darbuotojas`
--

CREATE TABLE `darbuotojas` (
  `id` int(11) NOT NULL,
  `vardas` varchar(255) DEFAULT NULL,
  `pavarde` varchar(255) DEFAULT NULL,
  `telNumeris` varchar(255) DEFAULT NULL,
  `lytis` int(11) DEFAULT NULL,
  `fk_SPORTO_SALEid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `darbuotojas`
--

INSERT INTO `darbuotojas` (`id`, `vardas`, `pavarde`, `telNumeris`, `lytis`, `fk_SPORTO_SALEid`) VALUES
(2, 'Lombukas', 'Bobmukas', '4563289', 1, 1),
(3, 'Lakas', 'Smakas', '99999', 2, 2),
(4, 'Kukulis', 'Kukuliukas', '4563336', 1, 3),
(5, 'Kipras', 'Sadauskas', '33333333', 1, 3),
(6, 'Ingrida', 'Nesak', '333111111', 2, 4);

-- --------------------------------------------------------

--
-- Table structure for table `inventorius`
--

CREATE TABLE `inventorius` (
  `id` int(11) NOT NULL,
  `pastatymas` date DEFAULT NULL,
  `kiekis` int(11) DEFAULT NULL,
  `kaina` float DEFAULT NULL,
  `pavadinimai` varchar(255) DEFAULT NULL,
  `fk_SPORTO_SALEid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `inventorius`
--

INSERT INTO `inventorius` (`id`, `pastatymas`, `kiekis`, `kaina`, `pavadinimai`, `fk_SPORTO_SALEid`) VALUES
(1, '2016-05-03', 7, 740000, 'Begtakiai', 1),
(2, '2023-05-02', 125, 12036, 'Hanteliai', 2),
(3, '2023-03-07', 4, 5000, 'Skersiniai', 3),
(4, '2023-03-14', 2, 8000, 'Linu aparatas', 4);

-- --------------------------------------------------------

--
-- Table structure for table `klientas`
--

CREATE TABLE `klientas` (
  `id` int(11) NOT NULL,
  `vardas` varchar(255) DEFAULT NULL,
  `pavarde` varchar(255) DEFAULT NULL,
  `amzius` int(11) DEFAULT NULL,
  `telefononr` varchar(255) DEFAULT NULL,
  `fk_NARYSTEid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `klientas`
--

INSERT INTO `klientas` (`id`, `vardas`, `pavarde`, `amzius`, `telefononr`, `fk_NARYSTEid`) VALUES
(1, 'Kamila', 'Butkutė', 54, '+37066668114', 3),
(2, 'Modestas\r\n', 'Linkevičius', 19, '+37057767729', 4);

-- --------------------------------------------------------

--
-- Table structure for table `lytis`
--

CREATE TABLE `lytis` (
  `id_Lytis` int(11) NOT NULL,
  `name` char(7) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `lytis`
--

INSERT INTO `lytis` (`id_Lytis`, `name`) VALUES
(1, 'Vyras'),
(2, 'Moteris');

-- --------------------------------------------------------

--
-- Table structure for table `miestai`
--

CREATE TABLE `miestai` (
  `id` int(11) NOT NULL,
  `pavadinimas` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `miestai`
--

INSERT INTO `miestai` (`id`, `pavadinimas`) VALUES
(1, 'Kaunas'),
(2, 'Vilnius'),
(3, 'Klaipeda'),
(4, 'Kedainiai');

-- --------------------------------------------------------

--
-- Table structure for table `naryste`
--

CREATE TABLE `naryste` (
  `id` int(11) NOT NULL,
  `planoPradzia` date DEFAULT NULL,
  `planoPabaiga` date DEFAULT NULL,
  `kaina` float DEFAULT NULL,
  `narystesLygis` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `naryste`
--

INSERT INTO `naryste` (`id`, `planoPradzia`, `planoPabaiga`, `kaina`, `narystesLygis`) VALUES
(3, '2000-01-10', '2000-05-10', 500, 1),
(4, '2023-05-02', '2023-05-25', 5, 3);

-- --------------------------------------------------------

--
-- Table structure for table `narysteslygis`
--

CREATE TABLE `narysteslygis` (
  `id_NarystesLygis` int(11) NOT NULL,
  `name` char(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `narysteslygis`
--

INSERT INTO `narysteslygis` (`id_NarystesLygis`, `name`) VALUES
(1, 'Silver'),
(2, 'Gold'),
(3, 'Platinum');

-- --------------------------------------------------------

--
-- Table structure for table `paslaugos`
--

CREATE TABLE `paslaugos` (
  `id` int(11) NOT NULL,
  `kaina` float DEFAULT NULL,
  `paslaugosTipas` int(11) DEFAULT NULL,
  `fk_SPORTO_SALEid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `paslaugos`
--

INSERT INTO `paslaugos` (`id`, `kaina`, `paslaugosTipas`, `fk_SPORTO_SALEid`) VALUES
(1, 33, 1, 1),
(2, 10, 2, 4),
(3, 54, 3, 3),
(4, 5, 1, 2);

-- --------------------------------------------------------

--
-- Table structure for table `paslaugostipas`
--

CREATE TABLE `paslaugostipas` (
  `id_PaslaugosTipas` int(11) NOT NULL,
  `name` char(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `paslaugostipas`
--

INSERT INTO `paslaugostipas` (`id_PaslaugosTipas`, `name`) VALUES
(1, 'Baseinas'),
(2, 'Pirtis'),
(3, 'Masazai');

-- --------------------------------------------------------

--
-- Table structure for table `pozicija`
--

CREATE TABLE `pozicija` (
  `id_Pozicija` int(11) NOT NULL,
  `name` char(14) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pozicija`
--

INSERT INTO `pozicija` (`id_Pozicija`, `name`) VALUES
(1, 'Administracija'),
(2, 'Valytojas'),
(3, 'Treneris');

-- --------------------------------------------------------

--
-- Table structure for table `priskirtas`
--

CREATE TABLE `priskirtas` (
  `fk_DARBASid` int(11) NOT NULL,
  `fk_DARBUOTOJASid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `priskirtas`
--

INSERT INTO `priskirtas` (`fk_DARBASid`, `fk_DARBUOTOJASid`) VALUES
(1, 4),
(2, 2),
(3, 6);

-- --------------------------------------------------------

--
-- Table structure for table `sales`
--

CREATE TABLE `sales` (
  `id` int(11) NOT NULL,
  `pavadinimas` varchar(255) DEFAULT NULL,
  `irengta` date DEFAULT NULL,
  `tipas` int(11) DEFAULT NULL,
  `fk_SPORTO_SALEid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `sales`
--

INSERT INTO `sales` (`id`, `pavadinimas`, `irengta`, `tipas`, `fk_SPORTO_SALEid`) VALUES
(1, 'Raudona', '2020-05-07', 1, 1),
(2, 'Melyna', '2023-05-04', 5, 4),
(3, 'Kamuoliukas', '2016-05-11', 4, 3),
(4, 'JOga', '0000-00-00', 3, 1),
(5, 'Judriukas', '0000-00-00', 2, 2),
(6, 'Raudona', '2020-05-07', 1, 1),
(7, 'Melyna', '2023-05-04', 5, 4),
(8, 'Kamuoliukas', '2016-05-11', 4, 3);

-- --------------------------------------------------------

--
-- Table structure for table `salestipas`
--

CREATE TABLE `salestipas` (
  `id_SalesTipas` int(11) NOT NULL,
  `name` char(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `salestipas`
--

INSERT INTO `salestipas` (`id_SalesTipas`, `name`) VALUES
(1, 'Trx'),
(2, 'Kalanetika'),
(3, 'KunoDizainas'),
(4, 'BallsWorkout'),
(5, 'ResistanceBand');

-- --------------------------------------------------------

--
-- Table structure for table `sporto_sale`
--

CREATE TABLE `sporto_sale` (
  `id` int(11) NOT NULL,
  `adresas` varchar(255) DEFAULT NULL,
  `maksimalusLankytojusk` int(11) DEFAULT NULL,
  `pavadinimas` varchar(255) DEFAULT NULL,
  `darboLaikoPradzia` date DEFAULT NULL,
  `darboLaikoPabaiga` date DEFAULT NULL,
  `telefonoNumeris` varchar(255) DEFAULT NULL,
  `elPastas` varchar(255) DEFAULT NULL,
  `intenetineSvetaine` varchar(255) DEFAULT NULL,
  `fk_Miestaiid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `sporto_sale`
--

INSERT INTO `sporto_sale` (`id`, `adresas`, `maksimalusLankytojusk`, `pavadinimas`, `darboLaikoPradzia`, `darboLaikoPabaiga`, `telefonoNumeris`, `elPastas`, `intenetineSvetaine`, `fk_Miestaiid`) VALUES
(1, 'Studnetu 69', 500, 'Studentu', '2023-05-03', '2023-05-20', '868686868', 'labas@pastas', 'www.studentai.lt', 1),
(2, 'Basanaviciaus', 50, 'Feniksas', '2023-05-01', '2023-05-06', '74745645', 'fenikas@gmail.com', 'www.feniksas.lt', 4),
(3, 'Kauno 78', 39, 'Jura', '2023-02-01', '2023-05-13', '123456', 'Jura@gmail.com', 'www.jura.lt', 3),
(4, 'Ozo 36 g', 136, 'Rytas', '2023-05-28', '2023-05-26', '7894632', 'rytas@gmail.com', 'www.Rytas.lt', 2);

-- --------------------------------------------------------

--
-- Table structure for table `teikia`
--

CREATE TABLE `teikia` (
  `fk_NARYSTEid` int(11) NOT NULL,
  `fk_SPORTO_SALEid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `teikia`
--

INSERT INTO `teikia` (`fk_NARYSTEid`, `fk_SPORTO_SALEid`) VALUES
(3, 1),
(4, 4);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `amokejimas`
--
ALTER TABLE `amokejimas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `apmokama` (`fk_NARYSTEid`);

--
-- Indexes for table `darbas`
--
ALTER TABLE `darbas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `pozicija` (`pozicija`);

--
-- Indexes for table `darbuotojas`
--
ALTER TABLE `darbuotojas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `lytis` (`lytis`),
  ADD KEY `dirba` (`fk_SPORTO_SALEid`);

--
-- Indexes for table `inventorius`
--
ALTER TABLE `inventorius`
  ADD PRIMARY KEY (`id`),
  ADD KEY `priklauso` (`fk_SPORTO_SALEid`);

--
-- Indexes for table `klientas`
--
ALTER TABLE `klientas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `suteikiama` (`fk_NARYSTEid`);

--
-- Indexes for table `lytis`
--
ALTER TABLE `lytis`
  ADD PRIMARY KEY (`id_Lytis`);

--
-- Indexes for table `miestai`
--
ALTER TABLE `miestai`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`,`pavadinimas`);

--
-- Indexes for table `naryste`
--
ALTER TABLE `naryste`
  ADD PRIMARY KEY (`id`),
  ADD KEY `narystesLygis` (`narystesLygis`);

--
-- Indexes for table `narysteslygis`
--
ALTER TABLE `narysteslygis`
  ADD PRIMARY KEY (`id_NarystesLygis`);

--
-- Indexes for table `paslaugos`
--
ALTER TABLE `paslaugos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `paslaugosTipas` (`paslaugosTipas`),
  ADD KEY `suteikiamos` (`fk_SPORTO_SALEid`);

--
-- Indexes for table `paslaugostipas`
--
ALTER TABLE `paslaugostipas`
  ADD PRIMARY KEY (`id_PaslaugosTipas`);

--
-- Indexes for table `pozicija`
--
ALTER TABLE `pozicija`
  ADD PRIMARY KEY (`id_Pozicija`);

--
-- Indexes for table `priskirtas`
--
ALTER TABLE `priskirtas`
  ADD PRIMARY KEY (`fk_DARBASid`,`fk_DARBUOTOJASid`);

--
-- Indexes for table `sales`
--
ALTER TABLE `sales`
  ADD PRIMARY KEY (`id`),
  ADD KEY `tipas` (`tipas`),
  ADD KEY `turi` (`fk_SPORTO_SALEid`);

--
-- Indexes for table `salestipas`
--
ALTER TABLE `salestipas`
  ADD PRIMARY KEY (`id_SalesTipas`);

--
-- Indexes for table `sporto_sale`
--
ALTER TABLE `sporto_sale`
  ADD PRIMARY KEY (`id`),
  ADD KEY `yra` (`fk_Miestaiid`);

--
-- Indexes for table `teikia`
--
ALTER TABLE `teikia`
  ADD PRIMARY KEY (`fk_NARYSTEid`,`fk_SPORTO_SALEid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `amokejimas`
--
ALTER TABLE `amokejimas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `darbas`
--
ALTER TABLE `darbas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `darbuotojas`
--
ALTER TABLE `darbuotojas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `inventorius`
--
ALTER TABLE `inventorius`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `klientas`
--
ALTER TABLE `klientas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `miestai`
--
ALTER TABLE `miestai`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `naryste`
--
ALTER TABLE `naryste`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `paslaugos`
--
ALTER TABLE `paslaugos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `sales`
--
ALTER TABLE `sales`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `sporto_sale`
--
ALTER TABLE `sporto_sale`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `amokejimas`
--
ALTER TABLE `amokejimas`
  ADD CONSTRAINT `apmokama` FOREIGN KEY (`fk_NARYSTEid`) REFERENCES `naryste` (`id`);

--
-- Constraints for table `darbas`
--
ALTER TABLE `darbas`
  ADD CONSTRAINT `darbas_ibfk_1` FOREIGN KEY (`pozicija`) REFERENCES `pozicija` (`id_Pozicija`);

--
-- Constraints for table `darbuotojas`
--
ALTER TABLE `darbuotojas`
  ADD CONSTRAINT `darbuotojas_ibfk_1` FOREIGN KEY (`lytis`) REFERENCES `lytis` (`id_Lytis`),
  ADD CONSTRAINT `dirba` FOREIGN KEY (`fk_SPORTO_SALEid`) REFERENCES `sporto_sale` (`id`);

--
-- Constraints for table `inventorius`
--
ALTER TABLE `inventorius`
  ADD CONSTRAINT `priklauso` FOREIGN KEY (`fk_SPORTO_SALEid`) REFERENCES `sporto_sale` (`id`);

--
-- Constraints for table `klientas`
--
ALTER TABLE `klientas`
  ADD CONSTRAINT `suteikiama` FOREIGN KEY (`fk_NARYSTEid`) REFERENCES `naryste` (`id`);

--
-- Constraints for table `naryste`
--
ALTER TABLE `naryste`
  ADD CONSTRAINT `naryste_ibfk_1` FOREIGN KEY (`narystesLygis`) REFERENCES `narysteslygis` (`id_NarystesLygis`);

--
-- Constraints for table `paslaugos`
--
ALTER TABLE `paslaugos`
  ADD CONSTRAINT `paslaugos_ibfk_1` FOREIGN KEY (`paslaugosTipas`) REFERENCES `paslaugostipas` (`id_PaslaugosTipas`),
  ADD CONSTRAINT `suteikiamos` FOREIGN KEY (`fk_SPORTO_SALEid`) REFERENCES `sporto_sale` (`id`);

--
-- Constraints for table `priskirtas`
--
ALTER TABLE `priskirtas`
  ADD CONSTRAINT `priskirtas` FOREIGN KEY (`fk_DARBASid`) REFERENCES `darbas` (`id`);

--
-- Constraints for table `sales`
--
ALTER TABLE `sales`
  ADD CONSTRAINT `sales_ibfk_1` FOREIGN KEY (`tipas`) REFERENCES `salestipas` (`id_SalesTipas`),
  ADD CONSTRAINT `turi` FOREIGN KEY (`fk_SPORTO_SALEid`) REFERENCES `sporto_sale` (`id`);

--
-- Constraints for table `sporto_sale`
--
ALTER TABLE `sporto_sale`
  ADD CONSTRAINT `yra` FOREIGN KEY (`fk_Miestaiid`) REFERENCES `miestai` (`id`);

--
-- Constraints for table `teikia`
--
ALTER TABLE `teikia`
  ADD CONSTRAINT `teikia` FOREIGN KEY (`fk_NARYSTEid`) REFERENCES `naryste` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
