using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemInformaticPensiune.Data;
using SistemInformaticPensiune.Models;

namespace SistemInformaticPensiune.Pages.Facilitati
{
    public class DeleteModel : PageModel
    {
        private readonly SistemInformaticPensiune.Data.SistemInformaticPensiuneContext _context;

        public DeleteModel(SistemInformaticPensiune.Data.SistemInformaticPensiuneContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Facilitate Facilitate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facilitate = await _context.Facilitate.FirstOrDefaultAsync(m => m.ID == id);

            if (facilitate == null)
            {
                return NotFound();
            }
            else
            {
                Facilitate = facilitate;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facilitate = await _context.Facilitate.FindAsync(id);
            if (facilitate != null)
            {
                Facilitate = facilitate;
                _context.Facilitate.Remove(Facilitate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
