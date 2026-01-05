using System.ComponentModel.DataAnnotations;

namespace SistemInformaticPensiune.Models
{
    public class Facilitate
    {
        public int ID { get; set; }
        [Required,Display(Name = "Facilitate")]
        public string NumeFacilitate {  get; set; }

        public ICollection<FacilitateCamera>? FacilitatiCamera { get; set; } 
    }
}
