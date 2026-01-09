using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemInformaticPensiune.Data;
using SistemInformaticPensiune.Models;

namespace SistemInformaticPensiune.Pages.Camere
{
    public class DeleteModel : PageModel
    {
        private readonly SistemInformaticPensiune.Data.SistemInformaticPensiuneContext _context;

        public DeleteModel(SistemInformaticPensiune.Data.SistemInformaticPensiuneContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Camera Camera { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camera = await _context.Camera.FirstOrDefaultAsync(m => m.ID == id);

            if (camera == null)
            {
                return NotFound();
            }
            else
            {
                Camera = camera;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
         
            var camera = await _context.Camera.FindAsync(id);

            if (camera != null)
            {
                try
                {
                    Camera = camera;
                    _context.Camera.Remove(Camera);
                    await _context.SaveChangesAsync();
                }catch(Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    ModelState.AddModelError(string.Empty, "Nu se poate sterge această cameraa deoarece este utilizata in alte inregistrari " +
                        "(ex: Rezervari sau Facilitati). Stergeti intai acele inregistrari.");
                    Camera = await _context.Camera
                   .Include(c => c.TipCamera)
                   .FirstOrDefaultAsync(m => m.ID == id);
                    return Page();
                }                
            }

            return RedirectToPage("./Index");
        }
    }
}
