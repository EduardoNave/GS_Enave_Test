create database Registro; 

use Registro;

create table mat_materia (
	mat_id int NOT NULL IDENTITY,
	mat_nombre varchar(100),
	PRIMARY KEY (mat_id)
);

create table grd_grado (
	grd_id int NOT NULL IDENTITY,
	grd_nombre varchar(100),
	PRIMARY KEY (grd_id)
);

create table mxg_materiasxgrado (
	mxg_id int NOT NULL IDENTITY,
	mxg_id_grd int,
	mxg_id_mat int,
	PRIMARY KEY (mxg_id),
	FOREIGN KEY (mxg_id_grd) REFERENCES grd_grado(grd_id),
	FOREIGN KEY (mxg_id_mat) REFERENCES mat_materia(mat_id)
);

create table alm_alumno (
	alm_id int NOT NULL IDENTITY,
	alm_codigo varchar(100),
	alm_nombre varchar(300),
	alm_edad int,
	alm_sexo varchar(100),
	alm_id_grd int,
	alm_observacion varchar(300),
	PRIMARY KEY (alm_id),
	FOREIGN KEY (alm_id_grd) REFERENCES grd_grado(grd_id)
);
