SELECT ISNULL(SUM(p.Price * part.Quantity),0) AS [PartsTotal]
FROM Orders AS o
JOIN OrderParts AS part
ON o.OrderId = part.OrderId
JOIN Parts AS p 
ON part.PartId = p.PartId
WHERE o.IssueDate > (DATEADD(WEEK, -3,'2017/04/24'))