Select TOP (5) e.EmployeeID, e.JobTitle,a.AddressID AS [AddressId],a.AddressText
FROM Employees AS e
JOIN Addresses as a ON e.AddressID = a.AddressID
JOIN Towns as t ON a.TownID = t.TownID
ORDER BY a.AddressID 