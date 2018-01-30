CREATE PROC OperacionesUser
@OP				int,
@correo			varchar(50),
@Pwd			varchar(200)=NULL,
@Nombre			varchar(50)=NULL,
@Ap_Paterno		varchar(50)=NULL,
@Ap_Materno		varchar(50)=NULL,
@FechaNac		datetime=NULL,
@TipoUsuario	INT = NULL
AS
BEGIN

	--SELECT
	IF(@OP=0)
		BEGIN
			SELECT 	Id_User,Correo,Pwd,Nombre,Ap_Paterno,Ap_Materno,FechaNac,TipoUsuario,FechaAlta,FechaBaja,FechaModificacion
				FROM Users WITH(NOLOCK)
			WHERE EnableU=1;
		END

	--BUSCAR POR CORREO
	IF(@OP=1)
		BEGIN
			SELECT 	Id_User,Correo,Pwd,Nombre,Ap_Paterno,Ap_Materno,FechaNac,TipoUsuario,FechaAlta,FechaBaja,FechaModificacion
				FROM Users WITH(NOLOCK)
			WHERE EnableU=1 AND correo=@correo
		END

	--INSERT
	IF(@OP=2)
		BEGIN
			IF(SELECT COUNT(CORREO) FROM Users WITH(NOLOCK) WHERE Correo=@correo)=1
				BEGIN
					SELECT 'ER' codigo,'*ERROR* EL CORREO YA ESTA DADO DE ALTA' mensaje;
				END
			ELSE
				BEGIN
					INSERT INTO Users(Correo,Pwd,Nombre,Ap_Paterno,Ap_Materno,FechaNac,FechaAlta,EnableU)
						VALUES
						 (	@correo,@Pwd,@Nombre,@Ap_Paterno,@Ap_Materno,@FechaNac,GETDATE(),1)

					SELECT 'OK' codigo,'*OK* EL CORREO SE DIO DE ALTA' mensaje;
				END
		END

	--DELETE LOGICO
	IF(@OP=3)
		BEGIN
			UPDATE Users SET	
								EnableU=0,
								FechaBaja=GETDATE()
			WHERE Correo=@correo

			SELECT 'OK'codigo,'*OK* EL REGISTRO SE MODIFICO'mensaje;

		END

	--ACTUALIZACION DE DATOS
	IF(@OP=4)
		BEGIN
			UPDATE Users 
				SET		Nombre=@Nombre,
						Ap_Paterno=@Ap_Paterno,
						Ap_Materno=@Ap_Materno,
						FechaNac=@FechaNac,
						FechaModificacion=GETDATE()
			WHERE Correo=@correo

			SELECT 'OK'codigo,'*OK* EL REGISTRO SE MODIFICO'mensaje;
		END

END

--SELECT * FROM Users