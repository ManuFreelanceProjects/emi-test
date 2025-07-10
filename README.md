# Emi-test

Servicio web para la administración, autorización y gestión de los usuarios del sistema.

## 🚀 Tecnologías utilizadas

- Backend: .NET Core  
- Base de datos: In-Memory

## ⚙️ Instalación y ejecución

1. Clona el repositorio:

```bash
git clone git@github.com:ManuFreelanceProjects/emi-test.git
```

2. Entra al directorio:

```bash
cd emi-test
```

3. Compila la solución:

```bash
dotnet build
```

4. Corre la solución:

```bash
dotnet run
```

## 🔍 **Prueba desde Swagger**

Una vez se encuentre la interfaz Swagger abierta sigue estos pasos:

1. Crea un usuario ejecutando: `/apli/Auth/register`  
2. Autentícate con el usuario creado ejecutando: `/apli/Auth/login`  
3. Copia el token retornado en la respuesta.  
4. Presiona el botón **Authorize**. Pega el token copiado en el campo como se muestra a continuación:

   ```
   Bearer {token_copiado}
   ```

5. Ahora puedes probar cualquier servicio que desees desde Swagger.

## 📌 **Notas**

1. Descripción de cómo implementar autenticación y autorización en la API:

   1.1. Usamos JWT (Json Web Token) para autenticación sin estado y basada en roles.  
   1.2. Agrega autenticación con JWT:

   ```bash
   dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
   dotnet add package Microsoft.IdentityModel.Tokens
   ```

   1.3. Configura la autenticación en `Program.cs`.  
   1.4. Agrega la configuración JWT en `appSettings.json`.  
   1.5. Crea un servicio que resuelva el JWT token.  
   1.6. Usa el atributo `[Authorize]` para proteger las rutas.  
   1.7. Crea un controlador que reciba usuario y contraseña y retorne el JWT.  
   1.8. Prueba las rutas protegidas con el token generado.

## 🗂️ **DataBase Schema**

El archivo **`Schema.sql`** se encuentran las estructuras SQL.
