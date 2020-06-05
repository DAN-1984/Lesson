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
        public IEnumerable<BrandDTO> GetBrands() => _ProductData.GetBrands();
        
        [HttpGet("{id}")]
        public ProductDTO GetProductById(int id) => _ProductData.GetProductById(id);
        
        [HttpPost]
        public PageProductsDTO GetProducts([FromBody] ProductFilter Filter = null) => _ProductData.GetProducts(Filter);
        
        [HttpGet("sections")]
        public IEnumerable<SectionDTO> GetSections() => _ProductData.GetSections();

        [HttpGet("sections/{id}")]
        public SectionDTO GetSectionById(int id) => _ProductData.GetSectionById(id);

        [HttpGet("brands/{id}")]
        public BrandDTO GetBrandById(int id) => _ProductData.GetBrandById(id);
    }
}