# 📅 Day 01 — 2026-04-11
## 🎯 Mục tiêu: Player di chuyển 3D + Camera Dark Souls style

> Kết thúc ngày hôm nay, bạn phải có 1 nhân vật di chuyển WASD trong scene 3D với camera third-person.

---

## ✅ Đã hoàn thành
- [x] Fix lỗi CS1003 (double quotes)
- [x] Tạo SKILL.md + .gitignore
- [x] Push lên GitHub
- [x] **Chuyển toàn bộ cấu trúc code sang 3D** (67 scripts updated)

---

## 📋 Việc cần làm hôm nay

### Task 0: Setup 3D Scene 🏗️
> Tạo scene 3D với Terrain làm test arena

- [ ] File → New Scene → Save As: `Assets/Assets/_Project/Scenes/TestArena.unity`
- [ ] Tạo Terrain: `3D Object → Terrain` (200x200)
- [ ] Paint terrain: cỏ + đất (dùng built-in textures hoặc tải free)
- [ ] Thêm vài đồ vật: `3D Object → Cube/Sphere` làm obstacles tạm

<details>
<summary>💡 Cách tạo Terrain nhanh</summary>

1. **Hierarchy** → Click phải → `3D Object → Terrain`
2. Chọn Terrain → Inspector → **Terrain Settings** (⚙️ icon):
   ```
   Terrain Width:  200
   Terrain Length: 200
   Terrain Height: 50
   ```
3. **Paint Terrain** (🖌️ icon):
   - Click `Edit Terrain Layers → Create Layer`
   - Chọn texture cỏ/đất (built-in hoặc import)
4. **Raise/Lower** (▲ icon):
   - Tạo vài đồi nhỏ để terrain không phẳng
</details>

---

### Task 1: Import 3D Character Model 🎭
> Tải model + animations từ Mixamo hoặc tự tìm

- [ ] Vào **Mixamo.com** (đăng nhập bằng Adobe ID free)
- [ ] Chọn 1 character → Download (.FBX for Unity)
- [ ] Tải animations: Idle, Walk, Run, Attack, Dodge, Die
- [ ] Import vào `Assets/_Project/Art/Models/Player/`
- [ ] Setup Animator Controller với Blend Tree

<details>
<summary>💡 Cách tải từ Mixamo</summary>

1. Vào https://www.mixamo.com/ → Sign Up free
2. Tab **Characters** → chọn model (ví dụ: Y Bot, X Bot, Paladin)
3. Click **Download** → Format: `FBX for Unity (.fbx)` → Pose: `T-Pose`
4. Tab **Animations** → tìm: Idle, Walking, Running, Slash Attack
5. Mỗi animation → Download: `FBX for Unity` → Without Skin
6. Kéo tất cả vào Unity folder `Assets/_Project/Art/Models/Player/`

**Setup Animator:**
```
States:
  Idle → Walking → Running (Blend Tree theo Speed float)
  Any State → Attack (trigger)
  Any State → Dodge (trigger)
  Any State → Death (trigger → final state)
```
</details>

---

### Task 2: Implement `PlayerInputHandler` ⌨️
> Đọc input WASD + Mouse look cho 3D

- [ ] Mở file `Scripts/Player/PlayerInputHandler.cs`
- [ ] Implement `Update()`: đọc WASD → `MovementInput` (Vector3, XZ plane)
- [ ] Đọc Mouse delta → `MouseDelta`
- [ ] Đọc Left Click → `AttackPressed`
- [ ] Đọc Space → `DashPressed`
- [ ] Test: Debug.Log để xem input

<details>
<summary>💡 Gợi ý</summary>

```csharp
void Update()
{
    float h = Input.GetAxisRaw("Horizontal");
    float v = Input.GetAxisRaw("Vertical");
    MovementInput = new Vector3(h, 0, v).normalized;
    
    MouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    
    AttackPressed = Input.GetMouseButtonDown(0);
    DashPressed = Input.GetKeyDown(KeyCode.Space);
    InteractPressed = Input.GetKeyDown(KeyCode.E);
    LockOnPressed = Input.GetKeyDown(KeyCode.Q);
}
```
</details>

---

### Task 3: Implement `PlayerMovement` 🏃
> Di chuyển 3D bằng CharacterController (không phải Rigidbody2D nữa!)

- [ ] Mở file `Scripts/Player/PlayerMovement.cs`
- [ ] Implement `Awake()`: GetComponent CharacterController
- [ ] Implement `Move()`: CharacterController.Move() relative to camera
- [ ] Implement `ApplyGravity()`: gravity thủ công
- [ ] Implement `GetCameraRelativeDirection()`: chuyển input thành hướng camera
- [ ] Rotate player xoay theo hướng di chuyển

<details>
<summary>💡 Gợi ý Move camera-relative</summary>

```csharp
private Vector3 GetCameraRelativeDirection(Vector3 input)
{
    Vector3 camForward = _cameraTransform.forward;
    Vector3 camRight = _cameraTransform.right;
    camForward.y = 0;  // Flatten — không di chuyển lên trời
    camRight.y = 0;
    camForward.Normalize();
    camRight.Normalize();
    return (camForward * input.z + camRight * input.x).normalized;
}

public void Move(Vector3 input, bool isRunning = false)
{
    Vector3 moveDir = GetCameraRelativeDirection(input);
    float speed = isRunning ? runSpeed : walkSpeed;
    _cc.Move(moveDir * speed * Time.deltaTime);
    
    // Rotate to face movement direction
    if (moveDir != Vector3.zero)
    {
        Quaternion targetRotation = Quaternion.LookRotation(moveDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
```
</details>

---

### Task 4: Implement `ThirdPersonCamera` 🎥
> Camera Dark Souls style — orbit, follow, collision

- [ ] Mở file `Scripts/Camera/ThirdPersonCamera.cs`
- [ ] Implement `FreeLookUpdate()`: xoay theo mouse
- [ ] Implement `HandleCollision()`: không xuyên tường
- [ ] Lock cursor khi play

<details>
<summary>💡 Gợi ý Camera</summary>

```csharp
private void FreeLookUpdate()
{
    _yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
    _pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
    _pitch = Mathf.Clamp(_pitch, minPitch, maxPitch);
    
    Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0);
    Vector3 desiredPosition = target.position + rotation * offset;
    
    transform.position = Vector3.Lerp(transform.position, desiredPosition, orbitSmoothing * Time.deltaTime);
    transform.LookAt(target.position + Vector3.up * 1.5f);
}
```
</details>

---

### Task 5: Implement `PlayerController` 🎮
> Kết nối tất cả: Input → Movement → Camera

- [ ] `Awake()`: GetComponent tất cả references
- [ ] `Update()`: đọc input → gọi movement.Move()
- [ ] Test: WASD di chuyển, mouse xoay camera

---

### Task 6: Gắn components + Test 🧪
> Setup Player GameObject trong scene

- [ ] Tạo Player GameObject (Empty hoặc import model)
- [ ] Add Components: `CharacterController`, `PlayerInputHandler`, `PlayerMovement`, `PlayerController`, `PlayerStats`, `PlayerAnimator`
- [ ] CharacterController settings:
  ```
  Height: 1.8
  Radius: 0.3
  Center: (0, 0.9, 0)
  ```
- [ ] Tạo Camera GameObject → add `ThirdPersonCamera` → set Target = Player
- [ ] **Play** → WASD + Mouse → Test!
- [ ] Nếu OK → 🎉 **Day 01 Complete!**

---

### Task 7: Git commit 📦
- [ ] Save scene trong Unity (`Ctrl+S`)
- [ ] Mở terminal:
```bash
git add .
git commit -m "✨ Day 01: 3D Player movement + Third-person camera"
git push
```

---

## 📝 Ghi chú
> Ghi lại nếu gặp bug hoặc học được gì mới

- Đã chuyển toàn bộ cấu trúc từ 2D → 3D
- CharacterController thay Rigidbody2D
- Vector3 thay Vector2 
- OnTriggerEnter thay OnTriggerEnter2D
- NavMeshAgent thay custom pathfinding

---

## 📌 Ngày mai — Day 02
- PlayerStats implementation (HP, Stamina, regen)
- PlayerCombat (3-hit combo + heavy attack)
- Dash/Dodge roll
- PlayerAnimator + Animator Controller setup
