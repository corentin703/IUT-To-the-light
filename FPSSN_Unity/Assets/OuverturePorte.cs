using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuverturePorte : MonoBehaviour
{
    Animation myAnim;
    GameObject Porte;
    BoxCollider ColliderASupprimer;

    void Start()
    {
        myAnim = Porte.GetComponent<Animation>();
        ColliderASupprimer = Porte.GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            myAnim.Play();
            ColliderASupprimer.enabled = !ColliderASupprimer.enabled;
        }
    }
}
