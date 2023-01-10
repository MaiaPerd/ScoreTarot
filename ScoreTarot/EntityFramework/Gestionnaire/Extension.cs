using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using EntityFramework.Entity;
using Model;

namespace EntityFramework
{
    public static class Extension
    {
        public static JoueurEntity toEntity(this Joueur joueur)
        {
            JoueurEntity joueurEntity = new JoueurEntity
            {
                Age = joueur.Age,
                URLIMG = joueur.URLIMG,
                Pseudo = joueur.Pseudo,
                Nom = joueur.Nom,
                Prenom = joueur.Prenom,
            };
            return joueurEntity;
        }

        public static IEnumerable<JoueurEntity> toEntities(this ReadOnlyCollection<Joueur> joueurs)
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
                case Bonus.Excuse:
                    return BonusEntity.Excuse;
                case Bonus.Le21:
                    return BonusEntity.Le21;
                case Bonus.Petit:
                    return BonusEntity.Petit;
                case Bonus.PetitAuBout:
                    return BonusEntity.PetitAuBout;
                case Bonus.SimplePoignee:
                    return BonusEntity.SimplePoignee;
                case Bonus.DoublePoignee:
                    return BonusEntity.DoublePoignee;
            }
            return BonusEntity.TriplePoignee;
        }

        public static Bonus toModel(this BonusEntity bonusEntity)
        {
            switch (bonusEntity)
            {
                case BonusEntity.Excuse:
                    return Bonus.Excuse;
                case BonusEntity.Le21:
                    return Bonus.Le21;
                case BonusEntity.Petit:
                    return Bonus.Petit;
                case BonusEntity.PetitAuBout:
                    return Bonus.PetitAuBout;
                case BonusEntity.SimplePoignee:
                    return Bonus.SimplePoignee;
                case BonusEntity.DoublePoignee:
                    return Bonus.DoublePoignee;
            }
            return Bonus.TriplePoignee;
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
            mancheEntity.Bonus = manche.Bonus.toEntity();
            mancheEntity.Contrat = manche.Contrat.toEntity();
            mancheEntity.Date = manche.Date;
            return mancheEntity;
        }

        public static IEnumerable<MancheEntity> ToEntities(this ReadOnlyCollection<Manche> manches)
        {
            return manches.Select(manche => manche.toEntity());
        }

        public static Manche ToModel(this MancheEntity mancheEntity)
        {
            return new Manche(mancheEntity.Contrat.toModel(), mancheEntity.JoueurQuiPrend.toModel(), mancheEntity.Score, mancheEntity.Bonus.toModel(), mancheEntity.NbJoueur, mancheEntity.JoueurAllier.toModel());
        }

        public static IEnumerable<Manche> ToModels(this ICollection<MancheEntity> manchesEntities)
        {
            return manchesEntities.Select(manche => manche.ToModel());
        }

        public static PartieEntity ToEntity(this Partie partie)
        {
            PartieEntity partieEntity = new();
            //if(partie.Id != 0)
            //{
                partieEntity.Id = partie.Id;
            //}
            //partie.Joueurs.ToList().ForEach(joueur => partieEntity.AjouterJoueur(joueur.toEntity()));
            partieEntity.Joueurs = partie.Joueurs.toEntities().ToList();
            partieEntity.Manches = partie.Manches.ToEntities().ToList();
            return partieEntity;
        }

        public static Partie ToModel(this PartieEntity partieEntity)
        {
            /*List<Joueur> joueurs = new();
            List<JoueurEntity> joueurEntities = partieEntity.Joueurs.ToList();

            joueurEntities.ForEach(j =>
            {
                //JoueurEntity joueur = joueurEntities.Find(jour => jour.Pseudo.Equals(j.JoueurForeignKey));
                joueurs.Add(j.toModel());
                
            });*/


            return new Partie(partieEntity.Id, partieEntity.Joueurs.toModels(), partieEntity.Manches.ToModels().ToList());
        }

    }
}