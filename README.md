# GyFChallenge
Challenge GyF

Dependencias: Visual Studio 2022, VS Code, SQL Server, SQL Server Management(para ver la base de datos) y node.js

Url Servidor: https://localhost:5001
Url Cliente: http://localhost:5173

En caso de tener alguna complicacion a la hora de utilizar el comando de EF Core referirse a la siguiente documentacion: https://learn.microsoft.com/en-us/ef/core/cli/powershell

Instrucciones:

Para el servidor usando Visual Studio 2022 se pueden levantar datos de prueba para la base de datos utilizando 
el comando "update-database" ya que existe una migracion hecha de EF Core, este comando se debe ejecutar en la consola package manager
ubicada en Tools > NuGet Package Manager > Package Manager Console, al compilar la aplicacion se abre una pestaña de Swagger donde se puede ver
y probar la API.

Una vez el servidor esta en marcha, con VS Code y node.js instalado, tenemos que utilizar la terminal dentro de la carpeta Client para realizar un comando
"npm install" para tener todas las dependencias necesarias, una vez que termine la instalacion, con "npm run dev" se creara el servidor del cliente y podremos
acceder a el desde el browser con la siguiente url default de Vite, que es la herramienta que utilice para armar el proyecto React.
