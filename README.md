# WebApiPost

Aplicación Web Api Blog Engine para registrar posts y comentarios a los mismos.  .NET Technical Test Zemoga 

## Comenzando 🚀

_Estas instrucciones te permitirán obtener una copia del proyecto en funcionamiento en tu máquina local para propósitos de desarrollo y pruebas._

* Abrir Visual Studio 2019, seleccionar el menu Git y luego seleccionar Clonar Repositorio.
* En el cuadro de texto Ubicación del repositorio pegar la siguiene url https://github.com/bethanneleon/WebApiPost.git.
* Hacer clic en Clonar.


### Pre-requisitos 📋

Para el funcionamiento de la aplicación se requiere:
* Visual Studio 2019 versión Community
* .Net Core versión 3.1
* [Microsoft.EntityFrameworkCore.SqlServer versión 3.1.15](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/3.1.15)
* [Microsoft.EntityFrameworkCore.Tools versión 3.1.15](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/3.1.15)
* Microsoft SqlServer Management Studio v18.8
* Postman

### Instalación 🔧

* Abrir Microsoft SqlServer Management Studio v18.8
* Ejecutar el script Paso 1 Script Creacion BD.sql para la creación de la base de datos.  Actualizar las rutas donde se crearan los archivos PostBD.mdf' y PostBD_log.ldf.
* Ejecutar el script Paso 2 Script_Creacion Tablas.sql para crear el usuario, tablas y datos de las tablas.
* Verificar conexión a la base de datos con el usuario SqlServer (usr_post).

## Ejecutando las pruebas ⚙️

* Abrir la solución desde Visual Studio 2019 Community.
* Ajustar el connection string que se encuentra en el archivo appsettings.Development.json en base a los datos de su servidor.
* Compilar la aplicación en modo debug.
* Ejecutar la aplicación en modo debug.
* Ir a postman, cambiar las Url's en los request de la colección colocando el puerto correcto y probar cada método.
* Verificar los cambios en la base de datos.

## Construido con 🛠️

* Visual Studio 2019 versión Community
* .Net Core versión 3.1.
* [Microsoft.EntityFrameworkCore.SqlServer versión 3.1.15](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/3.1.15)
* [Microsoft.EntityFrameworkCore.Tools versión 3.1.15](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/3.1.15)

## Agradecimiento 🎁

* Total de tiempo de desarrollo: 25 hrs.
* Gracias por considerarme en su proceso de selección
