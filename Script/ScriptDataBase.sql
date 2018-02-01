create table Users
(
	Id_User				int primary key identity(1,1) not null,
	Correo				varchar(50) not null,
	Pwd					varchar(200)not null,
	Nombre				varchar(50)not null,
	Ap_Paterno			varchar(50)not null,
	Ap_Materno			varchar(50)not null,
	FechaNac			datetime not null,
	TipoUsuario			int null,
	FechaAlta			datetime null,
	FechaBaja			datetime null,
	FechaModificacion	datetime null,
	EnableU				bit not null
)
go
create table Clientes
(
	IdCliente	int primary key identity(1,1),
	Nombre	varchar(50),
	Ap_Paterno	varchar(50),
	Ap_Materno	varchar(50),
	FechaNac	datetime,
	Edad	int,
)
go
create table TiposUsers
(
idTipo int primary key identity(1,1)not null,
tipo		varchar(20)not null,
descripcion varchar(50)null,
Enabled_T	bit,
)

insert into TiposUsers values('Admin','Administrador',1)
insert into TiposUsers values('User','Usuario',1)
insert into TiposUsers values('Costumer','Cliente',1)


drop table Users
select * from Users

select * from Clientes
truncate table Clientes

drop table TiposUsers


select idTipo,tipo,descripcion,Enabled_T from TiposUsers with(nolock) where Enabled_T=1
