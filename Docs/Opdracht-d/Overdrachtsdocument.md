# OVERDRACHTSDOCUMENT - RPG Unity Game
**Best Education B.V.** | Developer: Hamilton Posada | 02 oktober 2025
Repository: https://github.com/HamiltonPDev/RPG-Unity-game

## SETUP
1. Clone repo en open in **Unity 6000.1.10f1** (andere versies niet getest)
2. Start scene: `Assets/Scenes/MainScene.unity`
3. Controleer tags: Player = "Player", Enemies = "Enemy"

## ARCHITECTUUR
**Player systeem:** `PlayerController.cs` (movement/input), `CharacterStats.cs` (stats/leveling), `HealthManager.cs` (damage), `DontDestroyOnLoad.cs` (persistence tussen scenes)

**Enemy systeem:** `EnemyAI.cs` (state machine: Patrol→Chase→Attack→Idle), `EnemyStats.cs` (scaling met player level). **Let op:** `EnemyController.cs` is deprecated, niet gebruiken.

**Scene management:** `GoToNewPlace.cs` (transitions), `SpawnZone.cs` (spawn posities). Player blijft bestaan tussen scenes via DontDestroyOnLoad.

**UI:** `UIManager.cs` update real-time health/XP/level displays.

## GAME FLOW
MainScene start → Combat (XP gain) → Level up (stats +) → 3 scenes exploreerbaar → Victory (alle enemies dood) / Defeat (health = 0)

## PRIORITEITEN VOOR VOLGENDE ITERATIE
1. **KRITISCH:** Best Education branding (logo + slogan op UI)
2. **HIGH:** Victory/Game Over screens met restart buttons (code `RestartGame()` bestaat al)
3. **MEDIUM:** Audio systeem, Save/Load functionaliteit
4. **LOW:** UI polish, meer enemy types, inventory

## BEKENDE ISSUES
- Victory/defeat gebruiken basic GameObject deactivation (geen proper screens)
- Restart button ontbreekt in UI (functie wel beschikbaar)
- Enemies kunnen soms stuck raken bij obstacles tijdens patrol
- Scene spawn kan falen als SpawnZone marker ontbreekt

## DEBUG TIPS
- Console errors checken (Ctrl+Shift+C)
- Player/Enemy tags correct? Check Project Settings → Tags
- Scene in Build Settings? Check File → Build Settings
- Enemy AI issues? Controleer NavMesh baking