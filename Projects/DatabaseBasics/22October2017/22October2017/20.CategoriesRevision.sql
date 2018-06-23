SELECT c.Name AS[Category Name],
		COUNT(*) AS [ReportsNumber],
		CASE
			WHEN InProgressCount>WaitingCount
				THEN 'in progress'
			WHEN InProgressCount<WaitingCount
				THEN 'waiting'
			ELSE 'equal'
		END AS [MainStatus]
		FROM Reports AS r
	JOIN Categories AS c ON c.Id=r.CategoryId
	JOIN Status AS s ON s.Id=r.StatusId
	JOIN (SELECT r.CategoryId,
				SUM(CASE WHEN s.Label='in progress' THEN 1 ELSE 0 END) AS InProgressCount,
				SUM(CASE WHEN s.Label='waiting' THEN 1 ELSE 0 END) AS WaitingCount
				FROM Reports AS r
				JOIN Status AS s ON s.Id=r.StatusId
				WHERE Label IN ('waiting','in progress')
				GROUP BY r.CategoryId) AS sc ON sc.CategoryId=c.Id
		
	WHERE s.Label = 'waiting' OR s.Label='in progress'
	GROUP BY c.Name,
	CASE
			WHEN InProgressCount>WaitingCount
				THEN 'in progress'
			WHEN InProgressCount<WaitingCount
				THEN 'waiting'
			ELSE 'equal'
	END
ORDER BY [Category Name],ReportsNumber,MainStatus
