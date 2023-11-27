Se realizó la totalidad del requerimiento.

-El proyecto fue creado por completo utilizando el Framework Asp.Net Core y el runtime .NET 8.
-Para ejecutar el proyecto, solo se necesita tener instalado el motor de bases de datos SQL Server, ya que fue el motor utilizado.
-Tambien debe estar instalado el runtine .NET 8.
-Tener Visual Studio 2022 (Recomendable).
-Para crear la base de datos, se debe acceder al proyecto por la terminal y ejecuta los siguientes comandos:
     1-) dotnet ef migrations add Initial.
     2-) dotnet ef database update.
-Para utilizar la API de manera exitosa, también es necesario arrancar el proyecto CardApp junto con la API (en la configuración de arranque, indica que ambos se inicien).
-El proyecto CardApp es independiente de la API.

Observaciones:
-Dada la simplicidad del requerimiento, no vi necesario aplicar la arquitectura de capas.
-El patrón de diseño utilizado fue Repository
