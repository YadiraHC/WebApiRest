USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[Categoria_Listar]    Script Date: 27/08/2024 02:08:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Categoria_Listar]
(
	--Antes era '@idEstado' > '@Estado'
	@Estado int
)
as
begin
	select *
	from Categoria
	where Estado = @Estado
end
