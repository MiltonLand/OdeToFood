using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace OdeToFood1.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        public IConfiguration Config { get; }

        public ListModel(IConfiguration config)
        {
            Config = config;
        }

        public void OnGet()
        {
            Message = Config["Message"];
        }
    }
}
