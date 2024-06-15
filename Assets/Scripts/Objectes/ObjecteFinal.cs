using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjecteFinal : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;

    [SerializeField] private List<GameObject> objectesCompletat;

    private int objecteTriatContador;

    private int objecteId;

    private void Start()
    {
        foreach (GameObject objecteCompletat in objectesCompletat)
        {
            objecteCompletat.SetActive(false);
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
    }
}
