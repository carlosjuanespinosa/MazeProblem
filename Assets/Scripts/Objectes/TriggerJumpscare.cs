using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJumpscare : MonoBehaviour
{
    [SerializeField] private AudioManager auM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int jumpscareId = Random.Range(0, 3);
            if (jumpscareId == 0) auM.PlaySound(SoundName.JumpScare1);      
            if (jumpscareId == 1) auM.PlaySound(SoundName.JumpScare2);      
            if (jumpscareId == 2) auM.PlaySound(SoundName.JumpScare3);      
        }
    }
}
