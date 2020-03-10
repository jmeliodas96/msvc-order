using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using msvc_order.Controllers;
using msvc_order.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace msvc_order.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("api/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly BakeryContext db;  
        public ProductController(BakeryContext db) => this.db = db; 
       
        public Product FeaturedProduct { get; set; }  

        ///api/product
        [HttpGet]
        [ActionName("product")]
        public async Task<List<Product>> OnGetAsync()
        {
            var Products = await db.Products.ToListAsync(); 
            return Products;
        }

        ///api/feature
        [HttpGet]
        [ActionName("feature")]
        public async Task<Product> OnGetAsyncProduct()
        {
            var Products = await db.Products.ToListAsync();
            FeaturedProduct = Products.ElementAt(new Random().Next(Products.Count));
            return FeaturedProduct;
        }

        ///api/detail/1
        [HttpGet("{id}")]
        [ActionName("detail")]
        public async Task<Product> OnGetProductDetail(int id)
        {
            var ProductDetail = await db.Products.FindAsync(id);
            return ProductDetail;
        }



    }

}