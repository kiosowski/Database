SELECT
a.Id AS [AccountId],
a.FirstName + ' ' + a.LastName AS [FullName],
MAX(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) AS [LongestTrip],
MIN(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) AS [ShortestTrip]
FROM Accounts AS a
JOIN AccountsTrips AS at
ON at.AccountId = a.Id
JOIN Trips AS t
ON t.Id = at.AccountId
WHERE t.CancelDate IS NULL AND a.MiddleName IS NULL
GROUP BY a.Id,a.FirstName,a.LastName,at.AccountId
ORDER BY LongestTrip DESC, at.AccountId
