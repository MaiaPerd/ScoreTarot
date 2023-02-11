using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class JoueurDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Pseudo { get; set; }
        [StringLength(15)]
        public string Nom { get; set; }
        [StringLength(20)]
        public string Prenom { get; set; }
        public int Age { get; set; }
        [Url]
        public string URLIMG { get; set; }
    }
}