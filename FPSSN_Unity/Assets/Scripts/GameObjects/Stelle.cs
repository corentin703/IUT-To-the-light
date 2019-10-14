using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stelle : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
        {
            EnigmeStelle.Instance.Declencher_Etape_Suivante_Du_Scenario();
        }
    }
}
