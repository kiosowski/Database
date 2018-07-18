SELECT
c.Name AS [City],
COUNT(h.Id) AS [Hotels]
FROM Hotels AS h
RIGHT JOIN Cities AS c
ON c.Id = h.CityId
GROUP BY c.Name
ORDER BY Hotels DESC, c.Name