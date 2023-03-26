using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CutConnect_ASP.NET_CORE.Views.Customer
{
    public class cart : PageModel
    {
        private readonly ILogger<cart> _logger;

        public cart(ILogger<cart> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}