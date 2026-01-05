using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemInformaticPensiune.Data;
using SistemInformaticPensiune.Models;

namespace SistemInformaticPensiune.Pages.Rezervari
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
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeComplet");
            ViewData["CameraID"] = new SelectList(_context.Camera, "ID", "Numar");
            return Page();
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            // Ignoram validarea pentru obiectele de navigare (Navigation Properties)
            ModelState.Remove("Rezervare.Client");
            ModelState.Remove("Rezervare.Camera");

            if(Rezervare.DataSfarsit <= Rezervare.DataInceput)
            {
                ModelState.AddModelError("", "Erroare: Data de Check-out trebuie sa fie dupa data de Check-in!");
                //Re-populam listele dropdown pentru ca pagina sa se poata reincarca corect
                ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeComplet");
                ViewData["CameraID"] = new SelectList(_context.Camera, "ID", "Numar");
                return Page(); //oprim executia si ramanem pe pagina Create pentru a afisa eroarea
            }

            if (!ModelState.IsValid)
            {
                ViewData["ClientID"] = new SelectList(_context.Client, "ID", "NumeComplet");
                ViewData["CameraID"] = new SelectList(_context.Camera, "ID", "Numar");
                return Page();
            }

            //Se salveaza in baza de date
            _context.Rezervare.Add(Rezervare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
