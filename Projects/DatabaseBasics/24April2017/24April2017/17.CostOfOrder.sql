CREATE FUNCTION udf_GetCost(@jobsId INT)
RETURNS DECIMAL(8,2)
AS
	BEGIN
		DECLARE @totalCost DECIMAL(8,2) = (SELECT ISNULL(sum(p.Price * part.Quantity),0)
										  FROM Jobs AS j
										  JOIN Orders AS o
										  ON j.JobId = o.JobId
										  JOIN OrderParts AS part
										  ON o.OrderId = part.OrderId
										  JOIN Parts AS p
										  ON part.PartId = p.PartId
										  WHERE j.JobId = @jobsId)
		RETURN @totalCost
		END