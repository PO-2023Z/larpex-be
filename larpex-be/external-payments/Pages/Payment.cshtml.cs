using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace external_payments.Pages
{
    public class PaymentModel : PageModel
    {
        public void OnGet()
        {
        }


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost(string urlReturn, string urlRedirect)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    await httpClient.PostAsync(urlReturn, null);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Redirect(urlRedirect);
        }
    }
}
