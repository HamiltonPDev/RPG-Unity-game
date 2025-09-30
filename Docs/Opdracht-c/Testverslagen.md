# OPDRACHT C - REALISEREN EN TESTEN
**K0788 - Basis Programmeren van Games**

**Student:** Hamilton Posada  
**Datum:** 30 september 2025  
**Project:** RPG Unity Game voor Best Education B.V.

---

## GEREALISEERDE GAME

### Build Informatie
- **Versie:** v1.0
- **Platform:** Windows/Mac (Unity Standalone)
- **Build datum:** 30 september 2025
- **Unity versie:** 6000.1.10f1
- **Repository:** https://github.com/HamiltonPDev/RPG-Unity-game

---

## STATUS IMPLEMENTATIE

### MoSCoW Backlog - Gerealiseerd

#### MUSTS (5/6 - 83% compleet)

**1. Game kan worden gestart** ✅
- Main scene laadt correct
- Player spawnt op juiste positie
- Geen crashes bij startup

**2. Speler kan game/karakters besturen** ✅
- WASD controls geïmplementeerd
- Arrow keys als alternatief
- Mouse click voor attack (met cooldown)
- Smooth movement met vector normalization
- Responsive controls

**3. Speler kan winnen** ✅
- All enemies defeated = victory condition
- (Basic implementation - needs proper victory screen)

**4. Speler kan verliezen** ✅
- Health = 0 triggers defeat
- Player deactivation on death
- (Basic implementation - needs proper game over screen)

**5. Game kan opnieuw worden gestart** ✅
- Scene reload possible via SceneManager
- (Needs restart button UI implementation)

**6. Best Education B.V. branding** ❌
- Logo plaatsing: Niet toegevoegd
- Slogan "Wij lanceren je de toekomst in!": Niet zichtbaar
- Bedrijfsnaam: Niet geïntegreerd

---

#### SHOULDS (2/2 - 100% compleet)

**1. Score bijhouden** ✅
- Experience point systeem volledig functioneel
- XP display in UI
- XP wordt toegekend bij enemy defeat
- Persistent tussen levels

**2. Toenemende moeilijkheidsgraad** ✅
- Enemy scaling per player level geïmplementeerd
- Health scaling: `finalHealth = baseHealth + (healthPerLevel × (playerLevel - 1))`
- Damage scaling: `finalDamage = baseDamage + (damagePerLevel × (playerLevel - 1))`
- Dynamic difficulty adjustment werkend

---

#### COULDS (0/2 - Niet geïmplementeerd)

**1. Email verzameling** ❌
- Niet geïmplementeerd (buiten scope)

**2. Online scoreboard** ❌
- Niet geïmplementeerd (buiten scope)

---

#### WOULDS (0/1 - Niet geïmplementeerd)

**1. Online multiplayer** ❌
- Niet geïmplementeerd (toekomstige feature)

---

## TECHNISCHE FEATURES OVERZICHT

### Core Gameplay Systems

**Player Systems:**
- Movement: WASD/Arrow keys, normalized velocity
- Attack: Mouse click, timed cooldown (attackTime variable)
- Health management: Max health, current health, damage resistance
- Stats: Level, XP, Strength, Defense
- Animations: 4-directional movement + 4-directional attacks

**Enemy Systems:**
- AI State Machine:
  - Patrol state (waypoint navigation)
  - Chase state (player pursuit)
  - Attack state (damage dealing)
  - Idle state (waiting at waypoints)
- Dynamic scaling per player level
- Random patrol behavior (legacy EnemyController)
- Health management met I-frames
- XP drop on defeat

**Combat System:**
- Real-time collision-based combat
- Damage calculation: `totalDamage = baseDamage - defense`
- Negative damage prevention (Mathf.Clamp)
- Visual feedback: floating damage numbers
- Particle effects: blood burst on hit
- I-frame flashing on damage taken

**Progression System:**
- Experience points (XP)
- Level-up mechanics
- Stat scaling per level:
  - Health increases per level
  - Strength increases per level
  - Defense increases per level

**UI Systems:**
- Real-time health bar (Slider)
- Level display
- XP counter
- Strength indicator
- Defense indicator
- Enemy stats display

**Scene Management:**
- Multiple scenes (3): MainScene, HouseInteriorScene, HouseGardenScene
- Scene transitions via triggers
- Spawn positioning per scene (SpawnZone.cs)
- Player persistence (DontDestroyOnLoad.cs)
- Camera follow system

---

## ONTWIKKELINGSITEATIES

### Iteratie 1 - EnemyController (Random Patrol)
**Periode:** 1-3 september 2025  
**Status:** Werkend maar basis functionaliteit

**Geïmplementeerd:**
- Random movement pattern
- Time-based step system
- Basic animator integration
- Collision met player

**Bevindingen:**
- Functioneel voor basic gameplay
- Geen intelligente pursuit behavior
- Enemies bewegen willekeurig, niet uitdagend
- Goed voor eerste test en prototype fase

**Code:** `EnemyController.cs` (~60 lines)

---

### Iteratie 2 - EnemyAI (State Machine)
**Periode:** 30 september 2025  
**Status:** Volledig functioneel, production-ready

**Geïmplementeerd:**
- State machine: Patrol → Chase → Attack → Idle
- Intelligent player detection
- Dynamic chase behavior
- Attack range management
- Waypoint patrol system
- Gizmos visualization

**Verbetering t.o.v. Iteratie 1:**
- Enemies reageren op player proximity
- Uitdagender gameplay door chase behavior
- Meer strategische enemy positioning
- Beter balanced difficulty

**Code:** `EnemyAI.cs` (~250 lines)

**Reden voor upgrade:**
Na eerste test bleek dat enemies te voorspelbaar waren. AI upgrade was nodig voor betere gameplay experience en om SHOULD requirement (toenemende moeilijkheid) beter te implementeren.

---

## TESTING AANPAK

### Test 1 (met EnemyController)
**Focus:**
- Core gameplay mechanics
- Player controls
- Basic combat
- UI readability

**Enemy behavior:** Random patrol (EnemyController.cs)

---

### Test 2 (met EnemyAI)
**Focus:**
- Improved AI behavior
- Difficulty balance
- Chase mechanics
- Overall experience

**Enemy behavior:** State machine AI (EnemyAI.cs)

**Verwachte verbetering:**
- Meer engaging combat
- Beter balanced difficulty
- Strategischer gameplay