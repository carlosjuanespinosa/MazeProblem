using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public class Inventari : MonoBehaviour
{
    public List<GameObject> objectesInventari;

    [SerializeField] private TextMeshProUGUI textInventari;

    public void Agafar(GameObject objecte)
    {
        if (ComprovarInventariPle()) { textInventari.text = "Inventario lleno!"; }

        objectesInventari.Add(objecte);
        Destroy(objecte);
    }

    public void Amollar()
    {

    }

    private bool ComprovarInventariPle()
    {
        if (objectesInventari.Count >= 8) return true;
        return false;
    }
}
