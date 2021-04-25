## Tecnologia Usada

### ´Database layer´
se utilizo el ORM Entity Framework para el acceso y manejo de la base de datos, la cual es un sql server.
tambien se utilizo el pattern repository para encapsular la logica propia de EF

### ´Services layer´
se utilizo la libreria refit para podes facilitar la comunicacion con apis externas

### ´Domain layer´
capa que solo se utiliza para compartir informacion entre todas las capas, solo contiene DTOs

### ´Business layer´
capa utilizada para almacenar logica de negocio, en la misma se utiliza automapper para mapear las entidades de la DB a DTOs

### ´Api layer´
capa que contiene los endpoints de la Web Api REST

### ´Test´
contiene los test unitarios de la app, para los cuales se utilizo la libreria Moq para mockear las dependecias en algunos test, tambien se uso test integrales para probar la logica de negocio que solo accede a db, no se llego a tener un buen code coverage por cuestion de tiempo

### ´General´
la api esta protegida mediante Token JWT, necesario para acceder a los endpoint que requieren informacion, todo el codigo se hizo sobre .Net 5 

### ´dotnet run´
posicionarse dentro de la carpeta BirrasAPI donde esta el projecto api de la app, y ejecutar el comando

