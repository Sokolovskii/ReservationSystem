USE[ReservationSystem]
GO

--============================
--Author: Sokolovskiy Alexander
--Create Date: 11.06.2020
--Description: Возвращает пользователя по Логину
--============================

CREATE PROCEDURE GetPersonByLogin
	@Login NVARCHAR(100)
AS
	SELECT u.Id, u.Login, u.Name, u.PassHash FROM ReservationSystemUser u
	WHERE u.Login = @Login
	AND RemovedFlag = 0