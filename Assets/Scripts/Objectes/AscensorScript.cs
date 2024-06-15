using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class AscensorScript : MonoBehaviour
{
    public Transform playerLookPosition;

    // Total distance between the markers.
    public float journeyLength;

    [SerializeField] private float speed = -1F;

    private void Start()
    {
    }

    public void LookAnimation()
    {
        float distCovered = .1f * speed;
       journeyLength= Vector3.Distance(transform.position, playerLookPosition.position) * speed;
        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(transform.position, playerLookPosition.position, fractionOfJourney);
    }

    public void StartCoroutine()
    {
        StartCoroutine(CoroutineAnimation());
    }
    
    IEnumerator CoroutineAnimation()
    {
        while (Vector3.Distance(transform.position, playerLookPosition.position) > 0.01f)
        {
            LookAnimation();
            yield return new WaitForSeconds(.1f);
        }
    }
}
