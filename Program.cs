using Microsoft.EntityFrameworkCore;
using SistemInformaticPensiune.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SistemInformaticPensiuneContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SistemInformaticPensiuneContext") ?? throw new 
            InvalidOperationException("Connection string 'SistemInformaticPensiuneContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SistemInformaticPensiuneContext>();

// Add services to the container.
builder.Services.AddRazorPages(options => {
    options.Conventions.AuthorizeFolder("/Camere");
    options.Conventions.AuthorizeFolder("/Clienti");
    options.Conventions.AuthorizeFolder("/Rezervari");

    options.Conventions.AuthorizeFolder("/TipuriCamera");
    options.Conventions.AuthorizeFolder("/Facilitati");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
