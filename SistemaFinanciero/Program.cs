using Microsoft.EntityFrameworkCore;
using SistemaFinanciero.Data;
using SistemaFinanciero.GraphQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FinancialDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType(q => q.Name("Query"))
        .AddTypeExtension<AccountConceptQueries>()
        .AddTypeExtension<AccountConceptRelationQueries>()
    .AddMutationType(m => m.Name("Mutation"))
        .AddTypeExtension<AccountConceptMutations>()
        .AddTypeExtension<AccountConceptRelationMutations>()
        .AddTypeExtension<TransactionMutations>()
        .AddTypeExtension<TransactionQueries>();

var app = builder.Build();

app.MapGraphQL();

app.Run();