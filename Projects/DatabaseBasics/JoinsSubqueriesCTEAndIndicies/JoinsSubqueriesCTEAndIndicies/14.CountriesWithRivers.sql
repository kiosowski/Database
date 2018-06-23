SELECT TOP (5) co.CountryName,r.RiverName FROM Continents AS c
	LEFT JOIN Countries AS co ON co.ContinentCode = c.ContinentCode
	LEFT JOIN CountriesRivers AS cr ON cr.CountryCode =co.CountryCode
	LEFT JOIN Rivers as r ON r.Id=cr.RiverId
WHERE c.ContinentCode='AF'
ORDER BY co.CountryName 