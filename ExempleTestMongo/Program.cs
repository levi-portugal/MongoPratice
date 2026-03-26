using ExempleTestMongo.Data;
using ExempleTestMongo.Data.Repositories;
using ExempleTestMongo.Entities;
using ExempleTestMongo.Interfaces;
using ExempleTestMongo.Services;
using ExempleTestMongo.View;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        // 1. Configuração do Serializer (GUID)
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

        // 2. Setup do Container de DI
        var services = new ServiceCollection();

        services.AddSingleton(new MongoContext("mongodb://localhost:27017", "CatalogoProdutos"));
        services.AddScoped<IRepository<Product>>(sp =>
            new Repository<Product>(sp.GetRequiredService<MongoContext>(), "produtos"));
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<Menu>();

        // 3. Inicialização
        var serviceProvider = services.BuildServiceProvider();
        var menu = serviceProvider.GetRequiredService<Menu>();

        menu.Show();
    }
}