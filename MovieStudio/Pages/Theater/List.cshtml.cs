using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MovieStudio.Core;
using MovieStudio.Data;

namespace MovieStudio.Pages.Theater
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration congif;
        private readonly ITheaterData theaterData;

        public string Message { get; set; }
        public IEnumerable<Theaters> Theaters { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration congif, ITheaterData theaterData)
        {
            this.congif = congif;
            this.theaterData = theaterData;
        }

        public void OnGet(string searchTerm)
        {
            Message = congif["Message"];
            Theaters = theaterData.GetTheaterByName(SearchTerm);
        }
    }
}
