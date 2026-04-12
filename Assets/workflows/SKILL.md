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
| **Thể loại**   | 2D Top-Down Action RPG — thu thập linh hồn, chiến đấu, khám phá dungeon |
| **View**       | Top-Down 2D (camera nhìn từ trên xuống)                   |
| **Physics**    | Unity 2D Physics (Rigidbody2D, Collider2D)                |
| **Trạng thái** | 🟡 Early Dev — Player movement done, đang xây dựng core systems |
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

### 🔑 Design Patterns Đang Dùng

1. **Component Pattern** ⭐ (Player system)
   - Player tách thành nhiều component nhỏ, mỗi cái 1 việc:
   - `PlayerInputHandler` — CHỈ đọc input
   - `PlayerMovement` — CHỉ xử lý di chuyển + dash
   - `PlayerController` — BỘ NÃO, đọc input → ra lệnh cho movement
   - `PlayerCombat` — CHỉ xử lý chiến đấu (chưa implement)
   - `PlayerStats` — CHỉ lưu chỉ số (chưa implement)
   - `PlayerAnimator` — CHỉ xử lý animation (chưa implement)
   - **Luồng dữ liệu:** `Input → Controller → Movement/Combat/Animator`

2. **State Machine Pattern** (Enemy AI)
   - Mỗi state là 1 class riêng: Idle, Patrol, Chase, Attack, Dead
   - Interface: `IEnemyState` với `Enter()`, `Update()`, `Exit()`
   - Base: `EnemyBase.cs`, States tại: `Scripts/Enemy/StateMachine/`

3. **Singleton\<T\>** (Core managers)
   - DontDestroyOnLoad tự động
   - Đã dùng bởi: `GameManager`, `SceneLoader`
   - ⚠️ Chỉ dùng cho Manager/Service, KHÔNG dùng cho Player/Enemy

4. **Observer/Event Pattern** (Combat, stats)
   - `System.Action` events: `OnHealthChanged`, `OnDied`, `OnDashStarted`
   - Cho phép loose coupling: HP system thông báo, UI/VFX tự nghe

5. **Data-Driven Design** (ScriptableObjects)
   - Namespace: `DarkSoulCollector.Data`
   - Menu path: `DarkSoulCollector/Data/*`
   - Tách data ra khỏi logic: designer chỉnh Inspector, dev không sửa code

6. **Object Pooling** — `ObjectPool` cho projectile/VFX recycling

### 🔄 2D Top-Down Architecture Notes
```
⚠️ QUAN TRỌNG — Các quy tắc 2D:
- Rigidbody2D.gravityScale = 0 (top-down KHÔNG có trọng lực)
- Rigidbody2D.freezeRotation = true (sprite không xoay do physics)
- Movement dùng FixedUpdate() + rb.linearVelocity
- Hướng nhìn: SpriteRenderer.flipX (KHÔNG dùng Quaternion)
- Va chạm: OnTriggerEnter2D(Collider2D), KHÔNG phải OnTriggerEnter(Collider)
- Hit detection: Physics2D.OverlapCircleAll(), KHÔNG phải Physics.OverlapSphere()
- Di chuyển trên mặt phẳng X-Y (KHÔNG dùng Z)
```

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

| Class | Loại | Chức năng | Methods chính | Dependencies | Status |
|-------|------|-----------|--------------|--------------|--------|
| `PlayerController` | MonoBehaviour | **Bộ não** — đọc input, ra lệnh cho Movement + (sau này) Combat, Animator | `Update()`: gọi Move(), Dash() | PlayerInputHandler, PlayerMovement, Rigidbody2D | 🟢 Done |
| `PlayerInputHandler` | MonoBehaviour | Đọc input 2D: MoveInput(Vector2), LastFacingDirection, DashPressed, AttackPressed | `MoveInput`, `LastFacingDirection`, `IsRunning`, `AttackPressed`, `DashPressed`, `InteractPressed` | — | 🟢 Done |
| `PlayerMovement` | MonoBehaviour | Di chuyển 2D top-down (Rigidbody2D) + Dash system với cooldown | `Move(Vector2, bool)`, `Dash(Vector2)`, events: `OnDashStarted`, `OnDashEnded` | Rigidbody2D | 🟢 Done |
| `PlayerCombat` | MonoBehaviour | Combo melee (light/heavy), sử dụng ability từ Soul, cooldown management | `Attack()`, `HeavyAttack()`, `UseAbility(int slot)`, `ComboReset()` | PlayerAnimator, DamageDealer, PlayerStats | 🟡 Empty |
| `PlayerStats` | MonoBehaviour | Chỉ số nhân vật: HP, Stamina, ATK, DEF, Speed, Level, XP. Level-up bonus | `ModifyStat()`, `AddXP()`, `LevelUp()`, `ResetStats()` | — | 🟡 Empty |
| `PlayerAnimator` | MonoBehaviour | Wrapper cho Animator — set animation states dựa trên gameplay events | `SetMovement()`, `TriggerAttack()`, `TriggerHurt()`, `SetDashing()` | Animator, SpriteRenderer | 🟡 Empty |

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
| **3D → 2D Conversion**| 🟢     | Player scripts converted to 2D top-down   |
| Player Movement       | 🟢     | Rigidbody2D, 8-dir move, dash with cooldown |
| Player Input          | 🟢     | Vector2 input, facing direction, dash/attack |
| Player Controller     | 🟢     | Orchestrator connecting input → movement   |
| Player Combat         | 🟡     | Empty shell — cần implement                |
| Player Animator       | 🟡     | Empty shell — cần implement                |
| Player Stats          | 🟡     | Empty shell — cần implement                |
| Health System         | 🟡     | Có method signatures, chưa có logic        |
| Damage System         | 🟡     | DamageDealer, HitFlash, Knockback skeleton (vẫn 3D) |
| Enemy AI              | 🟡     | State Machine structure (vẫn 3D NavMesh)   |
| Enemy Spawner         | 🟡     | Script skeleton                            |
| Inventory System      | 🟡     | Manager + ItemSlot skeleton                |
| Equipment System      | 🟡     | Script skeleton                            |
| Soul Collection       | 🟡     | SoulManager, SoulCollectible — skeleton    |
| Soul Abilities        | 🟡     | AbilityBase + Abilities folder             |
| Weapon System         | 🟡     | WeaponData SO, cần weapon logic (vẫn 3D)  |
| Save/Load             | 🟡     | SaveManager + SaveData skeleton            |
| UI System             | 🟡     | Full UI controller skeleton                |
| Dialogue System       | 🟡     | DialogueDataSO + DialogueUIController      |
| Audio System          | 🟡     | AudioManager + SoundLibrary skeleton       |
| Player Sprite         | 🟢     | Sprite sheet tại Art/Sprites/Player/       |
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

5. **3D↔2D Mismatch** — Player scripts đã chuyển sang 2D nhưng Combat/Enemy/Weapon scripts vẫn là 3D.
   Khi implement các script đó, nhớ dùng: `Rigidbody2D`, `Collider2D`, `OnTriggerEnter2D`, `Physics2D`, `Vector2`.

6. **Rigidbody2D API** — Unity 6+ dùng `rb.linearVelocity` thay vì `rb.velocity` (deprecated).


## 📅 Daily Plans

> Kế hoạch ngày được tách ra file riêng tại: `Assets/workflows/daily/`
> Mỗi ngày 1 file: `day-01.md`, `day-02.md`, ...


---

## 🔧 Agent Task Queue (TODO cho Agent)

Khi user yêu cầu implement tính năng mới, agent nên ưu tiên theo thứ tự:

### Priority 1 — Core Gameplay Loop
- [x] Fix compile errors (CS1003)
- [x] Setup SKILL.md + .gitignore
- [x] Convert Player scripts from 3D → 2D Top-Down
- [x] Implement `PlayerInputHandler` (Vector2 input, facing, dash/attack)
- [x] Implement `PlayerMovement` (Rigidbody2D, 8-dir, dash with cooldown)
- [x] Implement `PlayerController` (orchestrator: input → movement + dash)
- [ ] Implement `PlayerAnimator` (SpriteRenderer flipX + Animator Blend Tree)
- [ ] Implement `PlayerCombat` (Physics2D.OverlapCircleAll melee attack)
- [ ] Implement `PlayerStats` (HP, Stamina, Level, XP)
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
| 2026-04-12 | **Converted Player scripts 3D → 2D Top-Down**              | Agent |
|            | - PlayerInputHandler: Vector3→Vector2, bỏ jump, thêm dash/attack/facing |
|            | - PlayerMovement: CharacterController→Rigidbody2D, bỏ gravity/jump, thêm Dash |
|            | - PlayerController: RequireComponent Rigidbody2D, jump→dash |
| 2026-04-12 | Generated player sprite sheet → Art/Sprites/Player/         | Agent |
| 2026-04-12 | Added Design Patterns documentation to SKILL.md             | Agent |
| 2026-04-12 | Các file khác (Combat, Enemy, Weapon) giữ nguyên skeleton 3D — user tự convert khi cần | Note |

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
