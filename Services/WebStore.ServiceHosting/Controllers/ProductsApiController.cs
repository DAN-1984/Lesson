using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.ServiceHosting.Controllers
{
    [Route(WebAPI.Products)]
    [ApiController]
    public class ProductsApiController : ControllerBase, IProductData
    {
        private readonly IProductData _ProductData;

        public ProductsApiController(IProductData ProductData) => _ProductData = ProductData;

        [HttpGet("brands")]
        public IEnumerable<Brand> GetBrands() => _ProductData.GetBrands();
        
        [HttpGet("{id}")]
        public ProductDTO GetProductById(int id) => _ProductData.GetProductById(id);
        
        [HttpPost]
        public IEnumerable<ProductDTO> GetProducts([FromBody] ProductFilter Filter = null) => _ProductData.GetProducts(Filter);
        
        [HttpGet("sections")]
        public IEnumerable<Section> GetSections() => _ProductData.GetSections();
    }
}