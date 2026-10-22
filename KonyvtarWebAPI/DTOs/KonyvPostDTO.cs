using System.ComponentModel.DataAnnotations;

namespace KonyvtarWebAPI.DTOs
{
    public class KonyvPostDTO
    {
        [Required(ErrorMessage = "A cím megadása kötelező!")]
        [MaxLength(150, ErrorMessage = "A cím maximum 150 karakter lehet!")]
        public string Cim { get; set; }
        public int KiadasEve { get; set; }
        [Required(ErrorMessage = "A szerző megadása kötelező!")]
        public int SzerzoId { get; set; }
    }
}
