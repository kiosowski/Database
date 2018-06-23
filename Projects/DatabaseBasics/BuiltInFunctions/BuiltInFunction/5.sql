SELECT [Name]
FROM Towns 
WHERE Len([Name]) IN(5,6)
ORDER BY [Name]