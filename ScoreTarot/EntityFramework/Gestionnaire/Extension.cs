using System.Diagnostics.Contracts;
using EntityFramework.Entity;
using Model;

namespace EntityFramework
{
    public static class Extension
    {
        public static JoueurEntity toEntity(this Joueur joueur)
        {
            JoueurEntity joueurEntity = new JoueurEntity();
            joueurEntity.Age = joueur.Age;
            joueurEntity.URLIMG = joueur.URLIMG;
            joueurEntity.Pseudo = joueur.Pseudo;
            joueurEntity.Nom = joueur.Nom;
            joueurEntity.Prenom = joueur.Prenom;
            return joueurEntity;
        }

        public static IEnumerable<JoueurEntity> toEntities(this List<Joueur> joueurs)
        {
            return joueurs.Select(joueur => joueur.toEntity());
        }

        public static Joueur toModel(this JoueurEntity joueurEntity)
        {
            return new Joueur(joueurEntity.Pseudo, joueurEntity.Age, joueurEntity.Nom, joueurEntity.Prenom, joueurEntity.URLIMG);
        }

        public static IEnumerable<Joueur> toModels(this IEnumerable<JoueurEntity> joueursEntities)
        {
            return joueursEntities.Select(joueur => joueur.toModel());
        }

        public static ContratEntity toEntity(this Contrat contrat)
        {
            if(contrat == Contrat.Garde)
            {
                return ContratEntity.Garde;
            }
            else if (contrat == Contrat.GardeContre)
            {
                return ContratEntity.GardeContre;
            }
            else if (contrat == Contrat.GardeSans)
            {
                return ContratEntity.GardeSans;
            }
            return ContratEntity.Prise;
        }

        public static Contrat toModel(this ContratEntity contratEntity)
        {
            if (contratEntity == ContratEntity.Garde)
            {
                return Contrat.Garde;
            }
            else if (contratEntity == ContratEntity.GardeContre)
            {
                return Contrat.GardeContre;
            }
            else if (contratEntity == ContratEntity.GardeSans)
            {
                return Contrat.GardeSans;
            }
            return Contrat.Prise;
        }

        public static BonusEntity toEntity(this Bonus bonus)
        {
            switch (bonus)
            {
                case Bonus.Escuse:
                    return BonusEntity.Escuse;
                case Bonus.Le21:
                    return BonusEntity.Le21;
                case Bonus.Petit:
                    return BonusEntity.Petit;
                case Bonus.PetitAuBout:
                    return BonusEntity.PetitAuBout;
                case Bonus.SimplePoignet:
                    return BonusEntity.SimplePoignet;
                case Bonus.DoublePoignet:
                    return BonusEntity.DoublePoignet;
            }
            return BonusEntity.TriplePoignet;
        }

        public static IEnumerable<BonusEntity> toEntities(this List<Bonus> bonus)
        {
            return bonus.Select(b => b.toEntity());
        }

        public static Bonus toModel(this BonusEntity bonusEntity)
        {
            switch (bonusEntity)
            {
                case BonusEntity.Escuse:
                    return Bonus.Escuse;
                case BonusEntity.Le21:
                    return Bonus.Le21;
                case BonusEntity.Petit:
                    return Bonus.Petit;
                case BonusEntity.PetitAuBout:
                    return Bonus.PetitAuBout;
                case BonusEntity.SimplePoignet:
                    return Bonus.SimplePoignet;
                case BonusEntity.DoublePoignet:
                    return Bonus.DoublePoignet;
            }
            return Bonus.TriplePoignet;
        }

        public static IEnumerable<Bonus> toModels(this List<BonusEntity> bonusEntities)
        {
            return bonusEntities.Select(bonus => bonus.toModel());
        }

        public static MancheEntity toEntity(this Manche manche)
        {
            MancheEntity mancheEntity = new MancheEntity();
            mancheEntity.Id = manche.Id;
            if(mancheEntity.JoueurAllier!=null)
                mancheEntity.JoueurAllier = manche.JoueurAllier.toEntity();
            mancheEntity.JoueurQuiPrend = manche.JoueurQuiPrend.toEntity();
            mancheEntity.NbJoueur = manche.NbJoueur;
            mancheEntity.Score = manche.Score;
            mancheEntity.Bonus = manche.Bonus.toEntities().ToList();
            mancheEntity.Contrat = manche.Contrat.toEntity();
            mancheEntity.Date = manche.Date;
            return mancheEntity;
        }

        public static IEnumerable<MancheEntity> toEntities(this List<Manche> manches)
        {
            return manches.Select(manche => manche.toEntity());
        }

        public static Manche toModel(this MancheEntity mancheEntity)
        {
            return new Manche(mancheEntity.Contrat.toModel(), mancheEntity.JoueurQuiPrend.toModel(), mancheEntity.Score, mancheEntity.Bonus.toModels().ToList(), mancheEntity.NbJoueur, mancheEntity.JoueurAllier.toModel());
        }

        public static IEnumerable<Manche> toModels(this List<MancheEntity> manchesEntities)
        {
            return manchesEntities.Select(manche => manche.toModel());
        }

        public static PartieEntity toEntity(this Partie partie)
        {
            PartieEntity partieEntity = new PartieEntity();
            partieEntity.Id = partie.Id;
            partie.Joueurs.toEntities().ToList().ForEach(joueur => partieEntity.AjouterJoueur(joueur));
            partieEntity.Manches = partie.Manches.toEntities().ToList();
            return partieEntity;
        }

        public static Partie toModel(this PartieEntity partieEntity)
        {
            return new Partie(partieEntity.Joueurs.toModels().ToList(), partieEntity.Manches.toModels().ToList(), partieEntity.Id);
        }

    }
}