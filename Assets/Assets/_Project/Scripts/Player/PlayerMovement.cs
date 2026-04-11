using System;
using System.Runtime.Serialization;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private float runMultiplier = 1.5f;
    [SerializeField] private float speedBonus = 0;

    //  trọng lực
    [SerializeField] private float gravity = -20f;
    private Vector3 _velocity;
    private CharacterController _cc;
    [SerializeField] private float jumpHeight = 2f; // độ cao khi nhảy

    void Awake()
    {
        _cc = GetComponent<CharacterController>();
    }
    void Update()
    {

        //reset lại trọng lực
        if(_cc.isGrounded && _velocity.y < 0f)
        {
            _velocity.y = -2f;
        }
        _velocity.y += gravity * Time.deltaTime; // tăng trọng lực theo từng frame để rớt nhanh hơn
        //áp dụng lực rơi
        _cc.Move(_velocity * Time.deltaTime);
     
        
    }


    //Hàm move dùng để controller gọi khi cần di chuyển
    public void Move(Vector3 direction,bool isRunning)
    {
        if(direction.magnitude < 0.1f) return; 
        float finalSpeed = (baseSpeed + speedBonus) *  (isRunning ? runMultiplier : 1f);
        _cc.Move(direction * finalSpeed * Time.deltaTime );
        //xoay nhân vật
        Quaternion targetPos = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation ,targetPos,10f * Time.deltaTime);

    }

    public void Jump()
    {
        if(!_cc.isGrounded) return; // kiểm tra xem có đứng trên mặt đất k
_velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}
