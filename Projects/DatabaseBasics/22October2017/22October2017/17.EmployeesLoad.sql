CREATE FUNCTION udf_GetReportsCount(@employeeId INT,@statusId INT)
RETURNS INT
AS
	BEGIN
		DECLARE @result INT=(
								SELECT ISNULL(COUNT(*),0) FROM Reports
								WHERE @employeeId=EmployeeId AND @statusId=StatusId
							)
		RETURN @result
	END 