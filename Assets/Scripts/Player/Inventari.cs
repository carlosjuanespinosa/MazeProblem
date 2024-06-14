using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Inventari : MonoBehaviour
{
    public List<GameObject> objectesInventari;

    [SerializeField] public List<Transform> llistaObjectes;
    [SerializeField] public GameObject llista;

    [SerializeField] private TextMeshProUGUI textInventari;

    private float contadorLlista;

    private void Start()
    {
        textInventari.gameObject.SetActive(false);
    }

    public void Agafar(GameObject objecte)
    {
        if (ComprovarInventariPle())
        {
            textInventari.gameObject.SetActive(true);
            return;
        }

        if (!ComprovarExistenciaItem(objecte))
        {
            objectesInventari.Add(objecte);
            objecte.SetActive(false);
        }
    }

    private bool ComprovarInventariPle()
    {
        if (objectesInventari.Count >= 8) return true;
        return false;
    }
    
    private bool ComprovarExistenciaItem(GameObject item)
    {
        foreach (GameObject objecteInventari in objectesInventari)
        {
            if (item == objecteInventari) return true;
        }
        return false;
    }

    public void LlistarObjectes()
    {
        for (int i = 0; i < objectesInventari.Count; i++) {
            objectesInventari[i].transform.parent = llistaObjectes[i].transform;
            objectesInventari[i].transform.localPosition = Vector3.zero;
            objectesInventari[i].transform.rotation = llistaObjectes[i].transform.rotation;
            objectesInventari[i].gameObject.SetActive(true);
            objectesInventari[i].GetComponent<ObjectId>().ObjectIDLlista = i;
        }
    }
}
