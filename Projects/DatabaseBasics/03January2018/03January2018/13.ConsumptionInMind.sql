SELECT
	m.Manufacturer AS [Manufacturer],
	AVG(m.Consumption) AS [AverageConsumption]
FROM 
 (SELECT TOP 7
	m.Id,
	COUNT(o.VehicleId) AS [OrdersCount]
 FROM Orders AS o
 JOIN Vehicles AS v
 ON o.VehicleId = v.Id
 JOIN Models AS m
 ON v.ModelId = m.Id
 GROUP BY m.Id
 ORDER BY COUNT(o.VehicleId) DESC
 ) AS mostOrdered
 JOIN Models m
 on m.Id = mostOrdered.Id
 GROUP BY m.Manufacturer
 HAVING AVG(m.Consumption) BETWEEN 5 AND 15