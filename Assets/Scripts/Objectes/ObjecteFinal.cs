using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjecteFinal : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;

    public bool ComprovarItem(GameObject _itemTriat)
    {
        foreach (GameObject obj in objects) {
            if (_itemTriat == obj) { return true; }
        }
        return false;
    }
}
