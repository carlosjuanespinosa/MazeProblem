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
        playerInputActions.Player.Interact.started += Interact;
    }

    private void OnDisable()
    {
        playerInputActions.Player.Move.performed -= MoveCTX;
        playerInputActions.Player.Move.canceled -= MoveCTX;

        playerInputActions.Disable();
    }

    private void MoveCTX(InputAction.CallbackContext ctx)
    {
        Vector2 moveDir=ctx.ReadValue<Vector2>();

        playerController.moveDir = moveDir;
    }

    private void Interact(InputAction.CallbackContext ctx)
    {
        playerController.Interact();
    }
}
