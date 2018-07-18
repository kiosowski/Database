SELECT 
	m.Model AS [Model],
	m.Seats AS [Seats],
	v.Mileage AS [Mileage]
FROM Vehicles AS v
JOIN Models AS m
ON v.ModelId = m.Id
WHERE v.Id NOT IN (
	SELECT VehicleId
	FROM Orders
	WHERE ReturnDate IS NULL
	)
ORDER BY v.Mileage,m.Seats DESC,m.Id