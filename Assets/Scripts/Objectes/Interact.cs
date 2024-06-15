using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private bool vater;
    [SerializeField] private bool ascensor;
    [SerializeField] private bool taquilla;
    [SerializeField] private bool porta;

    [SerializeField] private bool teObjecte;
    [SerializeField] private bool teAnimator;

    [SerializeField] private GameObject objecte;

    private AudioManager audioManager;

    public Texture textureNormal;

    [SerializeField] private Animator animator;
    [SerializeField] private AscensorScript ascensorScript;
    private void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        if (TryGetComponent(out Animator _animator)) animator = _animator;

        if (teObjecte)    objecte.SetActive(false);
    }

    public void TriarInteraccio()
    {
        if (vater) VaterInteraction();
        else if (ascensor) AscensorInteraction();
        else if (taquilla) TaquillaInteraction();
        else if (porta) TaquillaInteraction();
    }

    private void VaterInteraction()
    {
        if (audioManager != null) audioManager.PlaySound(SoundName.VaterUse);

        if (animator != null) animator.SetTrigger("Obrir");

        if (teObjecte) objecte.SetActive(true);
    }
    private void AscensorInteraction()
    {
        if (audioManager != null) audioManager.PlaySound(SoundName.AscensorUse);

        ascensorScript.StartCoroutine();

        if (teObjecte) objecte.SetActive(true);
    }
    private void TaquillaInteraction()
    {
        if (audioManager != null) audioManager.PlaySound(SoundName.OpenDoor);

        if (animator != null) animator.SetTrigger("Obrir");

        if (teObjecte) objecte.SetActive(true);
    }
    private void PortaInteraction() {
        if (audioManager != null)  audioManager.PlaySound(SoundName.OpenDoor);

        if (animator != null) animator.SetTrigger("Obrir");

        if (teObjecte) objecte.SetActive(true);


    }
}
