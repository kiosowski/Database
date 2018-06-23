SELECT
e.FirstName + ' ' + e.LastName AS [Name],
ISNULL(convert(VARCHAR,CloseSum.Sum),0) + '/' +
ISNULL(convert(VARCHAR,OpenSum.Sum),0)
FROM Employees AS e
JOIN(SELECT
		EmployeeId,
		COUNT(*) AS [Sum]
		FROM Reports
		WHERE YEAR(OpenDate) = '2016'
		GROUP BY EmployeeId) AS OpenSum
		ON e.Id = OpenSum.EmployeeId
		LEFT JOIN(SELECT
					EmployeeId,
					COUNT(*) AS [Sum]
					FROM Reports
					WHERE YEAR(CloseDate) = '2016'
					GROUP BY EmployeeId) AS CloseSum
					ON e.Id = CloseSum.EmployeeId
					ORDER BY Name