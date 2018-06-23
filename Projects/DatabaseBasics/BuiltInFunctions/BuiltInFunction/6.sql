SELECT TownID,
	   [Name]
	   FROM Towns
	   WHERE LEFT([Name],1)  IN ('m','k','b','e')
	   ORDER BY [Name]