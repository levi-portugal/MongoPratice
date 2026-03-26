using ExempleTestMongo.DTOs;
using ExempleTestMongo.Entities;
using ExempleTestMongo.Entities;
using ExempleTestMongo.Interfaces;
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
                        MenuAddProduct();
                        break;
                    case "2":
                        MenuListProducts();
                        break;
                    case "3":
                        MenuGetById();
                        break;
                    case "4":
                        MenuUpdateProduct();
                        break;
                    case "5":
                        MenuDeleteProduct();
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

        private void MenuAddProduct()
        {
            Console.Write("Nome: ");
            string name = Console.ReadLine();

            Console.Write("Preço: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Estoque: ");
            int stock = int.Parse(Console.ReadLine());

            var newDto = new ProductRequestDto
            {
                Name = name,
                Price = price,
                Stock = stock
            };

            _productService.Add(newDto);

            Console.WriteLine("Produto adicionado!");
        }

        private void MenuListProducts()
        {
            var products = _productService.GetAll();

            foreach (var p in products)
            {
                Console.WriteLine($"{p.Id} | {p.Name} | R$ {p.Price} | Estoque: {p.Stock}");
            }
        }

        private void MenuGetById()
        {
            Console.Write("Digite o ID: ");
            string id = Console.ReadLine();

            var productDto = _productService.GetById(id);

            if (productDto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            Console.WriteLine($"{productDto.Name} - R$ {productDto.Price}");
        }

        private void MenuUpdateProduct()
        {
            Console.Write("ID do produto: ");
            string id = Console.ReadLine();

            Console.Write("Novo nome: ");
            string name = Console.ReadLine();

            Console.Write("Novo preço: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Novo estoque: ");
            int stock = int.Parse(Console.ReadLine());

            var productDto = new ProductRequestDto
            {
                Name = name,
                Price = price,
                Stock = stock
            };

            _productService.Update(id,productDto);

            Console.WriteLine("Produto atualizado!");
        }

        private void MenuDeleteProduct()
        {
            Console.Write("ID do produto: ");
            string id = Console.ReadLine();

            _productService.Delete(id);

            Console.WriteLine("Produto removido!");
        }
    }
}