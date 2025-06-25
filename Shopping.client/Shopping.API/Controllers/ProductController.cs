using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopping.API.Models;
using Shopping.API.Data;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(ProductContext context, ILogger<ProductController> logger)
    {
        private readonly ProductContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<ProductController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _context
                             .Products
                             .Find(p => true)
                             .ToListAsync();
        }
    }
}