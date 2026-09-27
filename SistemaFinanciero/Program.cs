using Microsoft.EntityFrameworkCore;
using SistemaFinanciero.Data;
using SistemaFinanciero.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar Entity Framework Core con PostgreSQL
builder.Services.AddDbContext<FinancialDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Configurar HotChocolate GraphQL
builder.Services
    .AddGraphQLServer()
    .RegisterDbContextFactory<FinancialDbContext>()
    .AddQueryType(q => q.Name("Query"))
        .AddTypeExtension<AccountConceptQueries>()
    .AddMutationType(m => m.Name("Mutation"))
        .AddTypeExtension<AccountConceptMutations>();

var app = builder.Build();

// 3. Mapear el endpoint de GraphQL
app.MapGraphQL();

app.Run();