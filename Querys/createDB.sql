CREATE TABLE `Empresa` (
	`cuit` bigint NOT NULL,
	`razonSocial` varchar(50) NOT NULL,
	`fechaInicioActividades` date NOT NULL,
	`tipoPersona` int NOT NULL,
	PRIMARY KEY (`cuit`)
);

CREATE TABLE `Actividad` (
	`cuacm` int NOT NULL,
	`nombreActividad` varchar(100) NOT NULL,
	`estandar` int NOT NULL,
	`grupo` char NOT NULL,
	PRIMARY KEY (`cuacm`)
);

CREATE TABLE `actividadEmpresa` (
	`cuit` bigint NOT NULL,
	`cuacm` int NOT NULL,
	PRIMARY KEY (`cuit`, `cuacm`)
);

CREATE TABLE `GrupoActividad` (
	`idGrupo` char NOT NULL,
	`nombreGrupo` varchar(100) NOT NULL,
	PRIMARY KEY (`idGrupo`)
);

CREATE TABLE `Domicilio` (
	`cuit` bigint NOT NULL,
	`tipo` varchar(20) NOT NULL,
	`calle` varchar(50) NOT NULL,
	`numero` varchar(6) NOT NULL,
	`piso` int NOT NULL,
	`depto` varchar(6) NOT NULL,
	`localidad` varchar(50) NOT NULL,
	`cp` varchar(8) NOT NULL,
	`telefono` int NOT NULL,
	`email` varchar(50) NOT NULL,
	`idPlanta` int,
	PRIMARY KEY (`tipo`, `calle`, `numero`)
);

CREATE TABLE `Representante` (
	`documento` int NOT NULL,
	`apellido` varchar(50) NOT NULL,
	`nombre` varchar(50) NOT NULL,
	`cargo` varchar(50) NOT NULL,
	`cuit` bigint NOT NULL,
	`tipo` varchar(20) NOT NULL,
	`orden` int NOT NULL,
	PRIMARY KEY (`documento`)
);

CREATE TABLE `Producto` (
	`nombre` varchar(50) NOT NULL,
	`estadoFisico` varchar(20) NOT NULL,
	`produccionAnual` double NOT NULL,
	`unidad` varchar(10) NOT NULL,
	`almacenamiento` varchar(100) NOT NULL,
	`clasificacion` varchar(20) NOT NULL,
	`especificacion` varchar(200) NOT NULL,
	`idPlanta` int NOT NULL
);

CREATE TABLE `Subproducto` (
	`nombre` varchar(50) NOT NULL,
	`estadoFisico` varchar(20) NOT NULL,
	`produccionAnual` double NOT NULL,
	`unidad` varchar(10) NOT NULL,
	`almacenamiento` varchar(100) NOT NULL,
	`idPlanta` int NOT NULL,
	`idSubProducto` int NOT NULL,
	PRIMARY KEY (`idSubProducto`)
);

CREATE TABLE `MateriaPrima` (
	`nombre` varchar(50) NOT NULL,
	`estadoFisico` varchar(20) NOT NULL,
	`consumoAnual` double NOT NULL,
	`unidad` varchar(10) NOT NULL,
	`almacenamiento` varchar(100) NOT NULL,
	`idPlanta` int NOT NULL,
	`idMateriaPrima` int NOT NULL,
	PRIMARY KEY (`idMateriaPrima`)
);

CREATE TABLE `Insumo` (
	`nombre` varchar(50) NOT NULL,
	`estadoFisico` varchar(20) NOT NULL,
	`consumoAnual` double NOT NULL,
	`unidad` varchar(10) NOT NULL,
	`almacenamiento` varchar(100) NOT NULL,
	`idPlanta` int NOT NULL,
	`idInsumo` int NOT NULL,
	PRIMARY KEY (`idInsumo`)
);

CREATE TABLE `Planta` (
	`idPlanta` int NOT NULL,
	`cuit` bigint NOT NULL,
	`superficieTotalM2` double NOT NULL,
	`superficieCubiertaM2` double NOT NULL,
	`potenciaInstaladaHP` double NOT NULL,
	`dotacionDePersonal` int NOT NULL,
	PRIMARY KEY (`idPlanta`)
);

CREATE TABLE `FormacionDePersonal` (
	`cantidadObreros` int NOT NULL,
	`capacitacionObreros` boolean NOT NULL,
	`cantidadTecnicos` int NOT NULL,
	`capacitacionTecnicos` boolean NOT NULL,
	`cantidadProfesionales` int NOT NULL,
	`capacitacionProfesionales` boolean NOT NULL,
	`idPlanta` int NOT NULL,
	`idFormacionPersonal` int NOT NULL,
	PRIMARY KEY (`idFormacionPersonal`)
);

CREATE TABLE `EmisionGaseosa` (
	`tipo` varchar(60) NOT NULL,
	`emision` varchar(50) NOT NULL,
	`procesoGenerador` varchar(100) NOT NULL,
	`tratamiento` varchar(100) NOT NULL,
	`componentesRelevantes` varchar(100) NOT NULL,
	`idPlanta` int NOT NULL,
	`idEmisionGaseosa` int NOT NULL,
	PRIMARY KEY (`idEmisionGaseosa`)
);

CREATE TABLE `Efluente` (
	`procesoGenerador` varchar(50) NOT NULL,
	`componentesRelevantes` varchar(100) NOT NULL,
	`volumen` double NOT NULL,
	`unidad` varchar(5) NOT NULL,
	`unidadDeTiempo` varchar(10) NOT NULL,
	`gestion` varchar(200) NOT NULL,
	`cuerpoReceptor` varchar(200) NOT NULL,
	`idPlanta` int NOT NULL,
	`idEfluente` int NOT NULL,
	PRIMARY KEY (`idEfluente`)
);

CREATE TABLE `ResiduosSolidos` (
	`residuo` varchar(150) NOT NULL,
	`cantidad` double NOT NULL,
	`unidad` varchar(10) NOT NULL,
	`periodo` varchar(10) NOT NULL,
	`procesoGenerador` varchar(50) NOT NULL,
	`gestion` varchar(200) NOT NULL,
	`idPlanta` int NOT NULL,
	`idResiduoSolido` int NOT NULL,
	PRIMARY KEY (`idResiduoSolido`)
);

CREATE TABLE `RiesgoPresunto` (
	`fuentesMoviles` boolean NOT NULL,
	`aparatosSometidos` boolean NOT NULL,
	`sustanciasQuimicas` boolean NOT NULL,
	`explosion` boolean NOT NULL,
	`incendio` boolean NOT NULL,
	`otro` boolean NOT NULL,
	`observaciones` varchar(200) NOT NULL,
	`idPlanta` int NOT NULL,
	`idRiesgoPresunto` int NOT NULL,
	PRIMARY KEY (`idRiesgoPresunto`)
);

ALTER TABLE `Actividad` ADD FOREIGN KEY (`grupo`) REFERENCES `GrupoActividad`(`idGrupo`);
ALTER TABLE `actividadEmpresa` ADD FOREIGN KEY (`cuit`) REFERENCES `Empresa`(`cuit`);
ALTER TABLE `actividadEmpresa` ADD FOREIGN KEY (`cuacm`) REFERENCES `Actividad`(`cuacm`);
ALTER TABLE `Domicilio` ADD FOREIGN KEY (`cuit`) REFERENCES `Empresa`(`cuit`);
ALTER TABLE `Domicilio` ADD FOREIGN KEY (`idPlanta`) REFERENCES `Planta`(`idPlanta`);
ALTER TABLE `Representante` ADD FOREIGN KEY (`cuit`) REFERENCES `Empresa`(`cuit`);
ALTER TABLE `Producto` ADD FOREIGN KEY (`idPlanta`) REFERENCES `Planta`(`idPlanta`);
ALTER TABLE `Subproducto` ADD FOREIGN KEY (`idPlanta`) REFERENCES `Planta`(`idPlanta`);
ALTER TABLE `MateriaPrima` ADD FOREIGN KEY (`idPlanta`) REFERENCES `Planta`(`idPlanta`);
ALTER TABLE `Insumo` ADD FOREIGN KEY (`idPlanta`) REFERENCES `Planta`(`idPlanta`);
ALTER TABLE `Planta` ADD FOREIGN KEY (`cuit`) REFERENCES `Empresa`(`cuit`);
ALTER TABLE `FormacionDePersonal` ADD FOREIGN KEY (`idPlanta`) REFERENCES `Planta`(`idPlanta`);
ALTER TABLE `EmisionGaseosa` ADD FOREIGN KEY (`idPlanta`) REFERENCES `Planta`(`idPlanta`);
ALTER TABLE `Efluente` ADD FOREIGN KEY (`idPlanta`) REFERENCES `Planta`(`idPlanta`);
ALTER TABLE `ResiduosSolidos` ADD FOREIGN KEY (`idPlanta`) REFERENCES `Planta`(`idPlanta`);
ALTER TABLE `RiesgoPresunto` ADD FOREIGN KEY (`idPlanta`) REFERENCES `Planta`(`idPlanta`);