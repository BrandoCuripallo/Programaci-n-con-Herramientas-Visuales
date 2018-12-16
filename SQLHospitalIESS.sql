CREATE DATABASE HospitalIESS
GO
USE HospitalIESS
GO
CREATE TABLE tblAdministrador (cedulaAdministrador varchar(10) PRIMARY KEY, nombres varchar(50), 
apellidoPaterno varchar(25), apellidoMaterno varchar(25), fechaNacimiento date, edad int, sexo varchar(10), 
correoElectronico varchar(50), provincia varchar(20), ciudad varchar(20), dirección varchar(50), 
telefono varchar(10), usuario varchar(50) UNIQUE, contrasenia varchar(50))
GO
CREATE TABLE tblEspecialidad (codigoEspecialidad int PRIMARY KEY IDENTITY, nombreEspecialidad varchar(25))
GO
CREATE TABLE tblCirugia (idCirugia int PRIMARY KEY IDENTITY, descripcion varchar(100))
GO
CREATE TABLE tblDoctor (cedulaDoctor varchar(10) PRIMARY KEY, nombres varchar(50), apellidoPaterno varchar(25), 
apellidoMaterno varchar(25), fechaNacimiento date, edad int, sexo varchar(10), correoElectronico varchar(50), 
provincia varchar(20), ciudad varchar(20), dirección varchar(50), telefono varchar(10), usuario varchar(50) UNIQUE, 
contrasenia varchar(50), codigoEspecialidad int FOREIGN KEY REFERENCES tblEspecialidad (codigoEspecialidad) 
ON UPDATE CASCADE)
GO
CREATE TABLE tblRecepcionista (cedulaRecepcionista varchar(10) PRIMARY KEY, nombres varchar(50), 
apellidoPaterno varchar(25), apellidoMaterno varchar(25), fechaNacimiento date, edad int, sexo varchar(10), 
correoElectronico varchar(50), provincia varchar(20), ciudad varchar(20), dirección varchar(25), 
telefono varchar(10), usuario varchar(50) UNIQUE, contrasenia varchar(50))
GO
CREATE TABLE tblFarmaceutico (cedulaFarmaceutico varchar(10) PRIMARY KEY, nombres varchar(50), 
apellidoPaterno varchar(25), apellidoMaterno varchar(25), fechaNacimiento date, edad int, sexo varchar(10), 
correoElectronico varchar(50), provincia varchar(20), ciudad varchar(20), dirección varchar(50), 
telefono varchar(10), usuario varchar(50) UNIQUE, contrasenia varchar(50))
GO
CREATE TABLE tblPaciente (cedulaPaciente varchar(10) PRIMARY KEY, nombres varchar(50), apellidoPaterno varchar(25), 
apellidoMaterno varchar(25), fechaNacimiento date, edad int, sexo varchar(10), correoElectronico varchar(50), 
provincia varchar(20), ciudad varchar(20), dirección varchar(25), telefono varchar(10), contrasenia varchar(50))
GO
CREATE TABLE tblHistoriaClinica (numeroHistoria int PRIMARY KEY IDENTITY, cedulaPaciente varchar(10) FOREIGN KEY REFERENCES 
tblPaciente (cedulaPaciente) ON UPDATE CASCADE ON DELETE CASCADE)
GO
CREATE TABLE tblHistoriaClinicaDoctor (idHistoriaClinicaDoctor int PRIMARY KEY IDENTITY, cedulaDoctor varchar(10) 
FOREIGN KEY REFERENCES tblDoctor (cedulaDoctor) ON UPDATE CASCADE, numeroHistoria int FOREIGN KEY REFERENCES 
tblHistoriaClinica (numeroHistoria) ON UPDATE CASCADE ON DELETE CASCADE, fecha datetime, temperaturaPaciente float, 
altura float, peso float, diagnostico varchar(100), indicaciones varchar(100))
GO
CREATE TABLE tblCitaMedica (idCita int PRIMARY KEY IDENTITY, fechaCita datetime, descripcion varchar(100), cedulaPaciente 
varchar(10) FOREIGN KEY REFERENCES tblPaciente (cedulaPaciente), codigoEspecialidad int 
FOREIGN KEY REFERENCES tblEspecialidad (codigoEspecialidad), cedulaRecepcionista varchar(10) 
FOREIGN KEY REFERENCES tblRecepcionista (cedulaRecepcionista), cedulaDoctor varchar(10) 
FOREIGN KEY REFERENCES tblDoctor (cedulaDoctor))
GO
CREATE TABLE tblCirugiaPaciente (idCirugiaPaciente int PRIMARY KEY IDENTITY, idCirugia int FOREIGN KEY REFERENCES tblCirugia (idCirugia) 
ON UPDATE CASCADE ON DELETE CASCADE, cedulaDoctor varchar(10) FOREIGN KEY REFERENCES tblDoctor (cedulaDoctor) ON UPDATE CASCADE ON DELETE CASCADE, 
cedulaPaciente varchar(10) FOREIGN KEY REFERENCES tblPaciente (cedulaPaciente) ON UPDATE CASCADE ON DELETE CASCADE, descripcion varchar(100), fecha datetime)
GO
CREATE TABLE tblFactura (idFactura int PRIMARY KEY IDENTITY, cedulaFarmaceutico varchar(10) 
FOREIGN KEY REFERENCES tblFarmaceutico (cedulaFarmaceutico) ON UPDATE CASCADE, cedulaPaciente varchar(10) 
FOREIGN KEY REFERENCES tblPaciente (cedulaPaciente) ON UPDATE CASCADE, fechaEmision date, total float)
GO
CREATE TABLE tblMedicamento (codigoMedicamento varchar(5) PRIMARY KEY, nombreMedicamento varchar(50), descripcion varchar(50), stock int, 
precioUnitario float)
GO
CREATE TABLE tblMedicamentoFactura (idMedicamentoFactura int PRIMARY KEY IDENTITY, idFactura int FOREIGN KEY REFERENCES 
tblFactura (idFactura) ON UPDATE CASCADE ON DELETE CASCADE, codigoMedicamento varchar(5) FOREIGN KEY REFERENCES 
tblMedicamento (codigoMedicamento) ON UPDATE CASCADE, cantidad int, subtotal float)
GO
CREATE TABLE tblReceta (idReceta int PRIMARY KEY IDENTITY, cedulaPaciente varchar(10) FOREIGN KEY REFERENCES 
tblPaciente (cedulaPaciente) ON UPDATE CASCADE, cedulaDoctor varchar(10) FOREIGN KEY REFERENCES 
tblDoctor (cedulaDoctor) ON UPDATE CASCADE, fechaEmision date, indicaciones varchar(150))
GO
CREATE TABLE tblRecetaMedicamento (idRecetaMedicamento int PRIMARY KEY IDENTITY, idReceta int FOREIGN KEY REFERENCES 
tblReceta (idReceta) ON UPDATE CASCADE, codigoMedicamento varchar(5) FOREIGN KEY REFERENCES 
tblMedicamento (codigoMedicamento) ON UPDATE CASCADE)