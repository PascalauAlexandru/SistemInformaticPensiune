using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemInformaticPensiune.Models
{
    public class Camera
    {
        public int ID {  get; set; }
        [Required,Display(Name ="Numar Camera")]
        public string Numar {  get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "Tip Camera")]
        public int? TipCameraID { get; set; }
        public TipCamera? TipCamera { get; set; }
        public ICollection<FacilitateCamera> FacilitatiCamera { get; set; }
        
    }
}
