SELECT 
a.Id,a.Email,c.CountryCode, COUNT(t.Id) AS [Trips]
FROM AccountsTrips AS at
JOIN Accounts AS a
ON at.AccountId = a.Id
JOIN Cities AS c
ON a.CityId = c.Id
JOIN Hotels AS h
ON h.CityId = c.Id
JOIN Rooms AS r
ON h.Id = r.HotelId
JOIN Trips AS t
ON a.CityId = h.CityId
WHERE at.TripId = t.Id
GROUP BY a.Id,a.Email,c.CountryCode
ORDER BY  Trips DESC, a.Id
