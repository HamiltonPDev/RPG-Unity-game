# OVERDRACHTSDOCUMENT - RPG Unity Game
**Best Education B.V.** | Developer: Hamilton Posada | 08 oktober 2025
Repository: https://github.com/HamiltonPDev/RPG-Unity-game

## SETUP
1. Clone repo en open in **Unity 6000.1.10f1** (andere versies niet getest)
2. Start scene: `Assets/Scenes/MainScene.unity`
3. Controleer tags: Player = "Player", Enemies = "Enemy"
4. **NIEUW:** Zie `SPANISH_LABEL_SETUP_GUIDE.md` voor Spanish learning feature setup

## ARCHITECTUUR

**Player systeem:** `PlayerController.cs` (movement/input), `CharacterStats.cs` (stats/leveling), `HealthManager.cs` (damage), `DontDestroyOnLoad.cs` (persistence tussen scenes)

**Enemy systeem:** `EnemyAI.cs` (state machine: Patrol→Chase→Attack→Idle), `EnemyStats.cs` (scaling met player level). **Let op:** `EnemyController.cs` is deprecated, niet gebruiken.

**Scene management:** `GoToNewPlace.cs` (transitions), `SpawnZone.cs` (spawn posities). Player blijft bestaan tussen scenes via DontDestroyOnLoad.

**UI systeem:** `UIManager.cs` update real-time health/XP/level displays.

**✨ NIEUW: Spanish Learning & Branding System (v1.1)**
- `SpanishObjectLabel.cs` - Attach to ANY object (player, enemies, tilemap triggers)
  - **Timer feature:** displayTimer (3s) + cooldownTimer (5s) voor player
  - Set displayTimer = 0 voor enemies/tilemap (always visible)
- `SpanishLabelUIManager.cs` - Centralized UI display manager
  - Uses Image component for Best Education B.V. logo (niet text!)
  - Toont logo + Spanish/English object names
  - Safety check: prevents coroutine errors on inactive panel
- Werkt met collision triggers OF proximity detection
- Smart UX: Player labels auto-hide (non-intrusive), enemies blijven zichtbaar
- Educatieve feature: studenten leren Spaans tijdens gameplay

## GAME FLOW
MainScene start → Combat (XP gain) → Level up (stats +) → Spanish labels bij exploration → 3 scenes exploreerbaar → Victory (alle enemies dood) / Defeat (health = 0)

## UNIQUE SELLING POINT ⭐
**Spanish Learning Feature:** Deze game onderscheidt zich door educatieve waarde. Spelers leren Spaanse vocabulaire door interactie met game objects. Perfect voor doelgroep 15-18 jaar. Alle labels tonen Best Education B.V. branding.

## NIEUWE FEATURES (v1.1 - Final)
✅ **Best Education B.V. Branding** - Logo image (niet text!) op alle Spanish labels
✅ **Spanish Learning System** - Interactieve taalles tijdens gameplay
✅ **Smart Timer System** - Player labels: 3s display + 5s cooldown (non-intrusive UX)
✅ **Dual Detection Modes** - Triggers voor static objects, proximity voor moving objects
✅ **Bug Fixes** - Coroutine safety checks, collision issue resolved
✅ **Setup Documentation** - Complete guide in `SPANISH_LABEL_SETUP_GUIDE.md`

## PRIORITEITEN VOOR VOLGENDE ITERATIE
1. ~~**KRITISCH:** Best Education branding~~ ✅ VOLTOOID
2. **HIGH:** Victory/Game Over screens met restart buttons (code `RestartGame()` bestaat al)
3. **MEDIUM:** Audio systeem, Save/Load functionaliteit
4. **LOW:** UI polish, meer enemy types, inventory, meer Spanish vocabulaire

## BEKENDE ISSUES
- Victory/defeat gebruiken basic GameObject deactivation (geen proper screens)
- Restart button ontbreekt in UI (functie wel beschikbaar)
- Enemies kunnen soms stuck raken bij obstacles tijdens patrol
- Scene spawn kan falen als SpawnZone marker ontbreekt
- Spanish labels require manual Unity setup (zie guide)

## DEBUG TIPS
- Console errors checken (Ctrl+Shift+C)
- Player/Enemy tags correct? Check Project Settings → Tags
- Scene in Build Settings? Check File → Build Settings
- Enemy AI issues? Controleer NavMesh baking
- **Spanish labels niet zichtbaar?** Check SpanishLabelUIManager references in Inspector
- **Labels blijven staan?** Verify trigger colliders have "Is Trigger" checked

## IMPLEMENTATIE TIPS SPANISH SYSTEM
1. Start met Player en Enemy labels (easy wins)
2. Voeg strategisch invisible triggers toe op tilemap (niet elke tile!)
3. Gebruik Gizmos in Scene view om detection ranges te visualiseren
4. Test proximity vs trigger modes voor beste UX
5. Vocabulaire uitbreiden? Zie table in setup guide