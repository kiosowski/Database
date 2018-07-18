SELECT rtrim(concat(FirstName + ' ', MiddleName + ' ', LastName + ' ')) AS [Full Name],
DATEPART(YEAR,BirthDate) AS BirthYear
FROM Accounts
WHERE BirthDate > '1992'
ORDER BY BirthYear DESC, FirstName ASC

