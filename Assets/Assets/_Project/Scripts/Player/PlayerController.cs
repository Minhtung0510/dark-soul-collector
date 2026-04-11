using NUnit.Framework.Interfaces;
using UnityEngine;
[RequireComponent(typeof(PlayerInputHandler))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    
private PlayerInputHandler _Input;
private PlayerMovement _Movement;

    void Awake()
    {
   _Input = GetComponent<PlayerInputHandler>();
    _Movement = GetComponent<PlayerMovement>();    
    }
    void Update()
    {
        _Movement.Move(_Input.moveInput, _Input._isRunning);
        if(_Input.jumpPressed) _Movement.Jump();
        
    }
}
