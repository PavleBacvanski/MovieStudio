using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStudio.Core;
using MovieStudio.Data;

namespace MovieStudio.Pages.Theater
{
    public class EditModel : PageModel
    {
        private readonly ITheaterData theaterData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Theaters Theaters { get; set; }
        public IEnumerable<SelectListItem> Performances { get; set; } 

        public EditModel(ITheaterData theaterData, IHtmlHelper htmlHelper)
        {
            this.theaterData = theaterData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? theaterID)
        {
            Performances = htmlHelper.GetEnumSelectList<PerformanceType>();
            if (theaterID.HasValue)
                Theaters = theaterData.GetById(theaterID.Value);
            else
                Theaters = new Theaters();

            if (Theaters == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                Performances = htmlHelper.GetEnumSelectList<PerformanceType>();
                return Page();
            }
            if (Theaters.Id > 0)
                theaterData.Update(Theaters);
            else
                theaterData.Add(Theaters);

                theaterData.Commint();
            TempData["Message"] = "Theater saved!";
                return RedirectToPage("./Detail", new { theaterID  = Theaters.Id});
        }
    }
}