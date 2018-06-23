SELECT c.FirstName + ' ' + c.LastName AS Client,
		DATEDIFF(DAY,j.IssueDate,'04/24/2017') AS [Days going],
		j.Status AS Status
FROM Clients AS c
JOIN Jobs AS j
ON j.ClientId = c.ClientId
WHERE Status <> 'Finished' 
ORDER BY [Days going] DESC, c.ClientId ASC