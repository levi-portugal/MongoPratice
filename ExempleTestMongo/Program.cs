using ExempleTestMongo.Interfaces;
using ExempleTestMongo.Services;
using ExempleTestMongo.Interfaces;
using ExempleTestMongo.Services;
using ExempleTestMongo.View;

class Program
{
    static void Main()
    {
        IProductService productService = new ProductService();

        var menu = new Menu(productService);
        menu.Show();
    }
}