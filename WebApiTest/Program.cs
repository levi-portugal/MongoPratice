using ExempleTestMongo.Data;
using ExempleTestMongo.Data.Repositories;
using ExempleTestMongo.Entities;
using ExempleTestMongo.Interfaces;
using ExempleTestMongo.Services;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

var builder = WebApplication.CreateBuilder(args); //Criando meu builder

//Configurando meu mongo (serialização)
BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

//Adiciona o suporte para controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//O mongo context
builder.Services.AddSingleton(new MongoContext("mongodb://localhost:27017", "CatalogoProdutos"));
//perguntar sobre declarar um novo mongoContext

//repository Generico
builder.Services.AddScoped<IRepository<Product>>(sp =>
    new Repository<Product>(sp.GetRequiredService<MongoContext>(), "produtos"));

//Meu service
builder.Services.AddScoped<IProductService, ProductService>();

//Configuração do APP
var app = builder.Build();

// Configura o Swagger para podermos testar no navegador (apenas em desenvolvimento)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireciona chamadas HTTP para HTTPS por segurança
app.UseHttpsRedirection();

//Importante: Diz ao app para usar os Controllers que eu criei
app.MapControllers();

app.Run();
