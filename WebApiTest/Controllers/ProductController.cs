using ExempleTestMongo.DTOs;
using ExempleTestMongo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")] // Define a URL base como: api/products
    [ApiController]// Indica que esta classe responde a requisições HTTP
    public class ProductController : ControllerBase
    {
        //injeçãozinha humilde
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //Começa a configuração dos métodos Get,Post,Put,Delete etc

        [HttpGet]//Get para listagem
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products); //200
        }

        [HttpGet("{id}")] //Get que aceita parametro na URL
        public IActionResult GetById(string id)
        {
            var product = _productService.GetById(id);
            if (product == null) return NotFound(); //retorna 404

            return Ok(product); //200
        }

        [HttpPost]//criaçção
        public IActionResult Create([FromBody] ProductRequestDto dto)
        {
            _productService.Add(dto);
            //ideal retornar 201
            return StatusCode(201, dto);
        }

        [HttpPut("{id}")] //para Editar
        public IActionResult Update (string id, [FromBody] ProductRequestDto dto)
        {
            _productService.Update(id, dto);
            return NoContent(); //204, Sucesso, mas sem conteudo no corpo
        }

        [HttpDelete("{id}")] //Para deletar
        public IActionResult Delete(string id)
        {
            _productService.Delete(id);
            return NoContent();
        }

    }
}
