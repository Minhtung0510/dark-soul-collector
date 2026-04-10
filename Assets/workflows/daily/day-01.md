# 📅 Day 01 — 2026-04-11
## 🎯 Mục tiêu: Player di chuyển được bằng WASD

> Kết thúc ngày hôm nay, bạn phải có 1 nhân vật di chuyển 8 hướng bằng WASD trong scene.

---

## ✅ Đã hoàn thành
- [x] Fix lỗi CS1003 (double quotes)
- [x] Tạo SKILL.md + .gitignore
- [x] Push lên GitHub

---

## 📋 Việc cần làm hôm nay

### Task 1: Tạo scene Gameplay 🎬
> Tạo scene mới trong Unity để test

- [ ] File → New Scene → Save As: `Assets/Assets/_Project/Scenes/Gameplay.unity`
- [ ] Tạo 1 empty GameObject đặt tên "Player"
- [ ] Gắn component: `SpriteRenderer`, `Rigidbody2D`, `BoxCollider2D`
- [ ] Rigidbody2D → set `Gravity Scale = 0` (vì game 2D top-down)
- [ ] Rigidbody2D → set `Freeze Rotation Z = true` (để player không xoay)

<details>
<summary>💡 Gợi ý nếu bí</summary>

**Tạo Scene:**
- Menu Unity: `File → New Scene → Basic 2D (URP)` → `Ctrl+S` để save
- Chọn save vào thư mục `Assets/Assets/_Project/Scenes/`

**Tạo Player GameObject:**
- Trong Hierarchy: Click phải → `Create Empty` → đổi tên "Player"
- Trong Inspector: `Add Component` → tìm "Sprite Renderer"
- `Add Component` → tìm "Rigidbody 2D"
- `Add Component` → tìm "Box Collider 2D"

**Rigidbody2D Settings:**
```
Body Type: Dynamic
Gravity Scale: 0          ← Quan trọng! (top-down không cần gravity)
Constraints → Freeze Rotation Z: ✅
```
</details>

---

### Task 2: Implement `PlayerInputHandler` ⌨️
> Script đọc input WASD/Arrow keys từ người chơi

- [ ] Mở file `Scripts/Player/PlayerInputHandler.cs`
- [ ] Thêm property `Vector2 MovementInput` — đọc từ `Input.GetAxisRaw`
- [ ] Test: Debug.Log ra console để xem input hoạt động

<details>
<summary>💡 Gợi ý nếu bí</summary>

```csharp
// Cần có những thứ này trong class:

// Property để các script khác đọc input
public Vector2 MovementInput { get; private set; }

// Trong Update() — đọc input mỗi frame
void Update()
{
    float x = Input.GetAxisRaw("Horizontal"); // A/D hoặc ←/→
    float y = Input.GetAxisRaw("Vertical");   // W/S hoặc ↑/↓
    MovementInput = new Vector2(x, y).normalized; // normalized để chéo không nhanh hơn
}
```

**Giải thích:**
- `GetAxisRaw` trả về -1, 0, hoặc 1 (không smooth)
- `.normalized` để di chuyển chéo không nhanh hơn đi thẳng (Pythagoras)
- `{ get; private set; }` — script khác đọc được nhưng không sửa được
</details>

---

### Task 3: Implement `PlayerMovement` 🏃
> Script di chuyển player dùng Rigidbody2D

- [ ] Mở file `Scripts/Player/PlayerMovement.cs`
- [ ] Thêm `[SerializeField] float moveSpeed = 5f;`
- [ ] Lấy reference đến `Rigidbody2D`
- [ ] Trong `FixedUpdate()`: set `rb.velocity = direction * moveSpeed`
- [ ] Flip sprite khi đi trái/phải

<details>
<summary>💡 Gợi ý nếu bí</summary>

```csharp
// Các biến cần có
[SerializeField] private float moveSpeed = 5f;
private Rigidbody2D _rb;
private Vector2 _moveInput;

// Lấy reference trong Awake
void Awake()
{
    _rb = GetComponent<Rigidbody2D>();
}

// Method để PlayerController gọi, truyền input vào
public void SetMovementInput(Vector2 input)
{
    _moveInput = input;
}

// Di chuyển trong FixedUpdate (vật lý phải dùng FixedUpdate, không dùng Update)
void FixedUpdate()
{
    _rb.velocity = _moveInput * moveSpeed;
}

// Flip sprite khi đổi hướng
public void FlipSprite(float xInput)
{
    if (xInput != 0)
    {
        transform.localScale = new Vector3(
            Mathf.Sign(xInput), 1, 1
        );
    }
}
```

**Giải thích:**
- `[SerializeField]` → hiện trong Inspector để chỉnh mà không cần sửa code
- `FixedUpdate()` cho vật lý, `Update()` cho input — đây là quy tắc Unity
- `rb.velocity` thay vì `transform.position` → để collision hoạt động đúng
- `Mathf.Sign(x)` trả về 1 hoặc -1 → dùng để flip sprite
</details>

---

### Task 4: Implement `PlayerController` 🎮
> Script điều phối — kết nối InputHandler + Movement

- [ ] Mở file `Scripts/Player/PlayerController.cs`
- [ ] Lấy reference đến `PlayerInputHandler` và `PlayerMovement`
- [ ] Trong `Update()`: lấy input → truyền cho Movement

<details>
<summary>💡 Gợi ý nếu bí</summary>

```csharp
private PlayerInputHandler _inputHandler;
private PlayerMovement _movement;

void Awake()
{
    _inputHandler = GetComponent<PlayerInputHandler>();
    _movement = GetComponent<PlayerMovement>();
}

void Update()
{
    // Lấy input từ InputHandler → truyền cho Movement
    Vector2 input = _inputHandler.MovementInput;
    _movement.SetMovementInput(input);
    _movement.FlipSprite(input.x);
}
```

**Giải thích:**
- `GetComponent<T>()` — lấy script khác trên cùng GameObject
- Controller chỉ "keo dán" các component lại, không chứa logic phức tạp
</details>

---

### Task 5: Gắn scripts + Test 🧪
> Bước cuối: gắn vào Player và chạy thử

- [ ] Trong Unity, chọn Player GameObject
- [ ] Add Component → `PlayerInputHandler`
- [ ] Add Component → `PlayerMovement`
- [ ] Add Component → `PlayerController`
- [ ] Bấm **Play** → Dùng WASD di chuyển
- [ ] Nếu hoạt động → 🎉 **Congratulations! Day 01 complete!**

<details>
<summary>💡 Gợi ý nếu bí</summary>

**Không di chuyển?**
- Kiểm tra Console → có lỗi đỏ không?
- Kiểm tra Rigidbody2D → Gravity Scale = 0?
- Kiểm tra PlayerMovement trong Inspector → moveSpeed > 0?
- Thêm `Debug.Log(_inputHandler.MovementInput)` trong PlayerController.Update() để xem input có nhận không

**Player bay mất?**
- Rigidbody2D → Body Type = Dynamic (không phải Kinematic)
- Kiểm tra moveSpeed không quá lớn (5-8 là hợp lý)

**Console báo NullReferenceException?**
- Đảm bảo TẤT CẢ 3 scripts đều gắn trên CÙNG 1 GameObject
- `GetComponent<T>()` chỉ tìm script trên cùng object
</details>

---

### Task 6: Git commit 📦
- [ ] Save scene trong Unity (`Ctrl+S`)
- [ ] Mở terminal:
```bash
git add .
git commit -m "✨ Day 01: Player 8-directional movement"
git push
```

---

## 📝 Ghi chú
> Ghi lại nếu gặp bug hoặc học được gì mới

- ...

---

## 📌 Ngày mai — Day 02
- PlayerStats (HP, Stamina)
- Health component hoàn chỉnh
- Dash/Dodge roll
- PlayerAnimator (nếu có sprite sheet)
