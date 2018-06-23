SELECT *
INTO NewTable
FROM Employees
WHERE Salary > 30000

DELETE FROM NewTable
WHERE ManagerId = 42

UPDATE NewTable
SET Salary+=5000
WHERE DepartmentId = 1

SELECT DepartmentId, AVG(Salary) AS AverageSalary FROM NewTable
GROUP BY DepartmentId