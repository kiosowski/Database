SELECT v.Name,
	   COUNT(vm.MinionId) AS NumberOfMinions
FROM Villains AS v
	JOIN MinionsVillains AS vm ON vm.VillainId = v.Id
	GROUP BY v.Name
	ORDER BY NumberOfMinions DESC;