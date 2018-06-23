SELECT
m.ModelId AS [ModelId],
m.Name AS [Name],
CAST(AVG(DATEDIFF(DAY,j.IssueDate,j.FinishDate)) AS VARCHAR(5)) + ' days' AS [Average Service Time]
FROM Jobs AS j
JOIN Models AS m
ON j.ModelId = m.ModelId
WHERE j.Status = 'Finished'
GROUP BY m.Name,m.ModelId
ORDER BY AVG(DATEDIFF(DAY,j.IssueDate,j.FinishDate))