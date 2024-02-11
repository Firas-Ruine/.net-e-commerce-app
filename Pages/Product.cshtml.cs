using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using e_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Pages
{
    public class ProductModel : PageModel
    {
        private readonly EcommerceContext _ecommerceContext;

        // Constructor injection for EcommerceContext
        public ProductModel(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        // Property to hold the list of products
        public List<Product> Products { get; set; }
        public List<string> StoreNames { get; set; } = new List<string>(); // Initialize the list

        // Handler method for HTTP GET requests
        public void OnGet(int? productId)
        {
            // Retrieve products with related category, brand, and stocks information
            IQueryable<Product> productsQuery = _ecommerceContext.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Stocks)
                .Include(p => p.OrderItems)
                .Include(p => p.Stocks)
                    .ThenInclude(s => s.Store);

            // Check if productId parameter is provided
            if (productId.HasValue)
            {
                // Filter products by productId
                productsQuery = productsQuery.Where(p => p.ProductId == productId);
            }

            // Execute the query and assign the result to Products property
            Products = productsQuery.ToList();

            // Populate StoreNames with store names
            StoreNames = _ecommerceContext.Stores.Select(s => s.StoreName).ToList();
        }

    }

    }
