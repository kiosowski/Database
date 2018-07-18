SELECT TOP(10)
c.Id, c.Name, SUM(h.BaseRate + r.Price) AS [Total Revenue], COUNT(t.Id) AS [Trips]
FROM Cities AS c
JOIN Hotels AS h
ON c.Id = h.CityId
JOIN Rooms AS r
ON h.Id = r.HotelId
JOIN Trips AS t
ON r.Id = t.RoomId
WHERE YEAR(t.BookDate) = '2016'
GROUP BY c.Id,c.Name
ORDER BY [Total Revenue] DESC, [Trips] DESC

