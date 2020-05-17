﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Mapping;
using WebStore.ViewModels;
using WebStore.ViewModels.Search;

namespace WebStore.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductData _ProductData;

        public SearchController(IProductData ProductData) => _ProductData = ProductData;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(/*IEnumerable<ProductViewModel> product,*/ string searchString)
        {
            var product = _ProductData.GetProducts().FromDTO().ToView().Where(s => s.Name.Contains(searchString));
            return View(product);
        }
    }
}