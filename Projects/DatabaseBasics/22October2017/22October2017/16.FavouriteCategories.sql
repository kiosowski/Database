SELECT
 Department,
 Category,
 Percentage
 FROM(
 SELECT d.Name AS Department,
		c.Name AS Category,
		CAST(
		ROUND(
		COUNT(*)
		OVER(PARTITION BY c.Id) * 100.00/
		COUNT(*)
		OVER(PARTITION BY d.Id),
		0
		) AS INT
		) AS Percentage
		FROM Departments AS d
		JOIN Categories c
		ON d.Id = c.DepartmentId
		JOIN Reports AS r
		ON c.Id = r.CategoryId
		) AS Stats
GROUP BY Department,Category,Percentage
ORDER BY Department,Category,Percentage
