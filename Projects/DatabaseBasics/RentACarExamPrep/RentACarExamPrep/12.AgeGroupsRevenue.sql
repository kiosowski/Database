SELECT
	CASE
	WHEN c.BirthDate BETWEEN '1970' AND '1980'
	THEN '70''s'
	WHEN c.BirthDate BETWEEN '1980' AND '1990'
	THEN '80''s'
	WHEN c.BirthDate BETWEEN '1990 AND '200
FROM Clients AS c
	LEFT JOIN Orders AS o
	ON c.Id = o.ClientId
	JOIN Vehicles AS v
	ON o.VehicleId = v.Id
GROUP BY