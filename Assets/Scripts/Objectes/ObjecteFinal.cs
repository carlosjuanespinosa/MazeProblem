using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjecteFinal : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;

    [SerializeField] private List<GameObject> objectesCompletat;

    private int objecteTriatContador;

    private int objecteId;

    public Texture textureNormal;

    [SerializeField] private ChoosenItem choosenItem;

    private Interact interact;

    private void Start()
    {
        foreach (GameObject objecteCompletat in objectesCompletat)
        {
            objecteCompletat.SetActive(false);
        }

        if (TryGetComponent(out Interact _interact))
        {
            interact = _interact;

            interact.enabled = false;
        }
    }

    public bool ComprovarItem(GameObject _itemTriat)
    {
        objecteTriatContador = 0;
        foreach (GameObject obj in objects) {
            if (_itemTriat != obj)
            {
                objecteTriatContador++;
            }
            else
            {
                objecteId = objecteTriatContador;
                return true;
            }
            }
        return false;
    }

    public void CompletarObjecte()
    {
        //Debug.Log("Objecte Eliminat " + objects[objecteId].name);
        //Debug.Log("Objecte Eliminat " + objectesCompletat[objecteId].name);
        //Debug.Log(objecteId);
        objectesCompletat[objecteId].SetActive(true);
        objects.RemoveAt(objecteId);
        objectesCompletat.RemoveAt(objecteId);
        if (objects.Count <= 0)
        {
            choosenItem.EscapeItemChoose();
        }
        interact.enabled = true;
        Destroy(this);
    }
}
