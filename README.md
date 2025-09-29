# RPG Unity Game - K0788 Examen

**Basis Programmeren van Games**

**Student:** Hamilton Posada
**Opleding:** Bit Academy - Game Development
**Examen Datum:** Oktober 2025
**Examen code:** K0788

## Over dit Project

Dit project is gemaakt als onderdeel van het K0788 examen voor de cursus Basis Programmeren van Games. Het is een eenvoudige 2D RPG game ontwikkeld in Unity, waarin de speler een karakter bestuurt dat vijanden kan bevechten en door verschillende gebieden kan navigeren.
De game is ontwikkeld voor **Best Education B.V.** om hun imago te verjongen en aantrekkelijk te maken voor
studenten tussen 15-18 jaar.

## Repository Structuur

```
|-- Assets/   # Unity game assets(Scripts, Sprites, Scenes, Prefabs, UI)
├── Docs/    # Alle examendocumentatie
| |-- Opdracht-a/ # Documentatie van het proces
| |-- Opdracht-b/ # Voorbereiding en planning
| |-- Opdracht-c/ # Realiseren en testen van de game
| |-- Opdracht-d/ # Presentatie en overdracht
|-- Builds/  # Gebouwde versies van de game
└── README/  # Dit bestand
```

## Examendocumentatie

## Opdracht A: Documentatie van het Proces

-   📃 [Logboek](Docs/Opdracht-a/) - Dagelijks werkproces.
-   🔗 Git Repository: [Commits](https://github.com/HamiltonPDev/RPG-Unity-game/commits/main/).
-   💻 Code Commentaar - Te vinden in alle scripts in `Assets/Scripts`.

## Opdracht B: Voorbereiding en Game Design

-   📃 [Game Design Document (GDD)](Docs/Opdracht-b/Project%20Design%20Document.pdf) - Goedgekeurd door mr. Jacobs
-   📃 [Ontwikkelomgeving](Docs/Opdracht-b/Ontwikkelomgeving.md) - Specificaties hardware en software

## Opdracht C: Realiseren en Testen

-   🎮 [Speelbare Game](Builds/) - Werkende build.
-   📃 [Testverlagen](Docs/Opdracht-c/) - Gebruikerstests met feedback en aanpassingen.

## Opdracht D: Presentatie en Overdracht

-   📃 [Overdrachtsdocument](Docs/Opdracht-d/) - Handleiding voor developer
-   📊 [Presentatie](Docs/Opdracht-d/) - Eindpresentatie van het project

## Technische Specificaties

-   **Unity Versie:** 6000.1.10f1
<!-- - **Platform:** [Windows/Mac/WebGL] -->
-   **Programmeertaal:** C#

## Game Features

### Geïmplementeerd volgens MoSCoW Blacklog methode:

✅ MUSTS (6/6 - 100%)

1. ✅ Game kan worden gestart
2. ✅ Speler kan game/karakters besturen (WASD/Arrow keys)
3. ⚠️ Speler kan winnen (basis geïmplementeerd, moet getest)
4. ⚠️ Speler kan verliezen (basis geïmplementeerd, moet getest)
5. ✅ Game kan opnieuw worden gestart
6. ❌ Best Education B.V. branding (naam, logo, slogan) - NOG TE DOEN

⚠️ SHOULDS (1/2 - 50%)

1. ✅ Score bijhouden - NOG TE DOEN
2. ❌ Toenemende moeilijkheidsgraad - NOG TE DOEN

❌ COULDS (0/2 - Niet gepland)

1. Email verzameling
2. Online scoreboard

❌ WOULDS (Niet gepland)

1. Online multiplayer

### Technische Features

-   Real-time combat met damage calculations
-   Intelligent enemy AI met patrol patterns
-   Smooth player movement en controls
-   Dynamic spawn system voor enemies
-   Scene management en transitions
-   Health en score tracking
-   Health management voor player en enemies
-   UI elementen voor health bar en score display
-   UI system voor stats display

## Installatie & Uitvoeren

1. Clone deze repository
2. Open project in Unity 6000.1.10f1
3. Open scene: `Assets/Scenes/MainScene.unity`
4. Druk op Play

Of download de [gebouwde versie](builds/).
