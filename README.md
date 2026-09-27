# Actividad 4. Gestión de cuentas, conceptos y movimientos

El repositorio tiene dos programas. La actividad se entrega en **SistemaFinanciero** (C# y HotChocolate). **Actividad3_FastAPI** es una versión en Python de cuentas y conceptos, sin la relación cuenta-concepto.

Docker Desktop tiene que estar encendido antes de cualquiera de los dos.

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

## Actividad3_FastAPI

Dentro de la carpeta `Actividad3_FastAPI`:

```powershell
docker compose up -d --build
```

GraphQL: [http://localhost:8000/graphql](http://localhost:8000/graphql)

Esa base usa el puerto 5432 y la contraseña `tu_password`. Si PostgreSQL de Windows ya ocupa el 5432, el contenedor no puede arrancar. Los movimientos de la actividad no se programan en esta carpeta.
