create table Marks(
Student_id int primary key not null,
name varchar (50),
branch varchar(100),
marks int);

insert into Marks(Student_id, name, branch, marks)
values(1001, 'NITISH', 'EEE',82),
(1002, 'RISHABH','EEE',91),
(1003, 'ANIKANT', 'EEE', 89),
(1004, 'RUPESH', 'EEE', 78),
(1005, 'SHUBHAM', 'CSE', 77),
(1006, 'VEDHAL','CSE',43),
(1007, 'DEEPAK','ECE',95),
(1008,'ARPAN','ECE',87),
(1009,'VINAY','ECE',76),
(1010, 'ROHITH','MECH',67),
(1011,'PRASHANTH','MECH',69),
(1012,'AMITH','MECH',89),
(1013,'SUNNY','MECH',78);

SELECT * FROM MARKS;

SELECT branch, AVG(marks) AS "AVERAGE OF MARKS BRANCH WISE"
FROM MARKS
GROUP BY BRANCH;

SELECT *, MIN(MARKS) OVER(PARTITION BY BRANCH) AS "MIN OF MARKS"
FROM MARKS;

select *, avg (marks) over(partition by branch) as "Average Marks",
min(marks) over (partition by branch) as "Minimum Marks",
max(marks) over() AS "Maxmimum Marks",
SUM(MARKS) OVER (PARTITION BY BRANCH) AS "SUM OF MARKS"
from marks ORDER BY MARKS;
 
 ------print the details who are getting more than avg marks
SELECT name ,AVG(marks) over (partition by branch ) as "branch_avg"
from marks;

SELECT *
FROM (SELECT * ,AVG(marks) over (partition by branch ) as "branch_avg"
		from marks) t
where t.marks>t.branch_avg;

select *, DENSE_RANK() OVER(PARTITION BY branch order by marks desc) AS "BRANCH_WISE_RANKING"
FROM MARKS;

INSERT INTO MARKS VALUES(1014,'NITHA','EEE',89);

SELECT *,
LAST_VALUE(MARKS) OVER (ORDER BY MARKS DESC) as " marks from last in desc order"
FROM MARKS;








