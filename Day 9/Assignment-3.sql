create table course(
CourseId smallint not null, 
CourseName varchar(255) not null
);
begin transaction courseadd;
declare @custid smallint
select @custid = MAX(courseid)+1
from course

insert into course(CourseId, CourseName)
values ( 1080,'Biology');
BEGIN TRANSACTION;
ROLLBACK TRANSACTION;
SELECT * FROM COURSE;

BEGIN TRANSACTION;
INSERT INTO course VALUES(1,'BBB');
INSERT INTO course VALUES(2,'C');
INSERT INTO course VALUES(3,'DD');
COMMIT TRANSACTION;

BEGIN TRANSACTION;
Update course 
set CourseName ='Maths'
where CourseId = 2;

BEGIN TRANSACTION;
ROLLBACK TRANSACTION;
SELECT * FROM COURSE;






