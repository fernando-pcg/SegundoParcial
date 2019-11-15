create database CrudSP

use CrudSP

create table Materias(
	IdMateria int not null primary key identity (0,1),
	Codigo int not null,
	Nombre varchar(40) not null,
	Creditos int not null,
);

select Nombre From Materias;
insert into Materias (Codigo,Nombre,Creditos) values (0,'Ninguno',0);
insert into Materias (Codigo,Nombre,Creditos) values (1,'Fundamentos De Programacion',4);
insert into Materias (Codigo,Nombre,Creditos) values (2,'Programacion 1',4);

alter table Estudiantes Add Constraint Ck_Estado check (Estado in (1,2));


 create table Estudiantes(
	IdEstudiante int not null primary key identity (0,1),
	Nombre varchar(30) not null,
	Apellido varchar(30) not null,
	Materia int not null,
	Estado int not null,
	IdMateria int not null,
);

select Nombre,Apellido,Materia,Estado from Estudiantes 

ALTER TABLE Estudiantes ADD CONSTRAINT
Fk_Materias FOREIGN KEY(IdMateria) REFERENCES Materias(IdMateria);
