using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemInformaticPensiune.Data;
using SistemInformaticPensiune.Models;

namespace SistemInformaticPensiune.Pages.TipuriCamera
{
    public class CreateModel : PageModel
    {
        private readonly SistemInformaticPensiune.Data.SistemInformaticPensiuneContext _context;

        public CreateModel(SistemInformaticPensiune.Data.SistemInformaticPensiuneContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TipCamera TipCamera { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TipCamera.Add(TipCamera);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
