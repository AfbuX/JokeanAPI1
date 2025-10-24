create database DBJokean

use DBJokean

create table Usuario(
id int identity (1,1) primary key not null,
nombre varchar(100) not null,
documento varchar(20) not null, 
telefono varchar(20) not null,
correo varchar (150),
direccion varchar (200) not null,
rol int not null
)

create table UbicacionActual(
id int identity (1,1) primary key not null,
usuarioid int not null,
latitud decimal (10,8) not null,
longitud decimal (10,8) not null,
constraint FK_usuarioid foreign key (usuarioid) references Usuario(id)
)

create table TipoTransporte(
id int identity (1,1) primary key not null,
tipo varchar (100) not null,
descripcion varchar (500)
)

create table Transporte(
id int identity (1,1) primary key not null,
tipotransporteid int not null,
usuarioid int not null,
matricula varchar (50) not null,
capacidad int not null,
tipomotor varchar (50) not null,
cilindraje varchar(50),
placa varchar (20),
marca varchar (50),
modelo varchar (50),
constraint FK_Transporteusuarioid foreign key (usuarioid) references Usuario(id),
constraint FK_Transportetipotransporteid foreign key (tipotransporteid) references TipoTransporte(id)
)

create table MetodoPago(
id int identity (1,1) primary key not null,
descripcion varchar (100) not null
)

create table SolicitudServicio(
id int identity (1,1) primary key not null,
latitudOrigen decimal (10,8) not null,
longitudOrigen decimal (10,8) not null,
latitudDestino decimal (10,8) not null,
longitudDestino decimal (10,8) not null,
tipotransporteid int not null,
usuarioid int not null,
metodopagoid int not null,
fechaSolicitud datetime not null,
constraint FK_Soltipotransporteid foreign key (tipotransporteid) references TipoTransporte(id),
constraint FK_Solusuarioid foreign key (usuarioid) references Usuario(id),
constraint FK_Solmetodopagoid foreign key (metodopagoid) references MetodoPago(id),
)

create table Servicio(
id int identity (1,1) primary key not null,
transportistaid int not null,
constraint FK_Metodotransportistaidid foreign key (transportistaid) references Usuario(id),
solicitudservicioid int not null,

constraint FK_Serviciosolicitudservicioid foreign key (solicitudservicioid) references SolicitudServicio(id),
fechaServicio datetime,
estado int not null,
valor bigint,
)

create table Pago(
id int identity (1,1) primary key not null,
valor decimal (18,2) not null,
metodopagoid int not null,
descripcion varchar(100),
constraint FK_Pagometodopagoid foreign key (metodopagoid) references MetodoPago(id),
servicioid int not null,
constraint FK_Pagoservicioid foreign key (servicioid) references Servicio(id),
)


create table ExtraSolicitud(
id int identity (1,1) primary key not null,
descripcion varchar(500) not null,
solicitudservicioid int not null,
constraint FK_Extrasolicitudservicioid foreign key (solicitudservicioid) references SolicitudServicio(id),

)

create table Calificacion(
id int identity (1,1) primary key not null,
servicioid int not null,
calificacion varchar (50) not null,
descripcion varchar(200)
constraint FK_Calservicioid foreign key (servicioid) references Servicio(id),
)






