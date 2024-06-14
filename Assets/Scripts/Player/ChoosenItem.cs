using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChoosenItem : MonoBehaviour
{
    [SerializeField] public ObjecteFinal objecteInteractuable;

    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void TriarItem()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform.CompareTag("Interactuable"))
            {
                Debug.Log(hit.transform.name);
                if (objecteInteractuable.ComprovarItem(hit.transform.gameObject))
                {
                    playerController.inventari.objectesInventari.RemoveAt(hit.transform.GetComponent<ObjectId>().ObjectIDLlista);
                    playerController.inventari.LlistarObjectes();
                }
            }
        }
    }
    
    public void EscapeItemChoose()
    {
        playerController.inventari.llista.SetActive(false);
        playerController.inputActions.enabled = true;
        playerController.playerInputHandlerChoose.enabled = false;
        playerController.lookController.enabled = true;
        playerController.choosenItem.enabled = false;
    }
}
