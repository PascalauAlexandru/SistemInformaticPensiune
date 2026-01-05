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
    public class IndexModel : PageModel
    {
        private readonly SistemInformaticPensiune.Data.SistemInformaticPensiuneContext _context;

        public IndexModel(SistemInformaticPensiune.Data.SistemInformaticPensiuneContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Client = await _context.Client.ToListAsync();
        }
    }
}
