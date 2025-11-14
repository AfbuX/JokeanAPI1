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

  
INSERT INTO Usuario (nombre, documento, telefono, correo, direccion, rol)
VALUES 
('Cliente Ejemplo', '10000001', '3001112233', 'cliente@demo.com', 'Calle 1 #10-20', 1),   -- Cliente
('Transportista Moto', '20000001', '3002223344', 'moto@demo.com', 'Calle 2 #20-30', 2), -- Transportista
('Transportista Chiva', '20000002', '3003334455', 'chiva@demo.com', 'Calle 3 #30-40', 2), -- Transportista
('Transportista Jeep', '20000003', '3004445566', 'jeep@demo.com', 'Calle 4 #40-50', 2), -- Transportista
('Transportista Taxi', '20000004', '3005556677', 'taxi@demo.com', 'Calle 5 #50-60', 2), -- Transportista
('Transportista Bicitaxi', '20000005', '3006667788', 'bicitaxi@demo.com', 'Calle 6 #60-70', 2), -- Transportista
('Administrador del Sistema', '99999999', '3000000000', 'admin@demo.com', 'Calle Admin #1', 3); -- Admin

INSERT INTO TipoTransporte (tipo, descripcion)
VALUES 
('Moto', 'Motocicleta estándar para servicios rápidos'),
('Chiva', 'Vehículo típico colorido para transporte de grupos'),
('Bicitaxi', 'Bicicleta modificada con cabina para pasajeros'),
('Taxi', 'Automóvil convencional para transporte individual'),
('Jeep', 'Jeep rural colorido ideal para zonas montañosas'),
('Lancha', 'Embarcación ligera para transporte acuático');

INSERT INTO Transporte (tipotransporteid, usuarioid, matricula, capacidad, tipomotor, cilindraje, placa, marca, modelo)
VALUES (1, 2, 'MOTO-001', 1, 'Gasolina', '150cc', 'ABC123', 'Honda', 'CB150');

INSERT INTO Transporte (tipotransporteid, usuarioid, matricula, capacidad, tipomotor, cilindraje, placa, marca, modelo)
VALUES (2, 3, 'CHIVA-001', 20, 'Diesel', '4000cc', 'CHV456', 'Chevrolet', 'ChivaTurbo');

INSERT INTO Transporte (tipotransporteid, usuarioid, matricula, capacidad, tipomotor, cilindraje, placa, marca, modelo)
VALUES (3, 7, 'BICI-001', 2, 'Humano', 'N/A', 'BCT789', 'EcoBike', 'TaxiBike');

INSERT INTO Transporte (tipotransporteid, usuarioid, matricula, capacidad, tipomotor, cilindraje, placa, marca, modelo)
VALUES (4, 5, 'TAXI-001', 4, 'Gasolina', '1600cc', 'TXI321', 'Kia', 'Rio');

INSERT INTO Transporte (tipotransporteid, usuarioid, matricula, capacidad, tipomotor, cilindraje, placa, marca, modelo)
VALUES (5, 4, 'JEEP-001', 8, 'Gasolina', '3000cc', 'JEP654', 'Jeep', 'Rural 4x4');

INSERT INTO Transporte (tipotransporteid, usuarioid, matricula, capacidad, tipomotor, cilindraje, placa, marca, modelo)
VALUES (6, 6, 'LANCHA-001', 10, 'Fuera de borda', '1200cc', 'LNC987', 'Yamaha', 'WaveRunner');

INSERT INTO MetodoPago (descripcion)
VALUES ('Efectivo'), ('Transferencia'), ('Tarjeta');







