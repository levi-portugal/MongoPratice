using ExempleTestMongo.Entities;
using ExempleTestMongo.Interfaces;
using ExempleTestMongo.Entities;
using ExempleTestMongo.Interfaces;

namespace ExempleTestMongo.View
{
    public class Menu
    {
        private readonly IProductService _productService;

        public Menu(IProductService productService)
        {
            _productService = productService;
        }

        public void Show()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1 - Adicionar Produto");
                Console.WriteLine("2 - Listar Produtos");
                Console.WriteLine("3 - Buscar por ID");
                Console.WriteLine("4 - Atualizar Produto");
                Console.WriteLine("5 - Remover Produto");
                Console.WriteLine("0 - Sair");

                Console.Write("Escolha: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        ListProducts();
                        break;
                    case "3":
                        GetById();
                        break;
                    case "4":
                        UpdateProduct();
                        break;
                    case "5":
                        DeleteProduct();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private void AddProduct()
        {
            Console.Write("Nome: ");
            string name = Console.ReadLine();

            Console.Write("Preço: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Estoque: ");
            int stock = int.Parse(Console.ReadLine());

            var product = new Product
            {
                Name = name,
                Price = price,
                Stock = stock
            };

            _productService.Add(product);

            Console.WriteLine("Produto adicionado!");
        }

        private void ListProducts()
        {
            var products = _productService.GetAll();

            foreach (var p in products)
            {
                Console.WriteLine($"{p.Id} | {p.Name} | R$ {p.Price} | Estoque: {p.Stock}");
            }
        }

        private void GetById()
        {
            Console.Write("Digite o ID: ");
            Guid id = Guid.Parse(Console.ReadLine());

            var product = _productService.GetById(id);

            if (product == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            Console.WriteLine($"{product.Name} - R$ {product.Price}");
        }

        private void UpdateProduct()
        {
            Console.Write("ID do produto: ");
            Guid id = Guid.Parse(Console.ReadLine());

            Console.Write("Novo nome: ");
            string name = Console.ReadLine();

            Console.Write("Novo preço: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Novo estoque: ");
            int stock = int.Parse(Console.ReadLine());

            var product = new Product
            {
                Id = id,
                Name = name,
                Price = price,
                Stock = stock
            };

            _productService.Update(product);

            Console.WriteLine("Produto atualizado!");
        }

        private void DeleteProduct()
        {
            Console.Write("ID do produto: ");
            Guid id = Guid.Parse(Console.ReadLine());

            _productService.Delete(id);

            Console.WriteLine("Produto removido!");
        }
    }
}