USE [ReservationSystem]
GO

--====================================
--Autor: Sokolovskiy Alexander
--Create date: 08.06.2020
--Description: ���������� ������ �������� ������������ �� ��
--====================================

CREATE PROCEDURE DeleteUser
	@UserId INT
AS
	UPDATE ReservationSystemUser 
	SET 
		RemovedFlag = 1
	WHERE
	Id = @UserId 