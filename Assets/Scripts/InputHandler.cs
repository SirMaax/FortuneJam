using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
   
    [Header("Character Input Values")]
    public Vector2 move;
    public Vector2 look;
    public bool jump;
    public bool sprint;
    public bool sprintToggle = false;
    [Header("Movement Settings")]
    public bool analogMovement;

    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
    public bool cursorInputForLook = true;
    
    [Header("Refs")] private Movement_Controller _movement;
    public InputAction inputAction;
    private PlayerControl playerControl;
    
    private void Start()
    {
        //if(TryGetComponent(out Player player)) _player = GetComponent<Player>();
        playerControl = (PlayerControl) ReferenceManager.referenceManager.GiveRef(ReferenceManager.RefEnum.playerControl);
    }

    
    //How does a function to take input look like?
    public void OnNAMEofPart(InputValue value)
    {
        OtherFunction(value.Get<Vector3>());
    }
    
    public void OtherFunction(Vector3 vec)
    {
        //In combination with this function you specifiy why input is feed to the next function
    }
    //--------------------------------------------//


    

    
    
    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    public void OnShoot(InputValue value)
    {
        playerControl.ShootPrep();
    }
    
    public void OnJump(InputValue value)
    {
        // _movement.Jump();
    }

    public void OnJumpRelease(InputValue value)
    {
        // _movement.StopJump();
    }

    public void MoveInput(Vector2 newMoveDirection)
    {
        if (newMoveDirection[0] == 0 && newMoveDirection[1] == 0)
        {
            sprintToggle = false;
            sprint = false;
        }
        move = newMoveDirection;
    }


}
