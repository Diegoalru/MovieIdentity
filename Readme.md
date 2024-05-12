# MovieIdentity

## Descripción

MovieIdentity es un proyecto de ASP.NET Core que utiliza Identity para la autenticación y autorización de usuarios. También incluye la generación de códigos QR para la autenticación de dos factores.

## Tecnologías utilizadas

- .Net 8
- C#
- ASP.NET Core
- Identity
- QRCoder
- Entity Framework Core

## Configuración

Para configurar el proyecto, necesitas una cadena de conexión a la base de datos en tu archivo de configuración. Puedes agregarla en el archivo `appsettings.json` bajo la clave `"MovieAuthConnection"`.
Tambien configura un usuario administrador en el archivo `appsettings.json` bajo la clave `"AdminUser"`. Este usuario será creado al ejecutar el proyecto.

```json
{
  "ConnectionStrings": {
    "MovieAuthConnection": "Server=localhost;Database=MovieAuth;User Id=sa;Password=your_password;"
  },
  "AdminUser": {
    "Email": "admin@contoso.com"
  }
}
```

# Paquetes NuGet

- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.AspNetCore.Identity.UI
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- QRCoder

## Instalación

1. Clona el repositorio: `git clone https://github.com/diegoalru/MovieIdentity.git`
2. Navega al directorio del proyecto: `cd MovieIdentity`
3. Instala las dependencias: `dotnet restore`

# Notas del desarrollo

- `dotnet ef migrations add InitialCreate` para crear la migración.
- `dotnet ef database update` para aplicar la migración a la base de datos.
- `dotnet aspnet-codegenerator identity --useDefaultUI --dbContext MovieAuth` para generar las páginas de Identity.
- `dotnet aspnet-codegenerator identity --useDefaultUI --dbContext MovieAuth --files "Account.Register;Account.Login --force"` para generar las páginas de registro y login, con la opción `--force` para sobreescribir las páginas existentes.

## Uso

Para ejecutar el proyecto, puedes usar el comando `dotnet run` en la raíz del proyecto.
