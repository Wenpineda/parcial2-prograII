Create database RegistroNotas

use RegistroNotas

create table Estudiantes(
id int identity (1,1) primary key,
nombre varchar(50),
apellido varchar(50), 
carrera varchar(50),
asignatura varchar(50),
promedio1 decimal(18,2),
promedio2 decimal(18,2),
promedio3 decimal(18,2),
promediofinal decimal(18,2)
);
drop table Estudiantes

select *from Estudiantes 

Insert into Estudiantes (nombre,apellido,carrera, asignatura, promedio1, promedio2, promedio3, promediofinal) VALUES 
('Jordy', 'Cortez', 'ing', 'Fisica', 7, 8.6,9.5,8.4);