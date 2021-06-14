using OdeToFood.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.data;


namespace OdeToFood.Pages.Bars
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly BarData barData;

        public string message { get; set; }
        public IEnumerable<bars> Bars { get; set; }

        public ListModel(IConfiguration config, BarData barData)
        {
            this.config = config;
            this.barData = barData;
        }

        public void OnGet()
        {
            message = config["Message"];
        }
    }
}
