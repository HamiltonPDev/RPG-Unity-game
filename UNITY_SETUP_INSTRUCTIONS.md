# Unity Setup Instructions - Spanish Learning System
## Quick Setup Guide for Best Education B.V. Branding

This document explains what you need to do in Unity to complete the Spanish learning system setup.

---

## 🎯 What You Need To Do in Unity

### Step 1: Create the UI Panel (5-10 minutes)

1. **Open MainScene in Unity**
   - File → Open Scene → `Assets/Scenes/MainScene.unity`

2. **Create Canvas** (if you don't have one)
   - Right-click in Hierarchy → UI → Canvas
   - This creates a Canvas with EventSystem automatically

3. **Create the Label Panel**
   - Right-click on Canvas → Create Empty
   - Name it: `SpanishLabelPanel`
   - Add Component → Image (for background)
   - Set Image color: Black with Alpha ~180 (semi-transparent)

4. **Position the Panel on LEFT SIDE**
   - Select SpanishLabelPanel
   - In RectTransform:
     - Click anchor preset (top-left square icon)
     - Hold Alt + Shift, click **left-middle** anchor
     - Position X: 150
     - Position Y: 0
     - Width: 250
     - Height: 100

5. **Add the Logo Image**
   - Right-click SpanishLabelPanel → UI → Image
   - Name it: `BrandingLogo`
   - In Inspector:
     - Source Image: Drag `Assets/Sprites/Bijlage 2 - Logos/Bijlage 2 - Logo.png`
     - ✓ Preserve Aspect (check this!)
     - Anchor: Top-Center
     - Position Y: -20
     - Width: 220
     - Height: 40

6. **Add Spanish Name Text**
   - Right-click SpanishLabelPanel → UI → Text
   - Name it: `SpanishNameText`
   - Text: "Árbol" (placeholder)
   - Font Size: 20
   - Font Style: Bold
   - Color: White
   - Alignment: Left
   - Position: Middle of panel

7. **Add English Translation Text**
   - Right-click SpanishLabelPanel → UI → Text
   - Name it: `EnglishNameText`
   - Text: "(Tree)" (placeholder)
   - Font Size: 14
   - Color: Light Gray (#CCCCCC)
   - Alignment: Left
   - Position: Below Spanish text

8. **Add the Manager Script**
   - Select SpanishLabelPanel
   - Add Component → Search: "SpanishLabelUIManager"
   - In Inspector, drag components to fields:
     - Label Panel: SpanishLabelPanel (itself)
     - Branding Logo: BrandingLogo (Image component)
     - Spanish Text: SpanishNameText
     - English Text: EnglishNameText

---

### Step 2: Add to Player (2 minutes)

1. **Find your Player GameObject** in the scene
2. **Add Component** → Search: "SpanishObjectLabel"
3. **Configure in Inspector:**
   - Spanish Name: `Jugador`
   - English Name: `Player`
   - Show On Proximity: ✓ (checked)
   - Display Distance: `2.5`
   - Show Branding: ✓ (checked)

---

### Step 3: Add to Enemy Prefab (2 minutes)

1. **Open Enemy Prefab**
   - Project window → `Assets/Prefabs/Enemy.prefab`
   - Double-click to open in Prefab Mode

2. **Add Component** → "SpanishObjectLabel"

3. **Configure:**
   - Spanish Name: `Enemigo` (or `Esqueleto` for skeleton)
   - English Name: `Enemy` (or `Skeleton`)
   - Show On Proximity: ✓
   - Display Distance: `2.5`
   - Show Branding: ✓

4. **Save Prefab** (Auto-saves)

---

### Step 4: Add Triggers for Tilemap Objects (Optional, 5-10 minutes)

For trees, rocks, cemetery, etc. on your tilemap:

1. **Create Empty GameObject**
   - Right-click in Hierarchy → Create Empty
   - Name it: `TriggerLabel_Tree` (or appropriate name)

2. **Position over the tilemap object**
   - Move it to where the tree/rock/etc. is on your tilemap

3. **Add Collider**
   - Add Component → Circle Collider 2D (or Box Collider 2D)
   - ✓ **Is Trigger** (MUST CHECK THIS!)
   - Adjust size to cover the object

4. **Add Label Script**
   - Add Component → "SpanishObjectLabel"
   - Spanish Name: `Árbol` (tree), `Roca` (rock), `Cementerio` (cemetery)
   - English Name: `Tree`, `Rock`, `Cemetery`
   - Show On Proximity: ✗ (uncheck - using trigger instead)
   - Show Branding: ✓

5. **Repeat for other objects** you want to label

---

## ✅ Testing (2 minutes)

1. **Press Play** in Unity
2. **Move player near objects** with SpanishObjectLabel
3. **You should see:**
   ```
   [Best Education B.V. Logo]
   Jugador
   (Player)
   ```
4. **Move away** - label should fade out

---

## 🐛 Troubleshooting

**Logo doesn't show:**
- Check that BrandingLogo's Source Image is set to the logo PNG
- Check "Preserve Aspect" is enabled
- Verify the logo Image is active in hierarchy

**Label doesn't appear:**
- Check SpanishLabelUIManager references are assigned
- Verify Player has "Player" tag
- For triggers: check "Is Trigger" is enabled on collider

**Label doesn't disappear:**
- For triggers: verify collider is set as trigger
- For proximity: check Display Distance setting

---

## 📊 Total Time Estimate

- UI Setup: 5-10 minutes
- Player + Enemy: 4 minutes
- Tilemap triggers (3-5 objects): 5-10 minutes
- Testing: 2 minutes

**Total: ~15-25 minutes** ⏱️

---

## 🎨 Logo Variants

You have 3 logo options in `Assets/Sprites/Bijlage 2 - Logos/`:

1. **Bijlage 2 - Logo.png** ← RECOMMENDED (full logo with text)
2. **Bijlage 2 - Logo zonder text.png** (icon only)
3. **Bijlage 2 - Logo - onder.png** (logo with text underneath)

Change the Source Image in BrandingLogo component to switch variants.

---

## ✨ After Setup

Once you've created the UI in MainScene:
1. **Save the scene** (Ctrl+S / Cmd+S)
2. **Commit to Git** - The UI will now be in the repository
3. **Future users** just need to add SpanishObjectLabel to objects (Steps 2-4)

---

## 📝 Spanish Vocabulary Reference

Common objects for your game:

| Object | Spanish | English |
|--------|---------|---------|
| Player | Jugador / Héroe | Player / Hero |
| Enemy | Enemigo | Enemy |
| Skeleton | Esqueleto | Skeleton |
| Tree | Árbol | Tree |
| Rock | Roca / Piedra | Rock / Stone |
| Cemetery | Cementerio | Cemetery |
| Tombstone | Tumba / Lápida | Tombstone |
| House | Casa | House |
| Gate | Puerta / Portal | Gate / Portal |
| Bush | Arbusto | Bush |
| Flower | Flor | Flower |
| Grass | Hierba / Pasto | Grass |
| Path | Camino / Sendero | Path |
| Bridge | Puente | Bridge |
| Water | Agua | Water |

---

## 🎓 Educational Impact

Once set up, players will:
- Learn 20+ Spanish words during gameplay
- See translations in context (visual + text)
- Retain vocabulary through repetition (3-5 encounters per word)
- Have Best Education B.V. branding on every label

**This is your unique selling point!** 🌟
