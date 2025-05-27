-- MySQL dump 10.13  Distrib 8.0.26, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: testapi
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `absences`
--

DROP TABLE IF EXISTS `absences`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `absences` (
  `id` int NOT NULL AUTO_INCREMENT,
  `employeeid` int NOT NULL,
  `startdate` date NOT NULL,
  `enddate` date NOT NULL,
  `type` enum('обучение','отгул','отсутствие','отпуск') NOT NULL,
  `description` varchar(100) DEFAULT NULL,
  `paid` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `absences_ibfk_1` (`employeeid`),
  CONSTRAINT `absences_ibfk_1` FOREIGN KEY (`employeeid`) REFERENCES `employees` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `check_absence_dates` CHECK ((`startdate` <= `enddate`))
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `absences`
--

LOCK TABLES `absences` WRITE;
/*!40000 ALTER TABLE `absences` DISABLE KEYS */;
INSERT INTO `absences` VALUES (1,4,'2025-01-01','2025-01-06','отпуск','Новогодний отпуск',0),(10,11,'2025-02-13','2025-02-14','отгул','Отгул по причине тест',0),(11,11,'2025-02-01','2025-02-12','обучение','подготовка к чемпионату',1),(12,17,'2025-04-29','2025-04-29','отгул','Прогул',1);
/*!40000 ALTER TABLE `absences` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidates`
--

DROP TABLE IF EXISTS `candidates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `candidates` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fullname` varchar(255) NOT NULL,
  `position` varchar(255) DEFAULT NULL,
  `applicationdate` date DEFAULT NULL,
  `resume` text NOT NULL,
  `email` varchar(255) DEFAULT NULL,
  `phone` varchar(255) DEFAULT NULL,
  `skills` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidates`
--

LOCK TABLES `candidates` WRITE;
/*!40000 ALTER TABLE `candidates` DISABLE KEYS */;
INSERT INTO `candidates` VALUES (1,'Иванов Иван','С# разработчик','2024-05-05','BabyBoom\nТюмень, kidsbe.ru\nИнформационные технологии, системная интеграция, интернет\n• Интернет-компания (поисковики, платежные системы, соц.сети, информационно-познавательные и развлекательные ресурсы, продвижение сайтов и прочее)\nMiddle C#-разработчик\n- Участвовал в процессе проектирования пользовательского интерфейса и опыта в Figma, синхронизировал UI-кит в Figma с кодом\n- Внедрил Clean-архитектуру в проект\n- Описал всю логику для оплат и пейвола с использованием SDK YooMoney. \n- Для стейт-менеджмента пользовательских подписок реализовал рекурсивную структуру из 3 вложенных друг в друга scope\'ов\n- Написал с нуля экран поиска, для оптимизации использовал ленивые списки из ленивых списков\nЯндекс Практикум\nМосква, practicum.yandex.ru/\nИнформационные технологии, системная интеграция, интернет\n• Интернет-компания (поисковики, платежные системы, соц.сети, информационно-познавательные и развлекательные ресурсы, продвижение сайтов и прочее)\nАвтор и ревьюер на направлении дизайна\n- Писал про взаимодействие дизайна с разработкой, документацию и вёрстку на курсах Продуктового дизайна, Дизайна мобильных приложений и Дизайна интерфейсов\n- Проводил воркшопы по работе с Git и компонентному подходу в дизайне и разработке\n- Проверял финальные задания студентов по написанным мной темам и оставлял развёрнутую обратную связь и комментарии в Figma\n- Отвечал на вопросы студентов в чате\nМаркер\nИннополис, marker.tips/\nИнформационные технологии, системная интеграция, интернет\n• Интернет-компания (поисковики, платежные системы, соц.сети, информационно-познавательные и развлекательные ресурсы, продвижение сайтов и прочее)\nДизайнер продукта\n- Соучредил сервис, который генерирует текст и исправляет ошибки с помощью ИИ\n- Занимался дизайном продукта, лендинга, оформление соц. сетей и рекламных постов\n- Проводил UX-тестирования\nAlong\nИннополис, along.pw/\nИнформационные технологии, системная интеграция, интернет\n• Разработка программного обеспечения\nМладший c#-разработчик\n- Верстал экраны по макету в Figma\n- Следовал Clean-архитектуре \n- Отлаживал код с помощью Proxyman\nЯндекс\nМосква, www.yandex.ru\nИнформационные технологии, системная интеграция, интернет\n• Интернет-компания (поисковики, платежные системы, соц.сети, информационно-познавательные и развлекательные ресурсы, продвижение сайтов и прочее)\nСтажер-разработчик\n- Спроектировал дизайн и потом реализовал в коде собственный фича-модуль, заменяющий веб-вью \n- Вместе с аналитиком покрыл метрикой один модуль\n- Добавлял новые функции в существующие модули, подвязывал конфиги для их активации и кастомизации. Самой крупной задачей был статус-бар, для которого каждые 5 минут приходил кофиг с параметрами\n- Проектировал дизайн в Figma на основе существующего, используя библиотеку компонентов Про, и утверждал макеты с менеджерами\n- Искал логи багов и воспроизводил с помощью Crashlytics и AppMetrica и фиксил их\nПрогматика\nМосква, progmatica.innopolis.university/\nИнформационные технологии, системная интеграция, интернет\n• Разработка программного обеспечения\nПреподаватель программирования и автор учебных материалов\n- Проводил индивидуальные и групповые онлайн-занятия с детьми от 7 лет по Python\n- Писал длинный курс на 64 часа и интенсив на две недели по Python','qhdfkshfh@yrrhj.ttr','+7 (901) 1234567 ','Русский — Родной; C#  Dart Riverpod  GetIt  Hive  Isar  Dio  Crashlytics  AppMetrica  Flutter Test  Intl  Cloud Firestore  Firebase Auth  Location  Camera  Sensors Plus  Bloc  Cubit  Injectable  Git  fpdart  RxDart  Fast Immutable Collections'),(2,'Смирнов Игорь Федорович','Backend developer','2023-12-28','Сентябрь 2020 —\nнастоящее время\n3 года 5 месяцев\nBRINGOO\nГермания, bringoo.de/de/\nTech lead\nРазработка бакенда и фронтенда для системы доставки продуктов.\nРазработка микросервисной архитектуры.\nУправление командой\nСтек: typescript, nestjs, postgresql, rabbitmq, angular 14+\nМай 2018 —\nАвгуст 2020\n2 года 4 месяца\nOtalio GmbH\nГермания, www.otalio.com/\nFrontend Developer\nРазработка фронтенда для CRM системы используемой круизными компаниями.\nTypescript, Angular\nЯнварь 2016 —\nЯнварь 2018\n2 года 1 месяц\nBIMLIB\nbimlib.ru/\nFronend Developer\nРазработка фронтенда на angular 1, vanilla js\nЯнварь 2013 —\nСентябрь 2016\n3 года 9 месяцев\nAnimeonline.su\nanimeonline.su\nИнформационные технологии, системная интеграция, интернет\n• Интернет-компания (поисковики, платежные системы, соц.сети,\nинформационно-познавательные и развлекательные ресурсы, продвижение сайтов и\nпрочее)\nFullstack Developer\nРазработка онлайн кинотеатра\nbackend: php,mysql, zend\nfrontend: vanillajs,jquery, angular 1\nЯнварь 2009 —\nЯнварь 2013\nNovado\n4 года 1 месяц Киров (Кировская область), novado.ru/\nВеб разработчий\nРазработка сайтов различной сложности\nPHP javascript mysql Zend jquery',NULL,NULL,'Знание языков Русский — Родной\nАнглийский — B2 — Средне-продвинутый\nНавыки jQuery CSS3 Bootstrap JavaScript MySQL HTML5 PostgreSQL\nAngularJS TypeScript Angular Node.js RabbitMQ Less SQL\nGitlab PhpStorm Git Английский язык Jest CSS GraphQL Sass\nRxJS SOLID REST API NestJS Docker Redis\nКоммуникативная компетентность');
/*!40000 ALTER TABLE `candidates` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Comments`
--

DROP TABLE IF EXISTS `Comments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Comments` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DocumentId` int NOT NULL,
  `Text` text NOT NULL,
  `DateCreated` datetime DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `AuthorName` varchar(100) NOT NULL,
  `AuthorPosition` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `DocumentId` (`DocumentId`),
  CONSTRAINT `comments_ibfk_1` FOREIGN KEY (`DocumentId`) REFERENCES `Documents` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Comments`
--

LOCK TABLES `Comments` WRITE;
/*!40000 ALTER TABLE `Comments` DISABLE KEYS */;
INSERT INTO `Comments` VALUES (4,3,'Документ очень полезный!','2025-03-04 00:00:00','2025-03-04 00:00:00','Иван Иванов','Менеджер'),(5,3,'Добавьте больше примеров','2025-02-04 00:00:00','2025-02-05 00:00:00','Петр Петров','Разработчик'),(6,5,'Отличный план.','2024-12-31 00:00:00','2025-01-01 00:00:00','Анна Смирнова','Аналитик');
/*!40000 ALTER TABLE `Comments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departaments`
--

DROP TABLE IF EXISTS `departaments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `departaments` (
  `id` int NOT NULL AUTO_INCREMENT,
  `organizationid` int NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `managerid` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `organization_id_idx` (`organizationid`),
  KEY `manager_id_idx` (`managerid`),
  CONSTRAINT `manager_id` FOREIGN KEY (`managerid`) REFERENCES `employees` (`id`) ON DELETE CASCADE,
  CONSTRAINT `organization_id` FOREIGN KEY (`organizationid`) REFERENCES `organizations` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=111 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departaments`
--

LOCK TABLES `departaments` WRITE;
/*!40000 ALTER TABLE `departaments` DISABLE KEYS */;
INSERT INTO `departaments` VALUES (1,1,'1.1. Административный департамент',NULL,1),(2,1,'1.2. Договорной отдел',NULL,2),(3,1,'1.3. Общий отдел',NULL,3),(4,1,'1.4. Отдел закупок',NULL,4),(76,1,'1.5. Отдел протокольного сопровождения',NULL,5),(77,1,'1.6. Управление административно-хозяйственной деятельности',NULL,6),(78,1,'1.6.1. Отдел ИТ',NULL,8),(79,1,'1.6.2. Управление административно-хозяйственной деятельности',NULL,11),(80,1,'1.7. Управление безопасности',NULL,12),(81,1,'1.8. Управление по обеспечению безопасности',NULL,13),(82,2,'2.1. Академия Умные дороги',NULL,14),(83,2,'2.2. Отдел сетевых программ',NULL,15),(84,2,'2.3. Проектно-аналитический отдел',NULL,16),(85,2,'2.4. Учебно-организационный отдел',NULL,17),(86,4,'4.1. Департамент коммуникаций',NULL,18),(87,4,'4.2. Управление по PR-проектам',NULL,19),(88,4,'4.2.1. Отдел по организации и сопровождению мероприятий',NULL,20),(89,4,'4.2.2. Отдел по работе с корпорациями',NULL,21),(90,4,'4.3. Управление Пресс-службы',NULL,22),(91,4,'4.3.1. Отдел по работе со СМИ',NULL,23),(92,4,'4.3.2. Отдел цифровых коммуникаций',NULL,24),(93,4,'4.3.3. Управление Пресс-службы',NULL,25),(94,5,'5.1. Департамент маркетинга и партнерских отношений',NULL,26),(95,5,'5.2. Управление маркетинга',NULL,27),(96,5,'5.2.1. Лицензионный отдел',NULL,28),(97,5,'5.2.2. Управление маркетинга',NULL,29),(98,5,'5.3. Управление по развитию бизнеса',NULL,30),(99,5,'5.3.1. Отдел по  привлечению новых клиентов',NULL,31),(100,5,'5.3.2. Отдел по организации мероприятий',NULL,32),(101,5,'5.4. Управление по развитию партнерских отношений',NULL,33),(102,9,'9.1. Аналитический отдел',NULL,34),(103,9,'9.2. Отдел проектного управления',NULL,35),(104,11,'11.1. Управление бухгалтерского и налогового учета',NULL,36),(105,11,'11.2. Управление казначейства',NULL,37),(106,11,'11.2.1. Операционный отдел',NULL,38),(107,11,'11.3. Финансово-экономический департамент',NULL,39),(108,11,'11.4. Финансово-экономическое управление',NULL,40),(109,12,'12.1. Управление нормативного обеспечения и договорной работы',NULL,41),(110,12,'12.2. Юридический департамент',NULL,42);
/*!40000 ALTER TABLE `departaments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Documents`
--

DROP TABLE IF EXISTS `Documents`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Documents` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) NOT NULL,
  `DateCreated` datetime DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Category` varchar(100) DEFAULT NULL,
  `HasComments` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Documents`
--

LOCK TABLES `Documents` WRITE;
/*!40000 ALTER TABLE `Documents` DISABLE KEYS */;
INSERT INTO `Documents` VALUES (3,'Политика безопасности','2025-03-03 00:00:00','2025-03-04 00:00:00','Корпоративные документы',1),(4,'Руководство пользователя','2024-12-30 00:00:00','2024-12-30 00:00:00','Техническая документация',0),(5,'План развития','2024-12-09 00:00:00','2024-12-09 00:00:00','Бизнес-план',1);
/*!40000 ALTER TABLE `Documents` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employees` (
  `id` int NOT NULL AUTO_INCREMENT,
  `positionid` int NOT NULL,
  `fullname` varchar(255) NOT NULL,
  `birthdate` date NOT NULL,
  `workphone` varchar(20) NOT NULL,
  `office` varchar(10) NOT NULL,
  `email` varchar(255) NOT NULL,
  `mobilephone` varchar(20) DEFAULT NULL,
  `directorid` int DEFAULT NULL,
  `assistantid` int DEFAULT NULL,
  `terminationdate` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `position_id_idx` (`positionid`),
  KEY `director_id_idx` (`directorid`),
  KEY `assistant_id_idx` (`assistantid`),
  CONSTRAINT `assistant_id` FOREIGN KEY (`assistantid`) REFERENCES `employees` (`id`),
  CONSTRAINT `director_id` FOREIGN KEY (`directorid`) REFERENCES `employees` (`id`),
  CONSTRAINT `position_id` FOREIGN KEY (`positionid`) REFERENCES `positions` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES (1,1,'Белоусов Семен Агафонович','1971-04-25','+7 (179) 370-26-88','402А','белоусов@гкдр.ру',NULL,NULL,NULL,NULL),(2,2,'Матвеев Вадим Юрьевич','1979-04-14','+7 (711) 977-16-52','402А','матвеев@гкдр.ру',NULL,NULL,NULL,NULL),(3,3,'Ермакова Юнона Руслановна','2002-12-22','+7 (210) 088-64-36','482','ермакова@гкдр.ру',NULL,NULL,NULL,NULL),(4,4,'Евсеева Генриетта Дмитриевна','1969-11-26','+7 (904) 027-35-92','482','евсеева@гкдр.ру','+7 (123) 456-78-90',NULL,NULL,NULL),(5,4,'Шарапова Дария Андреевна','1969-01-15','+7 (212) 625-28-08','482','шарапова@гкдр.ру',NULL,NULL,NULL,NULL),(6,5,'Кузьмина Галина Максовна','1990-04-12','+7 (370) 519-03-10','479','кузьмина@гкдр.ру',NULL,NULL,NULL,NULL),(8,7,'Гурьева Янина Тимофеевна','1964-12-29','+7 (401) 189-86-51','479','гурьева@гкдр.ру','',4,NULL,NULL),(11,10,'Большакова Снежана Тарасовна','1984-05-23','+7 (223) 503-67-44','479','большакова@гкдр.ру','+8 922 366 42 28',4,8,NULL),(12,17,'Миронова Диша Митрофановна','1977-12-15','+7 (084) 252-77-53','479','миронова@гкдр.ру',NULL,NULL,NULL,NULL),(13,18,'Жданова Виоланта Иосифовна','1996-05-13','+7 (900) 353-41-72','479','жданова@гкдр.ру',NULL,NULL,NULL,NULL),(14,19,'Колесников Анатолий Владленович','1990-02-26','+7 (438) 363-52-14','482','колесников@гкдр.ру',NULL,NULL,NULL,NULL),(15,20,'Мухин Флор Иванович','1975-10-31','+7 (487) 123-91-17','482','мухин@гкдр.ру',NULL,NULL,NULL,NULL),(16,21,'Воронова Устинья Митрофановна','1999-08-07','+7 (708) 393-49-39','483','воронова@гкдр.ру',NULL,NULL,NULL,NULL),(17,21,'Ковалёва Муза Тарасовна','1964-01-26','+7 (624) 457-34-25','483','ковалёва@гкдр.ру',NULL,NULL,NULL,NULL),(18,22,'Крылов Флор Максович','1996-10-07','+7 (902) 340-55-48','483','крылов@гкдр.ру',NULL,NULL,NULL,NULL),(19,23,'Зимин Илья Серапионович','1971-05-02','+7 (565) 435-79-80','483','исзимин@гкдр.ру',NULL,NULL,NULL,NULL),(20,24,'Зайцев Парамон Феликсович','1984-10-15','+7 (454) 252-05-25','525','зайцев@гкдр.ру',NULL,NULL,NULL,NULL),(21,24,'Маслов Модест Дамирович','1968-04-27','+7 (664) 602-03-71','525','маслов@гкдр.ру',NULL,NULL,NULL,NULL),(22,24,'Исаков Велорий Витальевич','1960-06-26','+7 (098) 359-34-95','525','исаков@гкдр.ру',NULL,NULL,NULL,NULL),(23,24,'Шашков Донат Владленович','1988-06-22','+7 (051) 523-43-73','525','шашков@гкдр.ру',NULL,NULL,NULL,NULL),(24,24,'Тарасов Эрнест Якунович','1998-06-22','+7 (131) 790-43-24','525','тарасов@гкдр.ру',NULL,NULL,NULL,NULL),(25,23,'Зимин Лев Евсеевич','1998-09-25','+7 (609) 728-78-87','525','лезимин@гкдр.ру',NULL,NULL,NULL,NULL),(26,23,'Суханов Эрнест Петрович','1966-04-23','+7 (342) 350-52-75','525','суханов@гкдр.ру',NULL,NULL,NULL,NULL),(27,23,'Харитонов Любомир Андреевич','2001-05-29','+7 (933) 010-23-01','525','харитонов@гкдр.ру',NULL,NULL,NULL,NULL),(28,23,'Евдокимов Павел Пётрович','1997-01-20','+7 (676) 507-65-30','525','евдокимов@гкдр.ру',NULL,NULL,NULL,NULL),(29,23,'Кулагин Аввакум Альбертович','1983-04-25','+7 (091) 411-45-67','489','кулагин@гкдр.ру',NULL,NULL,NULL,NULL),(30,23,'Рогов Май Филатович','1967-04-06','+7 (046) 142-05-62','489','рогов@гкдр.ру',NULL,NULL,NULL,NULL),(31,23,'Фролов Мартин Константинович','2002-08-07','+7 (604) 952-64-10','527','фролов@гкдр.ру',NULL,NULL,NULL,NULL),(32,23,'Копылов Власий Валентинович','2000-07-03','+7 (710) 970-74-65','527','копылов@гкдр.ру',NULL,NULL,NULL,NULL),(33,23,'Воронцов Мстислав Лаврентьевич','1968-04-08','+7 (154) 776-83-19','527','воронцов@гкдр.ру',NULL,NULL,NULL,NULL),(34,23,'Стрелков Аркадий Никитевич','1990-06-02','+7 (938) 736-81-71','527','стрелков@гкдр.ру',NULL,NULL,NULL,NULL),(35,23,'Кононов Август Германнович','1968-04-29','+7 (812) 849-39-84','527','кононов@гкдр.ру',NULL,NULL,NULL,NULL),(36,23,'Горбачёв Глеб Мэлсович','1974-11-07','+7 (626) 861-82-67','527','горбачёв@гкдр.ру',NULL,NULL,NULL,NULL),(37,23,'Беляев Тарас Владленович','2001-07-15','+7 (909) 176-65-42','527','беляев@гкдр.ру',NULL,NULL,NULL,NULL),(38,23,'Селезнёва Мэри Фроловна','2002-12-22','+7 (956) 710-49-22','477','селезнёва@гкдр.ру',NULL,NULL,NULL,NULL),(39,23,'Филиппова Аза Николаевна','1989-05-23','+7 (163) 312-43-14','477','филиппова@гкдр.ру',NULL,NULL,NULL,NULL),(40,23,'Галкина Эрика Лукьяновна','1969-11-26','+7 (567) 060-46-69','404','галкина@гкдр.ру',NULL,NULL,NULL,NULL),(41,23,'Лихачёва Динара Георгьевна','1990-04-16','+7 (624) 064-06-24','404','лихачёва@гкдр.ру',NULL,NULL,NULL,NULL),(42,23,'Лобанова Дебора Владимировна','1970-06-25','+7 (318) 827-54-60','404','лобанова@гкдр.ру',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `events`
--

DROP TABLE IF EXISTS `events`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `events` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `date` datetime NOT NULL,
  `authorId` int NOT NULL,
  `description` varchar(255) NOT NULL,
  `typeId` int NOT NULL,
  `statusId` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `eventTypeFK_idx` (`typeId`),
  KEY `EventStatusFK_idx` (`statusId`),
  KEY `AuthorIdFK_idx` (`authorId`),
  CONSTRAINT `AuthorIdFK` FOREIGN KEY (`authorId`) REFERENCES `employees` (`id`),
  CONSTRAINT `EventStatusFK` FOREIGN KEY (`statusId`) REFERENCES `eventStatuses` (`id`),
  CONSTRAINT `EventTypeFK` FOREIGN KEY (`typeId`) REFERENCES `eventTypes` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `events`
--

LOCK TABLES `events` WRITE;
/*!40000 ALTER TABLE `events` DISABLE KEYS */;
INSERT INTO `events` VALUES (1,'С Новым 2025 Годом!','2025-01-02 00:00:00',1,'С Новым 2025 Годом!',3,4),(2,'Открытие нового корпуса \"Дороги России\"','2025-01-09 00:00:00',2,'Открытие нового корпуса \"Дороги России\".',2,4);
/*!40000 ALTER TABLE `events` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventStatuses`
--

DROP TABLE IF EXISTS `eventStatuses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `eventStatuses` (
  `id` int NOT NULL AUTO_INCREMENT,
  `status_name` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventStatuses`
--

LOCK TABLES `eventStatuses` WRITE;
/*!40000 ALTER TABLE `eventStatuses` DISABLE KEYS */;
INSERT INTO `eventStatuses` VALUES (1,'Запланировано'),(2,'Подтверждено'),(3,'В процессе'),(4,'Завершено'),(5,'Отменено');
/*!40000 ALTER TABLE `eventStatuses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventTypes`
--

DROP TABLE IF EXISTS `eventTypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `eventTypes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventTypes`
--

LOCK TABLES `eventTypes` WRITE;
/*!40000 ALTER TABLE `eventTypes` DISABLE KEYS */;
INSERT INTO `eventTypes` VALUES (1,'Обучение','Мероприятия по обучению сотрудников'),(2,'Совещание','Рабочие совещания'),(3,'Отпуск','Периоды отпусков сотрудников'),(4,'Командировка','Служебные командировки'),(5,'Больничный','Периоды временной нетрудоспособности'),(6,'Отгул','Дни отгулов сотрудников');
/*!40000 ALTER TABLE `eventTypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `materials`
--

DROP TABLE IF EXISTS `materials`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `materials` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `approvaldate` date DEFAULT NULL,
  `modificationdate` date DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  `type` varchar(50) DEFAULT NULL,
  `area` varchar(255) DEFAULT NULL,
  `authorid` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `authorid` (`authorid`),
  CONSTRAINT `materials_ibfk_1` FOREIGN KEY (`authorid`) REFERENCES `employees` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materials`
--

LOCK TABLES `materials` WRITE;
/*!40000 ALTER TABLE `materials` DISABLE KEYS */;
INSERT INTO `materials` VALUES (1,'Материалы по управлению персоналом','2025-02-02',NULL,'Ок','Тест','Область 1',1),(2,'Информационные технологии','2025-03-13',NULL,'Ок','Тест','Область 2',2),(3,'Финансовая отчетность и аналитика','2025-04-15',NULL,'Ок','Тест','Область 3',3);
/*!40000 ALTER TABLE `materials` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `news`
--

DROP TABLE IF EXISTS `news`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `news` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `date` datetime NOT NULL,
  `description` varchar(255) NOT NULL,
  `image` varchar(255) DEFAULT NULL,
  `likes` int DEFAULT '0',
  `dislikes` int DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `news`
--

LOCK TABLES `news` WRITE;
/*!40000 ALTER TABLE `news` DISABLE KEYS */;
INSERT INTO `news` VALUES (1,'Водители на трассе М-12 сыграли \"Полет шмеля\"','2024-04-05 00:00:00','Они ехали-ехали и сыграли! Они ехали-ехали и сыграли! Они ехали-ехали и сыграли!','https://s0.rbk.ru/v6_top_pics/media/img/8/35/346939900523358.jpeg',2,0),(2,'С Днем Святого Валентина!','2025-02-14 00:00:00','Test Test Test TestTest TestTest TestTest Test','https://img.razrisyika.ru/kart/66/1200/262390-den-svyatogo-valentina-3.jpg',1,0);
/*!40000 ALTER TABLE `news` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `organizations`
--

DROP TABLE IF EXISTS `organizations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `organizations` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `organizations`
--

LOCK TABLES `organizations` WRITE;
/*!40000 ALTER TABLE `organizations` DISABLE KEYS */;
INSERT INTO `organizations` VALUES (1,'1. Административный департамент'),(2,'2. Академия Умные дороги'),(3,'3. Аппарат управления'),(4,'4. Департамент коммуникаций'),(5,'5. Департамент маркетинга и партнерских отношений'),(6,'6. Департамент по организации корпоративов'),(7,'7. Департамент по работе с персоналом'),(8,'8. Департамент по работе с промышленностью'),(9,'9. Департамент стратегии и планирования'),(10,'10. Управление Финансового планирования и контроля'),(11,'11. Финансово-экономический департамент'),(12,'12. Юридический департамент');
/*!40000 ALTER TABLE `organizations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `positions`
--

DROP TABLE IF EXISTS `positions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `positions` (
  `id` int NOT NULL AUTO_INCREMENT,
  `departamentid` int NOT NULL,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `departament_id_idx` (`departamentid`),
  CONSTRAINT `departament_id` FOREIGN KEY (`departamentid`) REFERENCES `departaments` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `positions`
--

LOCK TABLES `positions` WRITE;
/*!40000 ALTER TABLE `positions` DISABLE KEYS */;
INSERT INTO `positions` VALUES (1,1,'Административный директор-руководитель аппарата'),(2,1,'Руководитель контрольно-ревизионного направления'),(3,2,'Начальник отдела'),(4,2,'Старший специалист'),(5,3,'Начальник отдела'),(6,3,'Руководитель проекта'),(7,3,'Специалист'),(10,3,'Старший специалист'),(17,4,'Начальник отдела'),(18,4,'Старший специалист'),(19,76,'Менеджер проектов'),(20,76,'Начальник отдела'),(21,77,'Начальник отдела'),(22,77,'Старший специалист'),(23,78,'Ведущий специалист'),(24,78,'Водитель');
/*!40000 ALTER TABLE `positions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Password` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` VALUES (1,'alex','Asdfg123'),(2,'admin','admin');
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `WorkingCalendar`
--

DROP TABLE IF EXISTS `WorkingCalendar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `WorkingCalendar` (
  `Id` int NOT NULL COMMENT 'Идентификатор строки',
  `ExceptionDate` date NOT NULL COMMENT 'День-исключение',
  `IsWorkingDay` tinyint(1) NOT NULL COMMENT '0 - будний день, но законодательно принят выходным; 1 - сб или вс, но является рабочим',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Список дней исключений в производственном календаре';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `WorkingCalendar`
--

LOCK TABLES `WorkingCalendar` WRITE;
/*!40000 ALTER TABLE `WorkingCalendar` DISABLE KEYS */;
INSERT INTO `WorkingCalendar` VALUES (1,'2024-01-01',0),(2,'2024-01-02',0),(3,'2024-01-03',0),(4,'2024-01-04',0),(5,'2024-01-05',0),(6,'2024-01-08',0),(7,'2024-02-23',0),(8,'2024-03-08',0),(9,'2024-04-27',1),(10,'2024-04-29',0),(11,'2024-04-30',0),(12,'2024-05-01',0),(13,'2024-05-09',0),(14,'2024-05-10',0),(15,'2024-06-12',0),(16,'2024-11-02',1),(17,'2024-11-04',0),(18,'2024-12-28',1),(19,'2024-12-30',0),(20,'2024-12-31',0);
/*!40000 ALTER TABLE `WorkingCalendar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'testapi'
--

--
-- Dumping routines for database 'testapi'
--
/*!50003 DROP PROCEDURE IF EXISTS `DeleteEmployee` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `DeleteEmployee`()
BEGIN
	DELETE FROM employees
    WHERE terminationdate IS NOT NULL
    AND terminationdate <= DATE_SUB(curdate(), INTERVAL 30 DAY);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetHistory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `GetHistory`(IN `IdPartner` INT)
BEGIN
    SELECT 
    p.Name, p.Article
    from Products p
    JOIN PartnerProducts pp on pp.Products = p.Id
    WHERE pp.Partners = IdPartner;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `TerminateEmployee` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `TerminateEmployee`(IN employeeId INT)
BEGIN
	IF (SELECT COUNT(*) FROM absences WHERE employeeid = employeeId AND paid = TRUE AND enddate >= CURDATE()) > 0
		THEN SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Ошибка: Сотрудник не может быть уволен, так как у него есть оплаченные обучения!';
	END IF;
    
    DELETE FROM absences WHERE absences.employeeid = employeeId AND startdate > CURDATE();
    
    UPDATE employees set terminationdate = CURDATE() WHERE id = employeeId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-13 23:58:29
