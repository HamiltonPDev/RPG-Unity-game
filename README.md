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

-   📃 [Logboek](Docs/Opdracht-a/LOGBOEK.pdf) - Dagelijks werkproces.
-   🔗 Git Repository: [Commits](https://github.com/HamiltonPDev/RPG-Unity-game/commits/main/).
-   💻 Code Commentaar - Te vinden in alle scripts in `Assets/Scripts`.

## Opdracht B: Voorbereiding en Game Design

-   📃 [Game Design Document (GDD)](Docs/Opdracht-b/Project%20Design%20Document.pdf) - Goedgekeurd door mr. Jacobs
-   📃 [Ontwikkelomgeving](Docs/Opdracht-b/Ontwikkelomgeving.md) - Specificaties hardware en software

## Opdracht C: Realiseren en Testen

-   🎮 [Speelbare Game](Builds/) - Werkende build ~nog te bepalen.
-   📃 [Testverlagen](Docs/Opdracht-c/Testverslagen.md) - Gebruikerstests met feedback en aanpassingen.

## Opdracht D: Presentatie en Overdracht

-   📃 [Overdrachtsdocument](Docs/Opdracht-d/Overdrachtsdocument.md) - Handleiding voor developer
-   📊 **Presentatie** - Eindpresentatie van het project

## 🎓 Game Status: EXAM READY ✅

**Datum Oplevering:** 8 Oktober 2025
**Versie:** v1.1 (Final)
**Status:** Alle MoSCoW requirements voltooid (100%)

## Technische Specificaties

-   **Unity Versie:** 6000.1.10f1
-   **Platform:** Windows/Mac (Unity Standalone)
-   **Programmeertaal:** C#
-   **Development Periode:** 30 augustus - 8 oktober 2025 (6 weken)

## Game Features

### Geïmplementeerd volgens MoSCoW Blacklog methode:

✅ MUSTS (6/6 - 100% VOLTOOID!)

1. ✅ Game kan worden gestart
2. ✅ Speler kan game/karakters besturen (WASD/Arrow keys)
3. ✅ Speler kan winnen (health = 0 triggers defeat)
4. ✅ Speler kan verliezen (all enemies defeated)
5. ✅ Game kan opnieuw worden gestart
6. ✅ Best Education B.V. branding (naam, logo, slogan) - **VOLTOOID!**

✅ SHOULDS (2/2 - 100%)

1. ✅ Score bijhouden (XP systeem)
2. ✅ Toenemende moeilijkheidsgraad (enemy scaling per level + AI difficulty)

❌ COULDS (0/2 - Niet gepland)

1. Email verzameling
2. Online scoreboard

❌ WOULDS (Niet gepland)

1. Online multiplayer

### ⭐ Unique Selling Point

**Spanish Learning Feature** - Deze game onderscheidt zich van andere RPG's door educatieve waarde toe te voegen. Spelers leren Spaanse vocabulaire tijdens gameplay door interactie met game objects. Perfect voor de doelgroep 15-18 jaar van Best Education B.V.!

**Smart Timer System:** Labels voor de player tonen 3 seconden en verdwijnen automatisch (5 seconden cooldown) - non-intrusive UX. Enemies en tilemap objects blijven zichtbaar voor betere informatieverstrekking.

#### Technische Features

-   **Real-time combat** met damage calculations en defense system
-   **Advanced Enemy AI** met state machine (Patrol → Chase → Attack → Idle)
-   **Smooth player movement** met normalized velocity
-   **Dynamic enemy scaling** (health + damage per player level)
-   **Scene management** met seamless transitions
-   **Experience system** met level progression
-   **Health management** voor player en enemies met I-frames
-   **UI system** voor stats display (health, XP, strength, defense)
-   **Visual feedback** (damage numbers, blood effects, flashing)
-   **🎓 Spanish Learning System** met Best Education B.V. branding
-   **Dual detection modes** (triggers + proximity) voor object labeling
-   **Educational UI** met Spanish/English translations op 20+ objects
-   **Smart Timer System** voor player labels (3s display, 5s cooldown)
-   **Professional branding** met Best Education B.V. logo image

## Installatie & Uitvoeren

1. Clone deze repository
2. Open project in Unity 6000.1.10f1
3. Open scene: `Assets/Scenes/MainScene.unity`
4. Druk op Play

Of download de [gebouwde versie](builds/).
