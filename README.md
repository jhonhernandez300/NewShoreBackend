# NewShoreBackend
Script para crear la base de datos en el Management Studio:
Create database NewShoreDB
go

use NewShoreDB
go

create table Journey (
JourneyId  Int Identity (1,1) primary key not null
,JourneyOrigin nvarchar(3) not null
,JourneyDestination nvarchar(3) not null
,JourneyPrice decimal(18,2) not null
)

create table Flight (
FlightId Int Identity (1,1) primary key not null
,FlightOrigin  nvarchar(3) not null
,FlightDestination nvarchar(3) not null
,FlightPrice decimal(18,2) not null
,TransportId int not null
)

create table Transport (
TransportId Int Identity (1,1) primary key not null
,FlightCarrier nvarchar(2) not null
,FlightNumber int not null
)

create table JourneyFlight (
JourneyFlightId  Int Identity (1,1) primary key not null
,JourneyId int not null
,FlightId int not null
)

ALTER TABLE JourneyFlight
ADD FOREIGN KEY (JourneyId) REFERENCES Journey(JourneyId);

ALTER TABLE JourneyFlight
ADD FOREIGN KEY (FlightId) REFERENCES Flight(FlightId);

ALTER TABLE Flight
ADD FOREIGN KEY (TransportId) REFERENCES Transport(TransportId);

CREATE INDEX JourneyOriginIndex
ON Journey(JourneyOrigin);

CREATE INDEX JourneyDestinationIndex
ON Journey(JourneyDestination);

CREATE INDEX FlightOriginIndex
ON Flight(FlightOrigin);

CREATE INDEX FlightDestinationIndex
ON Flight(FlightDestination);

La cadena de conexión en el proyecto, cambiar el nombre del PC.

