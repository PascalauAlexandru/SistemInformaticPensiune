using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SistemInformaticPensiune.Data;
using SistemInformaticPensiune.Models;

namespace SistemInformaticPensiune.Pages.Clienti
{
    public class DeleteModel : PageModel
    {
        private readonly SistemInformaticPensiune.Data.SistemInformaticPensiuneContext _context;

        public DeleteModel(SistemInformaticPensiune.Data.SistemInformaticPensiuneContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FirstOrDefaultAsync(m => m.ID == id);

            if (client == null)
            {
                return NotFound();
            }
            else
            {
                Client = client;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client != null)
            {
                try
                {
                    Client = client;
                    _context.Client.Remove(Client);
                    await _context.SaveChangesAsync();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                   
                   ModelState.AddModelError(string.Empty, "Nu se poate șterge acest client deoarece are rezervări active în sistem. Ștergeți întâi rezervările clientului.");

                    
                    Client = await _context.Client.FirstOrDefaultAsync(m => m.ID == id);

                    return Page();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
