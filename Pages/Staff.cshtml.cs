using e_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Pages
{
    public class StaffModel : PageModel
    {
        private readonly EcommerceContext _ecommerceContext;

        public StaffModel(EcommerceContext? _ecommerceContext)
        {
            this._ecommerceContext = _ecommerceContext;
        }

        public List<Staff> Staffs { get; set; }
        public void OnGet()
        {
            Staffs = _ecommerceContext.Staffs
                .Include(s => s.Manager)
                .Include(s => s.InverseManager)
                .ToList();
        }
    }
}

