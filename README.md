# Actividad 4. Gestión de cuentas, conceptos y movimientos

La actividad se entrega en **SistemaFinanciero** (C# y HotChocolate).

Docker Desktop tiene que estar encendido antes de arrancar.

## SistemaFinanciero

Base de datos en el puerto 5433, usuario `postgres`, contraseña `postgres`, base `SistemaFinancieroDb`.

Si el contenedor ya existe:

```powershell
docker start sistemafinanciero-postgres
```

Si no existe:

```powershell
docker run -d --name sistemafinanciero-postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=SistemaFinancieroDb -p 5433:5432 postgres:16
```

Dentro de la carpeta `SistemaFinanciero`:

```powershell
dotnet tool install --global dotnet-ef --version 10.0.12
dotnet ef database update
dotnet run --launch-profile http
```

GraphQL: [http://localhost:5198/graphql](http://localhost:5198/graphql)

La herramienta `dotnet-ef` solo se instala la primera vez.
