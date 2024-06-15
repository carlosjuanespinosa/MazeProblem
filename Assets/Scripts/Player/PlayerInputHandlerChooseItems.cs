using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandlerChooseItems : MonoBehaviour
{
    private PlayerChooseItems playerChooseItems;

    private ChoosenItem choosenItem;

    // Start is called before the first frame update
    void Start()
    {
        choosenItem = GetComponent<ChoosenItem>();
    }

    private void OnEnable()
    { 
        playerChooseItems = new PlayerChooseItems();

        playerChooseItems.Enable();

        playerChooseItems.Player.EscapeChooseItem.performed += EscapeChooseItem;
        playerChooseItems.Player.ChooseItem.performed += ChooseItem;
    }

    private void ChooseItem(InputAction.CallbackContext ctx)
    {
        //Debug.Log("Choosen items");
        if (choosenItem != null)
        {
            if (choosenItem.enabled)
            {
                    choosenItem.TriarItem();

            }
        }
    }

    private void EscapeChooseItem(InputAction.CallbackContext ctx)
    {
        //Debug.Log("Escape Choosen items");
        if (choosenItem.enabled) { choosenItem.EscapeItemChoose(); }
    }
}
