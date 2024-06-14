using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private Animator animator;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();

        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        playerInputActions = new PlayerInputActions();

        playerInputActions.Enable();

        playerInputActions.Player.Move.performed += MoveCTX;
        playerInputActions.Player.Move.canceled += MoveCTX;
        playerInputActions.Player.Provafunciona.started += ctx => Debug.Log("inoutsystem va");
    }

    private void OnDisable()
    {
        playerInputActions.Player.Move.performed -= MoveCTX;
        playerInputActions.Player.Move.canceled -= MoveCTX;
    }

    private void MoveCTX(InputAction.CallbackContext ctx)
    {
        Vector2 moveDir=ctx.ReadValue<Vector2>();

        playerController.moveDir = moveDir;

        if (ctx.ReadValue<Vector2>() == Vector2.zero)
        {
            animator.SetBool("Walk", false);
            animator.SetFloat("MoveX", moveDir.x, .1f, Time.fixedDeltaTime);
            animator.SetFloat("MoveY", moveDir.y, .1f, Time.fixedDeltaTime);
        }
        else {
            animator.SetBool("Walk", true);
            animator.SetFloat("MoveX", moveDir.x, .1f, Time.fixedDeltaTime);
            animator.SetFloat("MoveY", moveDir.y, .1f, Time.fixedDeltaTime);
        }
    }
}
