WITH CTE_MaxModel (ModelId,Name,MaxCount) AS
(
	SELECT
	modelsCount.ModelId,
	modelsCount.Name,
	Count
	FROM (
	SELECT
	m.ModelId,
	m.Name,
	COUNT(j.JobId) AS [Count]
	FROM Jobs AS j
	JOIN Models AS m
	ON j.ModelId = m.ModelId
	GROUP BY m.ModelId, m.Name
	) AS modelsCount
WHERE modelsCount.Count = (SELECT TOP(1) count(j.JobId) AS [Count]
								FROM Jobs AS j
								JOIN Models AS m
								ON j.ModelId = m.ModelId
								GROUP BY m.ModelId
								ORDER BY Count DESC))
SELECT
maxModel.Name AS [Model],
maxModel.MaxCount AS [Times Serviced],
ISNULL(SUM(p.Price * part.Quantity),0) AS [Parts Total]
FROM CTE_MaxModel AS maxModel
LEFT JOIN Jobs j
ON j.ModelId = maxModel.ModelId
LEFT JOIN Orders o
ON j.JobId = o.JobId
LEFT JOIN OrderParts AS part
ON o.OrderId = part.OrderId
LEFT JOIN Parts AS p
ON part.PartId = p.PartId
GROUP BY maxModel.Name,Maxmodel.MaxCount