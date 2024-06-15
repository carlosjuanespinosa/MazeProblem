using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChoosenItem : MonoBehaviour
{
    [SerializeField] public Transform objecteInteractuable;

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
                if (objecteInteractuable.TryGetComponent(out ObjecteFinal objecteFinal))
                {
                    if (objecteFinal.ComprovarItem(hit.transform.gameObject))
                    {
                        playerController.inventari.objectesInventari.RemoveAt(hit.transform.GetComponent<ObjectId>().ObjectIDLlista);
                        objecteFinal.CompletarObjecte();
                        Destroy(hit.transform.gameObject);
                        playerController.inventari.LlistarObjectes();
                    }
                }
                if (objecteInteractuable.TryGetComponent(out Forzadura forzadura))
                {
                    if (forzadura.ComprovarItem(hit.transform.gameObject))
                    {
                        playerController.inventari.objectesInventari.RemoveAt(hit.transform.GetComponent<ObjectId>().ObjectIDLlista);
                        forzadura.CompletarObjecte();
                        Destroy(hit.transform.gameObject);
                        playerController.inventari.LlistarObjectes();
                    }
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
        playerController.cameraPersonatge.SetActive(true);
        playerController.cameraInventari.SetActive(false);
        playerController.cursor.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
