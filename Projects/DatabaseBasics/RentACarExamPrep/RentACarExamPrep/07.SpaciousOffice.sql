SELECT t.Name AS [TownName],o.Name AS [OfficeName],o.ParkingPlaces AS [ParkingPlaces]
FROM Towns AS t
JOIN Offices AS o
ON t.Id = o.TownId
WHERE ParkingPlaces > 25
ORDER BY t.Name ASC, o.Id ASC
