namespace APIRest.DTOs
{
    public class JoueurDto
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public string URLIMG { get; private set; }
    }
}