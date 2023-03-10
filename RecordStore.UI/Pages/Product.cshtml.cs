using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Products;
using Shop.Database;

namespace RecordStore.UI.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;

        public ProductModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty]
        public Test ProductTest { get; set; }

        public class Test
        {
            public string Id { get; set; }
        }

        public GetProduct.ProductViewModel Product { get; set; }

        public IActionResult OnGet(string name)
        {
            Product = new GetProduct(_ctx).Do(name.Replace("-", " "));
            if(Product == null)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost() 
        {
            var current_id = HttpContext.Session.GetString("id");
            HttpContext.Session.SetString("id", ProductTest.Id);


            return RedirectToPage("Index");
        }
    }
}
