namespace DTOs
{
    public class JoueurDto
    {
        public JoueurDto(string pseudo, int age, string nom, string prenom, string uRLIMG)
        {
            Pseudo = pseudo;
            Age = age;
            Nom = nom;
            Prenom = prenom;
            URLIMG = uRLIMG;
        }

        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public string URLIMG { get; private set; }
    }
}