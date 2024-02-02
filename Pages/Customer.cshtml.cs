using e_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace e_commerce.Pages
{
    public class CustomerModel : PageModel
    {
        private readonly EcommerceContext _ecommerceContext;

        // Constructor injection for EcommerceContext
        public CustomerModel(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        // Property to hold the list of customers
        public List<Customer> Customers { get; set; }

        // Handler method for HTTP GET requests
        public void OnGet()
        {
            // Retrieve customers with related orders information
            Customers = _ecommerceContext.Customers
                .Include(c => c.Orders)
                .ToList();
        }
    }
}
