using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookController : MonoBehaviour
{
    [SerializeField] private Transform cameraPlayer;
    [SerializeField] private float xSens;
    [SerializeField] private float ySens;

    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        xSens = 1f; ySens=1f;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * xSens;
        float mouseY = Input.GetAxis("Mouse Y") * ySens;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        cameraPlayer.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
