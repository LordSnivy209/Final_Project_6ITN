-- drop schema if exists databasenotities;
create schema if not exists DatabaseNotities;
use DatabaseNotities;

create table if not exists organisation
(
orgID int not null auto_increment,
orgName varchar(50) not null,
orgPassword varchar(40) not null,
primary key(orgID)
);
create table if not exists gebruiker
(
userID int not null auto_increment,
orgID int not null,
username varchar(50) not null,
passwordUser varchar(40) not null,
primary key(userID),
foreign key(orgID) references organisation(orgID)
);

create table if not exists notitie
(
noteID int not null auto_increment,
userID int not null,
title varchar(120) not null,
content text,
creationDate date not null,
primary key(noteID),
foreign key(userID) references gebruiker(userID)
);

select organisation.*, gebruiker.username, gebruiker.passwordUser, notitie.noteID, notitie.title, notitie.content, notitie.creationDate from databasenotities.gebruiker
inner join databasenotities.organisation on gebruiker.orgID = organisation.orgID
inner join databasenotities.notitie on gebruiker.userID = notitie.userID;


-- INSERT INTO `databasenotities`.`gebruiker` (`orgID`, `username`, `passwordUser`) VALUES ('2', 'Luka', '1234');

-- toevoegen van een gebruiker bij een bedrijf
-- "INSERT INTO databasenotities.gebruiker (orgID, username, passwordUser) VALUES (@orgID, @username, @password)" 

-- INSERT INTO `databasenotities`.`organisation` (`userID`, `orgName`, `orgPassword`) VALUES ('1', 'Pidpa', '1234');

-- toevoegen van notities bij een gebruiker
-- INSERT INTO `databasenotities`.`notitie` (`userID`, `title`, `content`, `creationDate`) VALUES ('1', 'baap', 'beep beep', curdate());
-- "INSERT INTO databasenotities.notitie(userID, title, content, creationDate) VALUES (@userID, @title, @content, curdate())"
-- updaten van de notitie
-- "update databasenotities.notitie set content = @content where userID = @userID"
-- updaten van de titel
-- "update databasenototies.notitie set title = @title where userID = @userID"




