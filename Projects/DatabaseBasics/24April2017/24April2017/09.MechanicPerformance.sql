SELECT
m.FirstName + ' ' + m.LastName AS [Mechanic],
AVG(DaysPerMechanicId.Days)
FROM Mechanics AS m
JOIN (SELECT MechanicId,DATEDIFF(DAY,IssueDate,FinishDate) AS [Days]
FROM JOBS 
WHERE Status = 'Finished'
) AS DaysPerMechanicId
ON m.MechanicId = DaysPerMechanicId.MechanicId
GROUP BY m.FirstName + ' ' + m.LastName, m.MechanicId
ORDER BY m.MechanicId