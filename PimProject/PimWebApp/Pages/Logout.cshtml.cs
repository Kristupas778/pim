using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace PimWebApp.Pages
{
    public class log_outModel : PageModel
    {
        public string ReturnUrl { get; private set; }
        public async Task<IActionResult> OnGetAsync(
            string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            try
            {
                await HttpContext
                    .SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return LocalRedirect("/");
        }

    }
}

 
