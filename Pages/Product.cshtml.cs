using System.Collections.Generic;
using System.Linq;
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

        // Handler method for HTTP GET requests
        public void OnGet()
        {
            // Retrieve products with related category, brand, and stocks information
            Products = _ecommerceContext.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Stocks)
                .ToList();
        }
    }
}
