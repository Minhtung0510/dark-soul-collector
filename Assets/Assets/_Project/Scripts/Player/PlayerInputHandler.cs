using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector3 moveInput{ get;private set;}
    public bool jumpPressed{get;private set;} // lưu  trạng thái nhảy
    public bool _isRunning{get;private set;}
    
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");
    moveInput = new Vector3(h,0f,v).normalized;//Lưu hướng di chuyển
    jumpPressed = Input.GetKeyDown(KeyCode.Space);
    _isRunning = Input.GetKey(KeyCode.LeftShift);

    }




}
