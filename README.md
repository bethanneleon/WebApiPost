# WebApiPost

Aplicaci贸n Web Api Blog Engine para registrar posts y comentarios a los mismos.  .NET Technical Test Zemoga 

## Comenzando 馃殌

_Estas instrucciones te permitir谩n obtener una copia del proyecto en funcionamiento en tu m谩quina local para prop贸sitos de desarrollo y pruebas._

* Abrir Visual Studio 2019, seleccionar el menu Git y luego seleccionar Clonar Repositorio.
* En el cuadro de texto Ubicaci贸n del repositorio pegar la siguiene url https://github.com/bethanneleon/WebApiPost.git.
* Hacer clic en Clonar.


### Pre-requisitos 馃搵

Para el funcionamiento de la aplicaci贸n se requiere:
* Visual Studio 2019 versi贸n Community
* .Net Core versi贸n 3.1
* [Microsoft.EntityFrameworkCore.SqlServer versi贸n 3.1.15](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/3.1.15)
* [Microsoft.EntityFrameworkCore.Tools versi贸n 3.1.15](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/3.1.15)
* Microsoft SqlServer Management Studio v18.8
* Postman

### Instalaci贸n 馃敡

* Abrir Microsoft SqlServer Management Studio v18.8
* Ejecutar el script Paso 1 Script Creacion BD.sql para la creaci贸n de la base de datos.  Actualizar las rutas donde se crearan los archivos PostBD.mdf' y PostBD_log.ldf.
* Ejecutar el script Paso 2 Script_Creacion Tablas.sql para crear el usuario, tablas y datos de las tablas.
* Verificar conexi贸n a la base de datos con el usuario SqlServer (usr_post).

## Ejecutando las pruebas 鈿欙笍

* Abrir la soluci贸n desde Visual Studio 2019 Community.
* Ajustar el connection string que se encuentra en el archivo appsettings.Development.json en base a los datos de su servidor.
* Compilar la aplicaci贸n en modo debug.
* Ejecutar la aplicaci贸n en modo debug.
* Ir a postman, cambiar las Url's en los request de la colecci贸n colocando el puerto correcto y probar cada m茅todo.
* Verificar los cambios en la base de datos.

## Construido con 馃洜锔?

* Visual Studio 2019 versi贸n Community
* .Net Core versi贸n 3.1.
* [Microsoft.EntityFrameworkCore.SqlServer versi贸n 3.1.15](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/3.1.15)
* [Microsoft.EntityFrameworkCore.Tools versi贸n 3.1.15](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/3.1.15)

## Agradecimiento 馃巵

* Total de tiempo de desarrollo: 25 hrs.
* Gracias por considerarme en su proceso de selecci贸n
