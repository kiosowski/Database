SELECT DISTINCT u.Username
FROM Users AS u
JOIN Reports AS r
ON u.Id = r.UserId
JOIN Categories AS c
ON r.CategoryId = c.Id
WHERE (Username LIKE '[0-9]%' AND CAST(c.Id AS VARCHAR) = LEFT(u.Username,1)) OR
(Username LIKE '%[0-9]' AND CAST(c.Id AS VARCHAR) = RIGHT(u.Username,1))
ORDER BY u.Username ASC