SELECT t.Name,mp.MelaPercent,fp.FemalePercent
FROM Towns AS t
LEFT JOIN (SELECT
	t.Id,
	(COUNT(*) * 100)/tc.TotalCount AS [MelaPercent]
	FROM Clients AS c
	JOIN Orders AS o
	ON c.Id = o.ClientId
	FULL JOIN Towns AS t
	ON o.TownId = t.Id
	JOIN(
	SELECT
	t.Name AS[TownName],
	COUNT(*) AS [TotalCount]
	FROM Clients AS c
	JOIN Orders AS o
	ON c.Id = o.ClientId
	FULL JOIN Towns AS t
	ON o.TownId = t.Id
	GROUP BY t.Name
	) AS tc
	ON tc.TownName = t.Name
	WHERE c.Gender = 'M'
	GROUP BY t.Id,tc.TotalCount) as mp ON mp.Id = t.Id
LEFT JOIN(SELECT
		t.Id,
		(COUNT(*) * 100)/tc.TotalCount AS [FemalePercent]
		FROM Clients AS c
		JOIN Orders AS o
		ON c.Id = o.ClientId
		FULL JOIN Towns AS t
		ON o.TownId = t.Id
		JOIN
		(
		SELECT
		t.Name AS [TownName],
		COUNT(*) AS [TotalCount]
		FROM Clients AS c
		JOIN Orders AS o
		ON c.Id = o.ClientId
		FULL JOIN Towns AS t
		ON o.TownId = t.Id
		GROUP BY t.Name
		) AS tc
		ON tc.TownName = t.Name
		WHERE c.Gender = 'F'
		GROUP BY t.Id,tc.TotalCount) AS fp ON fp.Id = t.Id
ORDER BY t.Name, t.Id