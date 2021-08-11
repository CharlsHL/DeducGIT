--insert into usuarios values ('admin','admin@admin','admin','1','Estudio Andrade');
--insert into usuarios values ('invitado','invitado@invitado','invitado','1','invitado');

--select * from usuarios
CREATE PROCEDURE [acceso] 
    
AS   
    SET NOCOUNT ON;  
GO
ALTER procedure [dbo].[acceso] (
	@user varchar (50),
	@pass varchar (50)
	)
As
begin
	select usuario,contraseña from usuarios where usuario = @user and contraseña = @pass END



--Create table usuarios (Idusuario int NOT NULL IDENTITY(1,1) PRIMARY KEY, usuario varchar(50),correo varchar (50), contraseña varchar(50),permisos int,empresa varchar(50));  