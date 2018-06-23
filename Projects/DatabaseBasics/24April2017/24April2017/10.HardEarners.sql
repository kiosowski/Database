SELECT TOP(3)
m.FirstName + ' ' + m.LastName AS [Mechanic],
COUNT(*) AS[Jobs]
FROM Mechanics AS m
JOIN Jobs AS j
ON m.MechanicId = j.MechanicId
GROUP BY m.FirstName + ' ' + m.LastName, j.Status,j.MechanicId
HAVING j.Status <> 'Finished' AND COUNT(*) > 1
ORDER BY Jobs DESC, j.MechanicId ASC