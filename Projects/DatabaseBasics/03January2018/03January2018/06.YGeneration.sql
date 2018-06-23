SELECT 
	FirstName,
	LastName
FROM Clients
WHERE BirthDate BETWEEN '1977' AND '1995'
ORDER BY FirstName,LastName,Id