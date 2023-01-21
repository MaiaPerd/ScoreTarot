using DTOs;

namespace APIGraphQL.Query
{
    public class Query
    {
        public JoueurDto GetJoueur() =>
            new JoueurDto
            {
                Id = 0,
                Pseudo = "test"
            };

        public MancheDto GetManche() =>
            new MancheDto
            {
                Id = 0,
                JoueurQuiPrend = new JoueurDto { Id = 1 },
            };
    }
}
