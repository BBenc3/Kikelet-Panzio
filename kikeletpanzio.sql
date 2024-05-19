-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Máj 18. 14:41
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `kikeletpanzio`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `registeredguest`
--

CREATE TABLE `registeredguest` (
  `guestId` int(11) NOT NULL,
  `guestCode` varchar(50) NOT NULL,
  `registrationDate` datetime DEFAULT current_timestamp(),
  `guestName` varchar(100) NOT NULL,
  `birthDay` date NOT NULL,
  `country` varchar(50) NOT NULL,
  `postalCode` varchar(10) NOT NULL,
  `city` varchar(100) NOT NULL,
  `address` varchar(200) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `vip` tinyint(1) DEFAULT 0,
  `banned` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `registeredguest`
--

INSERT INTO `registeredguest` (`guestId`, `guestCode`, `registrationDate`, `guestName`, `birthDay`, `country`, `postalCode`, `city`, `address`, `email`, `vip`, `banned`) VALUES
(1, 'KissJános20240518', '2024-05-18 14:40:35', 'Kiss János', '1999-03-02', 'Magyarország', '1345', 'BudaPest', 'Szent István út 2', NULL, 0, 0),
(2, 'NagyAlexandra20240518', '2024-05-18 14:40:35', 'Nagy Alexandra', '2000-02-14', 'Magyarország', '3543', 'Hatvan', 'Petőfi Sándor út 5', 'AlexaN@hotmail.com', 1, 0),
(3, 'UrbanTamas20240518', '2024-05-18 14:40:35', 'Urbán Tamás', '2000-05-20', 'Magyarország', '9685', 'Szentendre', 'Hatvani utca 14', NULL, 0, 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `reservation`
--

CREATE TABLE `reservation` (
  `reservationId` int(11) NOT NULL,
  `checkedIn` datetime DEFAULT NULL,
  `checkedOut` datetime DEFAULT NULL,
  `guestId` int(11) NOT NULL,
  `roomId` int(11) NOT NULL,
  `dateOfReservation` datetime DEFAULT current_timestamp(),
  `firstReservedDay` date NOT NULL,
  `lastReservedDay` date NOT NULL,
  `reservationStatust` varchar(20) DEFAULT 'reserved'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `reservation`
--

INSERT INTO `reservation` (`reservationId`, `checkedIn`, `checkedOut`, `guestId`, `roomId`, `dateOfReservation`, `firstReservedDay`, `lastReservedDay`, `reservationStatust`) VALUES
(1, NULL, NULL, 1, 2, '2024-05-18 14:40:35', '2024-06-20', '2024-06-25', 'reserved'),
(2, NULL, NULL, 2, 5, '2024-05-18 14:40:35', '2024-05-25', '2024-05-27', 'reserved'),
(3, '2024-02-28 00:00:00', '2024-03-02 00:00:00', 1, 2, '2024-05-18 14:40:35', '2024-02-28', '2024-03-02', 'closed'),
(4, NULL, NULL, 1, 2, '2024-05-18 14:40:35', '2024-04-05', '2024-04-06', 'deleted');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `room`
--

CREATE TABLE `room` (
  `roomId` int(11) NOT NULL,
  `roomNumber` varchar(10) NOT NULL,
  `accommodation` int(11) NOT NULL,
  `price` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `room`
--

INSERT INTO `room` (`roomId`, `roomNumber`, `accommodation`, `price`) VALUES
(1, '1', 2, 6000),
(2, '2', 3, 9000),
(3, '3', 2, 6000),
(4, '4', 4, 12000),
(5, '5', 3, 9000),
(6, '6', 2, 6000);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `registeredguest`
--
ALTER TABLE `registeredguest`
  ADD PRIMARY KEY (`guestId`),
  ADD UNIQUE KEY `email` (`email`);

--
-- A tábla indexei `reservation`
--
ALTER TABLE `reservation`
  ADD PRIMARY KEY (`reservationId`),
  ADD KEY `guestId` (`guestId`),
  ADD KEY `roomId` (`roomId`);

--
-- A tábla indexei `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`roomId`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `registeredguest`
--
ALTER TABLE `registeredguest`
  MODIFY `guestId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `reservation`
--
ALTER TABLE `reservation`
  MODIFY `reservationId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT a táblához `room`
--
ALTER TABLE `room`
  MODIFY `roomId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `reservation`
--
ALTER TABLE `reservation`
  ADD CONSTRAINT `reservation_ibfk_1` FOREIGN KEY (`guestId`) REFERENCES `registeredguest` (`guestId`),
  ADD CONSTRAINT `reservation_ibfk_2` FOREIGN KEY (`roomId`) REFERENCES `room` (`roomId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
