using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;
using WebStore.Infrastructure.Interfaces;
using WebStore.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.ComponentModel.DataAnnotations;
using WebStore.Infrastructure.Mapping;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.Administrator)]
    public class ProductsController : Controller
    {
        private readonly IProductData _ProductData;
        private readonly WebStoreDB _db;

        public ProductsController(IProductData ProductData, WebStoreDB db)
        { 
            _ProductData = ProductData;
            _db = db;
        }

        public IActionResult Index(/*[FromServices] IProductData Products*/) => View(_ProductData.GetProducts().FromDTO());
        
        
        public async Task<IActionResult> Edit(int? id, Product _product)
        {
            var product = id is null ? new Product() : _ProductData.GetProductById((int)id).FromDTO();
            if (_product.Name == null)
            {
                
            }
            else
            {
                Product prod = new Product()
                {
                    Name = _product.Name,
                    Order = _product.Order,
                    SectionId = _product.SectionId,
                    BrandId = _product.BrandId,
                    ImageUrl = _product.ImageUrl,
                    Price = _product.Price
                };
                await _db.Products.AddAsync(prod).ConfigureAwait(false);
                await _db.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Edit3(int ? id) // Метод редактирования заполняет форму значениями
        {
            var product = id is null ? new Product() : _ProductData.GetProductById((int)id).FromDTO();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit3(int? id, Product _product) // Метод редактирования после заполнения формы
        {
            var product = id is null ? new Product() : _ProductData.GetProductById((int)id).FromDTO();
            if (_product.Name == null)
            {
               
            }
            else
            {
                product.Name = _product.Name;
                product.Order = _product.Order;
                product.Section.Id = _product.SectionId;
                product.Brand.Id = _product.BrandId.Value;
                product.ImageUrl = _product.ImageUrl;
                product.Price = _product.Price;
             
                _db.Products.Update(product); // Можно не использовать этот метод
                await _db.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = _ProductData.GetProductById(id).FromDTO();

            if (product is null)
                return NotFound();
       
            _db.Products.Remove(_db.Products.Where(o => o.Id == id).FirstOrDefault());
            await _db.SaveChangesAsync().ConfigureAwait(false);

            return View(product);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName(nameof(Delete))]
        public IActionResult DeleteConfirm(int id) => RedirectToAction(nameof(Index));

    }
}