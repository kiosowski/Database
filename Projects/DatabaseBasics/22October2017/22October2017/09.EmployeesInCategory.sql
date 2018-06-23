SELECT 
	c.Name AS [CategoryName],
	COUNT(e.Id) AS [Employees Number]
FROM Categories AS c
JOIN Departments AS d
ON c.DepartmentId = d.Id
JOIN Employees AS e
ON d.Id = e.DepartmentId
GROUP BY c.Name
ORDER BY CategoryName