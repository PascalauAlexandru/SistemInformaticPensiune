using System.ComponentModel.DataAnnotations;

namespace SistemInformaticPensiune.Models
{
    public class Client
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula"), StringLength(30, MinimumLength = 3)]
        public string? Prenume { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Numele trebuie sa inceapa cu majuscula"), StringLength(30, MinimumLength = 3)]
        public string? Nume { get; set; }

        [StringLength(70)]
        public string? Adresa { get; set; }

        [Required]
        [EmailAddress]
        public string Email {  get; set; }

        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722123456'")]
        public string? Telefon { get; set; }

        [Display(Name = "Nume Complet")]
        public string? NumeComplet => Prenume + " " + Nume;

        public ICollection<Rezervare>? Rezervari { get; set; }

    }
}
