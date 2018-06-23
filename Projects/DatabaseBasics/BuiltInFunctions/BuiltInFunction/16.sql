SELECT ProductName,
	   OrderDate,
	   DATEADD(Day,3,OrderDate) AS [Pay Due],
	   DATEADD(MONTH,1,OrderDate) AS [Deliver Due]
FROM Orders