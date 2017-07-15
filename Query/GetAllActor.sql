-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Alter PROCEDURE GetAllActor
@page int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	declare @Rows int = 30
	
	SELECT * FROM (
				 SELECT ROW_NUMBER() OVER(ORDER BY actor_id) AS NUMBER,
						actor_id, actor_name, cover_path FROM actor
				   ) AS TBL
	WHERE NUMBER BETWEEN ((@page - 1) * @Rows + 1) AND (@page * @Rows)
END
GO
