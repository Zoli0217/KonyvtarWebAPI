using System.ComponentModel.DataAnnotations;

namespace KonyvtarWebAPI.Models
{
    public class Szerzo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A név megadása kötelező!")]
        [MaxLength(100,ErrorMessage = "A név maximum 100 karakter lehet!")]
        public string Nev { get; set; }
        public int? SzuletesiEv { get; set; }

        public IList<Konyv> Konyvei { get; set; }

    }
}
