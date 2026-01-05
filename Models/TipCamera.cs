using System.ComponentModel.DataAnnotations;

namespace SistemInformaticPensiune.Models
{
    public class TipCamera
    {
        public int ID { get; set; }
        [Required, Display(Name = "Denumire Tip")]
        public string Tip { get; set; }

        public ICollection<Camera>? Camere { get; set; }
    }
}
