using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieStudio.Core;
using MovieStudio.Data;

namespace MovieStudio.Pages.Theater
{
    public class DetailModel : PageModel
    {
        private readonly ITheaterData theaterData;

        public Theaters Theaters { get; set; }

        [TempData]
        public string Message { get; set; }

        public DetailModel(ITheaterData theaterData)
        {
            this.theaterData = theaterData;
        }

        public IActionResult OnGet(int theaterId)
        {
            Theaters = theaterData.GetById(theaterId);
            if (Theaters == null)
                return RedirectToPage("./NotFound");
            return Page();
        }
    }
}