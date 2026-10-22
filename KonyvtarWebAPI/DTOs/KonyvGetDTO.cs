using KonyvtarWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace KonyvtarWebAPI.DTOs
{
    public class KonyvGetDTO
    {
        public string Cim { get; set; }
        public int KiadasEve { get; set; }
        public int SzerzoId { get; set; }

        public string SzerzoNev { get; set; }
    }
}
