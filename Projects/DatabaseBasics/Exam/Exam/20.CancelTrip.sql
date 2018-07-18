CREATE TRIGGER tr_DeleteTrip
ON Trips
INSTEAD OF DELETE
AS
BEGIN
	UPDATE Trips
	SET CancelDate = GETDATE()
	FROM Trips AS t
	JOIN deleted AS d ON d.Id = t.Id
    WHERE d.CancelDate IS NULL
END
