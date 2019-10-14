using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : BonusToPick
{
    [SerializeField]
    private AudioClip coinPickingSound = null;

    public override void Pick()
    {
        if (coinPickingSound)
            PlayPickingSound();

        base.Pick();
    }

    private void PlayPickingSound()
    {
        // Ajoute le son de mise en inventaire
        GameObject pickingSound = new GameObject();
        pickingSound.AddComponent<AudioSource>();
        pickingSound.GetComponent<AudioSource>().clip = coinPickingSound;
        pickingSound.GetComponent<AudioSource>().Play();
        pickingSound.name = "CoinPickingSound";

        // Détruit le GO à la fin du son
        Destroy(pickingSound, pickingSound.GetComponent<AudioSource>().clip.length);
    }
}
