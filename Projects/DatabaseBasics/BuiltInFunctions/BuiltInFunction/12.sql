SELECT TOP(50) [Name],FORMAT([Start],'yyyy-MM-dd') AS [Start] From Games
WHERE DATEPART(YEAR,[Start]) IN (2011,2012)
ORDER BY [Start],[Name]