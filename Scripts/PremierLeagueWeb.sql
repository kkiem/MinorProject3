-- Drop the database if you created an earlier version
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'PremierLeagueWeb')
BEGIN
    ALTER DATABASE PremierLeagueWeb SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE PremierLeagueWeb;
END
GO

CREATE DATABASE PremierLeagueWeb;
GO

USE PremierLeagueWeb;
GO

-- 1. Create Tables
CREATE TABLE Club (
    ClubID INT IDENTITY(1,1) PRIMARY KEY,
    ClubName NVARCHAR(100) NOT NULL,
    City NVARCHAR(100),
    Stadium NVARCHAR(100)
);

CREATE TABLE Manager (
    ManagerID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    TacticalStyle NVARCHAR(50),
    ClubID INT FOREIGN KEY REFERENCES Club(ClubID) NULL
);

CREATE TABLE Player (
    PlayerID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Position NVARCHAR(50),
    ClubID INT FOREIGN KEY REFERENCES Club(ClubID) NULL
);

-- 2. Insert Data
INSERT INTO Club (ClubName, City, Stadium) VALUES 
('Arsenal', 'London', 'Emirates Stadium'),
('Manchester City', 'Manchester', 'Etihad Stadium'),
('Liverpool', 'Liverpool', 'Anfield'),
('Chelsea', 'London', 'Stamford Bridge'),
('Manchester United', 'Manchester', 'Old Trafford');

INSERT INTO Manager (FirstName, LastName, TacticalStyle, ClubID) VALUES 
('Mikel', 'Arteta', 'Possession', 1),
('Enzo', 'Maresca', 'Possession', 2),
('Andoni', 'Iraola', 'Gegenpressing', 3),
('Xabi', 'Alonso', 'Positional Play', 4),
('Ruben', 'Amorim', 'Back Three', 5);

INSERT INTO Player (FirstName, LastName, Position, ClubID) VALUES 
-- Arsenal
('Bukayo', 'Saka', 'Forward', 1),
('Martin', 'Odegaard', 'Midfielder', 1),
('William', 'Saliba', 'Defender', 1),
('Bruno', 'Guimaraes', 'Midfielder', 1),
('Gabriel', 'Magalhaes', 'Defender', 1),
('Christos', 'Tzolis', 'Forward', 1),

-- Manchester City
('Erling', 'Haaland', 'Forward', 2),
('Phil', 'Foden', 'Midfielder', 2),
('Josko', 'Gvardiol', 'Defender', 2),
('Enzo', 'Fernandez', 'Midfielder', 2),
('Elliot', 'Anderson', 'Midfielder', 2),
('Rayan', 'Cherki', 'Midfielder', 2),

-- Liverpool
('Ronald', 'Araujo', 'Defender', 3),
('Jeremy', 'Jaquet', 'Defender', 3),
('Florian', 'Wirtz', 'Midfielder', 3),
('Alexander', 'Isak', 'Forward', 3),
('Bradley', 'Barcola', 'Forward', 3),
('Victor', 'Munoz', 'Midfielder', 3),

-- Chelsea
('Cole', 'Palmer', 'Midfielder', 4),
('Moises', 'Caicedo', 'Midfielder', 4),
('Morgan', 'Rogers', 'Midfielder', 4),
('Joao', 'Pedro', 'Forward', 4),
('Estevao', 'Willian', 'Forward', 4),
('Reece', 'James', 'Defender', 4),

-- Manchester United
('Bruno', 'Fernandes', 'Midfielder', 5),
('Kobbie', 'Mainoo', 'Midfielder', 5),
('Alejandro', 'Garnacho', 'Forward', 5),
('Leny', 'Yoro', 'Defender', 5),
('Amad', 'Diallo', 'Forward', 5),
('Matheus', 'Cunha', 'Forward', 5);