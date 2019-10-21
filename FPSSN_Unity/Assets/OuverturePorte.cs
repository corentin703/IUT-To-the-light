using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuverturePorte : MonoBehaviour
{
    private Animator Anim;

    private void Start()
    {
        Anim = GameObject.Find("Porte").GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Anim.SetBool("open", true);
    }
    private void OnTriggerExit(Collider other)
    {
        Anim.SetBool("open", false);
    }
}
