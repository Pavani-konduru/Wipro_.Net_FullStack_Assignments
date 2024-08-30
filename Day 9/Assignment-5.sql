create database Library_System;
Go
Use Library_System;
Go
create table Authors(
AuthorId int primary key identity(1,1),
FirstName varchar(255) not null,
LastName varchar(255) not null,
DateofBirth Date null,
Nationality varchar(50) null,
Constraint AuthorName unique (FirstName, LastName)
);

Create table Books(
BookId int Primary Key identity(1,1),
title varchar(100) not null,
PublishedYear date not null,
AuthorId int not null,
Constraint Books_Authors FOREIGN KEY (AuthorId) REFERENCES Authors(AuthorId)
);

create table patrons(
PatronId int identity(1,1),
FirstName varchar(50) not null,
LastName varchar(50) not null,
Email varchar(100) unique not null,
PhoneNumber varchar(15) null,
primary key(PatronId),
Constraint EmailFormat check (Email Like '%@%.%')
);

create table Loans(
LaonId int Primary key identity(1,1),
BookId int not null,
PatronId int not null,
LoanDate Date not null,
ReturnDate Date null
Constraint Loans_Books FOREIGN KEY (BookId) REFERENCES Books(BookId),
constraint Loan_Patrons FOREIGN KEY (PatronId) REFERENCES Patrons(PatronId)
);

Create table Categories(
CategoryId int Primary key Identity(1,1),
categoryName varchar(50) unique not null,
constraint CategoryName Check (categoryName <> '')
);

Create table BookCategories(
BookId int not null,
CategoryId int not null,
PRIMARY KEY (BookId, CategoryId),
CONSTRAINT BookCategories_Books FOREIGN KEY (BookId) REFERENCES Books(BookId),
Constraint BookCategories_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);
create table bookShell(ShellId int not null);

Alter Table Books
ADD BookCondition varchar(100) null;
go

Alter Table Patrons
Alter column PhoneNumber varchar(20) null;
go

alter table loans 
drop constraint Loans_Books;
go

Drop table bookShell;
GO




