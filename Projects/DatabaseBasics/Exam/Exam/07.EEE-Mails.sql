SELECT
a.FirstName,a.LastName,FORMAT(a.BirthDate,'MM-dd-yyyy') AS [BirthDate], c.Name AS [HomeTown],Email
FROM Accounts AS a
JOIN Cities AS c
ON a.CityId = c.Id
WHERE LEFT(Email,1) = 'e'
ORDER BY c.Name DESC