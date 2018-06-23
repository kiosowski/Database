WITH CTE_C(ReturnOfficeId,OfficeId,VehicleId,Manufacturer,Model)
AS
(
	SELECT
	w.ReturnOfficeId,
	w.OfficeId,
	w.Id,
	w.Manufacturer,
	w.Model
	FROM (
	SELECT
	DENSE_RANK()
	OVER(PARTITION BY v.Id
	ORDER BY O.CollectionDate DESC) AS [RANK],
	o.ReturnOfficeId,
	v.OfficeId,
	v.Id,
	m.Manufacturer,
	m.Model
	FROM Models AS m
	JOIN Vehicles AS v
	ON m.Id = v.ModelId
	LEFT JOIN Orders AS O
	ON o.VehicleId = v.Id) AS w
	WHERE w.Rank = 1
	)

SELECT 
CONCAT(C.Manufacturer, ' - ',C.Model) AS [Vehicle],
CASE 
WHEN (SELECT COUNT(*)
	FROM Orders
	WHERE VehicleId = C.VehicleId) = 0 OR C.OfficeId = C.ReturnOfficeId
	THEN 'home'
	WHEN C.ReturnOfficeId IS NULL
	THEN 'on a rent'
	WHEN C.OfficeId <> C.ReturnOfficeId
	THEN (Select CONCAT([To].Name, ' - ', [Of].Name)
	FROM Offices AS [Of]
	JOIN Towns AS [To]
	On [To].Id = [Of].TownId
	WHERE c.ReturnOfficeId = [Of].Id)
	END		AS [Location]
	FROM CTE_C as C
	ORDER BY Vehicle,c.VehicleId