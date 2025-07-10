# Suit Tracker App

Servicio web para la administración, autorización y administración de los usuarios del sistema.

## 🚀 Tecnologías utilizadas

- Backend: .NET Core
- Base de datos: In-Memory

## ⚙️ Instalación y ejecución

1. Clona el repositorio:

```bash
git clone git@github.com:ManuFreelanceProjects/emi-test.git

2. Entra al directorio
cd emi-test

3. Compila la solución
dotnet build

4. Corre la solución
dotnet run

## ⚙️ Prueba desde Swagger
Una vez se encuentre la interfaz Swagger abierta sigue estos pasos:

1. Debes crear un usuario ejecutando: /apli/Auth/register

2. Autenticate con el usuario creado ejecutando: /apli/Auth/login

2.1. Copia el Token retornado en la respuesta

3. Debes presionar el botón Authorize y dentro encontraras un campo donde debes pegar el Token copiado, Ej:

   Bearer: {token_copiado}

4. Puedes probar cualquier servicio que desees.


## ⚙️ Notas:
1. Descripción de cómo implementar autenticación y autorización en la API:

1.1. Para ello podemos usar JWT (Json Web Token) para autenticación sin estado y basada en Roles.

1.2. Agregar autenticación con JWT.

     Instalar los paquetes requeridos:

     dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
     dotnet add package Microsoft.IdentityModel.Tokens

1.3. Actualizar el archivo Program.cs para configurar autenticación JWT.

1.4. Agregamos nuestra configuración sobre JWT en el archivo appSettings.json

1.5. Creamos una clase service que se va a encargar de resolver nuestro JWT token.

1.6. Utilizamos el [Authorize] atributo para proteger nuestras rutas.

1.7. Creamos una controladora que se va a encargar de resolver el usuario y contraseña para obtener el JWT token.

1.8. Probamos las rutas con el token generado.
 
