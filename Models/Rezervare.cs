using System.ComponentModel.DataAnnotations;

namespace SistemInformaticPensiune.Models
{
    public class Rezervare
    {
        public int ID {  get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }

        public int? CameraID { get; set; }
        public Camera? Camera { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Check-in")]
        public DateTime DataInceput { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Check-out")]
        public DateTime DataSfarsit { get; set; }
    }
}
