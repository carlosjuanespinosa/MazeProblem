using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject panelInici;

    [SerializeField] private GameObject panelFinal;
    [SerializeField] private TextMeshProUGUI contador;

    [SerializeField] private PlayerController playerController;

    // Start is called before the first frame update
    private void Awake()
    {
        panelInici.SetActive(true);

        panelFinal.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        panelInici.SetActive(false);
        playerController.StartPlay();
    }

    private void EndGame()
    {
        contador.text = Time.time.ToString();
        panelFinal.SetActive(true);
    }
}
