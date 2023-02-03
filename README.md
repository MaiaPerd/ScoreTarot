[![Build Status](https://codefirst.ddns.net/api/badges/cecile.bonal/ScoreTarot/status.svg)](https://codefirst.ddns.net/cecile.bonal/ScoreTarot)  
[![Quality Gate Status](https://codefirst.ddns.net/sonar/api/project_badges/measure?project=ScoreTarot&metric=alert_status)](https://codefirst.ddns.net/sonar/dashboard?id=ScoreTarot)
[![Bugs](https://codefirst.ddns.net/sonar/api/project_badges/measure?project=ScoreTarot&metric=bugs)](https://codefirst.ddns.net/sonar/dashboard?id=ScoreTarot)
[![Code Smells](https://codefirst.ddns.net/sonar/api/project_badges/measure?project=ScoreTarot&metric=code_smells)](https://codefirst.ddns.net/sonar/dashboard?id=ScoreTarot)
[![Coverage](https://codefirst.ddns.net/sonar/api/project_badges/measure?project=ScoreTarot&metric=coverage)](https://codefirst.ddns.net/sonar/dashboard?id=ScoreTarot)  
[![Duplicated Lines (%)](https://codefirst.ddns.net/sonar/api/project_badges/measure?project=ScoreTarot&metric=duplicated_lines_density)](https://codefirst.ddns.net/sonar/dashboard?id=ScoreTarot)
[![Lines of Code](https://codefirst.ddns.net/sonar/api/project_badges/measure?project=ScoreTarot&metric=ncloc)](https://codefirst.ddns.net/sonar/dashboard?id=ScoreTarot)
[![Maintainability Rating](https://codefirst.ddns.net/sonar/api/project_badges/measure?project=ScoreTarot&metric=sqale_rating)](https://codefirst.ddns.net/sonar/dashboard?id=ScoreTarot)
[![Reliability Rating](https://codefirst.ddns.net/sonar/api/project_badges/measure?project=ScoreTarot&metric=reliability_rating)](https://codefirst.ddns.net/sonar/dashboard?id=ScoreTarot)  
[![Security Rating](https://codefirst.ddns.net/sonar/api/project_badges/measure?project=ScoreTarot&metric=security_rating)](https://codefirst.ddns.net/sonar/dashboard?id=ScoreTarot)
[![Technical Debt](https://codefirst.ddns.net/sonar/api/project_badges/measure?project=ScoreTarot&metric=sqale_index)](https://codefirst.ddns.net/sonar/dashboard?id=ScoreTarot)
[![Vulnerabilities](https://codefirst.ddns.net/sonar/api/project_badges/measure?project=ScoreTarot&metric=vulnerabilities)](https://codefirst.ddns.net/sonar/dashboard?id=ScoreTarot)  
 

# ScoreTarot

Bienvenue sur le gitea de ScoreTarot! 
 
ScoreTarot est une application permettant de gérer les scores d'un utilisateur qui joue au tarot.
En effet cette application peut lui permettre de garder une trace de ses précdentes parties.
Cette application peut aussi lui facilité certains calculs des scores.

# Sommaire

- [ScoreTarot](#scoreTarot)
- [Documentation:](#documentation)
- [Requirements](#requirements)
- [Installation](#installation)
    - [Lancement:](#lancement)
- [Architecture de la solution](#architecture-de-la-solution)
- [Auteurs](#auteurs)

# Documentation:

[**Le wiki**](https://codefirst.iut.uca.fr/git/cecile.bonal/ScoreTarot/wiki)

- [**Sketch**](https://codefirst.iut.uca.fr/git/cecile.bonal/ScoreTarot/wiki/Skechs)
- [**Cas d'utilisation**](https://codefirst.iut.uca.fr/git/cecile.bonal/ScoreTarot/wiki/Cas-d%27utilisation)
- [**Diagramme de classes**](https://codefirst.iut.uca.fr/git/cecile.bonal/ScoreTarot/wiki/Diagramme-de-classes)
- [**Diagramme de pacquetage**](https://codefirst.iut.uca.fr/git/cecile.bonal/ScoreTarot/wiki/Diagramme-de-packtage)
- [**Api rest**](https://codefirst.iut.uca.fr/git/cecile.bonal/ScoreTarot/wiki/API-Rest)
- [**Api graphQL**](https://codefirst.iut.uca.fr/git/cecile.bonal/ScoreTarot/wiki/API-GraphQL)

# Requirements

Le projet utilise **.NET6**, je vous conseille de le lancé sur **Visual Studio 2022** (ou 2019).

# Installation

Cloné le dépôt du projet: ```git clone https://codefirst.iut.uca.fr/git/cecile.bonal/ScoreTarot.git``` ou directement dans **Visual Studio 2022**.

## Lancement:

- Ouvrir la solution dans visual studio 2022.
- Défénir le projet de démarage entre l'api rest et graphQL en fonction du besoin.

# Architecture de la solution

Les projets:
- APIRest: [**plus d'information**](https://codefirst.iut.uca.fr/git/cecile.bonal/ScoreTarot/wiki/API-Rest)
- APIGraphQL: [**plus d'information**](https://codefirst.iut.uca.fr/git/cecile.bonal/ScoreTarot/wiki/API-GraphQL)
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

_Generated with a_ **Code#0** _template_  
<img src="Documentation/doc_images/CodeFirst.png" height=40/>   