# JeuRPG & MSTest

## Sommaire

- [Introduction](#introduction)
- [JeuRPG](#jeurpg)
- [MSTest](#mstest)
- [Contributions](#contributions)

## Introduction

MSTest-Formation est un dépôt contenant une application console qui simule un jeu de type RPG ainsi qu'un projet MSTest. L'objectif est d'apprendre à réaliser plusieurs types de tests (bout en bout, intégration, unitaires, etc.) avec le framework MSTest ainsi que le package FluentAssertion.

## JeuRPG

[JeuRPG](https://github.com/Corentin-cott/MSTest-Formation/tree/main/JeuRPG) est une application console qui servira de support pour ma formation. C'est un jeu de type RPG, basé sur des combats par vagues. À chaque vague, un monstre généré aléatoirement apparaîtra. Et à chaque combat gagné, le joueur gagne un point d'attribut à attribuer à l'une de ses statistiques : Vie, Attaque, Défense, Magie.

Le jeu est composé de 2 classes :
- **Entitee** (Bool Joueur, String Nom, Int Vie, Int MaxVie, Int Attaque, Int Défense, Int Magie)
- **Combat** (Int NbVagues)

La classe Entitee possède les méthodes d'actions ainsi que celles gérant l'augmentation des statistiques avec les attributs. Elle gère à la fois les actions du joueur et celles du monstre.
La classe Combat gère la génération des monstres, les calculs de dégâts ainsi que les soins.

## [MSTest](https://learn.microsoft.com/fr-fr/dotnet/core/testing/unit-testing-with-mstest)

[MSTest](https://github.com/Corentin-cott/MSTest-Formation/tree/main/MSTest) est un framework de tests pour les applications .NET. Il permet de créer, organiser et exécuter des tests automatisés afin de vérifier le bon fonctionnement du code. MSTest supporte différents types de tests, y compris les tests unitaires, les tests d'intégration et les tests de bout en bout.

Dans ce projet, nous utilisont aussi la package [FluentAssertion](https://fluentassertions.com/)

## Contributions

[Corentin COTTEREAU](https://github.com/Corentin-cott)
