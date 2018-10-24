
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Factura_Get_Total
	-- Add the parameters for the stored procedure here
	@CodCliente VARCHAR(60)
	,@Numero VARCHAR(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	SELECT [Total]
	FROM PAG_Factura
	WHERE [CodCliente] = @CodCliente
		AND [Numero] = @Numero;
END
