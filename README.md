# ScoreTarot

Bienvenue sur le git de ScoreTarot! 
 
ScoreTarot est une application permettant de gérer les scores d'un utilisateur qui joue au tarot.
En effet cette application peut lui permettre de garder une trace de ses précdentes parties.
Cette application peut aussi lui faciliter certains calculs des scores.

# Sommaire

- [ScoreTarot](#scoreTarot)
- [Requirements](#requirements)
- [Installation](#installation)
    - [Lancement:](#lancement)
- [Architecture de la solution](#architecture-de-la-solution)
- [Auteurs](#auteurs)

# Requirements

Le projet utilise **.NET6**, je vous conseille de le lancé sur **Visual Studio 2022** (ou 2019).

# Installation

Cloné le dépôt du projet: ```git clone https://codefirst.iut.uca.fr/git/cecile.bonal/ScoreTarot.git``` ou directement dans **Visual Studio 2022**.

## Lancement:

- Ouvrir la solution dans visual studio 2022.
- Défénir le projet de démarage entre l'api rest et graphQL en fonction du besoin.

# Architecture de la solution

Les projets:
- APIRest: [**plus d'information**](https://github.com/MaiaPerd/ScoreTarot/wiki/API-Rest)
- APIGraphQL: [**plus d'information**](https://github.com/MaiaPerd/ScoreTarot/wiki/API-GraphQL)
- AppliConsole: Projet de l'application console de ScoreTarot.
- DTOs: reprends les classes du model avec les données que l'ont utilisera dans les différentes APIs.
- EntityFramework: projet qui créer et définie notre base de donnée.
- Model: Les différentes classes utilisé dans la solution.
- Repository
- Service
- Stub: Projet avec des données prédéfinie pour les tests.
- TestsUnitaires: L'ensemble des tests des différent projets.

# Auteurs

Maïa PERDERIZET
Cécile BONAL 
