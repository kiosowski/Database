SELECT DepartmentID, MIN(Salary) AS MinimumSalary FROM Employees
WHERE DepartmentId IN (2,5,7)
AND HireDate > '01/01/2000'
GROUP BY DepartmentId