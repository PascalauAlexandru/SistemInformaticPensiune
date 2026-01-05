using Microsoft.EntityFrameworkCore;
using SistemInformaticPensiune.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SistemInformaticPensiune.Data
{
    public class SistemInformaticPensiuneContext : IdentityDbContext
    {
        public SistemInformaticPensiuneContext(DbContextOptions<SistemInformaticPensiuneContext> options)
            : base(options)
        {
        }

        public DbSet<Camera> Camera { get; set; }
        public DbSet<TipCamera> TipCamera { get; set; }
        public DbSet<Facilitate> Facilitate { get; set; }
        public DbSet<FacilitateCamera> FacilitateCamera { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Rezervare> Rezervare { get; set; }
    }
}