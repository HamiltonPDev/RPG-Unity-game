# RPG Unity Game - K0788 Examen Project

## Project Overzicht

Een 2D RPG game ontwikkeld in Unity voor het K0788 examen "Basis Programmeren van Games".

**Student:** Hamilton Posada
**Examen:** K0788 - Basis Programmeren van Games
**Periode:** 2 weken development cycle
**Game Engine:** Unity 2D

## Game Features

-   **Player Movement:** WASD/Arrow key control met smooth beweging
-   **Combat System:** Real-time gevechten met damage calculations
-   **Enemy AI:** Intelligente vijanden met patrol en chase behavior
-   **Health Management:** Player en enemy health systems
-   **UI Management:** Stats display (strength, defense, health)
-   **Scene Transitions:** Seamless overgangen tussen game areas
-   **Spawn System:** Dynamic enemy spawning in designated zones

### Ontwikkelomgeving

-   **Game Engine:** Unity 2020.3 LTS
-   **Scripting Language:** C#
-   **IDE:** Visual Studio Code / Visual Studio
-   **Version Control:** Git + GitHub

### Core Scripts

-   `PlayerController.cs` - Player movement en input handling
-   `DamagePlayer.cs` - Damage calculation en combat mechanics
-   `EnemyAI.cs` - Enemy behavior en pathfinding
-   `CharacterStats.cs` - Player statistics management
-   `HealthManager.cs` - Health system voor player en enemies
-   `UIManager.cs` - User interface updates
-   `SpawnZone.cs` - Enemy spawning mechaniek
-   `GoToNewPlace.cs` - Scene transition handling
-   `CameraFollow.cs` - Camera movement en follow logic
-   `DontDestroyOnLoad.cs` - Persistent objects tussen scenes

### Vereisten

-   Unity Hub
-   Unity Editor versie 2020.3 LTS
-   Visual Studio Code of Visual Studio
-   Git

## Game Controls

-   **WASD / Arrow Keys:** Player movement
-   **ClickDown:** Attack action

## Code Kwaliteit

-   Alle scripts bevatten uitgebreide commentaren voor duidelijkheid
-   Consistent gebruik van naming conventions
-   Modulaire code structuur voor onderhoudbaarheid
-   Error handling waar nodig

## Toekomstige Ontwikkelingen

**Aanbevolen verbeteringen:**

-   Uitbreiding van combat system met meer wapens
-   AI is nog niet volledig geïmplementeerd
-   Inventory management systeem
-   Quest systeem voor verhaal progressie
-   Audio implementatie (SFX en background music)
-   Save/Load functionaliteit

**Technische verbeteringen:**

-   Performance optimalisatie voor mobile deployment
-   Advanced AI behaviors

## Projectstructuur

```
Assets/
├── Scripts/           # Alle C# scripts
├── Sprites/          # 2D graphics en textures
├── Scenes/           # Unity scenes
├── Prefabs/          # Reusable game objects
└── UI/               # User interface assets
```

## Contact & Documentatie

-   **Developer:** Hamilton Posada
