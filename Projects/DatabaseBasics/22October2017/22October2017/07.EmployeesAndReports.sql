SELECT e.FirstName,e.LastName,r.Description,FORMAT(r.OpenDate,'yyyy-MM-dd') AS [OpenDate]
FROM Employees AS e
JOIN Reports AS r
ON r.EmployeeId = e.Id
WHERE r.EmployeeId IS NOT NULL
ORDER BY r.EmployeeId ASC, r.OpenDate ASC, r.Id ASC
