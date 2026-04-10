---
name: dark-soul-collector-agent
description: AI Agent Memory & Project Knowledge Base for the Dark Soul Collector 2D RPG Unity Game
---

# 🧠 Dark Soul Collector — AI Agent Skill & Memory

> **Đây là bộ nhớ trung tâm của AI Agent.** Mọi thông tin về project, kiến trúc, convention,
> và trạng thái phát triển đều được ghi nhận tại đây. Agent PHẢI đọc file này trước khi
> thực hiện bất kỳ thay đổi nào trong project.

---

## 📋 Project Overview

| Key            | Value                                              |
| -------------- | -------------------------------------------------- |
| **Tên game**   | Dark Soul Collector                                |
| **Engine**     | Unity (2D)                                         |
| **Ngôn ngữ**   | C#                                                 |
| **Namespace**  | `DarkSoulCollector.*`                              |
| **Thể loại**   | 2D Action RPG — thu thập linh hồn, chiến đấu, khám phá dungeon |
| **Trạng thái** | 🟡 Early Development — skeleton scripts, chưa có gameplay hoàn chỉnh |
| **Thư mục gốc**| `e:\Game\2D RPG GAME`                              |

---

## 🗂️ Project Structure

```
Assets/Assets/_Project/
├── Art/                    # Sprites, Tilesets, Animations
├── Audio/                  # Music, SFX clips
├── Data/                   # ScriptableObject scripts (SO definitions)
│   ├── AbilityData.cs      # Ability config (cooldown, damage, cost)
│   ├── DialogueDataSO.cs   # Dialogue tree data
│   ├── EnemyData.cs        # Enemy stats (HP, ATK, speed, detection)
│   ├── ItemData.cs         # Item definition (name, icon, stackable)
│   ├── SoulData.cs         # Soul data (ability granted, moral value)
│   └── WeaponData.cs       # Weapon stats (damage, speed, range)
├── Localization/           # Localization assets
├── Prefabs/                # Prefab categories:
│   ├── Enemies/
│   ├── Environment/
│   ├── Items/
│   ├── Player/
│   ├── UI/
│   ├── VFX/
│   └── Weapons/
├── Scenes/                 # (empty — cần tạo scenes)
├── ScriptableObjects/      # SO instances (asset files)
└── Scripts/                # Game logic:
    ├── Audio/              # AudioManager, SoundLibrary
    ├── Camera/             # Camera follow, shake
    ├── Combat/             # DamageDealer, Health, HitFlash, KnockbackHandler
    │   └── Interfaces/     # IDamageable, etc.
    ├── Core/               # Singleton<T>, GameManager, Constants, EventManager,
    │                       # ObjectPool, SceneLoader
    ├── Dungeon/            # Dungeon generation
    ├── Enemy/              # EnemyBase, EnemyLoot, EnemySpawner
    │   ├── Enemies/        # Concrete enemy types
    │   └── StateMachine/   # Enemy AI states
    ├── Inventory/          # InventoryManager, EquipmentManager, ItemSlot
    │   └── Interfaces/
    ├── Localization/       # Localization scripts
    ├── NPC/                # NPC interaction
    ├── Player/             # PlayerController, PlayerMovement, PlayerCombat,
    │                       # PlayerStats, PlayerAnimator, PlayerInputHandler
    ├── SaveSystem/         # SaveManager, SaveData
    │   └── Interfaces/     # ISaveable
    ├── Soul/               # SoulManager, SoulCollectible, AbilityBase
    │   └── Abilities/      # Concrete soul abilities
    ├── UI/                 # UIManager, HUD, Menus, Dialogue UI, Inventory UI,
    │                       # DamagePopup, Settings, GameOver
    ├── Utils/              # Utility/helper scripts
    ├── VFX/                # Visual effects scripts
    └── Weapons/            # Weapon logic scripts
```

---

## 🏗️ Architecture & Design Patterns

### Core Patterns
1. **Singleton\<T\>** — Generic MonoBehaviour singleton tại `Scripts/Core/Singleton.cs`
   - DontDestroyOnLoad tự động
   - Sử dụng: `public class MyManager : Singleton<MyManager> { }`
   - Đã dùng bởi: `GameManager`

2. **ScriptableObject Data** — Tất cả game data dùng SO (tạo qua `CreateAssetMenu`)
   - Namespace: `DarkSoulCollector.Data`
   - Menu path: `DarkSoulCollector/Data/*`

3. **Component-Based Player** — Player tách thành nhiều component:
   - `PlayerController` — điều phối chính
   - `PlayerMovement` — di chuyển
   - `PlayerCombat` — chiến đấu
   - `PlayerStats` — chỉ số
   - `PlayerAnimator` — animation
   - `PlayerInputHandler` — xử lý input

4. **Enemy State Machine** — Enemy AI sử dụng State Machine pattern
   - Base: `EnemyBase.cs`
   - States tại: `Scripts/Enemy/StateMachine/`

5. **Event-Driven** — `EventManager` cho loose coupling giữa systems

6. **Object Pooling** — `ObjectPool` cho projectile/VFX recycling

### Namespace Convention
```
DarkSoulCollector.Core        → Singleton, GameManager, Constants, EventManager
DarkSoulCollector.Data        → All ScriptableObject definitions
DarkSoulCollector.Combat      → Health, DamageDealer, KnockbackHandler
DarkSoulCollector.Player      → Player scripts
DarkSoulCollector.Enemy       → Enemy scripts
DarkSoulCollector.Inventory   → Inventory & Equipment
DarkSoulCollector.Soul        → Soul collection & abilities
DarkSoulCollector.UI          → UI controllers
DarkSoulCollector.Audio       → Audio system
DarkSoulCollector.SaveSystem  → Save/Load
```

---

## 📏 Coding Conventions

### C# Style Rules
- **Namespace**: Luôn bọc trong `namespace DarkSoulCollector.{Module}`
- **XML Docs**: Mỗi class public PHẢI có `/// <summary>`
- **Naming**:
  - Class/Enum: `PascalCase`
  - Public fields: `camelCase` (Unity serialized)
  - Private fields: `_camelCase` hoặc `camelCase`
  - Constants: `UPPER_SNAKE_CASE`
  - Methods: `PascalCase`
- **CreateAssetMenu**: Dùng single quotes `"` — **TUYỆT ĐỐI KHÔNG dùng double quotes `""`**
  ```csharp
  // ✅ ĐÚNG
  [CreateAssetMenu(fileName = "NewItem", menuName = "DarkSoulCollector/Data/Item")]
  
  // ❌ SAI — sẽ gây CS1003
  [CreateAssetMenu(fileName = ""NewItem"", menuName = ""DarkSoulCollector/Data/Item"")]
  ```
- **Interfaces**: Đặt trong thư mục `Interfaces/` bên trong module tương ứng, prefix `I`
- **TODO Comments**: Dùng `// TODO:` để đánh dấu phần chưa implement

### File Organization
- 1 class = 1 file (trừ small nested classes)
- File name = Class name
- `.meta` files: Không chỉnh sửa thủ công — Unity tự quản lý

---

## 📖 Class Reference — Bảng Chức Năng Từng Class

> Bảng này mô tả chi tiết **chức năng, methods cần implement, dependencies** của từng class.

### 🔵 Core (Scripts/Core/)

| Class | Loại | Chức năng | Methods cần implement | Dependencies | Status |
|-------|------|-----------|----------------------|--------------|--------|
| `Singleton<T>` | Abstract MonoBehaviour | Base class Singleton — tự tạo instance, DontDestroyOnLoad | ✅ Đã implement đầy đủ | — | 🟢 Done |
| `GameManager` | Singleton | Quản lý trạng thái game: Menu → Playing → Paused → GameOver. Điều phối flow toàn bộ game | `StartGame()`, `PauseGame()`, `ResumeGame()`, `GameOver()`, `RestartGame()` | SceneLoader, UIManager | 🟡 Skeleton |
| `Constants` | Static | Chứa hằng số toàn cục: Tags, Scene names, Animation params | ✅ Đã implement đầy đủ | — | 🟢 Done |
| `EventManager` | Static | Hệ thống sự kiện pub/sub — giúp các system giao tiếp loose coupling | `Subscribe<T>(Action)`, `Unsubscribe<T>(Action)`, `Publish<T>(T data)` | — | 🟡 Skeleton |
| `ObjectPool<T>` | Generic class | Pool tái sử dụng GameObject (đạn, VFX, enemy) — tránh Instantiate/Destroy | `Get()`, `Return(T obj)`, `PreWarm(int count)` | — | 🟡 Skeleton |
| `SceneLoader` | Singleton | Load scene async với loading screen, progress callback | `LoadSceneAsync(string name)`, `OnLoadProgress(float)` | Constants (scene names) | 🟡 Skeleton |

### 🟢 Player (Scripts/Player/)

| Class | Loại | Chức năng | Methods cần implement | Dependencies | Status |
|-------|------|-----------|----------------------|--------------|--------|
| `PlayerController` | MonoBehaviour | **Điều phối trung tâm** — kết nối tất cả component Player, quản lý state (alive/dead/stunned) | Tham chiếu + khởi tạo các component, `Initialize()` | PlayerMovement, PlayerCombat, PlayerStats, PlayerAnimator, PlayerInputHandler | 🟡 Skeleton |
| `PlayerInputHandler` | MonoBehaviour | Đọc input từ người chơi (keyboard/gamepad), chuyển thành lệnh cho Movement/Combat | `MovementInput` (Vector2), `AttackInput`, `DashInput`, `InteractInput` (booleans), `OnMove()`, `OnAttack()`, `OnDash()` | Unity Input System | 🟡 Skeleton |
| `PlayerMovement` | MonoBehaviour | Di chuyển 8 hướng, Dash/Dodge roll, speed modifier, flip sprite theo hướng | `Move(Vector2 input)`, `Dash()`, `SetSpeed(float)`, `FreezeMovement()` | Rigidbody2D, PlayerInputHandler | 🟡 Skeleton |
| `PlayerCombat` | MonoBehaviour | Combo melee (light/heavy), sử dụng ability từ Soul, cooldown management | `Attack()`, `HeavyAttack()`, `UseAbility(int slot)`, `ComboReset()` | PlayerAnimator, DamageDealer, PlayerStats | 🟡 Skeleton |
| `PlayerStats` | MonoBehaviour | Chỉ số nhân vật: HP, Stamina, ATK, DEF, Speed, Level, XP. Level-up bonus | `maxHealth`, `currentHealth`, `stamina`, `attackPower`, `defense`, `speed`, `level`, `xp`. Methods: `ModifyStat()`, `AddXP()`, `LevelUp()`, `ResetStats()` | — | 🟡 Skeleton |
| `PlayerAnimator` | MonoBehaviour | Wrapper cho Animator — set animation states dựa trên gameplay events | `PlayMove(float speed)`, `PlayAttack(int combo)`, `PlayHurt()`, `PlayDeath()`, `PlayDash()` | Animator, Constants (anim params) | 🟡 Skeleton |

### 🔴 Combat (Scripts/Combat/)

| Class | Loại | Chức năng | Methods cần implement | Dependencies | Status |
|-------|------|-----------|----------------------|--------------|--------|
| `Health` | MonoBehaviour, IDamageable | Component HP tái sử dụng — gắn vào Player, Enemy, vật phá được | `TakeDamage(float)`, `Heal(float)`, `Die()`. Events: `OnHealthChanged`, `OnDeath` | — | 🟡 Skeleton (có TakeDamage/Die nhưng chưa logic) |
| `DamageDealer` | MonoBehaviour | Gắn vào hitbox (sword swing, bullet) — gây damage khi va chạm | `damageAmount`, `OnTriggerEnter2D()` → tìm `IDamageable` → `TakeDamage()` | IDamageable | 🟡 Skeleton |
| `HitFlash` | MonoBehaviour | Hiệu ứng chớp trắng khi nhận damage — swap material trong SpriteRenderer | `Flash()` coroutine, `flashDuration`, `flashMaterial` | SpriteRenderer | 🟡 Skeleton |
| `KnockbackHandler` | MonoBehaviour, IKnockbackable | Đẩy lùi entity khi bị đánh — dùng Rigidbody2D.AddForce | `ApplyKnockback(Vector2 dir, float force)`, `knockbackDuration` | Rigidbody2D | 🟡 Skeleton (có method signature) |
| `IDamageable` | Interface | Contract cho mọi thứ nhận damage | `TakeDamage(float amount)`, `Die()` | — | 🟢 Done |
| `IKnockbackable` | Interface | Contract cho mọi thứ bị knockback | `ApplyKnockback(Vector2 direction, float force)` | — | 🟢 Done |

### 🟠 Enemy (Scripts/Enemy/)

| Class | Loại | Chức năng | Methods cần implement | Dependencies | Status |
|-------|------|-----------|----------------------|--------------|--------|
| `EnemyBase` | Abstract MonoBehaviour, IDamageable | Base class cho tất cả enemy — chứa shared logic, data reference | `health`, `stateMachine`, `detectionRange`, `attackRange`. Abstract: `TakeDamage()`, `Die()` | EnemyData (SO), Health, EnemyStateMachine | 🟡 Skeleton |
| `EnemyStateMachine` | MonoBehaviour | Quản lý trạng thái AI — chuyển đổi giữa các state | `ChangeState(IEnemyState)`, `currentState`, `Update()` delegates to state | IEnemyState | 🟡 Skeleton |
| `IEnemyState` | Interface | Contract cho mỗi state | `Enter()`, `Execute()`, `Exit()` | — | 🟡 Skeleton |
| `EnemyIdleState` | IEnemyState | Đứng yên — kiểm tra player có trong detection range không | `Enter()`, `Execute()` → nếu thấy player → chuyển Chase, `Exit()` | EnemyBase (reference) | 🟡 Skeleton |
| `EnemyPatrolState` | IEnemyState | Đi tuần tra giữa các waypoints | `Enter()`, `Execute()` → di chuyển giữa points, nếu thấy player → Chase, `Exit()` | EnemyBase, waypoints | 🟡 Skeleton |
| `EnemyChaseState` | IEnemyState | Đuổi theo player cho đến khi vào attack range hoặc mất tầm | `Enter()`, `Execute()` → move toward player, `Exit()` | EnemyBase, Player transform | 🟡 Skeleton |
| `EnemyAttackState` | IEnemyState | Tấn công player — cooldown giữa các đòn | `Enter()`, `Execute()` → attack nếu ready, `Exit()` | EnemyBase, DamageDealer | 🟡 Skeleton |
| `EnemyDeadState` | IEnemyState | Chết — play animation, drop loot, destroy/pool return | `Enter()` → animate + drop loot, `Execute()`, `Exit()` | EnemyLoot, ObjectPool | 🟡 Skeleton |
| `EnemySpawner` | MonoBehaviour | Spawn enemy theo wave hoặc trigger — dùng ObjectPool | `spawnPoints[]`, `enemyPrefabs[]`, `SpawnWave()`, `OnEnemyDied()` | ObjectPool, EnemyBase | 🟡 Skeleton |
| `EnemyLoot` | MonoBehaviour | Drop item/soul/gold khi enemy chết | `lootTable`, `DropLoot()`, `CalculateDrops()` | ItemData, SoulData | 🟡 Skeleton |

### 🟣 Soul System (Scripts/Soul/)

| Class | Loại | Chức năng | Methods cần implement | Dependencies | Status |
|-------|------|-----------|----------------------|--------------|--------|
| `SoulManager` | MonoBehaviour | Quản lý bộ sưu tập linh hồn, unlock ability, equip ability vào slot | `collectedSouls[]`, `soulCount`, `CollectSoul(SoulData)`, `UnlockAbility(AbilityData)`, `EquipAbility(int slot)` | SoulData, AbilityBase | 🟡 Skeleton |
| `SoulCollectible` | MonoBehaviour | Vật phẩm nhặt trong world — khi player chạm vào → thu thập soul | `soulData`, `OnTriggerEnter2D()` → `SoulManager.CollectSoul()`, VFX feedback | SoulData, SoulManager | 🟡 Skeleton |
| `AbilityBase` | Abstract MonoBehaviour | Base class cho tất cả ability từ soul | `cooldown`, `isReady`, Abstract: `Activate()`, `OnCooldown()` coroutine | AbilityData | 🟡 Skeleton |

### 🟤 Inventory (Scripts/Inventory/)

| Class | Loại | Chức năng | Methods cần implement | Dependencies | Status |
|-------|------|-----------|----------------------|--------------|--------|
| `InventoryManager` | MonoBehaviour | Quản lý túi đồ: thêm, xóa, sử dụng, sắp xếp items | `items[]` (ItemSlot array), `maxSlots`, `AddItem(ItemData, int qty)`, `RemoveItem()`, `UseItem()`, `SortItems()` | ItemSlot, ItemData | 🟡 Skeleton |
| `EquipmentManager` | MonoBehaviour | Quản lý trang bị đang mặc: vũ khí, giáp, phụ kiện | `equippedWeapon`, `equippedArmor`, `equippedAccessory`, `Equip(ItemData)`, `Unequip(string slot)` | ItemData, WeaponData, PlayerStats | 🟡 Skeleton |
| `ItemSlot` | Serializable class | Đại diện 1 ô trong túi đồ — chứa reference item + số lượng | `itemData`, `quantity`, `IsEmpty()`, `AddQuantity()`, `RemoveQuantity()` | ItemData | 🟡 Skeleton |

### 🟡 UI (Scripts/UI/)

| Class | Loại | Chức năng | Methods cần implement | Dependencies | Status |
|-------|------|-----------|----------------------|--------------|--------|
| `UIManager` | Singleton | Điều phối UI panels — show/hide/toggle với animation | `ShowPanel(GameObject)`, `HidePanel(GameObject)`, `TogglePanel(GameObject)` | — | 🟡 Skeleton |
| `HUDController` | MonoBehaviour | Thanh HP, Stamina, soul counter, minimap, weapon icon | `UpdateHealthBar(float)`, `UpdateStaminaBar(float)`, `UpdateSoulCount(int)`, `UpdateWeaponIcon(Sprite)` | PlayerStats, SoulManager | 🟡 Skeleton |
| `MainMenuController` | MonoBehaviour | Menu chính: New Game, Continue, Settings, Quit | `OnNewGame()`, `OnContinue()`, `OnSettings()`, `OnQuit()` | SceneLoader, SaveManager | 🟡 Skeleton |
| `PauseMenuController` | MonoBehaviour | Menu pause: Resume, Settings, Save, Quit to Menu | `OnResume()`, `OnSave()`, `OnQuitToMenu()` | GameManager, SaveManager | 🟡 Skeleton |
| `InventoryUIController` | MonoBehaviour | Hiển thị túi đồ dạng grid, drag & drop, item tooltip | `RefreshUI()`, `OnSlotClicked(int)`, `ShowTooltip(ItemData)` | InventoryManager | 🟡 Skeleton |
| `DialogueUIController` | MonoBehaviour | Hiển thị hội thoại NPC: typewriter effect, choices | `ShowDialogue(DialogueDataSO)`, `TypeText()` coroutine, `OnChoiceSelected(int)` | DialogueDataSO | 🟡 Skeleton |
| `DamagePopup` | MonoBehaviour | Text floating lên khi gây damage — spawn từ pool | `Setup(float damage, Vector3 pos)`, `Animate()`, auto-destroy | ObjectPool | 🟡 Skeleton |
| `GameOverController` | MonoBehaviour | Màn hình Game Over: Retry, Quit | `Show()`, `OnRetry()`, `OnQuit()` | GameManager, SceneLoader | 🟡 Skeleton |
| `SettingsUIController` | MonoBehaviour | Settings: Volume, Resolution, Fullscreen, Keybinding | `OnVolumeChanged(float)`, `OnResolutionChanged()`, `OnFullscreenToggled()`, `SaveSettings()` | AudioManager | 🟡 Skeleton |

### 🎵 Audio (Scripts/Audio/)

| Class | Loại | Chức năng | Methods cần implement | Dependencies | Status |
|-------|------|-----------|----------------------|--------------|--------|
| `AudioManager` | Singleton | Quản lý âm thanh: chơi BGM, SFX, volume control, pooling AudioSource | `PlayBGM(AudioClip)`, `PlaySFX(string name)`, `StopBGM()`, `SetMasterVolume(float)`, `SetSFXVolume(float)` | SoundLibrary | 🟡 Skeleton |
| `SoundLibrary` | ScriptableObject | Registry ánh xạ tên → AudioClip. Tạo qua menu DarkSoulCollector/Audio | `SoundEntry[] sounds`, `GetClip(string name)` | — | 🟡 Skeleton |

### 💾 Save System (Scripts/SaveSystem/)

| Class | Loại | Chức năng | Methods cần implement | Dependencies | Status |
|-------|------|-----------|----------------------|--------------|--------|
| `SaveManager` | MonoBehaviour | Điều phối save/load — serialize SaveData → JSON file | `Save()`, `Load()`, `DeleteSave()`, `HasSaveFile()`, `GetSavePath()` | SaveData, ISaveable | 🟡 Skeleton |
| `SaveData` | Serializable class | Cấu trúc dữ liệu lưu game — chứa toàn bộ state cần persist | `playerPosition`, `playerStats`, `inventoryItems`, `collectedSouls`, `currentRoom`, `playTime` | — | 🟡 Skeleton |

### 📦 Data — ScriptableObjects (Data/)

| Class | Loại | Chức năng | Trường dữ liệu | Menu Path | Status |
|-------|------|-----------|-----------------|-----------|--------|
| `AbilityData` | ScriptableObject | Config ability: cooldown, damage, cost, VFX | `abilityName`, `description`, `cooldown`, `damage`, `staminaCost`, `icon` | DarkSoulCollector/Data/Ability | 🟢 Done |
| `DialogueDataSO` | ScriptableObject | Dữ liệu hội thoại NPC | `speakerName` (TODO: lines, branching) | DarkSoulCollector/Data/Dialogue | 🟡 Basic |
| `EnemyData` | ScriptableObject | Config enemy: HP, ATK, speed, range | `enemyName`, `maxHealth`, `damage`, `moveSpeed`, `detectionRange`, `attackRange`, `icon` | DarkSoulCollector/Data/Enemy | 🟢 Done |
| `ItemData` | ScriptableObject | Định nghĩa item: tên, icon, stackable | `itemName`, `description`, `icon`, `isStackable`, `maxStack` | DarkSoulCollector/Data/Item | 🟢 Done |
| `SoulData` | ScriptableObject | Dữ liệu linh hồn: tên, ability, moral | `soulName`, `description`, `icon`, `moralValue` | DarkSoulCollector/Data/Soul | 🟢 Done |
| `WeaponData` | ScriptableObject | Config vũ khí: damage, speed, range | `weaponName`, `damage`, `attackSpeed`, `range`, `icon` | DarkSoulCollector/Data/Weapon | 🟢 Done |

---

## 🎯 Game Features & Status

| Feature               | Status | Notes                                      |
| --------------------- | ------ | ------------------------------------------ |
| Player Movement       | 🟡     | Script skeleton, cần implement logic       |
| Player Combat         | 🟡     | Script skeleton                            |
| Health System         | 🟡     | Có method signatures, chưa có logic        |
| Damage System         | 🟡     | DamageDealer, HitFlash, Knockback skeleton |
| Enemy AI              | 🟡     | State Machine structure, cần implement     |
| Enemy Spawner         | 🟡     | Script skeleton                            |
| Inventory System      | 🟡     | Manager + ItemSlot skeleton                |
| Equipment System      | 🟡     | Script skeleton                            |
| Soul Collection       | 🟡     | SoulManager, SoulCollectible — skeleton    |
| Soul Abilities        | 🟡     | AbilityBase + Abilities folder             |
| Weapon System         | 🟡     | WeaponData SO, cần weapon logic            |
| Save/Load             | 🟡     | SaveManager + SaveData skeleton            |
| UI System             | 🟡     | Full UI controller skeleton                |
| Dialogue System       | 🟡     | DialogueDataSO + DialogueUIController      |
| Audio System          | 🟡     | AudioManager + SoundLibrary skeleton       |
| Dungeon Generation    | 🔴     | Thư mục tồn tại, chưa có script           |
| Camera System         | 🔴     | Thư mục tồn tại, chưa có script           |
| VFX System            | 🔴     | Thư mục tồn tại, chưa có script           |
| Localization          | 🔴     | Thư mục tồn tại, chưa setup               |
| Scenes                | 🔴     | Thư mục trống — cần tạo MainMenu, Gameplay |
| Object Pooling        | 🟡     | Script skeleton                            |

**Legend:** 🟢 Done | 🟡 Skeleton/WIP | 🔴 Not started

---

## ⚠️ Known Issues & Gotchas

1. **Double-quote bug (ĐÃ FIX)** — Đã xảy ra lỗi CS1003 do `""` thay vì `"` trong `CreateAssetMenu`.
   Agent PHẢI kiểm tra lại string literals khi tạo/sửa SO attributes.

2. **Nested Assets path** — Project dùng `Assets/Assets/_Project/` (có 2 level Assets).
   Khi tham chiếu path, phải dùng đúng cấu trúc này.

3. **Empty Scenes folder** — Chưa có scene nào. Cần tạo ít nhất:
   - `MainMenu.unity`
   - `Gameplay.unity`
   - `Loading.unity` (referenced in Constants.cs)

4. ~~**Missing .gitignore**~~ — ✅ Đã tạo `.gitignore` cho Unity project.

---

## 📅 Kế Hoạch Ngày — Daily Plan

### 🗓️ 2026-04-11 (Hôm nay) — Player Foundation Day

> **Mục tiêu:** Hoàn thành Player core để có thể di chuyển và đánh trong scene test.
> **Thời lượng ước tính:** ~4-5 tiếng (vừa sức, không gấp)

| # | Task | Thời gian | Chi tiết | Status |
|---|------|-----------|----------|--------|
| 1 | ✅ Fix compile errors | 15 phút | Fix CS1003 double-quote trong 6 files | ✅ Done |
| 2 | ✅ Setup SKILL.md + .gitignore | 15 phút | Tạo bộ nhớ AI Agent + chuẩn bị Git | ✅ Done |
| 3 | 🔲 Push lên GitHub | 10 phút | `git init` → `commit` → `push` | ⬜ Chờ user |
| 4 | 🔲 Implement `PlayerInputHandler` | 30 phút | Đọc input WASD/Arrow + Attack + Dash + Interact. Dùng legacy Input hoặc New Input System | ⬜ |
| 5 | 🔲 Implement `PlayerMovement` | 45 phút | 8-directional movement, dash/dodge, flip sprite, speed modifier | ⬜ |
| 6 | 🔲 Implement `PlayerStats` | 30 phút | HP, Stamina, ATK, DEF, Speed fields + ModifyStat, events | ⬜ |
| 7 | 🔲 Implement `PlayerAnimator` | 30 phút | Wrapper Animator: move, attack, hurt, death animations | ⬜ |
| 8 | 🔲 Implement `PlayerController` | 20 phút | Kết nối tất cả component, khởi tạo references | ⬜ |
| 9 | 🔲 Implement `Health` (hoàn chỉnh) | 30 phút | maxHealth, currentHealth, TakeDamage, Heal, Die, events | ⬜ |
| 10 | 🔲 Implement `EventManager` | 20 phút | Pub/Sub system đơn giản dùng Dictionary<Type, List<Delegate>> | ⬜ |
| 11 | 🔲 Test compile | 10 phút | Kiểm tra tất cả scripts compile không lỗi | ⬜ |

**Tổng ước tính: ~4 tiếng** (bao gồm cả nghỉ giải lao)

> **Lưu ý:** Hôm nay tập trung vào **code logic C#** — chưa cần tạo scene, prefab, sprite.
> Scene test + prefab setup sẽ làm ngày mai khi có art assets.

### 📌 Ngày mai (dự kiến):
- Tạo `Gameplay.unity` scene
- Tạo Player prefab + gắn component
- Implement `DamageDealer` + `KnockbackHandler`
- Test gameplay loop cơ bản

---

## 🔧 Agent Task Queue (TODO cho Agent)

Khi user yêu cầu implement tính năng mới, agent nên ưu tiên theo thứ tự:

### Priority 1 — Core Gameplay Loop
- [x] Fix compile errors (CS1003)
- [x] Setup SKILL.md + .gitignore
- [ ] Implement `PlayerInputHandler` (input reading)
- [ ] Implement `PlayerMovement` (Rigidbody2D movement + dash)
- [ ] Implement `PlayerCombat` (attack, combo)
- [ ] Implement `PlayerStats` (HP, Stamina, Level, XP)
- [ ] Implement `PlayerAnimator` (animation state management)
- [ ] Implement `PlayerController` (orchestrator)
- [ ] Implement `Health` (complete with events)
- [ ] Implement `EventManager` (pub/sub)

### Priority 2 — Enemy & Combat
- [ ] Implement `EnemyBase` AI states (Idle, Patrol, Chase, Attack, Dead)
- [ ] Implement `EnemyStateMachine` + all states
- [ ] Implement `EnemySpawner` (wave system hoặc trigger-based)
- [ ] Implement `EnemyLoot` (drop items/souls on death)
- [ ] Implement `DamageDealer` (collision → damage)
- [ ] Implement `KnockbackHandler` (force application)
- [ ] Implement `HitFlash` (visual feedback)

### Priority 3 — Systems
- [ ] Implement `InventoryManager` (add, remove, use items)
- [ ] Implement `EquipmentManager` (equip/unequip)
- [ ] Implement `ItemSlot` (slot data)
- [ ] Implement `SoulManager` (collect, equip, use abilities)
- [ ] Implement `SoulCollectible` (pickup in world)
- [ ] Implement `SaveManager` (JSON serialization)
- [ ] Implement `SaveData` (data structure)
- [ ] Implement `AudioManager` (play SFX/music, volume control)
- [ ] Implement `SoundLibrary` (clip registry)

### Priority 4 — UI & Polish
- [ ] Implement `HUDController` (HP bar, soul counter, abilities)
- [ ] Implement `MainMenuController`
- [ ] Implement `PauseMenuController`
- [ ] Implement `DialogueUIController` (typewriter effect)
- [ ] Implement `DamagePopup` (floating text)
- [ ] Implement `SettingsUIController`
- [ ] Implement `GameOverController`
- [ ] Implement `InventoryUIController`

### Priority 5 — Advanced
- [ ] Dungeon procedural generation
- [ ] Camera follow & screen shake
- [ ] VFX system (soul collection, hit effects)
- [ ] Localization support
- [ ] Equipment/weapon switching
- [ ] Create `ObjectPool<T>` implementation

---

## 📝 Change Log

| Date       | Change                                                      | By    |
| ---------- | ----------------------------------------------------------- | ----- |
| 2026-04-11 | Fixed CS1003 double-quote bugs in 6 SO files                | Agent |
| 2026-04-11 | Created SKILL.md — AI Agent Memory & Project Knowledge Base | Agent |
| 2026-04-11 | Created .gitignore for Unity project                        | Agent |
| 2026-04-11 | Added Class Reference table + Daily Plan to SKILL.md        | Agent |

---

## 🤖 Agent Instructions

Khi nhận task từ user, agent PHẢI:

1. **Đọc file SKILL.md này trước** để hiểu context
2. **Tuân theo namespace convention** — không tạo script ngoài namespace
3. **Tuân theo coding style** — XML docs, naming, single quotes
4. **Update Change Log** sau mỗi thay đổi quan trọng
5. **Update Feature Status table** khi implement xong feature
6. **Update Task Queue** khi hoàn thành task
7. **Update Daily Plan** khi hoàn thành task trong ngày
8. **Kiểm tra lỗi đã biết** trong Known Issues trước khi debug
9. **Không sửa .meta files** — để Unity quản lý
10. **Test compile** sau khi sửa code (kiểm tra syntax errors)
11. **Giữ file SKILL.md luôn up-to-date** — đây là bộ nhớ dài hạn của agent
