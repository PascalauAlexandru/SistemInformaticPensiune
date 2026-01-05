using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemInformaticPensiune.Data;
using SistemInformaticPensiune.Models;
using SistemInformaticPensiune.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace SistemInformaticPensiune.Pages.Camere
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
            // Dropdown pentru Tip Camera
            ViewData["TipCameraID"] = new SelectList(_context.TipCamera, "ID", "Tip");

            // Pregatim lista de checkbox-uri
            var camera = new Camera();
            camera.FacilitatiCamera = new List<FacilitateCamera>();
            PopulateAssignedFacilitateData(_context, camera);

            return Page();
        }

        [BindProperty]
        public Camera Camera { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(string[] selectedFacilitati)
        {
            var newCamera = new Camera();

            if (selectedFacilitati != null)
            {
                newCamera.FacilitatiCamera = new List<FacilitateCamera>();
                foreach (var fac in selectedFacilitati)
                {
                    var facToAdd = new FacilitateCamera
                    {
                        FacilitateID = int.Parse(fac)
                    };
                    newCamera.FacilitatiCamera.Add(facToAdd);
                }
            }

            // Mapare restul proprietatilor din formular
            newCamera.Numar = Camera.Numar;
            newCamera.Price = Camera.Price;
            newCamera.TipCameraID = Camera.TipCameraID;

            _context.Camera.Add(newCamera);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        // Logica pentru afisarea checkbox-urilor 
        public List<AssignedFacilitateData> AssignedFacilitateDataList;

        public void PopulateAssignedFacilitateData(SistemInformaticPensiuneContext context, Camera camera)
        {
            var allFacilitati = context.Facilitate;
            var cameraFacilitati = new HashSet<int>(camera.FacilitatiCamera.Select(c => c.FacilitateID));
            AssignedFacilitateDataList = new List<AssignedFacilitateData>();
            foreach (var fac in allFacilitati)
            {
                AssignedFacilitateDataList.Add(new AssignedFacilitateData
                {
                    FacilitateID = fac.ID,
                    Nume = fac.NumeFacilitate,
                    Assigned = cameraFacilitati.Contains(fac.ID)
                });
            }
        }
    }
}