SELECT
t.Id,h.Name AS [HotelName],r.Type AS [RoomType], SUM(h.BaseRate + r.Price) AS [Revenue]
FROM Hotels AS h
JOIN Rooms AS r
ON h.Id = r.HotelId
JOIN Trips AS t
ON r.Id = t.RoomId
WHERE t.CancelDate IS NOT NULL
GROUP BY t.Id,h.Name,r.Type,t.CancelDate
ORDER BY [RoomType],t.Id