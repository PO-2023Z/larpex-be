using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace external_payments.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult Submit()
        {
            // Redirect to AnotherPage
            return RedirectToPage("/AnotherPage");
        }
    }
}
